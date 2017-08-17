namespace KeppyMIDIConverter
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
            this.MIDIImport = new System.Windows.Forms.OpenFileDialog();
            this.RenderingTimer = new System.Windows.Forms.Timer(this.components);
            this.UsedVoices = new System.Windows.Forms.Label();
            this.SettingsBox = new System.Windows.Forms.GroupBox();
            this.AdvSettingsButton = new System.Windows.Forms.Button();
            this.VoiceLimit = new System.Windows.Forms.NumericUpDown();
            this.VoiceLabel = new System.Windows.Forms.Label();
            this.ExportWhere = new System.Windows.Forms.SaveFileDialog();
            this.labelRMS = new System.Windows.Forms.Label();
            this.CurrentStatusText = new System.Windows.Forms.Label();
            this.RealTimePlayBack = new System.ComponentModel.BackgroundWorker();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.VolumeTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusPicture = new System.Windows.Forms.PictureBox();
            this.ConverterProcess = new System.ComponentModel.BackgroundWorker();
            this.DefaultMenu = new System.Windows.Forms.MainMenu(this.components);
            this.ActionsStrip = new System.Windows.Forms.MenuItem();
            this.importMIDIsToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.removeSelectedMIDIsToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.clearMIDIsListToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.openTheSoundfontsManagerToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.startRenderingWAVToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.startRenderingOGGToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.startRenderingMp3ToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.playInRealtimeBetaToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.abortRenderingToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.OptionsStrip = new System.Windows.Forms.MenuItem();
            this.AutoUpdatesCheckStrip = new System.Windows.Forms.MenuItem();
            this.enabledToolStripMenuItem3 = new System.Windows.Forms.MenuItem();
            this.disabledToolStripMenuItem3 = new System.Windows.Forms.MenuItem();
            this.AutomaticShutdownStrip = new System.Windows.Forms.MenuItem();
            this.enabledToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.ClearListAutomaticallyStrip = new System.Windows.Forms.MenuItem();
            this.enabledToolStripMenuItem1 = new System.Windows.Forms.MenuItem();
            this.disabledToolStripMenuItem1 = new System.Windows.Forms.MenuItem();
            this.ConvPosOrTimeLeft = new System.Windows.Forms.MenuItem();
            this.enabledToolStripMenuItem2 = new System.Windows.Forms.MenuItem();
            this.disabledToolStripMenuItem2 = new System.Windows.Forms.MenuItem();
            this.AudioEventsStrip = new System.Windows.Forms.MenuItem();
            this.enabledToolStripMenuItem4 = new System.Windows.Forms.MenuItem();
            this.disabledToolStripMenuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.OverrideStrip = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.forceCloseTheApplicationToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.HelpStrip = new System.Windows.Forms.MenuItem();
            this.informationAboutTheProgramToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.supportTheDeveloperWithADonationToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.KaleidonKep99sGitHubPageToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.KaleidonKep99sYouTubeChannelToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.DiscordHypeSquadRef = new System.Windows.Forms.MenuItem();
            this.DefMenu = new System.Windows.Forms.ContextMenu();
            this.ImportMIDIsRightClick = new System.Windows.Forms.MenuItem();
            this.RemoveMIDIsRightClick = new System.Windows.Forms.MenuItem();
            this.ClearMIDIsListRightClick = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.SortByName = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.MoveUpItem = new System.Windows.Forms.MenuItem();
            this.MoveDownItem = new System.Windows.Forms.MenuItem();
            this.VistaMenuSys = new wyDay.Controls.VistaMenu(this.components);
            this.ConverterProcessRT = new System.ComponentModel.BackgroundWorker();
            this.MIDIList = new System.Windows.Forms.ListView();
            this.GarbageCollector = new System.ComponentModel.BackgroundWorker();
            this.GetInfoWorker = new System.ComponentModel.BackgroundWorker();
            this.ThemeCheck = new System.ComponentModel.BackgroundWorker();
            this.RealTimePreviewTrackBar = new System.Windows.Forms.TrackBar();
            this.SettingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMenuSys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RealTimePreviewTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // MIDIImport
            // 
            this.MIDIImport.Filter = "MIDI files|*.mid;*.midi;*.kar;*.rmi;*.riff";
            this.MIDIImport.Multiselect = true;
            this.MIDIImport.RestoreDirectory = true;
            this.MIDIImport.Title = "Import MIDIs to the conversion list..";
            // 
            // RenderingTimer
            // 
            this.RenderingTimer.Interval = 10;
            this.RenderingTimer.Tick += new System.EventHandler(this.RenderingTimer_Tick);
            // 
            // UsedVoices
            // 
            this.UsedVoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UsedVoices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UsedVoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.UsedVoices.Location = new System.Drawing.Point(5, 311);
            this.UsedVoices.Name = "UsedVoices";
            this.UsedVoices.Size = new System.Drawing.Size(453, 13);
            this.UsedVoices.TabIndex = 8;
            this.UsedVoices.Text = "Active voices sign";
            this.UsedVoices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UsedVoices.Click += new System.EventHandler(this.UsedVoices_Click);
            // 
            // SettingsBox
            // 
            this.SettingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsBox.BackColor = System.Drawing.Color.Transparent;
            this.SettingsBox.Controls.Add(this.AdvSettingsButton);
            this.SettingsBox.Controls.Add(this.VoiceLimit);
            this.SettingsBox.Controls.Add(this.VoiceLabel);
            this.SettingsBox.Location = new System.Drawing.Point(475, 333);
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.Size = new System.Drawing.Size(181, 62);
            this.SettingsBox.TabIndex = 12;
            this.SettingsBox.TabStop = false;
            this.SettingsBox.Text = "Settings";
            // 
            // AdvSettingsButton
            // 
            this.AdvSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdvSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AdvSettingsButton.Location = new System.Drawing.Point(7, 35);
            this.AdvSettingsButton.Name = "AdvSettingsButton";
            this.AdvSettingsButton.Size = new System.Drawing.Size(168, 19);
            this.AdvSettingsButton.TabIndex = 3;
            this.AdvSettingsButton.Text = "Advanced settings";
            this.AdvSettingsButton.UseVisualStyleBackColor = true;
            this.AdvSettingsButton.Click += new System.EventHandler(this.AdvSettingsButton_Click);
            // 
            // VoiceLimit
            // 
            this.VoiceLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VoiceLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VoiceLimit.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoiceLimit.Location = new System.Drawing.Point(125, 14);
            this.VoiceLimit.Margin = new System.Windows.Forms.Padding(0);
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
            this.VoiceLimit.Size = new System.Drawing.Size(50, 18);
            this.VoiceLimit.TabIndex = 2;
            this.VoiceLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VoiceLimit.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.VoiceLimit.ValueChanged += new System.EventHandler(this.VoiceLimit_ValueChanged);
            // 
            // VoiceLabel
            // 
            this.VoiceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VoiceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.VoiceLabel.Location = new System.Drawing.Point(1, 16);
            this.VoiceLabel.Name = "VoiceLabel";
            this.VoiceLabel.Size = new System.Drawing.Size(128, 13);
            this.VoiceLabel.TabIndex = 0;
            this.VoiceLabel.Text = "Voice limit:";
            this.VoiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.labelRMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelRMS.Location = new System.Drawing.Point(5, 293);
            this.labelRMS.Name = "labelRMS";
            this.labelRMS.Size = new System.Drawing.Size(453, 13);
            this.labelRMS.TabIndex = 17;
            this.labelRMS.Text = "RMS sign";
            // 
            // CurrentStatusText
            // 
            this.CurrentStatusText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentStatusText.BackColor = System.Drawing.Color.Transparent;
            this.CurrentStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CurrentStatusText.Location = new System.Drawing.Point(0, 0);
            this.CurrentStatusText.Name = "CurrentStatusText";
            this.CurrentStatusText.Size = new System.Drawing.Size(345, 60);
            this.CurrentStatusText.TabIndex = 7;
            this.CurrentStatusText.Text = "Loading... Please wait...";
            this.CurrentStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RealTimePlayBack
            // 
            this.RealTimePlayBack.WorkerReportsProgress = true;
            this.RealTimePlayBack.WorkerSupportsCancellation = true;
            this.RealTimePlayBack.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RealTimePlayBack_DoWork);
            // 
            // VolumeBar
            // 
            this.VolumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeBar.AutoSize = false;
            this.VolumeBar.LargeChange = 1;
            this.VolumeBar.Location = new System.Drawing.Point(475, 310);
            this.VolumeBar.Maximum = 10000;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(180, 15);
            this.VolumeBar.TabIndex = 1;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeLabel.Location = new System.Drawing.Point(475, 292);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(180, 13);
            this.VolumeLabel.TabIndex = 19;
            this.VolumeLabel.Text = "Volume:";
            this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VolumeTip
            // 
            this.VolumeTip.AutomaticDelay = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.StatusPicture);
            this.panel1.Controls.Add(this.CurrentStatusText);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(5, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 62);
            this.panel1.TabIndex = 13;
            // 
            // StatusPicture
            // 
            this.StatusPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.StatusPicture.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusPicture.Image = global::KeppyMIDIConverter.Properties.Resources.convpause;
            this.StatusPicture.InitialImage = null;
            this.StatusPicture.Location = new System.Drawing.Point(403, 0);
            this.StatusPicture.Name = "StatusPicture";
            this.StatusPicture.Size = new System.Drawing.Size(60, 60);
            this.StatusPicture.TabIndex = 8;
            this.StatusPicture.TabStop = false;
            // 
            // ConverterProcess
            // 
            this.ConverterProcess.WorkerReportsProgress = true;
            this.ConverterProcess.WorkerSupportsCancellation = true;
            this.ConverterProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConverterProcess_DoWork);
            // 
            // DefaultMenu
            // 
            this.DefaultMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ActionsStrip,
            this.OptionsStrip,
            this.HelpStrip});
            // 
            // ActionsStrip
            // 
            this.ActionsStrip.Index = 0;
            this.ActionsStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.importMIDIsToolStripMenuItem,
            this.removeSelectedMIDIsToolStripMenuItem,
            this.clearMIDIsListToolStripMenuItem,
            this.menuItem5,
            this.openTheSoundfontsManagerToolStripMenuItem,
            this.menuItem7,
            this.startRenderingWAVToolStripMenuItem,
            this.startRenderingOGGToolStripMenuItem,
            this.startRenderingMp3ToolStripMenuItem,
            this.playInRealtimeBetaToolStripMenuItem,
            this.abortRenderingToolStripMenuItem,
            this.menuItem12,
            this.exitToolStripMenuItem});
            this.ActionsStrip.Text = "Actions";
            // 
            // importMIDIsToolStripMenuItem
            // 
            this.importMIDIsToolStripMenuItem.DefaultItem = true;
            this.VistaMenuSys.SetImage(this.importMIDIsToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.add_icon);
            this.importMIDIsToolStripMenuItem.Index = 0;
            this.importMIDIsToolStripMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
            this.importMIDIsToolStripMenuItem.Text = "Import MIDIs";
            this.importMIDIsToolStripMenuItem.Click += new System.EventHandler(this.importMIDIsToolStripMenuItem_Click);
            // 
            // removeSelectedMIDIsToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.removeSelectedMIDIsToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.remove_icon);
            this.removeSelectedMIDIsToolStripMenuItem.Index = 1;
            this.removeSelectedMIDIsToolStripMenuItem.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.removeSelectedMIDIsToolStripMenuItem.Text = "Remove selected MIDIs";
            this.removeSelectedMIDIsToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedMIDIsToolStripMenuItem_Click);
            // 
            // clearMIDIsListToolStripMenuItem
            // 
            this.clearMIDIsListToolStripMenuItem.Index = 2;
            this.clearMIDIsListToolStripMenuItem.Shortcut = System.Windows.Forms.Shortcut.ShiftDel;
            this.clearMIDIsListToolStripMenuItem.Text = "Clear MIDIs list";
            this.clearMIDIsListToolStripMenuItem.Click += new System.EventHandler(this.clearMIDIsListToolStripMenuItem_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "-";
            // 
            // openTheSoundfontsManagerToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.openTheSoundfontsManagerToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.configure_icon);
            this.openTheSoundfontsManagerToolStripMenuItem.Index = 4;
            this.openTheSoundfontsManagerToolStripMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.openTheSoundfontsManagerToolStripMenuItem.Text = "Open the soundfonts/VST DSP manager";
            this.openTheSoundfontsManagerToolStripMenuItem.Click += new System.EventHandler(this.openTheSoundfontsManagerToolStripMenuItem_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 5;
            this.menuItem7.Text = "-";
            // 
            // startRenderingWAVToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.startRenderingWAVToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.audio_icon);
            this.startRenderingWAVToolStripMenuItem.Index = 6;
            this.startRenderingWAVToolStripMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            this.startRenderingWAVToolStripMenuItem.Text = "Render files to Wave (.WAV)";
            this.startRenderingWAVToolStripMenuItem.Click += new System.EventHandler(this.startRenderingWAVToolStripMenuItem_Click);
            // 
            // startRenderingOGGToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.startRenderingOGGToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.audio_icon);
            this.startRenderingOGGToolStripMenuItem.Index = 7;
            this.startRenderingOGGToolStripMenuItem.Text = "Render files to Vorbis (.OGG)";
            this.startRenderingOGGToolStripMenuItem.Click += new System.EventHandler(this.startRenderingOGGToolStripMenuItem_Click);
            // 
            // startRenderingMp3ToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.startRenderingMp3ToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.audio_icon);
            this.startRenderingMp3ToolStripMenuItem.Index = 8;
            this.startRenderingMp3ToolStripMenuItem.Text = "Render files to LAME (.MP3)";
            this.startRenderingMp3ToolStripMenuItem.Click += new System.EventHandler(this.startRenderingMp3ToolStripMenuItem_Click);
            // 
            // playInRealtimeBetaToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.playInRealtimeBetaToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.speaker_icon);
            this.playInRealtimeBetaToolStripMenuItem.Index = 9;
            this.playInRealtimeBetaToolStripMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.playInRealtimeBetaToolStripMenuItem.Text = "Preview files (Real-time playback)";
            this.playInRealtimeBetaToolStripMenuItem.Click += new System.EventHandler(this.playInRealtimeBetaToolStripMenuItem_Click);
            // 
            // abortRenderingToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.abortRenderingToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.delete_icon);
            this.abortRenderingToolStripMenuItem.Index = 10;
            this.abortRenderingToolStripMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
            this.abortRenderingToolStripMenuItem.Text = "Abort rendering/preview";
            this.abortRenderingToolStripMenuItem.Click += new System.EventHandler(this.abortRenderingToolStripMenuItem_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 11;
            this.menuItem12.Text = "-";
            // 
            // exitToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.exitToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.back_icon);
            this.exitToolStripMenuItem.Index = 12;
            this.exitToolStripMenuItem.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // OptionsStrip
            // 
            this.OptionsStrip.Index = 1;
            this.OptionsStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.AutoUpdatesCheckStrip,
            this.AutomaticShutdownStrip,
            this.ClearListAutomaticallyStrip,
            this.ConvPosOrTimeLeft,
            this.AudioEventsStrip,
            this.menuItem13,
            this.OverrideStrip,
            this.menuItem2,
            this.forceCloseTheApplicationToolStripMenuItem});
            this.OptionsStrip.Text = "Options";
            // 
            // AutoUpdatesCheckStrip
            // 
            this.AutoUpdatesCheckStrip.Index = 0;
            this.AutoUpdatesCheckStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.enabledToolStripMenuItem3,
            this.disabledToolStripMenuItem3});
            this.AutoUpdatesCheckStrip.Text = "Automatically check for updates when starting the converter";
            // 
            // enabledToolStripMenuItem3
            // 
            this.enabledToolStripMenuItem3.Index = 0;
            this.enabledToolStripMenuItem3.Text = "Enabled";
            this.enabledToolStripMenuItem3.Click += new System.EventHandler(this.enabledToolStripMenuItem3_Click);
            // 
            // disabledToolStripMenuItem3
            // 
            this.disabledToolStripMenuItem3.Index = 1;
            this.disabledToolStripMenuItem3.Text = "Disabled";
            this.disabledToolStripMenuItem3.Click += new System.EventHandler(this.disabledToolStripMenuItem3_Click);
            // 
            // AutomaticShutdownStrip
            // 
            this.AutomaticShutdownStrip.Index = 1;
            this.AutomaticShutdownStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.enabledToolStripMenuItem,
            this.disabledToolStripMenuItem});
            this.AutomaticShutdownStrip.Text = "Automatic shutdown after rendering";
            // 
            // enabledToolStripMenuItem
            // 
            this.enabledToolStripMenuItem.Index = 0;
            this.enabledToolStripMenuItem.Text = "Enabled";
            this.enabledToolStripMenuItem.Click += new System.EventHandler(this.enabledToolStripMenuItem_Click);
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.Index = 1;
            this.disabledToolStripMenuItem.Text = "Disabled";
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.disabledToolStripMenuItem_Click);
            // 
            // ClearListAutomaticallyStrip
            // 
            this.ClearListAutomaticallyStrip.Index = 2;
            this.ClearListAutomaticallyStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.enabledToolStripMenuItem1,
            this.disabledToolStripMenuItem1});
            this.ClearListAutomaticallyStrip.Text = "Clear MIDIs list after rendering";
            // 
            // enabledToolStripMenuItem1
            // 
            this.enabledToolStripMenuItem1.Index = 0;
            this.enabledToolStripMenuItem1.Text = "Enabled";
            this.enabledToolStripMenuItem1.Click += new System.EventHandler(this.enabledToolStripMenuItem1_Click);
            // 
            // disabledToolStripMenuItem1
            // 
            this.disabledToolStripMenuItem1.Index = 1;
            this.disabledToolStripMenuItem1.Text = "Disabled";
            this.disabledToolStripMenuItem1.Click += new System.EventHandler(this.disabledToolStripMenuItem1_Click);
            // 
            // ConvPosOrTimeLeft
            // 
            this.ConvPosOrTimeLeft.Index = 3;
            this.ConvPosOrTimeLeft.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.enabledToolStripMenuItem2,
            this.disabledToolStripMenuItem2});
            this.ConvPosOrTimeLeft.Text = "Show conversion position instead of time left";
            // 
            // enabledToolStripMenuItem2
            // 
            this.enabledToolStripMenuItem2.Index = 0;
            this.enabledToolStripMenuItem2.Text = "Enabled";
            this.enabledToolStripMenuItem2.Click += new System.EventHandler(this.enabledToolStripMenuItem2_Click);
            // 
            // disabledToolStripMenuItem2
            // 
            this.disabledToolStripMenuItem2.Index = 1;
            this.disabledToolStripMenuItem2.Text = "Disabled";
            this.disabledToolStripMenuItem2.Click += new System.EventHandler(this.disabledToolStripMenuItem2_Click);
            // 
            // AudioEventsStrip
            // 
            this.AudioEventsStrip.Index = 4;
            this.AudioEventsStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.enabledToolStripMenuItem4,
            this.disabledToolStripMenuItem4});
            this.AudioEventsStrip.Text = "Conversion started/finished/failed sounds";
            // 
            // enabledToolStripMenuItem4
            // 
            this.enabledToolStripMenuItem4.Index = 0;
            this.enabledToolStripMenuItem4.Text = "Enabled";
            this.enabledToolStripMenuItem4.Click += new System.EventHandler(this.enabledToolStripMenuItem4_Click);
            // 
            // disabledToolStripMenuItem4
            // 
            this.disabledToolStripMenuItem4.Index = 1;
            this.disabledToolStripMenuItem4.Text = "Disabled";
            this.disabledToolStripMenuItem4.Click += new System.EventHandler(this.disabledToolStripMenuItem4_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 5;
            this.menuItem13.Text = "-";
            // 
            // OverrideStrip
            // 
            this.VistaMenuSys.SetImage(this.OverrideStrip, global::KeppyMIDIConverter.Properties.Resources.configure_icon);
            this.OverrideStrip.Index = 6;
            this.OverrideStrip.Text = "Override language";
            this.OverrideStrip.Click += new System.EventHandler(this.OverrideStrip_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 7;
            this.menuItem2.Text = "-";
            // 
            // forceCloseTheApplicationToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.forceCloseTheApplicationToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.delete_icon);
            this.forceCloseTheApplicationToolStripMenuItem.Index = 8;
            this.forceCloseTheApplicationToolStripMenuItem.Text = "Crash the application";
            this.forceCloseTheApplicationToolStripMenuItem.Click += new System.EventHandler(this.forceCloseTheApplicationToolStripMenuItem_Click);
            // 
            // HelpStrip
            // 
            this.HelpStrip.Index = 2;
            this.HelpStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.informationAboutTheProgramToolStripMenuItem,
            this.supportTheDeveloperWithADonationToolStripMenuItem,
            this.menuItem3,
            this.KaleidonKep99sGitHubPageToolStripMenuItem,
            this.KaleidonKep99sYouTubeChannelToolStripMenuItem,
            this.menuItem8,
            this.DiscordHypeSquadRef});
            this.HelpStrip.Text = "Help";
            // 
            // informationAboutTheProgramToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.informationAboutTheProgramToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.information_icon);
            this.informationAboutTheProgramToolStripMenuItem.Index = 0;
            this.informationAboutTheProgramToolStripMenuItem.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.informationAboutTheProgramToolStripMenuItem.Text = "Information about the program";
            this.informationAboutTheProgramToolStripMenuItem.Click += new System.EventHandler(this.informationsToolStripMenuItem_Click);
            // 
            // supportTheDeveloperWithADonationToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.supportTheDeveloperWithADonationToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.edit_icon);
            this.supportTheDeveloperWithADonationToolStripMenuItem.Index = 1;
            this.supportTheDeveloperWithADonationToolStripMenuItem.Text = "Support the developer with a donation";
            this.supportTheDeveloperWithADonationToolStripMenuItem.Click += new System.EventHandler(this.makeADonationToSupportTheDeveloperToolStripMenuItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "-";
            // 
            // KaleidonKep99sGitHubPageToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.KaleidonKep99sGitHubPageToolStripMenuItem, ((System.Drawing.Image)(resources.GetObject("KaleidonKep99sGitHubPageToolStripMenuItem.Image"))));
            this.KaleidonKep99sGitHubPageToolStripMenuItem.Index = 3;
            this.KaleidonKep99sGitHubPageToolStripMenuItem.Text = "KaleidonKep99\'s GitHub Page";
            this.KaleidonKep99sGitHubPageToolStripMenuItem.Click += new System.EventHandler(this.KaleidonKep99sGitHubPageToolStripMenuItem_Click);
            // 
            // KaleidonKep99sYouTubeChannelToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.KaleidonKep99sYouTubeChannelToolStripMenuItem, ((System.Drawing.Image)(resources.GetObject("KaleidonKep99sYouTubeChannelToolStripMenuItem.Image"))));
            this.KaleidonKep99sYouTubeChannelToolStripMenuItem.Index = 4;
            this.KaleidonKep99sYouTubeChannelToolStripMenuItem.Text = "KaleidonKep99\'s YouTube Channel";
            this.KaleidonKep99sYouTubeChannelToolStripMenuItem.Click += new System.EventHandler(this.kaleidonKep99sYouTubeChannelToolStripMenuItem_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 5;
            this.menuItem8.Text = "-";
            // 
            // DiscordHypeSquadRef
            // 
            this.VistaMenuSys.SetImage(this.DiscordHypeSquadRef, global::KeppyMIDIConverter.Properties.Resources.hypebadge);
            this.DiscordHypeSquadRef.Index = 6;
            this.DiscordHypeSquadRef.Text = "Join the Discord HypeSquad!";
            this.DiscordHypeSquadRef.Click += new System.EventHandler(this.DiscordHypeSquadRef_Click);
            // 
            // DefMenu
            // 
            this.DefMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ImportMIDIsRightClick,
            this.RemoveMIDIsRightClick,
            this.ClearMIDIsListRightClick,
            this.menuItem1,
            this.SortByName,
            this.menuItem6,
            this.MoveUpItem,
            this.MoveDownItem});
            this.DefMenu.Popup += new System.EventHandler(this.DefMenu_Popup);
            // 
            // ImportMIDIsRightClick
            // 
            this.VistaMenuSys.SetImage(this.ImportMIDIsRightClick, global::KeppyMIDIConverter.Properties.Resources.add_icon);
            this.ImportMIDIsRightClick.Index = 0;
            this.ImportMIDIsRightClick.Text = "Import MIDIs";
            this.ImportMIDIsRightClick.Click += new System.EventHandler(this.importMIDIsToolStripMenuItem_Click);
            // 
            // RemoveMIDIsRightClick
            // 
            this.VistaMenuSys.SetImage(this.RemoveMIDIsRightClick, global::KeppyMIDIConverter.Properties.Resources.remove_icon);
            this.RemoveMIDIsRightClick.Index = 1;
            this.RemoveMIDIsRightClick.Text = "Remove selected MIDIs";
            this.RemoveMIDIsRightClick.Click += new System.EventHandler(this.removeSelectedMIDIsToolStripMenuItem_Click);
            // 
            // ClearMIDIsListRightClick
            // 
            this.ClearMIDIsListRightClick.Index = 2;
            this.ClearMIDIsListRightClick.Text = "Clear MIDIs list";
            this.ClearMIDIsListRightClick.Click += new System.EventHandler(this.clearMIDIsListToolStripMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // SortByName
            // 
            this.SortByName.Index = 4;
            this.SortByName.Text = "Sort by name";
            this.SortByName.Click += new System.EventHandler(this.SortByName_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "-";
            // 
            // MoveUpItem
            // 
            this.MoveUpItem.Enabled = false;
            this.VistaMenuSys.SetImage(this.MoveUpItem, global::KeppyMIDIConverter.Properties.Resources.up_icon);
            this.MoveUpItem.Index = 6;
            this.MoveUpItem.Text = "Move up (One item)";
            this.MoveUpItem.Click += new System.EventHandler(this.MoveUpItem_Click);
            // 
            // MoveDownItem
            // 
            this.MoveDownItem.Enabled = false;
            this.VistaMenuSys.SetImage(this.MoveDownItem, global::KeppyMIDIConverter.Properties.Resources.down_icon);
            this.MoveDownItem.Index = 7;
            this.MoveDownItem.Text = "Move down (One item)";
            this.MoveDownItem.Click += new System.EventHandler(this.MoveDownItem_Click);
            // 
            // VistaMenuSys
            // 
            this.VistaMenuSys.ContainerControl = this;
            // 
            // ConverterProcessRT
            // 
            this.ConverterProcessRT.WorkerReportsProgress = true;
            this.ConverterProcessRT.WorkerSupportsCancellation = true;
            this.ConverterProcessRT.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConverterProcessRT_DoWork);
            // 
            // MIDIList
            // 
            this.MIDIList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.MIDIList.AllowDrop = true;
            this.MIDIList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MIDIList.BackColor = System.Drawing.Color.White;
            this.MIDIList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MIDIList.FullRowSelect = true;
            this.MIDIList.GridLines = true;
            this.MIDIList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MIDIList.Location = new System.Drawing.Point(0, 0);
            this.MIDIList.Name = "MIDIList";
            this.MIDIList.ShowGroups = false;
            this.MIDIList.Size = new System.Drawing.Size(660, 285);
            this.MIDIList.TabIndex = 0;
            this.MIDIList.UseCompatibleStateImageBehavior = false;
            this.MIDIList.View = System.Windows.Forms.View.Details;
            this.MIDIList.SizeChanged += new System.EventHandler(this.MIDIList_SizeChanged);
            this.MIDIList.DragDrop += new System.Windows.Forms.DragEventHandler(this.MIDIList_DragDrop);
            this.MIDIList.DragEnter += new System.Windows.Forms.DragEventHandler(this.MIDIList_DragEnter);
            this.MIDIList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MIDIList_KeyPress);
            // 
            // GarbageCollector
            // 
            this.GarbageCollector.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GarbageCollector_DoWork);
            // 
            // GetInfoWorker
            // 
            this.GetInfoWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GetInfoWorker_DoWork);
            // 
            // ThemeCheck
            // 
            this.ThemeCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ThemeCheck_DoWork);
            // 
            // RealTimePreviewTrackBar
            // 
            this.RealTimePreviewTrackBar.AutoSize = false;
            this.RealTimePreviewTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RealTimePreviewTrackBar.Enabled = false;
            this.RealTimePreviewTrackBar.Location = new System.Drawing.Point(0, 403);
            this.RealTimePreviewTrackBar.Name = "RealTimePreviewTrackBar";
            this.RealTimePreviewTrackBar.Size = new System.Drawing.Size(660, 30);
            this.RealTimePreviewTrackBar.TabIndex = 20;
            this.RealTimePreviewTrackBar.TickFrequency = 0;
            this.RealTimePreviewTrackBar.Scroll += new System.EventHandler(this.RealTimePreviewTrackBar_Scroll);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(660, 433);
            this.Controls.Add(this.RealTimePreviewTrackBar);
            this.Controls.Add(this.MIDIList);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.VolumeBar);
            this.Controls.Add(this.UsedVoices);
            this.Controls.Add(this.labelRMS);
            this.Controls.Add(this.SettingsBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(668, 460);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keppy\'s MIDI Converter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.SettingsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VoiceLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatusPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMenuSys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RealTimePreviewTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog MIDIImport;
        private System.Windows.Forms.SaveFileDialog ExportWhere;
        public System.ComponentModel.BackgroundWorker RealTimePlayBack;
        private System.Windows.Forms.ToolTip VolumeTip;
        private System.Windows.Forms.Panel panel1;
        public System.ComponentModel.BackgroundWorker ConverterProcess;
        private System.Windows.Forms.MainMenu DefaultMenu;
        private System.Windows.Forms.MenuItem ActionsStrip;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuItem OptionsStrip;
        private System.Windows.Forms.MenuItem AutoUpdatesCheckStrip;
        private System.Windows.Forms.MenuItem AutomaticShutdownStrip;
        private System.Windows.Forms.MenuItem ClearListAutomaticallyStrip;
        private System.Windows.Forms.MenuItem ConvPosOrTimeLeft;
        private System.Windows.Forms.MenuItem AudioEventsStrip;
        private System.Windows.Forms.MenuItem forceCloseTheApplicationToolStripMenuItem;
        private System.Windows.Forms.MenuItem enabledToolStripMenuItem;
        private System.Windows.Forms.MenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.MenuItem enabledToolStripMenuItem1;
        private System.Windows.Forms.MenuItem disabledToolStripMenuItem1;
        private System.Windows.Forms.MenuItem enabledToolStripMenuItem2;
        private System.Windows.Forms.MenuItem disabledToolStripMenuItem2;
        private System.Windows.Forms.MenuItem enabledToolStripMenuItem4;
        private System.Windows.Forms.MenuItem disabledToolStripMenuItem4;
        private System.Windows.Forms.MenuItem enabledToolStripMenuItem3;
        private System.Windows.Forms.MenuItem disabledToolStripMenuItem3;
        private System.Windows.Forms.MenuItem HelpStrip;
        private System.Windows.Forms.MenuItem informationAboutTheProgramToolStripMenuItem;
        private System.Windows.Forms.MenuItem supportTheDeveloperWithADonationToolStripMenuItem;
        private System.Windows.Forms.MenuItem KaleidonKep99sYouTubeChannelToolStripMenuItem;
        private System.Windows.Forms.ContextMenu DefMenu;
        private wyDay.Controls.VistaMenu VistaMenuSys;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem KaleidonKep99sGitHubPageToolStripMenuItem;
        private System.Windows.Forms.MenuItem OverrideStrip;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem6;
        public System.ComponentModel.BackgroundWorker ConverterProcessRT;
        public System.Windows.Forms.Timer RenderingTimer;
        public System.Windows.Forms.Label UsedVoices;
        public System.Windows.Forms.Label CurrentStatusText;
        public System.Windows.Forms.GroupBox SettingsBox;
        public System.Windows.Forms.Button AdvSettingsButton;
        public System.Windows.Forms.NumericUpDown VoiceLimit;
        public System.Windows.Forms.Label VoiceLabel;
        public System.Windows.Forms.Label labelRMS;
        public System.Windows.Forms.MenuItem importMIDIsToolStripMenuItem;
        public System.Windows.Forms.MenuItem removeSelectedMIDIsToolStripMenuItem;
        public System.Windows.Forms.MenuItem clearMIDIsListToolStripMenuItem;
        public System.Windows.Forms.MenuItem openTheSoundfontsManagerToolStripMenuItem;
        public System.Windows.Forms.MenuItem startRenderingWAVToolStripMenuItem;
        public System.Windows.Forms.MenuItem startRenderingOGGToolStripMenuItem;
        public System.Windows.Forms.MenuItem playInRealtimeBetaToolStripMenuItem;
        public System.Windows.Forms.MenuItem abortRenderingToolStripMenuItem;
        public System.Windows.Forms.MenuItem ImportMIDIsRightClick;
        public System.Windows.Forms.MenuItem RemoveMIDIsRightClick;
        public System.Windows.Forms.MenuItem ClearMIDIsListRightClick;
        public System.Windows.Forms.MenuItem MoveUpItem;
        public System.Windows.Forms.MenuItem MoveDownItem;
        public System.Windows.Forms.MenuItem SortByName;
        public System.Windows.Forms.ListView MIDIList;
        public System.Windows.Forms.MenuItem startRenderingMp3ToolStripMenuItem;
        public System.Windows.Forms.TrackBar VolumeBar;
        public System.Windows.Forms.Label VolumeLabel;
        public System.Windows.Forms.PictureBox StatusPicture;
        private System.ComponentModel.BackgroundWorker GarbageCollector;
        private System.ComponentModel.BackgroundWorker GetInfoWorker;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem DiscordHypeSquadRef;
        private System.ComponentModel.BackgroundWorker ThemeCheck;
        public System.Windows.Forms.TrackBar RealTimePreviewTrackBar;
    }
}

