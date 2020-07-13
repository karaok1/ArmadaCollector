using CefSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using ArmadaCollector.Properties;
using ArmadaCollector.ArmadaBattle;
using ArmadaCollector.Licensing;
using DiscordRPC;
using System.Net.Http;
using System.Net.Http.Headers;
using MetroFramework.Controls;
using Timer = System.Threading.Timer;
using System.Reflection.Emit;
using ArmadaCollector.Utils;
using System.Timers;
using System.Globalization;

namespace ArmadaCollector
{
    public partial class Form1 : Form
    {
        public static Form1 form1;
        public delegate void writerDelegate(string message);
        public delegate void scriptRunnerDelegate();
        public writerDelegate writer;
        public scriptRunnerDelegate scriptrunner;
        private ChromiumWebBrowser browser;
        public Thread worker;
        private DiscordRpcClient client;
        delegate void SetTextCallback(string text);
        public HttpResponseMessage clientCore = new HttpResponseMessage();
        public System.Timers.Timer fakeMove = new System.Timers.Timer(6 * 1000); //one hour in milliseconds


        public Form1()
        {
            InitializeComponent();
            this.Init();
            InitializeChromium();
            this.OnStartUp();
            tabControl1.SelectedTab = tabPage1;
        }
        
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";
            settings.CefCommandLineArgs.Add("disable-gpu", "");
            // Initialize cef with the provided settings
            Cef.EnableHighDPISupport();
            Cef.Initialize(settings);
            // Create a browser component
            LifeSpanHandler lifeSpanHandler = new LifeSpanHandler();

            RequestContext rc = new RequestContext();
            browser = new ChromiumWebBrowser("http://www.armadabattle.com", rc);
            tabPage1.Controls.Add(browser);
            browser.LifeSpanHandler = lifeSpanHandler;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            browser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;
            browser.JavascriptMessageReceived += Browser_JavascriptMessageReceived;
            browser.ConsoleMessage += Browser_ConsoleMessage;
            browser.Focus();
#if (DEBUG)
            browser.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChanged;
            string read = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"client_c.js");
            var encText = StringCipher.Encrypt(read, "enjoylowlife");
            File.WriteAllText(@"C:\Users\Abdullah\Desktop\ArColWeb\src\public\source\client_c.bin", encText);
            File.WriteAllText(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + "\\Release\\" + @"client_c.bin", encText);
#endif
        }

        private void Browser_JavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            var msg = (string) e.Message;
            Bot.Log(msg);
        }

#if (DEBUG)

        private void Browser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            if (browser.IsBrowserInitialized)
            {
                browser.ShowDevTools();
            }
        }
#endif

        private void Browser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            var task = Task.Run(() => {

                var m = Regex.Match(e.Message, @"collected: ([0-9]+).([#a-z]+)", RegexOptions.None);
                if (!m.Success) return;

                var value = m.Groups[1].Value;
                var type = m.Groups[2].Value;

                switch (type)
                {
                    case "golds":
                        Client.gainedGold = Client.collectedGolds += Convert.ToInt32(value);
                        Bot.Log("Collected " + value + " " + type);
                        break;
                    case "diamonds":
                        Client.gainedDiamond = Client.collectedDiamonds += Convert.ToInt32(value);
                        Bot.Log("Collected " + value + " " + type);
                        break;
                    case "#money":
                        Client.gainedDiamond = Client.collectedDiamonds += Convert.ToInt32(value);
                        Bot.Log("Collected " + value + " " + "diamonds");
                        break;
                    case "elixirs":
                        Client.gainedElixir = Client.collectedElixirs += Convert.ToInt32(value);
                        Bot.Log("Collected Elixir");
                        break;
                    case "box":
                        Client.collectedGlows += Convert.ToInt32(value);
                        break;
                }
            });
            task.Wait();
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                loginButton.Invoke((MethodInvoker)(() =>
                {
                    loginButton.Enabled = true;
                }));

                if (browser.Address.Contains("homepage"))
                {
                    browser.ExecuteScriptAsync("document.getElementsByClassName('col-md-offset-4 playbutton fs-30 hvr-wobble-to-bottom-right')[0].click();");
                    browser.GetSourceAsync().ContinueWith(taskHtml =>
                    {
                        var html = taskHtml.Result;
                        string pattern = @"([A-Za-z0-9]+)<\/b>";
                        var m = Regex.Matches(html, pattern);
                        Account.ID = m[0].Groups[1].Value;
                        Account.UserName = m[1].Groups[1].Value;
                        Account.Level = m[2].Groups[1].Value;
                        Account.Rank = m[3].Groups[1].Value;
                    });

                }
                else if (browser.Address.Contains("play"))
                {
                    Bot.Log("Loading game...");
                    browser.ExecuteScriptAsync("document.getElementsByClassName('btn btn-sm btn-default')[2].click();");
                    browser.GetSourceAsync().ContinueWith(taskHtml =>
                    {
                        var html = taskHtml.Result;
                        if (html.Contains("Multiple entries!") || html.Contains("Birden fazla giriş!"))
                        {
                            Thread.Sleep(3000);
                            BotClick(450, 340);
                        }

                        if (Client.manuelStart)
                        Task.Delay(5000).ContinueWith(action =>
                        {
                            var script = @"(function () {
                                if (ArmadaBattle && ArmadaBattle.Game && ArmadaBattle.Game.myPlayer)
                                     return true;
                                })();";
                            var result = browser.EvaluateScriptAsync(script).ContinueWith(x =>
                            {
                                var response = x.Result;
                                if (response.Success && response.Result != null)
                                {
                                    if ((dynamic)response.Result == true)
                                    {
                                        Task.Delay(2000).ContinueWith(a =>
                                        {
                                            Bot.Log("Restarting...");
                                            BootstrapClient();
                                        });
                                    }
                                }
                            });
                        });
                    });
                    Client.ready = true;
                }
            }
        }

        private async void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                if (browser.Address.Contains("play"))
                {
                }
            }
        }

        private void Init()
        {
            this.writer = new Form1.writerDelegate(this.Log);
            this.scriptrunner = new Form1.scriptRunnerDelegate(this.ExecuteJavaScript);
            form1 = this;
        }

        private async void OnStartUp()
        {
            this.StartLocalProxy();
            loginButton.Enabled = false;
            await AppUpdater.RunUpdater();
            Authenticate();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e, DateTime expirationDate)
        {
            DateTime current = DateTime.Now;

            if (expirationDate < current)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate {
                        ShowErrorAndClose("License expired!");
                    });
                }
                catch
                {
                    Application.Exit();
                }
            }
        }

        public void Authenticate()
        {
            Licensing.User user = new Licensing.User();
            user.hWID = Program.fingerprint;
            user.timeStamp = DateTime.Now;

            try
            {
                var res = CheckLicense(user).GetAwaiter().GetResult();
                var aTimer = new System.Timers.Timer(6 * 1000); //one hour in milliseconds
                aTimer.Enabled = true;

                if (res.status)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        label2.Text = res.expirationDate.ToString();
                        Bot.Log("License valid until: " + res.expirationDate);
                        DownloadFiles();
                    });
                    aTimer.Elapsed += new ElapsedEventHandler((sender, e) => OnTimedEvent(sender, e, res.expirationDate));
                    aTimer.Start();
                }
                else
                {
                    try
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            buttonStart.Invoke((MethodInvoker)(() =>
                            {
                                buttonStart.Enabled = false;
                            }));
                            Bot.Log(
                                "You don't have a valid license to use the bot! " +
                                "Please contact on the Discord server for more information.");
                        });
                    }
                    catch
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                buttonStart.Invoke((MethodInvoker)(() =>
                {
                    buttonStart.Enabled = false;
                }));
                ShowErrorAndClose(ex.Message);
            }
        }

        private async void DownloadFiles()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
#if DEBUG
                    //httpClient.BaseAddress = new Uri("https://akchan.me/");
                    httpClient.BaseAddress = new Uri("http://localhost:5000/");
#else
                    httpClient.BaseAddress = new Uri("https://akchan.me/");
#endif
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    using (clientCore = httpClient.GetAsync("source/client_c.bin").Result)
                    {
                        clientCore.EnsureSuccessStatusCode();
                        // Download client_c.bin
                        if (clientCore.IsSuccessStatusCode)
                        {
                            Bot.Log("Downloaded necessary files");
                            Client.scriptCode = await clientCore.Content.ReadAsStringAsync();
                        }
                        else
                        {
                            ShowErrorAndClose("Failed to download necessary files.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorAndClose(ex.Message);
            }
        }

        [Obfuscation(Exclude = false, Feature = "constants")]
        private async Task<RoleValidation> CheckLicense(Licensing.User user)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
#if DEBUG
                    //httpClient.BaseAddress = new Uri("https://akchan.me/");
                    httpClient.BaseAddress = new Uri("http://localhost:5000/");
#else
                    httpClient.BaseAddress = new Uri("https://akchan.me/");
#endif
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));


                    //var crypto = new ClsCrypto("lol");
                    //DateTime result;
                    //DateTime.TryParse(crypto.Encrypt(user.timeStamp.ToString()), out result);
                    //user.timeStamp = result;

                    using (var response = httpClient.PostAsJsonAsync("api/checkLicense", user).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            RoleValidation roleValidation = response.Content.ReadAsAsync<RoleValidation>().Result;
                            return roleValidation;
                        }
                        else
                        {
                            Bot.Log("Can't connect to the license server.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorAndClose(ex.Message);
            }
            return new RoleValidation();
        }
        
        private void ShowErrorAndClose(string _text)
        {
            AutoClosingMessageBox.Show(
                text: _text,
                caption: "Error",
                timeout: 5000,
                buttons: MessageBoxButtons.OK,
                defaultResult: DialogResult.Yes);
            // close the form on the forms thread
            Application.Exit();
        }

        private void SaveUserSettings()
        {
            Settings.Default.Username = userTextBox.Text;
            Settings.Default.Password = passTextBox.Text;
            Settings.Default.Remember = rememberMeCheckbox.Checked;
            Settings.Default.AvoidIslands = avoidislandcheckbox.Checked;
            Settings.Default.CollectBox = collectboxcheckbox.Checked;
            Settings.Default.ShootMonster = shootmonstercheckbox.Checked;
            Settings.Default.ShootNPC = shootnpccheckbox.Checked;
            Settings.Default.BuyHollows = checkBoxBuyCannonballs.Checked;
            Settings.Default.EquipSails = checkBoxEquipSails.Checked;
            Settings.Default.RepairAt = (int) numericUpDown1.Value;
            Settings.Default.ShootBack = checkBoxShootBack.Checked;
            Settings.Default.Save();
        }

        public void StartLocalProxy()
        {
            //Server server = new Server();
            //this.localThread = new Thread(server.Start);
            //this.localThread.IsBackground = false;
            //this.localThread.Start();
            //this.StartBrowserProxy();
        }

        public void Log(string message)
        {
            var dt = DateTime.Now;
            string time = "[" + dt.ToString("HH:mm:ss") + "]: ";
            LogBox.AppendText(time + message + System.Environment.NewLine);
            LogBox.ScrollToCaret();
        }

        private void ButtonLoginPlayer_Click(object sender, EventArgs e)
        {
            SaveUserSettings();
            try
            {
                loginButton.Enabled = false;
                Client.username = userTextBox.Text;
                Client.password = passTextBox.Text;
                browser.ExecuteScriptAsync("var event = new Event('input', { bubbles: true }); \ndocument.getElementsByName('username')[0].value = '" + userTextBox.Text + "'; document.getElementsByName('username')[0].dispatchEvent(event);");
                browser.ExecuteScriptAsync("document.getElementsByName('password')[0].value = '" + passTextBox.Text + "'; document.getElementsByName('password')[0].dispatchEvent(event);");
                Task.Delay(300).Wait();
                browser.ExecuteScriptAsync("document.getElementsByClassName('nk-btn col-md-12 col-xs-12 bg-main-2')[0].click();");
            }
            catch (Exception ex)
            {
                Bot.Log("Can't navigate to webpage: " + ex.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rememberMeCheckbox.Checked)
            {
                Settings.Default.TotalDiamond += Client.gainedDiamond;
                Settings.Default.TotalElixir += Client.gainedElixir;
                Settings.Default.TotalGold += Client.gainedGold;
                SaveUserSettings();
            }
            else
                ResetUserSettings();

            Cef.Shutdown();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetUserSettings();
            Assembly assembly = Assembly.GetExecutingAssembly();

            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            this.Text += $" v{ versionInfo.FileVersion }";

            Bot.Log("Armada Battle bot - ArmadaCollector");
            Bot.Log("Current version: v" + assembly.GetName().Version.ToString(3));
            Bot.Log("HWID: " + Program.fingerprint);
        }
        private void GetUserSettings()
        {
            metroComboBoxQuantity.SelectedIndex = 1;
            metroComboBoxCbType.SelectedIndex = 1;
            metroComboBoxEquipPirates.SelectedIndex = 2;
            userTextBox.Text = Settings.Default.Username;
            passTextBox.Text = Settings.Default.Password;
            rememberMeCheckbox.Checked = Settings.Default.Remember;
            avoidislandcheckbox.Checked = Settings.Default.AvoidIslands;
            shootmonstercheckbox.Checked = Settings.Default.ShootMonster;
            shootnpccheckbox.Checked = Settings.Default.ShootNPC;
            collectboxcheckbox.Checked = Settings.Default.CollectBox;
            checkBoxBuyCannonballs.Checked = Settings.Default.BuyHollows;
            checkBoxEquipSails.Checked = Settings.Default.EquipSails;
            numericUpDown1.Value = (decimal) Settings.Default.RepairAt;
            checkBoxShootBack.Checked = Settings.Default.ShootBack;
            gaineddiamondlabel.Text = Settings.Default.TotalDiamond.ToString();
            gainedelixirlabel.Text = Settings.Default.TotalElixir.ToString();
            gainedgoldlabel.Text = Settings.Default.TotalGold.ToString();
        }

        private void ResetUserSettings()
        {
            Properties.Settings.Default.Reset();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            double restartInterval = (double) numericUpDownRestart.Value * 60 * 60 * 3600;
            System.Timers.Timer restartTimer = new System.Timers.Timer(restartInterval);
            if (fakeMove == null)
                fakeMove = new System.Timers.Timer(6 * 1000); //one hour in millisecond
            restartTimer.Elapsed += RestartTimer_Elapsed;

            if (buttonStart.Text == "Start")
            {
                if (!Client.ready)
                {
                    Bot.Log("Please wait until game loads.");
                    return;
                }

                Client.manuelStart = true;
                if (restartInterval > 0)
                {
                    restartTimer.Start();
                }
                BootstrapClient();
            }
            else if (buttonStart.Text == "Stop")
            {
                restartTimer.Stop();
                restartTimer.Close();
                buttonStart.Text = "Start";
                browser.Reload();
                Client.collecting = false;
                Client.manuelStart = false;
            }
        }

        private void RestartTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            browser.Reload();
            BootstrapClient();
        }

        private async void BootstrapClient()
        {
            string lines = "";
#if DEBUG
            // === Replacement for Logic.js === 
            lines = File.ReadAllText(@"C:\Users\Abdullah\Desktop\ArColWeb\src\public\source\client_c.bin");
#else
            lines = Client.scriptCode;
#endif
            var decText = StringCipher.Decrypt(lines, "enjoylowlife");
            int quantity = 10000;
            string cannonBallType = "_id.cannonballDivisional";
            string pirateType = "Juliette";
            metroComboBoxQuantity.Invoke((MethodInvoker)(() =>
            {
                quantity = Convert.ToInt32(metroComboBoxQuantity.Text);
            }));
            metroComboBoxCbType.Invoke((MethodInvoker)(() =>
            {
                cannonBallType = metroComboBoxCbType.Text;
                switch (cannonBallType)
                {
                    case "Divisional":
                        cannonBallType = "_id.cannonballDivisional";
                        break;
                    case "Hollow":
                        cannonBallType = "_id.cannonballHollow";
                        break;
                    case "Stone":
                        cannonBallType = "_id.cannonballStone";
                        break;
                    case "Slime":
                        cannonBallType = "_id.cannonballSlime";
                        break;
                    default:
                        cannonBallType = "_id.cannonballHollow";
                        break;
                }
            }));
            metroComboBoxEquipPirates.Invoke((MethodInvoker)(() =>
            {
                pirateType = metroComboBoxEquipPirates.Text;
            }));
            await browser.EvaluateScriptAsync("let shootObj=[];" +
                "bs = {" +
                "   cb:false," +
                "   sa:false," +
                "   buyCannonball:{}," +
                "   equipPirates:{}," +
                "   sn:false," +
                "   ai:false," +
                "   onlyFullHp:" +
                "   false," +
                "   repLimit:50" +
                "}");
            if (collectboxcheckbox.Checked)
                await browser.EvaluateScriptAsync("bs.cb=true;");
            if (shootmonstercheckbox.Checked)
                await browser.EvaluateScriptAsync("bs.sa=true;");
            if (shootnpccheckbox.Checked)
                await browser.EvaluateScriptAsync("bs.sn=true;");
            if (avoidislandcheckbox.Checked)
                await browser.EvaluateScriptAsync("bs.ai=true;");
            if (checkBoxShootBack.Checked)
                await browser.EvaluateScriptAsync("bs.shootBack=true;");
            if (checkBoxEquipSails.Checked)
                await browser.EvaluateScriptAsync("bs.equipSails=true;");
            if (checkboxShootOnlyFullHp.Checked)
                await browser.EvaluateScriptAsync("bs.onlyFullHp=true;");
            if (checkBoxBuyCannonballs.Checked)
            {
                await browser.EvaluateScriptAsync("bs.buyCannonball.active=true;" +
                    "bs.buyCannonball.type=" + cannonBallType + ";" +
                    "bs.buyCannonball.quantity= " + quantity + ";" + 
                    "bs.buyCannonball.ifBelow= " + numericUpDownIfBelow.Value + ";");
            }
            if (metroCheckBoxEquipPirates.Checked)
            {
                await browser.EvaluateScriptAsync("bs.equipPirates.active=true;" +
                    "bs.equipPirates.type=" + pirateType + ";");
            }
            await browser.EvaluateScriptAsync("bs.repLimit=" + numericUpDown1.Value + ";");
            if (collectboxcheckbox.Checked || shootnpccheckbox.Checked || shootmonstercheckbox.Checked)
            {
                await browser.EvaluateScriptAsync(decText); // change this !!!

                if (listBox1.Items.Count > 0)
                {
                    foreach (var item in listBox1.Items)
                    {
                        await browser.EvaluateScriptAsync("shootObj.push(\"" + item + "\");")
                            .ContinueWith(t =>
                            {
                                if (!t.IsFaulted)
                                {
                                    var response = t.Result;
                                    Bot.Log(response.Message);
                                }
                            });
                    }
                }

                Client.sessionStartTime = DateTime.Now;
                Client.running = true;
                buttonStart.Text = "Stop";
                Bot.Log("Bot started.");
            }
            else
            {
                Bot.Log("Check at least one checkbox to perform tasks!");
            }
            if (fakeMove.Enabled != true)
            {
                fakeMove.Enabled = true;
                fakeMove.Elapsed += FakeMove_Elapsed;
                fakeMove.Start();
            }
        }

        private void FakeMove_Elapsed(object sender, ElapsedEventArgs e)
        {
            Bot.Log("Fake move called");
            var rand = new Random();
            BotClick(rand.Next(10, 990), rand.Next(0, 300));
        }

        private void ExecuteJavaScript()
        {
            if (!browser.IsBrowserInitialized)
            {
                Bot.Log("Browser isn't initialized yet!");
                return;
            }

            Client.collecting = true;
            Client.collecting = false;
        }

        private void BotClick(int miniMapCoordX, int miniMapCoordY)
        {
            browser.GetBrowser().GetHost().SendMouseMoveEvent(miniMapCoordX, miniMapCoordY, false, CefEventFlags.LeftMouseButton);
            Thread.Sleep(50);
            //browser.GetBrowser().GetHost().SendMouseClickEvent(miniMapCoordX, miniMapCoordY, MouseButtonType.Left, false, 1, CefEventFlags.LeftMouseButton);
            //Thread.Sleep(50);
            //browser.GetBrowser().GetHost().SendMouseClickEvent(miniMapCoordX, miniMapCoordY, MouseButtonType.Left, true, 1, CefEventFlags.LeftMouseButton);
            //Thread.Sleep(100);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (worker != null)
                if (worker.IsAlive)
                {
                    worker.Abort();
                }
            fakeMove.Stop();
            fakeMove.Enabled = false;
            Bot.Log("Bot stopped.");
            Client.running = false;
        }

        private void updateFormTimer_Tick(object sender, EventArgs e)
        {
            UpdateStats();
        }

        private void UpdateStats()
        {
            try
            {
                usernamelabel.Text = Account.UserName;
                useridlabel.Text = Account.ID;
                levellabel.Text = Account.Level;
                ranklabel.Text = Account.Rank;
                if (Client.running)
                {
                    collectedDiamonds.Text = Client.collectedDiamonds.ToString();
                    collectedGolds.Text = Client.collectedGolds.ToString();
                    collectedElixirs.Text = Client.collectedElixirs.ToString();
                    collectedGlows.Text = Client.collectedGlows.ToString();
                    gaineddiamondlabel.Text = Client.gainedDiamond.ToString();
                    gainedgoldlabel.Text = Client.gainedGold.ToString();
                    gainedelixirlabel.Text = Client.gainedElixir.ToString();
                    int num = Convert.ToInt32(new DateTime(DateTime.Now.Subtract(Client.sessionStartTime).Ticks).ToString("d "));
                    num--;
                    this.runtimeLabel.Text = num + " days " + new DateTime(DateTime.Now.Subtract(Client.sessionStartTime).Ticks).ToString("HH:mm:ss");
                    this.sessionStartTimeLabel.Text = Client.sessionStartTime.ToShortDateString() + " " + Client.sessionStartTime.ToLongTimeString();
                }
            }
            catch (Exception e)
            {
                Bot.Log(e.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "No payment options available yet",
                "Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            Bot.Log("Saved settings.");
            SaveUserSettings();
        }

        private void speedhacktrackbar_Scroll(object sender, EventArgs e)
        {

        }

        private void attackedInfoGroupbox_Enter(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Contains(metroTextBox1.Text) || String.IsNullOrWhiteSpace(metroTextBox1.Text)) 
                return;

            listBox1.Items.Add(metroTextBox1.Text);
            metroTextBox1.Clear();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox1);
            selectedItems = listBox1.SelectedItems;

            if (listBox1.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox1.Items.Remove(selectedItems[i]);
            }
            else
            {
                MessageBox.Show("Select one or more items to delete.");
            }
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }
    }
}
