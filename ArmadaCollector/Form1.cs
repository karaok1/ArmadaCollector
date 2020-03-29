using CefSharp;
using Fiddler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using CefSharp.Internals;
using CefSharp.Structs;
using CefSharp.WinForms;
using Timer = System.Threading.Timer;
using ArmadaCollector.Properties;
using ArmadaCollector.ArmadaBattle;
using ArmadaCollector;

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

        public Form1()
        {
            InitializeComponent();
            this.Init();
            InitializeChromium();
            this.OnStartUp();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";
            settings.CefCommandLineArgs.Add("disable-gpu", "");
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            LifeSpanHandler lifeSpanHandler = new LifeSpanHandler();

            RequestContext rc = new RequestContext();

            try
            {
                Cef.UIThreadTaskFactory.StartNew(delegate
                {
                    var v = new Dictionary<string, object>();
                    v["mode"] = "fixed_servers";
                    v["server"] = "127.0.0.1:7777";
                    string error;
                    bool success = rc.SetPreference("proxy", v, out error);
                });
            }
            catch (Exception e)
            {
                throw new System.InvalidOperationException(e.ToString());
            }
            browser = new ChromiumWebBrowser("http://www.armadabattle.com", rc);
            tabPage1.Controls.Add(browser);
            browser.LifeSpanHandler = lifeSpanHandler;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            browser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;
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
                        string pattern = @"([0-9]+)<\/span>";
                        var m = Regex.Matches(html, pattern);

                        pattern = @"([A-Za-z0-9]+)<\/b>";
                        Account.ID = Regex.Matches(html, pattern)[0].Groups[1].Value;
                        Account.UserName = Regex.Matches(html, pattern)[1].Groups[1].Value;
                        Account.Level = Regex.Matches(html, pattern)[2].Groups[1].Value;
                        Account.Rank = Regex.Matches(html, pattern)[3].Groups[1].Value;
                    });
                }
                else if (browser.Address.Contains("play"))
                {
                    pictureBox1.Invoke((MethodInvoker)(() => pictureBox1.Visible = false));
                    browser.ExecuteScriptAsync("document.getElementsByClassName('btn btn-sm btn-default')[2].click();");
                    browser.GetSourceAsync().ContinueWith(taskHtml =>
                    {
                        var html = taskHtml.Result;
                        if (html.Contains("Multiple entries!") || html.Contains("Birden fazla giriş!"))
                        {
                            Thread.Sleep(3000);
                            BotClick(450, 340);
                        }
                    });
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
            CertMaker.createRootCert();
            CertMaker.trustRootCert();
            this.StartLocalProxy();
            loginButton.Enabled = false;
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
            catch(Exception ex)
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
            FiddlerApplication.Shutdown();
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

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            browser.ExecuteScriptAsync("document.getElementsByClassName('pintoship-icon')[0].hidden = true;" +
                                       "\r\ndocument.getElementsByClassName('brand')[0].hidden = true;" +
                                       "\r\ndocument.getElementsByClassName('hpbar')[0].hidden = true;" +
                                       "\r\ndocument.getElementsByClassName('bg')[1].hidden = true;" +
                                       "\r\ndocument.getElementsByClassName('skillbox')[0].hidden = true;" +
                                       "\r\ndocument.getElementsByClassName('expbar')[0].hidden = true;");

            Client.sessionStartTime = DateTime.Now;
            Client.running = true;
            Client.previousAngle = -1;
            Client.collecting = false;
            worker = new Thread(() =>
            {
                while (true)
                {
                    if (Client.collecting == false)
                    {
                        ExecuteJavaScript();
                    }
                    Thread.Sleep(500);
                }
            });
            worker.Start();
            Bot.Log("Bot started.");
            buttonStart.Invoke((MethodInvoker)(() =>
            {
                buttonStart.Enabled = false;
            }));
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
            Client.collectedElixir = 0;
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
                goldreslabel.Text = Client.playerGold;
                diamondreslabel.Text = Client.playerDiamond;
                expreslabel.Text = Client.playerExp;
                usernamelabel.Text = Account.UserName;
                useridlabel.Text = Account.ID;
                levellabel.Text = Account.Level;
                ranklabel.Text = Account.Rank;
                if (Client.running)
                {
                    collectedDiamonds.Text = Client.collectedDiamonds.ToString();
                    gaineddiamondlabel.Text = Client.collectedDiamonds.ToString();
                    gainedelixirlabel.Text = Client.collectedElixir.ToString();
                    collectedGlows.Text = Client.collectedGlows.ToString();
                    collectedElixir.Text = Client.collectedElixir.ToString();
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

        private void resetCertButton_Click(object sender, EventArgs e)
        {
            if (CertMaker.removeFiddlerGeneratedCerts(true))
            {
                Bot.Log("Unistalled Fiddler Certificates.");
            }
            MessageBox.Show("All Certificates have been removed!\nPlease restart the Bot, for the changes to take affect!", "Unistalled Certificate.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            Bot.Log("Saved settings.");
            SaveUserSettings();
        }

        private void speedhacktrackbar_Scroll(object sender, EventArgs e)
        {

        }
    }
}
