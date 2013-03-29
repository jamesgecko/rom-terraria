namespace RomTerraria
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ZIP Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Folders", System.Windows.Forms.HorizontalAlignment.Left);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGraphics = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.useHiDef = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.globalMinimap = new System.Windows.Forms.CheckBox();
            this.localMinimap = new System.Windows.Forms.CheckBox();
            this.resizeGroup = new System.Windows.Forms.GroupBox();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.gameHeight = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.gameWidth = new System.Windows.Forms.TextBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.gameResize = new System.Windows.Forms.RadioButton();
            this.gameMultimon = new System.Windows.Forms.RadioButton();
            this.gameNoResize = new System.Windows.Forms.RadioButton();
            this.tabGameplay = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rainRate = new System.Windows.Forms.TrackBar();
            this.lava = new System.Windows.Forms.CheckBox();
            this.rain = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.spawnEye = new System.Windows.Forms.CheckBox();
            this.infiniteGoblinInvasion = new System.Windows.Forms.CheckBox();
            this.infiniteBloodMoon = new System.Windows.Forms.CheckBox();
            this.waterInHell = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.regenRate = new System.Windows.Forms.TrackBar();
            this.regenMana = new System.Windows.Forms.CheckBox();
            this.regenHealth = new System.Windows.Forms.CheckBox();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.resizeBackgrounds = new System.Windows.Forms.CheckBox();
            this.showTooltip = new System.Windows.Forms.CheckBox();
            this.inGameClock = new System.Windows.Forms.CheckBox();
            this.labelNPCRooms = new System.Windows.Forms.CheckBox();
            this.manaBoots = new System.Windows.Forms.CheckBox();
            this.profanityFilter = new System.Windows.Forms.CheckBox();
            this.createCraftableList = new System.Windows.Forms.CheckBox();
            this.tabTextures = new System.Windows.Forms.TabPage();
            this.refreshList = new System.Windows.Forms.PictureBox();
            this.useInternalFonts = new System.Windows.Forms.CheckBox();
            this.generateDefault = new System.Windows.Forms.Button();
            this.texturePack = new System.Windows.Forms.ListView();
            this.texturePackIcons = new System.Windows.Forms.ImageList(this.components);
            this.useTexturePacks = new System.Windows.Forms.CheckBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.launch = new System.Windows.Forms.Button();
            this.lavaCleanup = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabGraphics.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.resizeGroup.SuspendLayout();
            this.tabGameplay.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rainRate)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regenRate)).BeginInit();
            this.tabTools.SuspendLayout();
            this.tabTextures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshList)).BeginInit();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabGraphics);
            this.tabControl.Controls.Add(this.tabGameplay);
            this.tabControl.Controls.Add(this.tabTools);
            this.tabControl.Controls.Add(this.tabTextures);
            this.tabControl.Controls.Add(this.tabAbout);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(598, 363);
            this.tabControl.TabIndex = 0;
            // 
            // tabGraphics
            // 
            this.tabGraphics.Controls.Add(this.groupBox4);
            this.tabGraphics.Controls.Add(this.groupBox2);
            this.tabGraphics.Controls.Add(this.resizeGroup);
            this.tabGraphics.Location = new System.Drawing.Point(4, 22);
            this.tabGraphics.Name = "tabGraphics";
            this.tabGraphics.Padding = new System.Windows.Forms.Padding(3);
            this.tabGraphics.Size = new System.Drawing.Size(590, 337);
            this.tabGraphics.TabIndex = 1;
            this.tabGraphics.Text = "Graphics";
            this.tabGraphics.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.useHiDef);
            this.groupBox4.Location = new System.Drawing.Point(9, 217);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(573, 114);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Graphical Enhancements";
            // 
            // useHiDef
            // 
            this.useHiDef.AutoSize = true;
            this.useHiDef.Location = new System.Drawing.Point(7, 21);
            this.useHiDef.Name = "useHiDef";
            this.useHiDef.Size = new System.Drawing.Size(300, 17);
            this.useHiDef.TabIndex = 0;
            this.useHiDef.Text = "Enable XNA\'s HiDef Profile For Shader Model 3.0 Shaders";
            this.useHiDef.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.globalMinimap);
            this.groupBox2.Controls.Add(this.localMinimap);
            this.groupBox2.Location = new System.Drawing.Point(9, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 73);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Minimaps";
            // 
            // globalMinimap
            // 
            this.globalMinimap.AutoSize = true;
            this.globalMinimap.Location = new System.Drawing.Point(7, 45);
            this.globalMinimap.Name = "globalMinimap";
            this.globalMinimap.Size = new System.Drawing.Size(219, 17);
            this.globalMinimap.TabIndex = 1;
            this.globalMinimap.Text = "Show Global Minimap When In Inventory";
            this.globalMinimap.UseVisualStyleBackColor = true;
            // 
            // localMinimap
            // 
            this.localMinimap.AutoSize = true;
            this.localMinimap.Location = new System.Drawing.Point(7, 21);
            this.localMinimap.Name = "localMinimap";
            this.localMinimap.Size = new System.Drawing.Size(260, 17);
            this.localMinimap.TabIndex = 0;
            this.localMinimap.Text = "Show Local Area Minimap When Not In Inventory";
            this.localMinimap.UseVisualStyleBackColor = true;
            // 
            // resizeGroup
            // 
            this.resizeGroup.Controls.Add(this.linkLabel8);
            this.resizeGroup.Controls.Add(this.gameHeight);
            this.resizeGroup.Controls.Add(this.labelHeight);
            this.resizeGroup.Controls.Add(this.gameWidth);
            this.resizeGroup.Controls.Add(this.labelWidth);
            this.resizeGroup.Controls.Add(this.gameResize);
            this.resizeGroup.Controls.Add(this.gameMultimon);
            this.resizeGroup.Controls.Add(this.gameNoResize);
            this.resizeGroup.Location = new System.Drawing.Point(9, 7);
            this.resizeGroup.Name = "resizeGroup";
            this.resizeGroup.Size = new System.Drawing.Size(573, 123);
            this.resizeGroup.TabIndex = 0;
            this.resizeGroup.TabStop = false;
            this.resizeGroup.Text = "Change Resolution";
            // 
            // linkLabel8
            // 
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.Location = new System.Drawing.Point(460, 21);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(107, 13);
            this.linkLabel8.TabIndex = 7;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Text = "Eyefinity Warning";
            this.linkLabel8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel8_LinkClicked);
            // 
            // gameHeight
            // 
            this.gameHeight.Enabled = false;
            this.gameHeight.Location = new System.Drawing.Point(254, 90);
            this.gameHeight.Name = "gameHeight";
            this.gameHeight.Size = new System.Drawing.Size(100, 21);
            this.gameHeight.TabIndex = 6;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Enabled = false;
            this.labelHeight.Location = new System.Drawing.Point(205, 93);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(43, 13);
            this.labelHeight.TabIndex = 5;
            this.labelHeight.Text = "Height";
            // 
            // gameWidth
            // 
            this.gameWidth.Enabled = false;
            this.gameWidth.Location = new System.Drawing.Point(71, 90);
            this.gameWidth.Name = "gameWidth";
            this.gameWidth.Size = new System.Drawing.Size(100, 21);
            this.gameWidth.TabIndex = 4;
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Enabled = false;
            this.labelWidth.Location = new System.Drawing.Point(26, 93);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(39, 13);
            this.labelWidth.TabIndex = 3;
            this.labelWidth.Text = "Width";
            // 
            // gameResize
            // 
            this.gameResize.AutoSize = true;
            this.gameResize.Location = new System.Drawing.Point(7, 69);
            this.gameResize.Name = "gameResize";
            this.gameResize.Size = new System.Drawing.Size(283, 17);
            this.gameResize.TabIndex = 2;
            this.gameResize.Tag = "2";
            this.gameResize.Text = "Enable support for a non-standard resolution in Terraria";
            this.gameResize.UseVisualStyleBackColor = true;
            this.gameResize.CheckedChanged += new System.EventHandler(this.gameResize_CheckedChanged);
            // 
            // gameMultimon
            // 
            this.gameMultimon.AutoSize = true;
            this.gameMultimon.Location = new System.Drawing.Point(7, 45);
            this.gameMultimon.Name = "gameMultimon";
            this.gameMultimon.Size = new System.Drawing.Size(388, 17);
            this.gameMultimon.TabIndex = 1;
            this.gameMultimon.Tag = "1";
            this.gameMultimon.Text = "Use DirectX Cooperative Mode for full screen (helpful for multimonitor configs)";
            this.gameMultimon.UseVisualStyleBackColor = true;
            // 
            // gameNoResize
            // 
            this.gameNoResize.AutoSize = true;
            this.gameNoResize.Checked = true;
            this.gameNoResize.Location = new System.Drawing.Point(7, 21);
            this.gameNoResize.Name = "gameNoResize";
            this.gameNoResize.Size = new System.Drawing.Size(214, 17);
            this.gameNoResize.TabIndex = 0;
            this.gameNoResize.TabStop = true;
            this.gameNoResize.Tag = "0";
            this.gameNoResize.Text = "Let Terraria handle my game\'s resolution";
            this.gameNoResize.UseVisualStyleBackColor = true;
            // 
            // tabGameplay
            // 
            this.tabGameplay.Controls.Add(this.groupBox1);
            this.tabGameplay.Controls.Add(this.groupBox5);
            this.tabGameplay.Controls.Add(this.groupBox3);
            this.tabGameplay.Location = new System.Drawing.Point(4, 22);
            this.tabGameplay.Name = "tabGameplay";
            this.tabGameplay.Size = new System.Drawing.Size(590, 337);
            this.tabGameplay.TabIndex = 2;
            this.tabGameplay.Text = "Gameplay";
            this.tabGameplay.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rainRate);
            this.groupBox1.Controls.Add(this.lava);
            this.groupBox1.Controls.Add(this.rain);
            this.groupBox1.Location = new System.Drawing.Point(9, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 76);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weather";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Noah";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Arid";
            // 
            // rainRate
            // 
            this.rainRate.BackColor = System.Drawing.SystemColors.Window;
            this.rainRate.Location = new System.Drawing.Point(129, 17);
            this.rainRate.Maximum = 100;
            this.rainRate.Name = "rainRate";
            this.rainRate.Size = new System.Drawing.Size(438, 45);
            this.rainRate.TabIndex = 3;
            this.rainRate.TickFrequency = 10;
            // 
            // lava
            // 
            this.lava.AutoSize = true;
            this.lava.Location = new System.Drawing.Point(7, 45);
            this.lava.Name = "lava";
            this.lava.Size = new System.Drawing.Size(50, 17);
            this.lava.TabIndex = 1;
            this.lava.Text = "Lava";
            this.lava.UseVisualStyleBackColor = true;
            this.lava.CheckedChanged += new System.EventHandler(this.lava_CheckedChanged);
            // 
            // rain
            // 
            this.rain.AutoSize = true;
            this.rain.Location = new System.Drawing.Point(7, 21);
            this.rain.Name = "rain";
            this.rain.Size = new System.Drawing.Size(48, 17);
            this.rain.TabIndex = 0;
            this.rain.Text = "Rain";
            this.rain.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.spawnEye);
            this.groupBox5.Controls.Add(this.infiniteGoblinInvasion);
            this.groupBox5.Controls.Add(this.infiniteBloodMoon);
            this.groupBox5.Controls.Add(this.waterInHell);
            this.groupBox5.Location = new System.Drawing.Point(9, 86);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(573, 166);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "World Behavior";
            // 
            // spawnEye
            // 
            this.spawnEye.AutoSize = true;
            this.spawnEye.Location = new System.Drawing.Point(7, 93);
            this.spawnEye.Name = "spawnEye";
            this.spawnEye.Size = new System.Drawing.Size(271, 17);
            this.spawnEye.TabIndex = 3;
            this.spawnEye.Text = "Spawn An Eye Of Cthulhu Each Day (If You Qualify)";
            this.spawnEye.UseVisualStyleBackColor = true;
            // 
            // infiniteGoblinInvasion
            // 
            this.infiniteGoblinInvasion.AutoSize = true;
            this.infiniteGoblinInvasion.Location = new System.Drawing.Point(7, 69);
            this.infiniteGoblinInvasion.Name = "infiniteGoblinInvasion";
            this.infiniteGoblinInvasion.Size = new System.Drawing.Size(201, 17);
            this.infiniteGoblinInvasion.TabIndex = 2;
            this.infiniteGoblinInvasion.Text = "Trigger A Continuous Goblin Invasion";
            this.infiniteGoblinInvasion.UseVisualStyleBackColor = true;
            // 
            // infiniteBloodMoon
            // 
            this.infiniteBloodMoon.AutoSize = true;
            this.infiniteBloodMoon.Location = new System.Drawing.Point(7, 45);
            this.infiniteBloodMoon.Name = "infiniteBloodMoon";
            this.infiniteBloodMoon.Size = new System.Drawing.Size(181, 17);
            this.infiniteBloodMoon.TabIndex = 1;
            this.infiniteBloodMoon.Text = "Make Every Night A Blood Moon";
            this.infiniteBloodMoon.UseVisualStyleBackColor = true;
            // 
            // waterInHell
            // 
            this.waterInHell.AutoSize = true;
            this.waterInHell.Location = new System.Drawing.Point(7, 21);
            this.waterInHell.Name = "waterInHell";
            this.waterInHell.Size = new System.Drawing.Size(237, 17);
            this.waterInHell.TabIndex = 0;
            this.waterInHell.Text = "Try To Counteract Water Evaporation In Hell";
            this.waterInHell.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.regenRate);
            this.groupBox3.Controls.Add(this.regenMana);
            this.groupBox3.Controls.Add(this.regenHealth);
            this.groupBox3.Location = new System.Drawing.Point(9, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(573, 75);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Regeneration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(345, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fast Healing Comic-Book Character In Stupid Yellow Tights";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Slow";
            // 
            // regenRate
            // 
            this.regenRate.BackColor = System.Drawing.SystemColors.Window;
            this.regenRate.Location = new System.Drawing.Point(129, 21);
            this.regenRate.Maximum = 100;
            this.regenRate.Name = "regenRate";
            this.regenRate.Size = new System.Drawing.Size(438, 45);
            this.regenRate.TabIndex = 2;
            this.regenRate.TickFrequency = 10;
            // 
            // regenMana
            // 
            this.regenMana.AutoSize = true;
            this.regenMana.Location = new System.Drawing.Point(7, 45);
            this.regenMana.Name = "regenMana";
            this.regenMana.Size = new System.Drawing.Size(53, 17);
            this.regenMana.TabIndex = 1;
            this.regenMana.Text = "Mana";
            this.regenMana.UseVisualStyleBackColor = true;
            // 
            // regenHealth
            // 
            this.regenHealth.AutoSize = true;
            this.regenHealth.Location = new System.Drawing.Point(7, 21);
            this.regenHealth.Name = "regenHealth";
            this.regenHealth.Size = new System.Drawing.Size(57, 17);
            this.regenHealth.TabIndex = 0;
            this.regenHealth.Text = "Health";
            this.regenHealth.UseVisualStyleBackColor = true;
            // 
            // tabTools
            // 
            this.tabTools.Controls.Add(this.lavaCleanup);
            this.tabTools.Controls.Add(this.resizeBackgrounds);
            this.tabTools.Controls.Add(this.showTooltip);
            this.tabTools.Controls.Add(this.inGameClock);
            this.tabTools.Controls.Add(this.labelNPCRooms);
            this.tabTools.Controls.Add(this.manaBoots);
            this.tabTools.Controls.Add(this.profanityFilter);
            this.tabTools.Controls.Add(this.createCraftableList);
            this.tabTools.Location = new System.Drawing.Point(4, 22);
            this.tabTools.Name = "tabTools";
            this.tabTools.Size = new System.Drawing.Size(590, 337);
            this.tabTools.TabIndex = 3;
            this.tabTools.Text = "Tools and Enhancements";
            this.tabTools.UseVisualStyleBackColor = true;
            // 
            // resizeBackgrounds
            // 
            this.resizeBackgrounds.AutoSize = true;
            this.resizeBackgrounds.Enabled = false;
            this.resizeBackgrounds.Location = new System.Drawing.Point(8, 156);
            this.resizeBackgrounds.Name = "resizeBackgrounds";
            this.resizeBackgrounds.Size = new System.Drawing.Size(489, 17);
            this.resizeBackgrounds.TabIndex = 6;
            this.resizeBackgrounds.Text = "Rescale Backgrounds To Reduce VRAM Usage To 25% (Will Cause Visual Issues)";
            this.resizeBackgrounds.UseVisualStyleBackColor = true;
            // 
            // showTooltip
            // 
            this.showTooltip.AutoSize = true;
            this.showTooltip.Location = new System.Drawing.Point(9, 132);
            this.showTooltip.Name = "showTooltip";
            this.showTooltip.Size = new System.Drawing.Size(375, 17);
            this.showTooltip.TabIndex = 5;
            this.showTooltip.Text = "Show What Blocks Are When Holding CTRL Key (Incomplete)";
            this.showTooltip.UseVisualStyleBackColor = true;
            // 
            // inGameClock
            // 
            this.inGameClock.AutoSize = true;
            this.inGameClock.Location = new System.Drawing.Point(9, 108);
            this.inGameClock.Name = "inGameClock";
            this.inGameClock.Size = new System.Drawing.Size(463, 17);
            this.inGameClock.TabIndex = 4;
            this.inGameClock.Text = "Show A Real-Time Clock In Game In The Lower Right Corner Of The Screen";
            this.inGameClock.UseVisualStyleBackColor = true;
            // 
            // labelNPCRooms
            // 
            this.labelNPCRooms.AutoSize = true;
            this.labelNPCRooms.Location = new System.Drawing.Point(9, 84);
            this.labelNPCRooms.Name = "labelNPCRooms";
            this.labelNPCRooms.Size = new System.Drawing.Size(127, 17);
            this.labelNPCRooms.TabIndex = 3;
            this.labelNPCRooms.Text = "Label NPC Rooms";
            this.labelNPCRooms.UseVisualStyleBackColor = true;
            // 
            // manaBoots
            // 
            this.manaBoots.AutoSize = true;
            this.manaBoots.Location = new System.Drawing.Point(9, 60);
            this.manaBoots.Name = "manaBoots";
            this.manaBoots.Size = new System.Drawing.Size(226, 17);
            this.manaBoots.TabIndex = 2;
            this.manaBoots.Text = "Have Rocket Boots Consume Mana";
            this.manaBoots.UseVisualStyleBackColor = true;
            // 
            // profanityFilter
            // 
            this.profanityFilter.AutoSize = true;
            this.profanityFilter.Location = new System.Drawing.Point(9, 36);
            this.profanityFilter.Name = "profanityFilter";
            this.profanityFilter.Size = new System.Drawing.Size(264, 17);
            this.profanityFilter.TabIndex = 1;
            this.profanityFilter.Text = "Enable Profanity Filter In Multiplayer Chat";
            this.profanityFilter.UseVisualStyleBackColor = true;
            // 
            // createCraftableList
            // 
            this.createCraftableList.AutoSize = true;
            this.createCraftableList.Location = new System.Drawing.Point(8, 12);
            this.createCraftableList.Name = "createCraftableList";
            this.createCraftableList.Size = new System.Drawing.Size(368, 17);
            this.createCraftableList.TabIndex = 0;
            this.createCraftableList.Text = "Create Craftables List In \"My Documents\" Folder On Launch";
            this.createCraftableList.UseVisualStyleBackColor = true;
            // 
            // tabTextures
            // 
            this.tabTextures.Controls.Add(this.refreshList);
            this.tabTextures.Controls.Add(this.useInternalFonts);
            this.tabTextures.Controls.Add(this.generateDefault);
            this.tabTextures.Controls.Add(this.texturePack);
            this.tabTextures.Controls.Add(this.useTexturePacks);
            this.tabTextures.Location = new System.Drawing.Point(4, 22);
            this.tabTextures.Name = "tabTextures";
            this.tabTextures.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextures.Size = new System.Drawing.Size(590, 337);
            this.tabTextures.TabIndex = 4;
            this.tabTextures.Text = "Textures and Fonts";
            this.tabTextures.UseVisualStyleBackColor = true;
            // 
            // refreshList
            // 
            this.refreshList.Image = ((System.Drawing.Image)(resources.GetObject("refreshList.Image")));
            this.refreshList.Location = new System.Drawing.Point(566, 7);
            this.refreshList.Name = "refreshList";
            this.refreshList.Size = new System.Drawing.Size(16, 16);
            this.refreshList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.refreshList.TabIndex = 4;
            this.refreshList.TabStop = false;
            this.refreshList.Click += new System.EventHandler(this.refreshList_Click);
            // 
            // useInternalFonts
            // 
            this.useInternalFonts.AutoSize = true;
            this.useInternalFonts.Location = new System.Drawing.Point(9, 307);
            this.useInternalFonts.Name = "useInternalFonts";
            this.useInternalFonts.Size = new System.Drawing.Size(209, 17);
            this.useInternalFonts.TabIndex = 3;
            this.useInternalFonts.Text = "Always Use RomTerraria Internal Fonts";
            this.useInternalFonts.UseVisualStyleBackColor = true;
            // 
            // generateDefault
            // 
            this.generateDefault.Location = new System.Drawing.Point(347, 303);
            this.generateDefault.Name = "generateDefault";
            this.generateDefault.Size = new System.Drawing.Size(235, 23);
            this.generateDefault.TabIndex = 2;
            this.generateDefault.Text = "Generate Default Texture Pack";
            this.generateDefault.UseVisualStyleBackColor = true;
            this.generateDefault.Click += new System.EventHandler(this.generateDefault_Click);
            // 
            // texturePack
            // 
            this.texturePack.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.texturePack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.texturePack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.texturePack.Enabled = false;
            listViewGroup3.Header = "ZIP Files";
            listViewGroup3.Name = "zip";
            listViewGroup4.Header = "Folders";
            listViewGroup4.Name = "folder";
            this.texturePack.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.texturePack.HideSelection = false;
            this.texturePack.Location = new System.Drawing.Point(9, 31);
            this.texturePack.MultiSelect = false;
            this.texturePack.Name = "texturePack";
            this.texturePack.Size = new System.Drawing.Size(573, 266);
            this.texturePack.SmallImageList = this.texturePackIcons;
            this.texturePack.TabIndex = 1;
            this.texturePack.UseCompatibleStateImageBehavior = false;
            this.texturePack.View = System.Windows.Forms.View.SmallIcon;
            // 
            // texturePackIcons
            // 
            this.texturePackIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("texturePackIcons.ImageStream")));
            this.texturePackIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.texturePackIcons.Images.SetKeyName(0, "Folder");
            this.texturePackIcons.Images.SetKeyName(1, "ZIP");
            // 
            // useTexturePacks
            // 
            this.useTexturePacks.AutoSize = true;
            this.useTexturePacks.Location = new System.Drawing.Point(9, 7);
            this.useTexturePacks.Name = "useTexturePacks";
            this.useTexturePacks.Size = new System.Drawing.Size(172, 17);
            this.useTexturePacks.TabIndex = 0;
            this.useTexturePacks.Text = "Enable Texture And Font Pack";
            this.useTexturePacks.UseVisualStyleBackColor = true;
            this.useTexturePacks.CheckedChanged += new System.EventHandler(this.useTexturePacks_CheckedChanged);
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.linkLabel7);
            this.tabAbout.Controls.Add(this.linkLabel6);
            this.tabAbout.Controls.Add(this.linkLabel5);
            this.tabAbout.Controls.Add(this.linkLabel4);
            this.tabAbout.Controls.Add(this.linkLabel3);
            this.tabAbout.Controls.Add(this.linkLabel2);
            this.tabAbout.Controls.Add(this.linkLabel1);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(590, 337);
            this.tabAbout.TabIndex = 0;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // linkLabel7
            // 
            this.linkLabel7.LinkArea = new System.Windows.Forms.LinkArea(30, 74);
            this.linkLabel7.Location = new System.Drawing.Point(12, 55);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(540, 44);
            this.linkLabel7.TabIndex = 6;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Tag = "http://creativecommons.org/licenses/by-nc-sa/3.0/";
            this.linkLabel7.Text = "This program licensed under a Creative Commons Attribution-NonCommercial-ShareAli" +
    "ke 3.0 Unported License with the additional restriction that it cannot be used t" +
    "o create illegal copies of Terraria.";
            this.linkLabel7.UseCompatibleTextRendering = true;
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Location = new System.Drawing.Point(9, 29);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(175, 13);
            this.linkLabel6.TabIndex = 5;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Tag = "http://www.terraria.org/";
            this.linkLabel6.Text = "Terraria created by Re-Logic.";
            this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.LinkArea = new System.Windows.Forms.LinkArea(50, 11);
            this.linkLabel5.Location = new System.Drawing.Point(9, 310);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(372, 18);
            this.linkLabel5.TabIndex = 4;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Tag = "mailto:jra101@gmail.com";
            this.linkLabel5.Text = "DirectX cooperative mode support code provided by Jason Allen.";
            this.linkLabel5.UseCompatibleTextRendering = true;
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.LinkArea = new System.Windows.Forms.LinkArea(28, 43);
            this.linkLabel4.Location = new System.Drawing.Point(9, 288);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(412, 18);
            this.linkLabel4.TabIndex = 3;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Tag = "http://urbanoalvarez.es/blog/2008/04/04/bad-words-list/";
            this.linkLabel4.Text = "The profanity filter uses a \"bad words list\" compiled by Urbano Alvares.";
            this.linkLabel4.UseCompatibleTextRendering = true;
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkArea = new System.Windows.Forms.LinkArea(19, 9);
            this.linkLabel3.Location = new System.Drawing.Point(9, 266);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(461, 18);
            this.linkLabel3.TabIndex = 2;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Tag = "http://www.fonts.com/findfonts/detail.htm?productid=423441";
            this.linkLabel3.Text = "The included font, Miramonte, is licensed for use with XNA Game Studio games.";
            this.linkLabel3.UseCompatibleTextRendering = true;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkArea = new System.Windows.Forms.LinkArea(31, 11);
            this.linkLabel2.Location = new System.Drawing.Point(9, 244);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(340, 18);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Tag = "http://sharpdevelop.net/OpenSource/SharpZipLib/";
            this.linkLabel2.Text = "Texture pack support relies on SharpZipLib to extract files.";
            this.linkLabel2.UseCompatibleTextRendering = true;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(23, 15);
            this.linkLabel1.Location = new System.Drawing.Point(9, 7);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(234, 18);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "http://www.romsteady.net/";
            this.linkLabel1.Text = "RomTerraria created by Michael Russell.";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // launch
            // 
            this.launch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.launch.Location = new System.Drawing.Point(4, 369);
            this.launch.Name = "launch";
            this.launch.Size = new System.Drawing.Size(590, 23);
            this.launch.TabIndex = 1;
            this.launch.Text = "Launch Terraria";
            this.launch.UseVisualStyleBackColor = true;
            this.launch.Click += new System.EventHandler(this.launch_Click);
            // 
            // lavaCleanup
            // 
            this.lavaCleanup.AutoSize = true;
            this.lavaCleanup.Location = new System.Drawing.Point(8, 180);
            this.lavaCleanup.Name = "lavaCleanup";
            this.lavaCleanup.Size = new System.Drawing.Size(396, 17);
            this.lavaCleanup.TabIndex = 7;
            this.lavaCleanup.Text = "Delete All Lava From The Top 25% Of The World (Lava Cleanup)";
            this.lavaCleanup.UseVisualStyleBackColor = true;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(598, 396);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Launcher";
            this.Text = "RomTerraria";
            this.tabControl.ResumeLayout(false);
            this.tabGraphics.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.resizeGroup.ResumeLayout(false);
            this.resizeGroup.PerformLayout();
            this.tabGameplay.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rainRate)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regenRate)).EndInit();
            this.tabTools.ResumeLayout(false);
            this.tabTools.PerformLayout();
            this.tabTextures.ResumeLayout(false);
            this.tabTextures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshList)).EndInit();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.TabPage tabGraphics;
        private System.Windows.Forms.TabPage tabGameplay;
        private System.Windows.Forms.TabPage tabTools;
        private System.Windows.Forms.GroupBox resizeGroup;
        private System.Windows.Forms.TextBox gameHeight;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.TextBox gameWidth;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.RadioButton gameResize;
        private System.Windows.Forms.RadioButton gameMultimon;
        private System.Windows.Forms.RadioButton gameNoResize;
        private System.Windows.Forms.TabPage tabTextures;
        private System.Windows.Forms.Button launch;
        private System.Windows.Forms.ListView texturePack;
        private System.Windows.Forms.CheckBox useTexturePacks;
        private System.Windows.Forms.Button generateDefault;
        private System.Windows.Forms.CheckBox useInternalFonts;
        private System.Windows.Forms.ImageList texturePackIcons;
        private System.Windows.Forms.PictureBox refreshList;
        private System.Windows.Forms.CheckBox createCraftableList;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox globalMinimap;
        private System.Windows.Forms.CheckBox localMinimap;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox regenMana;
        private System.Windows.Forms.CheckBox regenHealth;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox useHiDef;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox waterInHell;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox lava;
        private System.Windows.Forms.CheckBox rain;
        private System.Windows.Forms.CheckBox profanityFilter;
        private System.Windows.Forms.TrackBar rainRate;
        private System.Windows.Forms.TrackBar regenRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox manaBoots;
        private System.Windows.Forms.CheckBox labelNPCRooms;
        private System.Windows.Forms.CheckBox inGameClock;
        private System.Windows.Forms.CheckBox infiniteGoblinInvasion;
        private System.Windows.Forms.CheckBox infiniteBloodMoon;
        private System.Windows.Forms.CheckBox spawnEye;
        private System.Windows.Forms.CheckBox showTooltip;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.CheckBox resizeBackgrounds;
        private System.Windows.Forms.LinkLabel linkLabel8;
        private System.Windows.Forms.CheckBox lavaCleanup;
    }
}

