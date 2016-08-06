namespace KeppySpartanMIDIConverter
{
    partial class MainWindow
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.startRenderingWAVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abortRenderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeADonationToSupportTheDeveloperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.keppyStudiosWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackMIDIStuffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.officialBlackMIDIWikiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.officialBlackMIDICommunityGoogleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.wikipediasPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MIDIImport = new System.Windows.Forms.OpenFileDialog();
            this.RenderingTimer = new System.Windows.Forms.Timer(this.components);
            this.UsedVoices = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MIDIList = new System.Windows.Forms.ListBox();
            this.DefMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMIDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMIDIsListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsBox = new System.Windows.Forms.GroupBox();
            this.AdvSettingsButton = new System.Windows.Forms.Button();
            this.VoiceLimit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentStatus = new System.Windows.Forms.ProgressBar();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMIDIsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openTheSoundfontsManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRenderingOGGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playInRealtimeBetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticallyCheckForUpdatesWhenStartingTheConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.autoShutdownAfterRenderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMIDIListAfterRenderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showConversionPositionInsteadOfTimeLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.conversionStartedfinishedfailedSoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.forceCloseTheApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingpic = new System.Windows.Forms.PictureBox();
            this.ExportWhere = new System.Windows.Forms.SaveFileDialog();
            this.labelRMS = new System.Windows.Forms.Label();
            this.CurrentStatusText = new System.Windows.Forms.Label();
            this.RealTimePlayBack = new System.ComponentModel.BackgroundWorker();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.VolumeTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConverterProcess = new System.ComponentModel.BackgroundWorker();
            this.DefMenu.SuspendLayout();
            this.SettingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceLimit)).BeginInit();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startRenderingWAVToolStripMenuItem
            // 
            this.startRenderingWAVToolStripMenuItem.Name = "startRenderingWAVToolStripMenuItem";
            this.startRenderingWAVToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.startRenderingWAVToolStripMenuItem.Text = "Render files to Wave (.WAV)";
            this.startRenderingWAVToolStripMenuItem.Click += new System.EventHandler(this.startRenderingWAVToolStripMenuItem_Click);
            // 
            // abortRenderingToolStripMenuItem
            // 
            this.abortRenderingToolStripMenuItem.Enabled = false;
            this.abortRenderingToolStripMenuItem.Name = "abortRenderingToolStripMenuItem";
            this.abortRenderingToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.abortRenderingToolStripMenuItem.Text = "Abort rendering";
            this.abortRenderingToolStripMenuItem.Click += new System.EventHandler(this.abortRenderingToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(262, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationsToolStripMenuItem,
            this.makeADonationToSupportTheDeveloperToolStripMenuItem,
            this.toolStripSeparator3,
            this.keppyStudiosWebsiteToolStripMenuItem,
            this.blackMIDIStuffToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.toolStripMenuItem1.Text = "Help";
            // 
            // informationsToolStripMenuItem
            // 
            this.informationsToolStripMenuItem.Name = "informationsToolStripMenuItem";
            this.informationsToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.informationsToolStripMenuItem.Text = "Information about the program";
            this.informationsToolStripMenuItem.Click += new System.EventHandler(this.informationsToolStripMenuItem_Click);
            // 
            // makeADonationToSupportTheDeveloperToolStripMenuItem
            // 
            this.makeADonationToSupportTheDeveloperToolStripMenuItem.Name = "makeADonationToSupportTheDeveloperToolStripMenuItem";
            this.makeADonationToSupportTheDeveloperToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.makeADonationToSupportTheDeveloperToolStripMenuItem.Text = "Support the developer with a donation";
            this.makeADonationToSupportTheDeveloperToolStripMenuItem.Click += new System.EventHandler(this.makeADonationToSupportTheDeveloperToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(256, 6);
            // 
            // keppyStudiosWebsiteToolStripMenuItem
            // 
            this.keppyStudiosWebsiteToolStripMenuItem.Name = "keppyStudiosWebsiteToolStripMenuItem";
            this.keppyStudiosWebsiteToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.keppyStudiosWebsiteToolStripMenuItem.Text = "Keppy Studios Website";
            this.keppyStudiosWebsiteToolStripMenuItem.Click += new System.EventHandler(this.keppyStudiosWebsiteToolStripMenuItem_Click);
            // 
            // blackMIDIStuffToolStripMenuItem
            // 
            this.blackMIDIStuffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem,
            this.toolStripSeparator6,
            this.officialBlackMIDIWikiaToolStripMenuItem,
            this.officialBlackMIDICommunityGoogleToolStripMenuItem,
            this.toolStripSeparator7,
            this.wikipediasPageToolStripMenuItem});
            this.blackMIDIStuffToolStripMenuItem.Name = "blackMIDIStuffToolStripMenuItem";
            this.blackMIDIStuffToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.blackMIDIStuffToolStripMenuItem.Text = "Black MIDI stuff";
            // 
            // kaleidonKep99sYouTubeChannelToolStripMenuItem
            // 
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem.Name = "kaleidonKep99sYouTubeChannelToolStripMenuItem";
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem.Text = "KaleidonKep99\'s YouTube Channel";
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem.Click += new System.EventHandler(this.kaleidonKep99sYouTubeChannelToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(265, 6);
            // 
            // officialBlackMIDIWikiaToolStripMenuItem
            // 
            this.officialBlackMIDIWikiaToolStripMenuItem.Name = "officialBlackMIDIWikiaToolStripMenuItem";
            this.officialBlackMIDIWikiaToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.officialBlackMIDIWikiaToolStripMenuItem.Text = "Official Black MIDI Wikia";
            this.officialBlackMIDIWikiaToolStripMenuItem.Click += new System.EventHandler(this.officialBlackMIDIWikiaToolStripMenuItem_Click);
            // 
            // officialBlackMIDICommunityGoogleToolStripMenuItem
            // 
            this.officialBlackMIDICommunityGoogleToolStripMenuItem.Name = "officialBlackMIDICommunityGoogleToolStripMenuItem";
            this.officialBlackMIDICommunityGoogleToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.officialBlackMIDICommunityGoogleToolStripMenuItem.Text = "Official Black MIDI Community (Google+)";
            this.officialBlackMIDICommunityGoogleToolStripMenuItem.Click += new System.EventHandler(this.officialBlackMIDICommunityGoogleToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(265, 6);
            // 
            // wikipediasPageToolStripMenuItem
            // 
            this.wikipediasPageToolStripMenuItem.Name = "wikipediasPageToolStripMenuItem";
            this.wikipediasPageToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.wikipediasPageToolStripMenuItem.Text = "Wikipedia\'s page";
            this.wikipediasPageToolStripMenuItem.Click += new System.EventHandler(this.wikipediasPageToolStripMenuItem_Click);
            // 
            // MIDIImport
            // 
            this.MIDIImport.Filter = "MIDI files|*.mid;*.midi;*.rmi";
            this.MIDIImport.Multiselect = true;
            this.MIDIImport.RestoreDirectory = true;
            this.MIDIImport.Title = "Import MIDIs to the conversion list..";
            // 
            // RenderingTimer
            // 
            this.RenderingTimer.Enabled = true;
            this.RenderingTimer.Interval = 1;
            this.RenderingTimer.Tick += new System.EventHandler(this.RenderingTimer_Tick);
            // 
            // UsedVoices
            // 
            this.UsedVoices.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsedVoices.Location = new System.Drawing.Point(359, 307);
            this.UsedVoices.Name = "UsedVoices";
            this.UsedVoices.Size = new System.Drawing.Size(143, 13);
            this.UsedVoices.TabIndex = 8;
            this.UsedVoices.Text = "Voices: 100000/100000";
            this.UsedVoices.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(262, 6);
            // 
            // MIDIList
            // 
            this.MIDIList.AllowDrop = true;
            this.MIDIList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MIDIList.ContextMenuStrip = this.DefMenu;
            this.MIDIList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MIDIList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDIList.FormattingEnabled = true;
            this.MIDIList.HorizontalScrollbar = true;
            this.MIDIList.ItemHeight = 16;
            this.MIDIList.Location = new System.Drawing.Point(12, 36);
            this.MIDIList.Name = "MIDIList";
            this.MIDIList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.MIDIList.Size = new System.Drawing.Size(628, 258);
            this.MIDIList.TabIndex = 11;
            this.MIDIList.DragDrop += new System.Windows.Forms.DragEventHandler(this.MIDIList_DragDrop);
            this.MIDIList.DragEnter += new System.Windows.Forms.DragEventHandler(this.MIDIList_DragEnter);
            this.MIDIList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MIDIList_KeyPress);
            // 
            // DefMenu
            // 
            this.DefMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMIDIsToolStripMenuItem,
            this.removeMIDIToolStripMenuItem,
            this.clearMIDIsListToolStripMenuItem1,
            this.toolStripSeparator5,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.DefMenu.Name = "contextMenuStrip1";
            this.DefMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.DefMenu.Size = new System.Drawing.Size(188, 142);
            // 
            // addMIDIsToolStripMenuItem
            // 
            this.addMIDIsToolStripMenuItem.Name = "addMIDIsToolStripMenuItem";
            this.addMIDIsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.addMIDIsToolStripMenuItem.Text = "Import MIDIs";
            this.addMIDIsToolStripMenuItem.Click += new System.EventHandler(this.addMIDIsToolStripMenuItem_Click);
            // 
            // removeMIDIToolStripMenuItem
            // 
            this.removeMIDIToolStripMenuItem.Name = "removeMIDIToolStripMenuItem";
            this.removeMIDIToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.removeMIDIToolStripMenuItem.Text = "Remove selected MIDIs";
            this.removeMIDIToolStripMenuItem.Click += new System.EventHandler(this.removeMIDIToolStripMenuItem_Click);
            // 
            // clearMIDIsListToolStripMenuItem1
            // 
            this.clearMIDIsListToolStripMenuItem1.Name = "clearMIDIsListToolStripMenuItem1";
            this.clearMIDIsListToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.clearMIDIsListToolStripMenuItem1.Text = "Clear MIDIs list";
            this.clearMIDIsListToolStripMenuItem1.Click += new System.EventHandler(this.clearMIDIsListToolStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(184, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.moveUpToolStripMenuItem.Text = "Move up (One item)";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.moveDownToolStripMenuItem.Text = "Move down (One item)";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // SettingsBox
            // 
            this.SettingsBox.Controls.Add(this.AdvSettingsButton);
            this.SettingsBox.Controls.Add(this.VoiceLimit);
            this.SettingsBox.Controls.Add(this.label1);
            this.SettingsBox.Location = new System.Drawing.Point(510, 329);
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.Size = new System.Drawing.Size(130, 70);
            this.SettingsBox.TabIndex = 12;
            this.SettingsBox.TabStop = false;
            this.SettingsBox.Text = "Settings";
            // 
            // AdvSettingsButton
            // 
            this.AdvSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AdvSettingsButton.Location = new System.Drawing.Point(6, 40);
            this.AdvSettingsButton.Name = "AdvSettingsButton";
            this.AdvSettingsButton.Size = new System.Drawing.Size(118, 23);
            this.AdvSettingsButton.TabIndex = 2;
            this.AdvSettingsButton.Text = "Advanced settings";
            this.AdvSettingsButton.UseVisualStyleBackColor = true;
            this.AdvSettingsButton.Click += new System.EventHandler(this.AdvSettingsButton_Click);
            // 
            // VoiceLimit
            // 
            this.VoiceLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VoiceLimit.Location = new System.Drawing.Point(63, 16);
            this.VoiceLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.VoiceLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VoiceLimit.Name = "VoiceLimit";
            this.VoiceLimit.Size = new System.Drawing.Size(58, 21);
            this.VoiceLimit.TabIndex = 1;
            this.VoiceLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VoiceLimit.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.VoiceLimit.ValueChanged += new System.EventHandler(this.VoiceLimit_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voice limit:";
            // 
            // CurrentStatus
            // 
            this.CurrentStatus.BackColor = System.Drawing.SystemColors.Control;
            this.CurrentStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CurrentStatus.Location = new System.Drawing.Point(0, 411);
            this.CurrentStatus.Name = "CurrentStatus";
            this.CurrentStatus.Size = new System.Drawing.Size(652, 23);
            this.CurrentStatus.Step = 1;
            this.CurrentStatus.TabIndex = 14;
            // 
            // Menu
            // 
            this.Menu.AllowMerge = false;
            this.Menu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Menu.Size = new System.Drawing.Size(652, 24);
            this.Menu.TabIndex = 15;
            this.Menu.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importMIDIsToolStripMenuItem,
            this.removeSelectedMIDIsToolStripMenuItem,
            this.clearMIDIsListToolStripMenuItem,
            this.toolStripSeparator4,
            this.openTheSoundfontsManagerToolStripMenuItem,
            this.toolStripSeparator1,
            this.startRenderingWAVToolStripMenuItem,
            this.startRenderingOGGToolStripMenuItem,
            this.playInRealtimeBetaToolStripMenuItem,
            this.abortRenderingToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // importMIDIsToolStripMenuItem
            // 
            this.importMIDIsToolStripMenuItem.Name = "importMIDIsToolStripMenuItem";
            this.importMIDIsToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.importMIDIsToolStripMenuItem.Text = "Import MIDIs";
            this.importMIDIsToolStripMenuItem.Click += new System.EventHandler(this.importMIDIsToolStripMenuItem_Click);
            // 
            // removeSelectedMIDIsToolStripMenuItem
            // 
            this.removeSelectedMIDIsToolStripMenuItem.Name = "removeSelectedMIDIsToolStripMenuItem";
            this.removeSelectedMIDIsToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.removeSelectedMIDIsToolStripMenuItem.Text = "Remove selected MIDIs";
            this.removeSelectedMIDIsToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedMIDIsToolStripMenuItem_Click);
            // 
            // clearMIDIsListToolStripMenuItem
            // 
            this.clearMIDIsListToolStripMenuItem.Name = "clearMIDIsListToolStripMenuItem";
            this.clearMIDIsListToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.clearMIDIsListToolStripMenuItem.Text = "Clear MIDIs list";
            this.clearMIDIsListToolStripMenuItem.Click += new System.EventHandler(this.clearMIDIsListToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(262, 6);
            // 
            // openTheSoundfontsManagerToolStripMenuItem
            // 
            this.openTheSoundfontsManagerToolStripMenuItem.Name = "openTheSoundfontsManagerToolStripMenuItem";
            this.openTheSoundfontsManagerToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.openTheSoundfontsManagerToolStripMenuItem.Text = "Open the soundfonts/VST DSP manager";
            this.openTheSoundfontsManagerToolStripMenuItem.Click += new System.EventHandler(this.openTheSoundfontsManagerToolStripMenuItem_Click);
            // 
            // startRenderingOGGToolStripMenuItem
            // 
            this.startRenderingOGGToolStripMenuItem.Name = "startRenderingOGGToolStripMenuItem";
            this.startRenderingOGGToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.startRenderingOGGToolStripMenuItem.Text = "Render files to Vorbis (.OGG)";
            this.startRenderingOGGToolStripMenuItem.Click += new System.EventHandler(this.startRenderingOGGToolStripMenuItem_Click);
            // 
            // playInRealtimeBetaToolStripMenuItem
            // 
            this.playInRealtimeBetaToolStripMenuItem.Name = "playInRealtimeBetaToolStripMenuItem";
            this.playInRealtimeBetaToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.playInRealtimeBetaToolStripMenuItem.Text = "Preview files (Real-time playback)";
            this.playInRealtimeBetaToolStripMenuItem.Click += new System.EventHandler(this.playInRealtimeBetaToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automaticallyCheckForUpdatesWhenStartingTheConverterToolStripMenuItem,
            this.autoShutdownAfterRenderingToolStripMenuItem,
            this.clearMIDIListAfterRenderingToolStripMenuItem,
            this.showConversionPositionInsteadOfTimeLeftToolStripMenuItem,
            this.conversionStartedfinishedfailedSoundsToolStripMenuItem,
            this.forceCloseTheApplicationToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // automaticallyCheckForUpdatesWhenStartingTheConverterToolStripMenuItem
            // 
            this.automaticallyCheckForUpdatesWhenStartingTheConverterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem3,
            this.disabledToolStripMenuItem3});
            this.automaticallyCheckForUpdatesWhenStartingTheConverterToolStripMenuItem.Name = "automaticallyCheckForUpdatesWhenStartingTheConverterToolStripMenuItem";
            this.automaticallyCheckForUpdatesWhenStartingTheConverterToolStripMenuItem.Size = new System.Drawing.Size(365, 22);
            this.automaticallyCheckForUpdatesWhenStartingTheConverterToolStripMenuItem.Text = "Automatically check for updates when starting the converter";
            // 
            // enabledToolStripMenuItem3
            // 
            this.enabledToolStripMenuItem3.Name = "enabledToolStripMenuItem3";
            this.enabledToolStripMenuItem3.Size = new System.Drawing.Size(114, 22);
            this.enabledToolStripMenuItem3.Text = "Enabled";
            this.enabledToolStripMenuItem3.Click += new System.EventHandler(this.enabledToolStripMenuItem3_Click);
            // 
            // disabledToolStripMenuItem3
            // 
            this.disabledToolStripMenuItem3.Name = "disabledToolStripMenuItem3";
            this.disabledToolStripMenuItem3.Size = new System.Drawing.Size(114, 22);
            this.disabledToolStripMenuItem3.Text = "Disabled";
            this.disabledToolStripMenuItem3.Click += new System.EventHandler(this.disabledToolStripMenuItem3_Click);
            // 
            // autoShutdownAfterRenderingToolStripMenuItem
            // 
            this.autoShutdownAfterRenderingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem,
            this.disabledToolStripMenuItem});
            this.autoShutdownAfterRenderingToolStripMenuItem.Name = "autoShutdownAfterRenderingToolStripMenuItem";
            this.autoShutdownAfterRenderingToolStripMenuItem.Size = new System.Drawing.Size(365, 22);
            this.autoShutdownAfterRenderingToolStripMenuItem.Text = "Automatic shutdown after rendering";
            // 
            // enabledToolStripMenuItem
            // 
            this.enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            this.enabledToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.enabledToolStripMenuItem.Text = "Enabled";
            this.enabledToolStripMenuItem.Click += new System.EventHandler(this.enabledToolStripMenuItem_Click);
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            this.disabledToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.disabledToolStripMenuItem.Text = "Disabled";
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.disabledToolStripMenuItem_Click);
            // 
            // clearMIDIListAfterRenderingToolStripMenuItem
            // 
            this.clearMIDIListAfterRenderingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem1,
            this.disabledToolStripMenuItem1});
            this.clearMIDIListAfterRenderingToolStripMenuItem.Name = "clearMIDIListAfterRenderingToolStripMenuItem";
            this.clearMIDIListAfterRenderingToolStripMenuItem.Size = new System.Drawing.Size(365, 22);
            this.clearMIDIListAfterRenderingToolStripMenuItem.Text = "Clear MIDIs list after rendering";
            // 
            // enabledToolStripMenuItem1
            // 
            this.enabledToolStripMenuItem1.Name = "enabledToolStripMenuItem1";
            this.enabledToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.enabledToolStripMenuItem1.Text = "Enabled";
            this.enabledToolStripMenuItem1.Click += new System.EventHandler(this.enabledToolStripMenuItem1_Click);
            // 
            // disabledToolStripMenuItem1
            // 
            this.disabledToolStripMenuItem1.Name = "disabledToolStripMenuItem1";
            this.disabledToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.disabledToolStripMenuItem1.Text = "Disabled";
            this.disabledToolStripMenuItem1.Click += new System.EventHandler(this.disabledToolStripMenuItem1_Click);
            // 
            // showConversionPositionInsteadOfTimeLeftToolStripMenuItem
            // 
            this.showConversionPositionInsteadOfTimeLeftToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem2,
            this.disabledToolStripMenuItem2});
            this.showConversionPositionInsteadOfTimeLeftToolStripMenuItem.Name = "showConversionPositionInsteadOfTimeLeftToolStripMenuItem";
            this.showConversionPositionInsteadOfTimeLeftToolStripMenuItem.Size = new System.Drawing.Size(365, 22);
            this.showConversionPositionInsteadOfTimeLeftToolStripMenuItem.Text = "Show conversion position instead of time left";
            // 
            // enabledToolStripMenuItem2
            // 
            this.enabledToolStripMenuItem2.Name = "enabledToolStripMenuItem2";
            this.enabledToolStripMenuItem2.Size = new System.Drawing.Size(114, 22);
            this.enabledToolStripMenuItem2.Text = "Enabled";
            this.enabledToolStripMenuItem2.Click += new System.EventHandler(this.enabledToolStripMenuItem2_Click);
            // 
            // disabledToolStripMenuItem2
            // 
            this.disabledToolStripMenuItem2.Name = "disabledToolStripMenuItem2";
            this.disabledToolStripMenuItem2.Size = new System.Drawing.Size(114, 22);
            this.disabledToolStripMenuItem2.Text = "Disabled";
            this.disabledToolStripMenuItem2.Click += new System.EventHandler(this.disabledToolStripMenuItem2_Click);
            // 
            // conversionStartedfinishedfailedSoundsToolStripMenuItem
            // 
            this.conversionStartedfinishedfailedSoundsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem4,
            this.disabledToolStripMenuItem4});
            this.conversionStartedfinishedfailedSoundsToolStripMenuItem.Name = "conversionStartedfinishedfailedSoundsToolStripMenuItem";
            this.conversionStartedfinishedfailedSoundsToolStripMenuItem.Size = new System.Drawing.Size(365, 22);
            this.conversionStartedfinishedfailedSoundsToolStripMenuItem.Text = "Conversion started/finished/failed sounds";
            // 
            // enabledToolStripMenuItem4
            // 
            this.enabledToolStripMenuItem4.Name = "enabledToolStripMenuItem4";
            this.enabledToolStripMenuItem4.Size = new System.Drawing.Size(114, 22);
            this.enabledToolStripMenuItem4.Text = "Enabled";
            this.enabledToolStripMenuItem4.Click += new System.EventHandler(this.enabledToolStripMenuItem4_Click);
            // 
            // disabledToolStripMenuItem4
            // 
            this.disabledToolStripMenuItem4.Name = "disabledToolStripMenuItem4";
            this.disabledToolStripMenuItem4.Size = new System.Drawing.Size(114, 22);
            this.disabledToolStripMenuItem4.Text = "Disabled";
            this.disabledToolStripMenuItem4.Click += new System.EventHandler(this.disabledToolStripMenuItem4_Click);
            // 
            // forceCloseTheApplicationToolStripMenuItem
            // 
            this.forceCloseTheApplicationToolStripMenuItem.Name = "forceCloseTheApplicationToolStripMenuItem";
            this.forceCloseTheApplicationToolStripMenuItem.Size = new System.Drawing.Size(365, 22);
            this.forceCloseTheApplicationToolStripMenuItem.Text = "Crash the application";
            this.forceCloseTheApplicationToolStripMenuItem.Click += new System.EventHandler(this.forceCloseTheApplicationToolStripMenuItem_Click);
            // 
            // loadingpic
            // 
            this.loadingpic.Image = global::KeppyMIDIConverter.Properties.Resources.convbusy;
            this.loadingpic.Location = new System.Drawing.Point(425, 0);
            this.loadingpic.Name = "loadingpic";
            this.loadingpic.Size = new System.Drawing.Size(63, 60);
            this.loadingpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadingpic.TabIndex = 9;
            this.loadingpic.TabStop = false;
            this.loadingpic.Visible = false;
            // 
            // ExportWhere
            // 
            this.ExportWhere.AddExtension = false;
            this.ExportWhere.Filter = "Select a folder|*.*";
            this.ExportWhere.OverwritePrompt = false;
            this.ExportWhere.RestoreDirectory = true;
            this.ExportWhere.Title = "Where do you want to export?";
            this.ExportWhere.ValidateNames = false;
            // 
            // labelRMS
            // 
            this.labelRMS.Location = new System.Drawing.Point(12, 307);
            this.labelRMS.Name = "labelRMS";
            this.labelRMS.Size = new System.Drawing.Size(341, 13);
            this.labelRMS.TabIndex = 17;
            this.labelRMS.Text = "Root mean square: -Infinito dB | Average: -Infinito dB | Peak: -0.0 dB";
            // 
            // CurrentStatusText
            // 
            this.CurrentStatusText.BackColor = System.Drawing.Color.Transparent;
            this.CurrentStatusText.Dock = System.Windows.Forms.DockStyle.Left;
            this.CurrentStatusText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentStatusText.Location = new System.Drawing.Point(0, 0);
            this.CurrentStatusText.Name = "CurrentStatusText";
            this.CurrentStatusText.Size = new System.Drawing.Size(488, 60);
            this.CurrentStatusText.TabIndex = 7;
            this.CurrentStatusText.Text = "Loading... Please wait...";
            this.CurrentStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CurrentStatusText.UseCompatibleTextRendering = true;
            // 
            // RealTimePlayBack
            // 
            this.RealTimePlayBack.WorkerReportsProgress = true;
            this.RealTimePlayBack.WorkerSupportsCancellation = true;
            this.RealTimePlayBack.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RealTimePlayBackBeta_DoWork);
            // 
            // VolumeBar
            // 
            this.VolumeBar.AutoSize = false;
            this.VolumeBar.LargeChange = 1;
            this.VolumeBar.Location = new System.Drawing.Point(510, 308);
            this.VolumeBar.Maximum = 10000;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(130, 20);
            this.VolumeBar.TabIndex = 18;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(510, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Volume:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VolumeTip
            // 
            this.VolumeTip.AutomaticDelay = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.CurrentStatusText);
            this.panel1.Controls.Add(this.loadingpic);
            this.panel1.Location = new System.Drawing.Point(12, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 64);
            this.panel1.TabIndex = 13;
            // 
            // ConverterProcess
            // 
            this.ConverterProcess.WorkerReportsProgress = true;
            this.ConverterProcess.WorkerSupportsCancellation = true;
            this.ConverterProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConverterProcess_DoWork);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(652, 434);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VolumeBar);
            this.Controls.Add(this.UsedVoices);
            this.Controls.Add(this.labelRMS);
            this.Controls.Add(this.MIDIList);
            this.Controls.Add(this.SettingsBox);
            this.Controls.Add(this.CurrentStatus);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keppy\'s MIDI Converter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DefMenu.ResumeLayout(false);
            this.SettingsBox.ResumeLayout(false);
            this.SettingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceLimit)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem startRenderingWAVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortRenderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem informationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.OpenFileDialog MIDIImport;
        private System.Windows.Forms.Timer RenderingTimer;
        private System.Windows.Forms.Label UsedVoices;
        private System.Windows.Forms.Label CurrentStatusText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ListBox MIDIList;
        private System.Windows.Forms.ContextMenuStrip DefMenu;
        private System.Windows.Forms.ToolStripMenuItem addMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMIDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.GroupBox SettingsBox;
        private System.Windows.Forms.Button AdvSettingsButton;
        private System.Windows.Forms.NumericUpDown VoiceLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar CurrentStatus;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMIDIsListToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog ExportWhere;
        private System.Windows.Forms.Label labelRMS;
        private System.Windows.Forms.ToolStripMenuItem blackMIDIStuffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem officialBlackMIDIWikiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaleidonKep99sYouTubeChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem wikipediasPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keppyStudiosWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startRenderingOGGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playInRealtimeBetaToolStripMenuItem;
        public System.ComponentModel.BackgroundWorker RealTimePlayBack;
        private System.Windows.Forms.TrackBar VolumeBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoShutdownAfterRenderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.ToolTip VolumeTip;
        private System.Windows.Forms.ToolStripMenuItem importMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem openTheSoundfontsManagerToolStripMenuItem;
        private System.Windows.Forms.PictureBox loadingpic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem makeADonationToSupportTheDeveloperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem officialBlackMIDICommunityGoogleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem forceCloseTheApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMIDIsListToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearMIDIListAfterRenderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showConversionPositionInsteadOfTimeLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem automaticallyCheckForUpdatesWhenStartingTheConverterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem conversionStartedfinishedfailedSoundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem4;
        public System.ComponentModel.BackgroundWorker ConverterProcess;
    }
}

