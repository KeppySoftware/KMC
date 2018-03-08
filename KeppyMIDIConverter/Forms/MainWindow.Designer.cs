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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ConverterMenu = new System.Windows.Forms.MainMenu(this.components);
            this.ActionsStrip = new System.Windows.Forms.MenuItem();
            this.ImportMIDIs = new System.Windows.Forms.MenuItem();
            this.RemoveMIDIs = new System.Windows.Forms.MenuItem();
            this.ClearList = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.OpenSFVSTManager = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.RenderToWAV = new System.Windows.Forms.MenuItem();
            this.RenderToOGG = new System.Windows.Forms.MenuItem();
            this.RenderToLAME = new System.Windows.Forms.MenuItem();
            this.PreviewFiles = new System.Windows.Forms.MenuItem();
            this.AbortConversion = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.Exit = new System.Windows.Forms.MenuItem();
            this.OptionsStrip = new System.Windows.Forms.MenuItem();
            this.RenderMode = new System.Windows.Forms.MenuItem();
            this.RenderStandard = new System.Windows.Forms.MenuItem();
            this.RenderRTS = new System.Windows.Forms.MenuItem();
            this.menuItem42 = new System.Windows.Forms.MenuItem();
            this.NoAffectPreview = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.ACFUWSTC = new System.Windows.Forms.MenuItem();
            this.ASAR = new System.Windows.Forms.MenuItem();
            this.CMLAR = new System.Windows.Forms.MenuItem();
            this.SCPIOTL = new System.Windows.Forms.MenuItem();
            this.CSFFS = new System.Windows.Forms.MenuItem();
            this.SVDS = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.ChangeLanguage = new System.Windows.Forms.MenuItem();
            this.HelpStrip = new System.Windows.Forms.MenuItem();
            this.IATP = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.STDWD = new System.Windows.Forms.MenuItem();
            this.KK99GP = new System.Windows.Forms.MenuItem();
            this.KK99YTC = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.JKSUS = new System.Windows.Forms.MenuItem();
            this.PreviewTrackBar = new System.Windows.Forms.TrackBar();
            this.MIDIList = new System.Windows.Forms.ListView();
            this.MIDIFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MIDILength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MIDINotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MIDISize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.AVSLabel = new System.Windows.Forms.Label();
            this.RMSLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusPicture = new System.Windows.Forms.PictureBox();
            this.StatusMsg = new System.Windows.Forms.Label();
            this.OpenSettings = new System.Windows.Forms.Button();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.ListMenu = new System.Windows.Forms.ContextMenu();
            this.ImportMIDIsC = new System.Windows.Forms.MenuItem();
            this.RemoveMIDIsC = new System.Windows.Forms.MenuItem();
            this.ClearListC = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.AutoResizeColumns = new System.Windows.Forms.MenuItem();
            this.SortName = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.MoveUp = new System.Windows.Forms.MenuItem();
            this.MoveDown = new System.Windows.Forms.MenuItem();
            this.VistaMenuSys = new wyDay.Controls.VistaMenu(this.components);
            this.VSTiSeparator = new System.Windows.Forms.MenuItem();
            this.VSTiSettings = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMenuSys)).BeginInit();
            this.SuspendLayout();
            // 
            // ConverterMenu
            // 
            this.ConverterMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ActionsStrip,
            this.OptionsStrip,
            this.HelpStrip,
            this.VSTiSeparator,
            this.VSTiSettings});
            // 
            // ActionsStrip
            // 
            this.ActionsStrip.Index = 0;
            this.ActionsStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ImportMIDIs,
            this.RemoveMIDIs,
            this.ClearList,
            this.menuItem5,
            this.OpenSFVSTManager,
            this.menuItem7,
            this.RenderToWAV,
            this.RenderToOGG,
            this.RenderToLAME,
            this.PreviewFiles,
            this.AbortConversion,
            this.menuItem13,
            this.Exit});
            this.ActionsStrip.Text = "{Actions}";
            // 
            // ImportMIDIs
            // 
            this.ImportMIDIs.DefaultItem = true;
            this.VistaMenuSys.SetImage(this.ImportMIDIs, global::KeppyMIDIConverter.Properties.Resources.add_icon);
            this.ImportMIDIs.Index = 0;
            this.ImportMIDIs.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
            this.ImportMIDIs.Text = "{ImportMIDIs}";
            this.ImportMIDIs.Click += new System.EventHandler(this.ImportMIDIs_Click);
            // 
            // RemoveMIDIs
            // 
            this.VistaMenuSys.SetImage(this.RemoveMIDIs, global::KeppyMIDIConverter.Properties.Resources.remove_icon);
            this.RemoveMIDIs.Index = 1;
            this.RemoveMIDIs.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.RemoveMIDIs.Text = "{RemoveSelectedMIDIs}";
            this.RemoveMIDIs.Click += new System.EventHandler(this.RemoveMIDIs_Click);
            // 
            // ClearList
            // 
            this.VistaMenuSys.SetImage(this.ClearList, global::KeppyMIDIConverter.Properties.Resources.delete_icon);
            this.ClearList.Index = 2;
            this.ClearList.Shortcut = System.Windows.Forms.Shortcut.ShiftDel;
            this.ClearList.Text = "{ClearList}";
            this.ClearList.Click += new System.EventHandler(this.ClearList_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "-";
            // 
            // OpenSFVSTManager
            // 
            this.VistaMenuSys.SetImage(this.OpenSFVSTManager, global::KeppyMIDIConverter.Properties.Resources.gear_icon);
            this.OpenSFVSTManager.Index = 4;
            this.OpenSFVSTManager.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.OpenSFVSTManager.Text = "{OpenSFVSTManager}";
            this.OpenSFVSTManager.Click += new System.EventHandler(this.OpenSFVSTManager_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 5;
            this.menuItem7.Text = "-";
            // 
            // RenderToWAV
            // 
            this.VistaMenuSys.SetImage(this.RenderToWAV, ((System.Drawing.Image)(resources.GetObject("RenderToWAV.Image"))));
            this.RenderToWAV.Index = 6;
            this.RenderToWAV.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            this.RenderToWAV.Text = "{RenderToWAV}";
            this.RenderToWAV.Click += new System.EventHandler(this.RenderToWAV_Click);
            // 
            // RenderToOGG
            // 
            this.RenderToOGG.Index = 7;
            this.RenderToOGG.Text = "{RenderToOGG}";
            this.RenderToOGG.Click += new System.EventHandler(this.RenderToOGG_Click);
            // 
            // RenderToLAME
            // 
            this.RenderToLAME.Index = 8;
            this.RenderToLAME.Text = "{RenderToLAME}";
            this.RenderToLAME.Click += new System.EventHandler(this.RenderToLAME_Click);
            // 
            // PreviewFiles
            // 
            this.VistaMenuSys.SetImage(this.PreviewFiles, global::KeppyMIDIConverter.Properties.Resources.play_icon);
            this.PreviewFiles.Index = 9;
            this.PreviewFiles.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.PreviewFiles.Text = "{PreviewFiles}";
            this.PreviewFiles.Click += new System.EventHandler(this.PreviewFiles_Click);
            // 
            // AbortConversion
            // 
            this.VistaMenuSys.SetImage(this.AbortConversion, global::KeppyMIDIConverter.Properties.Resources.stop_icon);
            this.AbortConversion.Index = 10;
            this.AbortConversion.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
            this.AbortConversion.Text = "{AbortConversion}";
            this.AbortConversion.Click += new System.EventHandler(this.AbortConversion_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 11;
            this.menuItem13.Text = "-";
            // 
            // Exit
            // 
            this.VistaMenuSys.SetImage(this.Exit, global::KeppyMIDIConverter.Properties.Resources.exit_icon);
            this.Exit.Index = 12;
            this.Exit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.Exit.Text = "{Exit}";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // OptionsStrip
            // 
            this.OptionsStrip.Index = 1;
            this.OptionsStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.RenderMode,
            this.menuItem17,
            this.ACFUWSTC,
            this.ASAR,
            this.CMLAR,
            this.SCPIOTL,
            this.CSFFS,
            this.SVDS,
            this.menuItem23,
            this.ChangeLanguage});
            this.OptionsStrip.Text = "{Options}";
            // 
            // RenderMode
            // 
            this.VistaMenuSys.SetImage(this.RenderMode, global::KeppyMIDIConverter.Properties.Resources.gear_icon);
            this.RenderMode.Index = 0;
            this.RenderMode.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.RenderStandard,
            this.RenderRTS,
            this.menuItem42,
            this.NoAffectPreview});
            this.RenderMode.Text = "{RenderMode}";
            // 
            // RenderStandard
            // 
            this.RenderStandard.Index = 0;
            this.RenderStandard.Text = "{Standard}";
            this.RenderStandard.Click += new System.EventHandler(this.RenderStandard_Click);
            // 
            // RenderRTS
            // 
            this.RenderRTS.Index = 1;
            this.RenderRTS.Text = "{RealTimeSim}";
            this.RenderRTS.Click += new System.EventHandler(this.RenderRTS_Click);
            // 
            // menuItem42
            // 
            this.menuItem42.Index = 2;
            this.menuItem42.Text = "-";
            // 
            // NoAffectPreview
            // 
            this.NoAffectPreview.Enabled = false;
            this.NoAffectPreview.Index = 3;
            this.NoAffectPreview.Text = "{NoAffectPreview}";
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 1;
            this.menuItem17.Text = "-";
            // 
            // ACFUWSTC
            // 
            this.ACFUWSTC.Index = 2;
            this.ACFUWSTC.Text = "{ACFUWSTC}";
            this.ACFUWSTC.Click += new System.EventHandler(this.ACFUWSTC_Click);
            // 
            // ASAR
            // 
            this.ASAR.Index = 3;
            this.ASAR.Text = "{ASAR}";
            this.ASAR.Click += new System.EventHandler(this.ASAR_Click);
            // 
            // CMLAR
            // 
            this.CMLAR.Index = 4;
            this.CMLAR.Text = "{CMLAR}";
            this.CMLAR.Click += new System.EventHandler(this.CMLAR_Click);
            // 
            // SCPIOTL
            // 
            this.SCPIOTL.Index = 5;
            this.SCPIOTL.Text = "{SCPIOTL}";
            this.SCPIOTL.Click += new System.EventHandler(this.SCPIOTL_Click);
            // 
            // CSFFS
            // 
            this.CSFFS.Index = 6;
            this.CSFFS.Text = "{CSFFS}";
            this.CSFFS.Click += new System.EventHandler(this.CSFFS_Click);
            // 
            // SVDS
            // 
            this.SVDS.Index = 7;
            this.SVDS.Text = "{SVDS}";
            this.SVDS.Click += new System.EventHandler(this.SVS_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 8;
            this.menuItem23.Text = "-";
            // 
            // ChangeLanguage
            // 
            this.VistaMenuSys.SetImage(this.ChangeLanguage, global::KeppyMIDIConverter.Properties.Resources.lang_icon);
            this.ChangeLanguage.Index = 9;
            this.ChangeLanguage.Text = "{ChangeLanguage}";
            this.ChangeLanguage.Click += new System.EventHandler(this.ChangeLanguage_Click);
            // 
            // HelpStrip
            // 
            this.HelpStrip.Index = 2;
            this.HelpStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.IATP,
            this.menuItem32,
            this.STDWD,
            this.KK99GP,
            this.KK99YTC,
            this.menuItem30,
            this.JKSUS});
            this.HelpStrip.Text = "{Help}";
            // 
            // IATP
            // 
            this.VistaMenuSys.SetImage(this.IATP, global::KeppyMIDIConverter.Properties.Resources.info_icon);
            this.IATP.Index = 0;
            this.IATP.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.IATP.Text = "{IATP}";
            this.IATP.Click += new System.EventHandler(this.IATP_Click);
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 1;
            this.menuItem32.Text = "-";
            // 
            // STDWD
            // 
            this.VistaMenuSys.SetImage(this.STDWD, global::KeppyMIDIConverter.Properties.Resources.ppdonate);
            this.STDWD.Index = 2;
            this.STDWD.Text = "{STDWD}";
            this.STDWD.Click += new System.EventHandler(this.STDWD_Click);
            // 
            // KK99GP
            // 
            this.VistaMenuSys.SetImage(this.KK99GP, global::KeppyMIDIConverter.Properties.Resources.github_icon);
            this.KK99GP.Index = 3;
            this.KK99GP.Text = "{KK99GP}";
            this.KK99GP.Click += new System.EventHandler(this.KK99GP_Click);
            // 
            // KK99YTC
            // 
            this.VistaMenuSys.SetImage(this.KK99YTC, global::KeppyMIDIConverter.Properties.Resources.youtube_icon);
            this.KK99YTC.Index = 4;
            this.KK99YTC.Text = "{KK99YTC}";
            this.KK99YTC.Click += new System.EventHandler(this.KK99YTC_Click);
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 5;
            this.menuItem30.Text = "-";
            // 
            // JKSUS
            // 
            this.VistaMenuSys.SetImage(this.JKSUS, global::KeppyMIDIConverter.Properties.Resources.discord_icon);
            this.JKSUS.Index = 6;
            this.JKSUS.Text = "{JKSUS}";
            this.JKSUS.Click += new System.EventHandler(this.JKSUS_Click);
            // 
            // PreviewTrackBar
            // 
            this.PreviewTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewTrackBar.AutoSize = false;
            this.PreviewTrackBar.Enabled = false;
            this.PreviewTrackBar.Location = new System.Drawing.Point(4, 444);
            this.PreviewTrackBar.Name = "PreviewTrackBar";
            this.PreviewTrackBar.Size = new System.Drawing.Size(718, 30);
            this.PreviewTrackBar.TabIndex = 28;
            this.PreviewTrackBar.TickFrequency = 0;
            this.PreviewTrackBar.Scroll += new System.EventHandler(this.PreviewTrackBar_Scroll);
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
            this.MIDIList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MIDIFile,
            this.MIDILength,
            this.MIDINotes,
            this.MIDISize});
            this.MIDIList.FullRowSelect = true;
            this.MIDIList.GridLines = true;
            this.MIDIList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MIDIList.Location = new System.Drawing.Point(12, 12);
            this.MIDIList.Name = "MIDIList";
            this.MIDIList.ShowGroups = false;
            this.MIDIList.Size = new System.Drawing.Size(702, 315);
            this.MIDIList.TabIndex = 21;
            this.MIDIList.UseCompatibleStateImageBehavior = false;
            this.MIDIList.View = System.Windows.Forms.View.Details;
            this.MIDIList.DragDrop += new System.Windows.Forms.DragEventHandler(this.MIDIList_DragDrop);
            this.MIDIList.DragEnter += new System.Windows.Forms.DragEventHandler(this.MIDIList_DragEnter);
            this.MIDIList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MIDIList_KeyDown);
            // 
            // MIDIFile
            // 
            this.MIDIFile.Text = "A";
            // 
            // MIDILength
            // 
            this.MIDILength.Text = "A";
            // 
            // MIDINotes
            // 
            this.MIDINotes.Text = "A";
            // 
            // MIDISize
            // 
            this.MIDISize.Text = "A";
            // 
            // VolumeBar
            // 
            this.VolumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeBar.AutoSize = false;
            this.VolumeBar.LargeChange = 1;
            this.VolumeBar.Location = new System.Drawing.Point(589, 356);
            this.VolumeBar.Maximum = 10000;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(131, 15);
            this.VolumeBar.TabIndex = 22;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeBar.Value = 10000;
            this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
            // 
            // AVSLabel
            // 
            this.AVSLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AVSLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AVSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.AVSLabel.Location = new System.Drawing.Point(9, 353);
            this.AVSLabel.Name = "AVSLabel";
            this.AVSLabel.Size = new System.Drawing.Size(397, 13);
            this.AVSLabel.TabIndex = 23;
            this.AVSLabel.Text = "{AVS}";
            this.AVSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AVSLabel.Click += new System.EventHandler(this.AVSLabel_Click);
            // 
            // RMSLabel
            // 
            this.RMSLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RMSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.RMSLabel.Location = new System.Drawing.Point(9, 334);
            this.RMSLabel.Name = "RMSLabel";
            this.RMSLabel.Size = new System.Drawing.Size(528, 13);
            this.RMSLabel.TabIndex = 26;
            this.RMSLabel.Text = "{RMS}";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.StatusPicture);
            this.panel1.Controls.Add(this.StatusMsg);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(12, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 62);
            this.panel1.TabIndex = 25;
            // 
            // StatusPicture
            // 
            this.StatusPicture.BackColor = System.Drawing.Color.Transparent;
            this.StatusPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.StatusPicture.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusPicture.InitialImage = null;
            this.StatusPicture.Location = new System.Drawing.Point(640, 0);
            this.StatusPicture.Name = "StatusPicture";
            this.StatusPicture.Size = new System.Drawing.Size(60, 60);
            this.StatusPicture.TabIndex = 8;
            this.StatusPicture.TabStop = false;
            // 
            // StatusMsg
            // 
            this.StatusMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusMsg.BackColor = System.Drawing.Color.Transparent;
            this.StatusMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.StatusMsg.Location = new System.Drawing.Point(0, 0);
            this.StatusMsg.Name = "StatusMsg";
            this.StatusMsg.Size = new System.Drawing.Size(640, 60);
            this.StatusMsg.TabIndex = 7;
            this.StatusMsg.Text = "{StatusMsg}";
            this.StatusMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpenSettings
            // 
            this.OpenSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OpenSettings.Location = new System.Drawing.Point(549, 331);
            this.OpenSettings.Name = "OpenSettings";
            this.OpenSettings.Size = new System.Drawing.Size(166, 23);
            this.OpenSettings.TabIndex = 29;
            this.OpenSettings.Text = "{OpenSettings}";
            this.OpenSettings.UseVisualStyleBackColor = true;
            this.OpenSettings.Click += new System.EventHandler(this.OpenSettings_Click);
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeLabel.Location = new System.Drawing.Point(418, 356);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(174, 13);
            this.VolumeLabel.TabIndex = 9;
            this.VolumeLabel.Text = "{Volume}";
            this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ListMenu
            // 
            this.ListMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ImportMIDIsC,
            this.RemoveMIDIsC,
            this.ClearListC,
            this.menuItem4,
            this.AutoResizeColumns,
            this.SortName,
            this.menuItem10,
            this.MoveUp,
            this.MoveDown});
            // 
            // ImportMIDIsC
            // 
            this.VistaMenuSys.SetImage(this.ImportMIDIsC, global::KeppyMIDIConverter.Properties.Resources.add_icon);
            this.ImportMIDIsC.Index = 0;
            this.ImportMIDIsC.Text = "{ImportMIDIs}";
            this.ImportMIDIsC.Click += new System.EventHandler(this.ImportMIDIs_Click);
            // 
            // RemoveMIDIsC
            // 
            this.VistaMenuSys.SetImage(this.RemoveMIDIsC, global::KeppyMIDIConverter.Properties.Resources.remove_icon);
            this.RemoveMIDIsC.Index = 1;
            this.RemoveMIDIsC.Text = "{RemoveMIDIs}";
            this.RemoveMIDIsC.Click += new System.EventHandler(this.RemoveMIDIs_Click);
            // 
            // ClearListC
            // 
            this.VistaMenuSys.SetImage(this.ClearListC, global::KeppyMIDIConverter.Properties.Resources.delete_icon);
            this.ClearListC.Index = 2;
            this.ClearListC.Text = "{ClearList}";
            this.ClearListC.Click += new System.EventHandler(this.ClearList_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "-";
            // 
            // AutoResizeColumns
            // 
            this.AutoResizeColumns.Index = 4;
            this.AutoResizeColumns.Text = "{AutoResizeColumns}";
            this.AutoResizeColumns.Click += new System.EventHandler(this.AutoResizeColumns_Click);
            // 
            // SortName
            // 
            this.SortName.Index = 5;
            this.SortName.Text = "{SortName}";
            this.SortName.Click += new System.EventHandler(this.SortName_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 6;
            this.menuItem10.Text = "-";
            // 
            // MoveUp
            // 
            this.VistaMenuSys.SetImage(this.MoveUp, global::KeppyMIDIConverter.Properties.Resources.up_icon);
            this.MoveUp.Index = 7;
            this.MoveUp.Text = "{MoveUp}";
            this.MoveUp.Click += new System.EventHandler(this.MoveUp_Click);
            // 
            // MoveDown
            // 
            this.VistaMenuSys.SetImage(this.MoveDown, global::KeppyMIDIConverter.Properties.Resources.down_icon);
            this.MoveDown.Index = 8;
            this.MoveDown.Text = "{MoveDown}";
            this.MoveDown.Click += new System.EventHandler(this.MoveDown_Click);
            // 
            // VistaMenuSys
            // 
            this.VistaMenuSys.ContainerControl = this;
            // 
            // VSTiSeparator
            // 
            this.VSTiSeparator.Enabled = false;
            this.VSTiSeparator.Index = 3;
            this.VSTiSeparator.Text = "|";
            this.VSTiSeparator.Visible = false;
            // 
            // VSTiSettings
            // 
            this.VSTiSettings.Index = 4;
            this.VSTiSettings.Text = "{VSTiSettings}";
            this.VSTiSettings.Visible = false;
            this.VSTiSettings.Click += new System.EventHandler(this.VSTiSettings_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 481);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.OpenSettings);
            this.Controls.Add(this.PreviewTrackBar);
            this.Controls.Add(this.MIDIList);
            this.Controls.Add(this.VolumeBar);
            this.Controls.Add(this.AVSLabel);
            this.Controls.Add(this.RMSLabel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{0} {1}";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatusPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMenuSys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuItem ActionsStrip;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem OptionsStrip;
        private System.Windows.Forms.MenuItem menuItem42;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.MenuItem menuItem23;
        private System.Windows.Forms.MenuItem HelpStrip;
        private System.Windows.Forms.MenuItem menuItem32;
        private System.Windows.Forms.MenuItem menuItem30;
        public System.Windows.Forms.TrackBar PreviewTrackBar;
        public System.Windows.Forms.ListView MIDIList;
        public System.Windows.Forms.TrackBar VolumeBar;
        public System.Windows.Forms.Label AVSLabel;
        public System.Windows.Forms.Label RMSLabel;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox StatusPicture;
        public System.Windows.Forms.Label StatusMsg;
        public System.Windows.Forms.Button OpenSettings;
        private System.Windows.Forms.ContextMenu ListMenu;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem10;
        public System.Windows.Forms.MainMenu ConverterMenu;
        public System.Windows.Forms.MenuItem ImportMIDIs;
        public System.Windows.Forms.MenuItem RemoveMIDIs;
        public System.Windows.Forms.MenuItem ClearList;
        public System.Windows.Forms.MenuItem OpenSFVSTManager;
        public System.Windows.Forms.MenuItem RenderToWAV;
        public System.Windows.Forms.MenuItem RenderToOGG;
        public System.Windows.Forms.MenuItem RenderToLAME;
        public System.Windows.Forms.MenuItem PreviewFiles;
        public System.Windows.Forms.MenuItem AbortConversion;
        public System.Windows.Forms.MenuItem Exit;
        public System.Windows.Forms.MenuItem RenderMode;
        public System.Windows.Forms.MenuItem RenderStandard;
        public System.Windows.Forms.MenuItem RenderRTS;
        public System.Windows.Forms.MenuItem NoAffectPreview;
        public System.Windows.Forms.MenuItem ACFUWSTC;
        public System.Windows.Forms.MenuItem CMLAR;
        public System.Windows.Forms.MenuItem SCPIOTL;
        public System.Windows.Forms.MenuItem CSFFS;
        public System.Windows.Forms.MenuItem ChangeLanguage;
        public System.Windows.Forms.MenuItem IATP;
        public System.Windows.Forms.MenuItem STDWD;
        public System.Windows.Forms.MenuItem KK99GP;
        public System.Windows.Forms.MenuItem KK99YTC;
        public System.Windows.Forms.MenuItem JKSUS;
        public System.Windows.Forms.MenuItem ASAR;
        public System.Windows.Forms.Label VolumeLabel;
        private wyDay.Controls.VistaMenu VistaMenuSys;
        private System.Windows.Forms.ColumnHeader MIDIFile;
        private System.Windows.Forms.ColumnHeader MIDILength;
        private System.Windows.Forms.ColumnHeader MIDINotes;
        private System.Windows.Forms.ColumnHeader MIDISize;
        public System.Windows.Forms.MenuItem ImportMIDIsC;
        public System.Windows.Forms.MenuItem RemoveMIDIsC;
        public System.Windows.Forms.MenuItem ClearListC;
        public System.Windows.Forms.MenuItem SortName;
        public System.Windows.Forms.MenuItem MoveUp;
        public System.Windows.Forms.MenuItem MoveDown;
        public System.Windows.Forms.MenuItem AutoResizeColumns;
        public System.Windows.Forms.MenuItem SVDS;
        public System.Windows.Forms.MenuItem VSTiSeparator;
        public System.Windows.Forms.MenuItem VSTiSettings;
    }
}

