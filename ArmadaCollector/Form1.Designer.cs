using MetroFramework.Controls;

namespace ArmadaCollector
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.collectboxcheckbox = new System.Windows.Forms.CheckBox();
            this.shootnpccheckbox = new System.Windows.Forms.CheckBox();
            this.avoidislandcheckbox = new System.Windows.Forms.CheckBox();
            this.shootmonstercheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rememberMeCheckbox = new System.Windows.Forms.CheckBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.attackedInfoGroupbox = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.collectedGolds = new System.Windows.Forms.Label();
            this.collectedElixirs = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.collectedGlows = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.collectedDiamonds = new System.Windows.Forms.Label();
            this.sessionStartTimeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.runtimeLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ranklabel = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.levellabel = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.useridlabel = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.guildlabel = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.usernamelabel = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.gainedelixirlabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.gainedgoldlabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.gaineddiamondlabel = new System.Windows.Forms.Label();
            this.buttonStart = new MetroFramework.Controls.MetroButton();
            this.updateFormTimer = new System.Windows.Forms.Timer(this.components);
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.attackedInfoGroupbox.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogBox.Location = new System.Drawing.Point(0, 463);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(1014, 128);
            this.LogBox.TabIndex = 0;
            this.LogBox.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.metroTabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1014, 461);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.UseSelectable = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.saveSettingsButton);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.HorizontalScrollbarBarColor = true;
            this.tabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage2.HorizontalScrollbarSize = 10;
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1006, 419);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.VerticalScrollbarBarColor = true;
            this.tabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage2.VerticalScrollbarSize = 10;
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSettingsButton.Location = new System.Drawing.Point(0, 380);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(1006, 39);
            this.saveSettingsButton.TabIndex = 15;
            this.saveSettingsButton.Text = "Save settings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Location = new System.Drawing.Point(8, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(507, 128);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Functions";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.collectboxcheckbox);
            this.groupBox5.Controls.Add(this.shootnpccheckbox);
            this.groupBox5.Controls.Add(this.avoidislandcheckbox);
            this.groupBox5.Controls.Add(this.shootmonstercheckbox);
            this.groupBox5.Location = new System.Drawing.Point(17, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 94);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Basic";
            // 
            // collectboxcheckbox
            // 
            this.collectboxcheckbox.AutoSize = true;
            this.collectboxcheckbox.Location = new System.Drawing.Point(14, 19);
            this.collectboxcheckbox.Name = "collectboxcheckbox";
            this.collectboxcheckbox.Size = new System.Drawing.Size(90, 17);
            this.collectboxcheckbox.TabIndex = 0;
            this.collectboxcheckbox.Text = "Collect Boxes";
            this.collectboxcheckbox.UseVisualStyleBackColor = true;
            // 
            // shootnpccheckbox
            // 
            this.shootnpccheckbox.AutoSize = true;
            this.shootnpccheckbox.Location = new System.Drawing.Point(151, 49);
            this.shootnpccheckbox.Name = "shootnpccheckbox";
            this.shootnpccheckbox.Size = new System.Drawing.Size(84, 17);
            this.shootnpccheckbox.TabIndex = 3;
            this.shootnpccheckbox.Text = "Shoot NPCs";
            this.shootnpccheckbox.UseVisualStyleBackColor = true;
            // 
            // avoidislandcheckbox
            // 
            this.avoidislandcheckbox.AutoSize = true;
            this.avoidislandcheckbox.Location = new System.Drawing.Point(151, 19);
            this.avoidislandcheckbox.Name = "avoidislandcheckbox";
            this.avoidislandcheckbox.Size = new System.Drawing.Size(89, 17);
            this.avoidislandcheckbox.TabIndex = 1;
            this.avoidislandcheckbox.Text = "Avoid Islands";
            this.avoidislandcheckbox.UseVisualStyleBackColor = true;
            // 
            // shootmonstercheckbox
            // 
            this.shootmonstercheckbox.AutoSize = true;
            this.shootmonstercheckbox.Location = new System.Drawing.Point(14, 48);
            this.shootmonstercheckbox.Name = "shootmonstercheckbox";
            this.shootmonstercheckbox.Size = new System.Drawing.Size(100, 17);
            this.shootmonstercheckbox.TabIndex = 2;
            this.shootmonstercheckbox.Text = "Shoot Monsters";
            this.shootmonstercheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.numericUpDown1);
            this.groupBox6.Location = new System.Drawing.Point(275, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(226, 94);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Repair";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(157, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Repair at:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(93, 34);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.metroButton2);
            this.groupBox3.Controls.Add(this.metroTextBox1);
            this.groupBox3.Controls.Add(this.metroButton1);
            this.groupBox3.Controls.Add(this.metroLabel1);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Location = new System.Drawing.Point(8, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 233);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Targets";
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(213, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[] {
        "Type in an object name..."};
            this.metroTextBox1.Location = new System.Drawing.Point(6, 48);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(235, 23);
            this.metroTextBox1.TabIndex = 4;
            this.metroTextBox1.Text = "Type in an object name...";
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox1.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(6, 77);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(235, 41);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Add";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(17, 16);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(61, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Selected:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(258, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(241, 186);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.metroLabel2);
            this.groupBox2.Controls.Add(this.metroTrackBar1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rememberMeCheckbox);
            this.groupBox2.Controls.Add(this.loginButton);
            this.groupBox2.Controls.Add(this.passTextBox);
            this.groupBox2.Controls.Add(this.userTextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(521, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 367);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Login";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 244);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(68, 19);
            this.metroLabel2.TabIndex = 11;
            this.metroLabel2.Text = "Map view:";
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.Location = new System.Drawing.Point(24, 266);
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(364, 23);
            this.metroTrackBar1.TabIndex = 10;
            this.metroTrackBar1.Text = "metroTrackBar1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "License status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "-";
            // 
            // rememberMeCheckbox
            // 
            this.rememberMeCheckbox.AutoSize = true;
            this.rememberMeCheckbox.Location = new System.Drawing.Point(85, 97);
            this.rememberMeCheckbox.Name = "rememberMeCheckbox";
            this.rememberMeCheckbox.Size = new System.Drawing.Size(94, 17);
            this.rememberMeCheckbox.TabIndex = 6;
            this.rememberMeCheckbox.Text = "Remember me";
            this.rememberMeCheckbox.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(85, 120);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(197, 31);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Log In";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.ButtonLoginPlayer_Click);
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(85, 67);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(197, 20);
            this.passTextBox.TabIndex = 3;
            this.passTextBox.UseSystemPasswordChar = true;
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(85, 35);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(197, 20);
            this.userTextBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Username:";
            // 
            // tabPage1
            // 
            this.tabPage1.HorizontalScrollbarBarColor = true;
            this.tabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage1.HorizontalScrollbarSize = 10;
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1006, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.VerticalScrollbarBarColor = true;
            this.tabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage1.VerticalScrollbarSize = 10;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.attackedInfoGroupbox);
            this.metroTabPage1.Controls.Add(this.groupBox7);
            this.metroTabPage1.Controls.Add(this.groupBox1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1006, 419);
            this.metroTabPage1.TabIndex = 2;
            this.metroTabPage1.Text = "Statistics";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // attackedInfoGroupbox
            // 
            this.attackedInfoGroupbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.attackedInfoGroupbox.Controls.Add(this.label36);
            this.attackedInfoGroupbox.Controls.Add(this.label37);
            this.attackedInfoGroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackedInfoGroupbox.Location = new System.Drawing.Point(521, 241);
            this.attackedInfoGroupbox.Name = "attackedInfoGroupbox";
            this.attackedInfoGroupbox.Size = new System.Drawing.Size(469, 175);
            this.attackedInfoGroupbox.TabIndex = 4;
            this.attackedInfoGroupbox.TabStop = false;
            this.attackedInfoGroupbox.Text = "Attacked Info";
            this.attackedInfoGroupbox.Enter += new System.EventHandler(this.attackedInfoGroupbox_Enter);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(191, 31);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(12, 16);
            this.label36.TabIndex = 8;
            this.label36.Text = "\\";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(15, 31);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(131, 16);
            this.label37.TabIndex = 7;
            this.label37.Text = "Attacked by Players:";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.collectedGolds);
            this.groupBox7.Controls.Add(this.collectedElixirs);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.collectedGlows);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.collectedDiamonds);
            this.groupBox7.Controls.Add(this.sessionStartTimeLabel);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.runtimeLabel);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(520, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(478, 231);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Current Session";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Gold:";
            // 
            // collectedGolds
            // 
            this.collectedGolds.AutoSize = true;
            this.collectedGolds.Location = new System.Drawing.Point(151, 62);
            this.collectedGolds.Name = "collectedGolds";
            this.collectedGolds.Size = new System.Drawing.Size(15, 16);
            this.collectedGolds.TabIndex = 11;
            this.collectedGolds.Text = "0";
            // 
            // collectedElixirs
            // 
            this.collectedElixirs.AutoSize = true;
            this.collectedElixirs.Location = new System.Drawing.Point(151, 78);
            this.collectedElixirs.Name = "collectedElixirs";
            this.collectedElixirs.Size = new System.Drawing.Size(15, 16);
            this.collectedElixirs.TabIndex = 9;
            this.collectedElixirs.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(32, 78);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 16);
            this.label24.TabIndex = 8;
            this.label24.Text = "Elixir:";
            // 
            // collectedGlows
            // 
            this.collectedGlows.AutoSize = true;
            this.collectedGlows.Location = new System.Drawing.Point(151, 94);
            this.collectedGlows.Name = "collectedGlows";
            this.collectedGlows.Size = new System.Drawing.Size(15, 16);
            this.collectedGlows.TabIndex = 7;
            this.collectedGlows.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Diamond:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Glow:";
            // 
            // collectedDiamonds
            // 
            this.collectedDiamonds.AutoSize = true;
            this.collectedDiamonds.Location = new System.Drawing.Point(151, 43);
            this.collectedDiamonds.Name = "collectedDiamonds";
            this.collectedDiamonds.Size = new System.Drawing.Size(15, 16);
            this.collectedDiamonds.TabIndex = 1;
            this.collectedDiamonds.Text = "0";
            // 
            // sessionStartTimeLabel
            // 
            this.sessionStartTimeLabel.AutoSize = true;
            this.sessionStartTimeLabel.Location = new System.Drawing.Point(152, 127);
            this.sessionStartTimeLabel.Name = "sessionStartTimeLabel";
            this.sessionStartTimeLabel.Size = new System.Drawing.Size(12, 16);
            this.sessionStartTimeLabel.TabIndex = 5;
            this.sessionStartTimeLabel.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Runtime:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Started:";
            // 
            // runtimeLabel
            // 
            this.runtimeLabel.AutoSize = true;
            this.runtimeLabel.Location = new System.Drawing.Point(152, 110);
            this.runtimeLabel.Name = "runtimeLabel";
            this.runtimeLabel.Size = new System.Drawing.Size(12, 16);
            this.runtimeLabel.TabIndex = 3;
            this.runtimeLabel.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 413);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resources";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label35);
            this.groupBox9.Controls.Add(this.progressBar1);
            this.groupBox9.Controls.Add(this.ranklabel);
            this.groupBox9.Controls.Add(this.label34);
            this.groupBox9.Controls.Add(this.levellabel);
            this.groupBox9.Controls.Add(this.label32);
            this.groupBox9.Controls.Add(this.useridlabel);
            this.groupBox9.Controls.Add(this.label30);
            this.groupBox9.Controls.Add(this.guildlabel);
            this.groupBox9.Controls.Add(this.label28);
            this.groupBox9.Controls.Add(this.usernamelabel);
            this.groupBox9.Controls.Add(this.label25);
            this.groupBox9.Location = new System.Drawing.Point(7, 153);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(488, 254);
            this.groupBox9.TabIndex = 9;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "User";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(11, 184);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(30, 16);
            this.label35.TabIndex = 16;
            this.label35.Text = "HP:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(121, 184);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(345, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // ranklabel
            // 
            this.ranklabel.AutoSize = true;
            this.ranklabel.Location = new System.Drawing.Point(118, 143);
            this.ranklabel.Name = "ranklabel";
            this.ranklabel.Size = new System.Drawing.Size(12, 16);
            this.ranklabel.TabIndex = 14;
            this.ranklabel.Text = "\\";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(10, 143);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(43, 16);
            this.label34.TabIndex = 13;
            this.label34.Text = "Rank:";
            // 
            // levellabel
            // 
            this.levellabel.AutoSize = true;
            this.levellabel.Location = new System.Drawing.Point(119, 116);
            this.levellabel.Name = "levellabel";
            this.levellabel.Size = new System.Drawing.Size(12, 16);
            this.levellabel.TabIndex = 12;
            this.levellabel.Text = "\\";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(11, 116);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(44, 16);
            this.label32.TabIndex = 11;
            this.label32.Text = "Level:";
            // 
            // useridlabel
            // 
            this.useridlabel.AutoSize = true;
            this.useridlabel.Location = new System.Drawing.Point(119, 89);
            this.useridlabel.Name = "useridlabel";
            this.useridlabel.Size = new System.Drawing.Size(12, 16);
            this.useridlabel.TabIndex = 10;
            this.useridlabel.Text = "\\";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 89);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 16);
            this.label30.TabIndex = 9;
            this.label30.Text = "UserID:";
            // 
            // guildlabel
            // 
            this.guildlabel.AutoSize = true;
            this.guildlabel.Location = new System.Drawing.Point(119, 62);
            this.guildlabel.Name = "guildlabel";
            this.guildlabel.Size = new System.Drawing.Size(12, 16);
            this.guildlabel.TabIndex = 8;
            this.guildlabel.Text = "\\";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 62);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(42, 16);
            this.label28.TabIndex = 7;
            this.label28.Text = "Guild:";
            // 
            // usernamelabel
            // 
            this.usernamelabel.AutoSize = true;
            this.usernamelabel.Location = new System.Drawing.Point(119, 33);
            this.usernamelabel.Name = "usernamelabel";
            this.usernamelabel.Size = new System.Drawing.Size(12, 16);
            this.usernamelabel.TabIndex = 6;
            this.usernamelabel.Text = "\\";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(11, 33);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 16);
            this.label25.TabIndex = 0;
            this.label25.Text = "Username:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label21);
            this.groupBox8.Controls.Add(this.gainedelixirlabel);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.gainedgoldlabel);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.gaineddiamondlabel);
            this.groupBox8.Location = new System.Drawing.Point(20, 21);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(308, 126);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Gained";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(34, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 16);
            this.label21.TabIndex = 12;
            this.label21.Text = "+ Elixir:";
            // 
            // gainedelixirlabel
            // 
            this.gainedelixirlabel.AutoSize = true;
            this.gainedelixirlabel.Location = new System.Drawing.Point(153, 74);
            this.gainedelixirlabel.Name = "gainedelixirlabel";
            this.gainedelixirlabel.Size = new System.Drawing.Size(15, 16);
            this.gainedelixirlabel.TabIndex = 13;
            this.gainedelixirlabel.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(34, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 16);
            this.label17.TabIndex = 10;
            this.label17.Text = "+ Gold:";
            // 
            // gainedgoldlabel
            // 
            this.gainedgoldlabel.AutoSize = true;
            this.gainedgoldlabel.Location = new System.Drawing.Point(153, 57);
            this.gainedgoldlabel.Name = "gainedgoldlabel";
            this.gainedgoldlabel.Size = new System.Drawing.Size(15, 16);
            this.gainedgoldlabel.TabIndex = 11;
            this.gainedgoldlabel.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(34, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 16);
            this.label18.TabIndex = 8;
            this.label18.Text = "+ Diamond:";
            // 
            // gaineddiamondlabel
            // 
            this.gaineddiamondlabel.AutoSize = true;
            this.gaineddiamondlabel.Location = new System.Drawing.Point(153, 41);
            this.gaineddiamondlabel.Name = "gaineddiamondlabel";
            this.gaineddiamondlabel.Size = new System.Drawing.Size(15, 16);
            this.gaineddiamondlabel.TabIndex = 9;
            this.gaineddiamondlabel.Text = "0";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.buttonStart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonStart.Location = new System.Drawing.Point(184, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(818, 29);
            this.buttonStart.Style = MetroFramework.MetroColorStyle.Green;
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonStart.UseCustomBackColor = true;
            this.buttonStart.UseCustomForeColor = true;
            this.buttonStart.UseSelectable = true;
            this.buttonStart.UseStyleColors = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // updateFormTimer
            // 
            this.updateFormTimer.Enabled = true;
            this.updateFormTimer.Tick += new System.EventHandler(this.updateFormTimer_Tick);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(6, 176);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(235, 41);
            this.metroButton2.TabIndex = 5;
            this.metroButton2.Text = "Remove";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 591);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArmadaCollector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.metroTabPage1.ResumeLayout(false);
            this.attackedInfoGroupbox.ResumeLayout(false);
            this.attackedInfoGroupbox.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogBox;
        private MetroTabControl tabControl1;
        private MetroTabPage tabPage1;
        private MetroTabPage tabPage2;
        private System.Windows.Forms.Timer updateFormTimer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private MetroTabPage metroTabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label collectedGlows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sessionStartTimeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label runtimeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label collectedDiamonds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox rememberMeCheckbox;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox collectboxcheckbox;
        private System.Windows.Forms.CheckBox shootnpccheckbox;
        private System.Windows.Forms.CheckBox avoidislandcheckbox;
        private System.Windows.Forms.CheckBox shootmonstercheckbox;
        private System.Windows.Forms.GroupBox attackedInfoGroupbox;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label collectedElixirs;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ranklabel;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label levellabel;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label useridlabel;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label guildlabel;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label usernamelabel;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label gainedelixirlabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label gainedgoldlabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label gaineddiamondlabel;
        private MetroButton buttonStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label collectedGolds;
        private System.Windows.Forms.ListBox listBox1;
        private MetroLabel metroLabel1;
        private MetroTextBox metroTextBox1;
        private MetroButton metroButton1;
        private MetroLabel metroLabel2;
        private MetroTrackBar metroTrackBar1;
        private MetroButton metroButton2;
    }
}