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
        public HttpClient httpClient = new HttpClient();
        Licensing.User user = new Licensing.User();

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
            browser.ConsoleMessage += Browser_ConsoleMessage;
            browser.Focus();
#if (DEBUG)
            browser.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChanged;
            string read = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"client_core.js");
            var encText = StringCipher.Encrypt(read, "enjoylowlife");
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"client_core.bin", encText);
#endif
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
            if (e.Level >= LogSeverity.Error) return;

            var task = Task.Run(() => {

                var m = Regex.Match(e.Message, @"collected: ([0-9]+).([a-z]+)", RegexOptions.None);

                if (!m.Success) return;

                var value = m.Groups[1].Value;
                var type = m.Groups[2].Value;

                Bot.Log("Collected " + value + " " + type);
                switch (type)
                {
                    case "golds":
                        Client.collectedGolds += Convert.ToInt32(value);
                        break;
                    case "diamonds":
                        Client.collectedDiamonds += Convert.ToInt32(value);
                        break;
                    case "exps":
                        Client.collectedExps += Convert.ToInt32(value);
                        break;
                    case "elixirs":
                        Client.collectedElixirs += Convert.ToInt32(value);
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
                    Bot.Log("Game is loading...");
                    browser.ExecuteScriptAsync("document.getElementsByClassName('btn btn-sm btn-default')[2].click();");
                    browser.GetSourceAsync().ContinueWith(taskHtml =>
                    {
                        var html = taskHtml.Result;
                        if (html.Contains("Multiple entries!") || html.Contains("Birden fazla giriş!"))
                        {
                            Thread.Sleep(3000);
                            BotClick(450, 340);
                        }

                        //Task.Delay(5000).ContinueWith(action =>
                        //{
                        //    string lines = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"api-req.js");
                        //    browser.EvaluateScriptAsync(lines);
                        //});

                    });
                    Client.ready = true;
                }
            }
        }

        private void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
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

        private void OnStartUp()
        {
            this.StartLocalProxy();
            loginButton.Enabled = false;
            SetDiscordRPC();
        }

        private void SetDiscordRPC()
        {
            httpClient.BaseAddress = new Uri("http://13.53.182.223:8080/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client = new DiscordRpcClient("689514388272578673");

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                Bot.Log("Discord client is ready: " + e.User.Username);
                user.id = e.User.ID.ToString();
                if (checkRole().GetAwaiter().GetResult())
                {
                    Bot.Log("You are now playing as a Beta Tester");
                    this.Invoke((MethodInvoker)delegate
                    {
                        label2.Text = "Beta Tester";
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        DialogResult dialog =
                            MessageBox.Show("You don't have an appropriate role to use the bot! Please contact on the Discord server for more information.",
                            "Discord error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        // close the form on the forms thread
                        this.Close();
                    });
                }
            };

            client.OnConnectionFailed += (sender, e) =>
            {

                this.Invoke((MethodInvoker)delegate
                {
                    DialogResult dialog =
                        MessageBox.Show("Connection failed.",
                        "Discord error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    // close the form on the forms thread
                    this.Close();
                });
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = "Collecting stuff",
                State = "Botting",
                Assets = new Assets()
                {
                    LargeImageKey = "standart_image",
                    LargeImageText = "Saisama's ArmadaBattle bot",
                    SmallImageKey = "standart_image"
                }
            });
        }

        [Obfuscation(Exclude = false, Feature = "constants")]
        private async Task<bool> checkRole()
        {
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("checkRole", user);
                response.EnsureSuccessStatusCode();
                RoleValidation roleValidation = await response.Content.ReadAsAsync<RoleValidation>();
                return roleValidation.hasRole;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
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
            Settings.Default.Save();
        }

        public void StartLocalProxy()
        {
            Server server = new Server();
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
                SaveUserSettings();
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

            Bot.Log("Armadabattle bot - ArmadaCollector");
            Bot.Log("Current version: v" + assembly.GetName().Version.ToString(3));
        }
        private void GetUserSettings()
        {
            userTextBox.Text = Settings.Default.Username;
            passTextBox.Text = Settings.Default.Password;
            rememberMeCheckbox.Checked = Settings.Default.Remember;
            avoidislandcheckbox.Checked = Settings.Default.AvoidIslands;
            shootmonstercheckbox.Checked = Settings.Default.ShootMonster;
            shootnpccheckbox.Checked = Settings.Default.ShootNPC;
            collectboxcheckbox.Checked = Settings.Default.CollectBox;
        }

        private void ResetUserSettings()
        {
            Properties.Settings.Default.Reset();
        }

        private async void ButtonStart_Click(object sender, EventArgs e)
        {
            if (buttonStart.Text == "Start")
            {
                if (!Client.ready)
                {
                    Bot.Log("Please wait until game loads.");
                    return;
                }

                // === Replacement for Logic.js === 


                string lines = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"client_core.bin");
                var decText = StringCipher.Decrypt(lines, "enjoylowlife");
                var viewPort = 1000 + metroTrackBar1.Value * 70;

                await browser.EvaluateScriptAsync("window.bs={cb:false,sa:false,sn:false,ai:false,repLimit:50,vp:1000}");
                await browser.EvaluateScriptAsync("bs.vp=" + viewPort + ";");
                if (collectboxcheckbox.Checked)
                    await browser.EvaluateScriptAsync("bs.cb=true;");
                if (shootmonstercheckbox.Checked)
                    await browser.EvaluateScriptAsync("bs.sa=true;");
                if (shootnpccheckbox.Checked)
                    await browser.EvaluateScriptAsync("bs.sn=true;");
                if (avoidislandcheckbox.Checked)
                    await browser.EvaluateScriptAsync("bs.ai=true;");
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
            }
            else if (buttonStart.Text == "Stop")
            {
                buttonStart.Text = "Start";
                browser.Reload();
                await browser.EvaluateScriptAsync("stopBot();");
                Client.collecting = false;
            }
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
            browser.GetBrowser().GetHost().SendMouseClickEvent(miniMapCoordX, miniMapCoordY, MouseButtonType.Left, false, 1, CefEventFlags.LeftMouseButton);
            Thread.Sleep(50);
            browser.GetBrowser().GetHost().SendMouseClickEvent(miniMapCoordX, miniMapCoordY, MouseButtonType.Left, true, 1, CefEventFlags.LeftMouseButton);
            Thread.Sleep(100);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (worker != null)
                if (worker.IsAlive)
                {
                    worker.Abort();
                }
            Bot.Log("Bot stopped.");
            Client.running = false;
            Client.collectedDiamonds = 0;
            Client.collectedElixirs = 0;
            Client.collectedGlows = 0;
            buttonStart.Invoke((MethodInvoker)(() =>
            {
                buttonStart.Enabled = true;
            }));
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
    }
}
