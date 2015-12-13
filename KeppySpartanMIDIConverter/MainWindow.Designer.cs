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
            this.unloadSoundfontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRenderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abortRenderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.blackMIDIStuffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.officialBlackMIDIWikiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikipediasPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keppyStudiosWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Converter = new System.ComponentModel.BackgroundWorker();
            this.MIDIImport = new System.Windows.Forms.OpenFileDialog();
            this.RenderingTimer = new System.Windows.Forms.Timer(this.components);
            this.UsedVoices = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadSoundfontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MIDIList = new System.Windows.Forms.ListBox();
            this.DefMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMIDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsBox = new System.Windows.Forms.GroupBox();
            this.AdvSettingsButton = new System.Windows.Forms.Button();
            this.VoiceLimit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentStatus = new System.Windows.Forms.ProgressBar();
            this.SoundfontImportDialog = new System.Windows.Forms.OpenFileDialog();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMIDIsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadingpic = new System.Windows.Forms.PictureBox();
            this.ExportWhere = new System.Windows.Forms.SaveFileDialog();
            this.labelRMS = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CurrentStatusText = new System.Windows.Forms.Label();
            this.DefMenu.SuspendLayout();
            this.SettingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceLimit)).BeginInit();
            this.Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingpic)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // unloadSoundfontToolStripMenuItem
            // 
            this.unloadSoundfontToolStripMenuItem.Name = "unloadSoundfontToolStripMenuItem";
            this.unloadSoundfontToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.unloadSoundfontToolStripMenuItem.Text = "Unload soundfont";
            this.unloadSoundfontToolStripMenuItem.Click += new System.EventHandler(this.unloadSoundfontToolStripMenuItem_Click);
            // 
            // startRenderingToolStripMenuItem
            // 
            this.startRenderingToolStripMenuItem.Name = "startRenderingToolStripMenuItem";
            this.startRenderingToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.startRenderingToolStripMenuItem.Text = "Start rendering";
            this.startRenderingToolStripMenuItem.Click += new System.EventHandler(this.startRenderingToolStripMenuItem_Click);
            // 
            // abortRenderingToolStripMenuItem
            // 
            this.abortRenderingToolStripMenuItem.Enabled = false;
            this.abortRenderingToolStripMenuItem.Name = "abortRenderingToolStripMenuItem";
            this.abortRenderingToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.abortRenderingToolStripMenuItem.Text = "Abort rendering";
            this.abortRenderingToolStripMenuItem.Click += new System.EventHandler(this.abortRenderingToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationsToolStripMenuItem,
            this.toolStripSeparator3,
            this.blackMIDIStuffToolStripMenuItem,
            this.keppyStudiosWebsiteToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.toolStripMenuItem1.Text = "Help";
            // 
            // informationsToolStripMenuItem
            // 
            this.informationsToolStripMenuItem.Name = "informationsToolStripMenuItem";
            this.informationsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.informationsToolStripMenuItem.Text = "Informations";
            this.informationsToolStripMenuItem.Click += new System.EventHandler(this.informationsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // blackMIDIStuffToolStripMenuItem
            // 
            this.blackMIDIStuffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem,
            this.toolStripSeparator6,
            this.officialBlackMIDIWikiaToolStripMenuItem,
            this.wikipediasPageToolStripMenuItem});
            this.blackMIDIStuffToolStripMenuItem.Name = "blackMIDIStuffToolStripMenuItem";
            this.blackMIDIStuffToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.blackMIDIStuffToolStripMenuItem.Text = "Black MIDI stuff";
            // 
            // kaleidonKep99sYouTubeChannelToolStripMenuItem
            // 
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem.Name = "kaleidonKep99sYouTubeChannelToolStripMenuItem";
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem.Text = "KaleidonKep99\'s YouTube Channel";
            this.kaleidonKep99sYouTubeChannelToolStripMenuItem.Click += new System.EventHandler(this.kaleidonKep99sYouTubeChannelToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(235, 6);
            // 
            // officialBlackMIDIWikiaToolStripMenuItem
            // 
            this.officialBlackMIDIWikiaToolStripMenuItem.Name = "officialBlackMIDIWikiaToolStripMenuItem";
            this.officialBlackMIDIWikiaToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.officialBlackMIDIWikiaToolStripMenuItem.Text = "Official Black MIDI Wikia";
            this.officialBlackMIDIWikiaToolStripMenuItem.Click += new System.EventHandler(this.officialBlackMIDIWikiaToolStripMenuItem_Click);
            // 
            // wikipediasPageToolStripMenuItem
            // 
            this.wikipediasPageToolStripMenuItem.Name = "wikipediasPageToolStripMenuItem";
            this.wikipediasPageToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.wikipediasPageToolStripMenuItem.Text = "Wikipedia\'s page";
            this.wikipediasPageToolStripMenuItem.Click += new System.EventHandler(this.wikipediasPageToolStripMenuItem_Click);
            // 
            // keppyStudiosWebsiteToolStripMenuItem
            // 
            this.keppyStudiosWebsiteToolStripMenuItem.Name = "keppyStudiosWebsiteToolStripMenuItem";
            this.keppyStudiosWebsiteToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.keppyStudiosWebsiteToolStripMenuItem.Text = "Keppy Studios Website";
            this.keppyStudiosWebsiteToolStripMenuItem.Click += new System.EventHandler(this.keppyStudiosWebsiteToolStripMenuItem_Click);
            // 
            // Converter
            // 
            this.Converter.WorkerReportsProgress = true;
            this.Converter.WorkerSupportsCancellation = true;
            this.Converter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Converter_DoWork);
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
            this.UsedVoices.Location = new System.Drawing.Point(487, 275);
            this.UsedVoices.Name = "UsedVoices";
            this.UsedVoices.Size = new System.Drawing.Size(153, 13);
            this.UsedVoices.TabIndex = 8;
            this.UsedVoices.Text = "Loading...";
            this.UsedVoices.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // loadSoundfontToolStripMenuItem
            // 
            this.loadSoundfontToolStripMenuItem.Name = "loadSoundfontToolStripMenuItem";
            this.loadSoundfontToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.loadSoundfontToolStripMenuItem.Text = "Load soundfont";
            this.loadSoundfontToolStripMenuItem.Click += new System.EventHandler(this.loadSoundfontToolStripMenuItem_Click);
            // 
            // MIDIList
            // 
            this.MIDIList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MIDIList.ContextMenuStrip = this.DefMenu;
            this.MIDIList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MIDIList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDIList.FormattingEnabled = true;
            this.MIDIList.HorizontalScrollbar = true;
            this.MIDIList.ItemHeight = 16;
            this.MIDIList.Location = new System.Drawing.Point(12, 36);
            this.MIDIList.Name = "MIDIList";
            this.MIDIList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.MIDIList.Size = new System.Drawing.Size(628, 226);
            this.MIDIList.TabIndex = 11;
            // 
            // DefMenu
            // 
            this.DefMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMIDIsToolStripMenuItem,
            this.removeMIDIToolStripMenuItem,
            this.toolStripSeparator5,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.DefMenu.Name = "contextMenuStrip1";
            this.DefMenu.Size = new System.Drawing.Size(198, 98);
            // 
            // addMIDIsToolStripMenuItem
            // 
            this.addMIDIsToolStripMenuItem.Name = "addMIDIsToolStripMenuItem";
            this.addMIDIsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addMIDIsToolStripMenuItem.Text = "Import MIDIs";
            this.addMIDIsToolStripMenuItem.Click += new System.EventHandler(this.addMIDIsToolStripMenuItem_Click);
            // 
            // removeMIDIToolStripMenuItem
            // 
            this.removeMIDIToolStripMenuItem.Name = "removeMIDIToolStripMenuItem";
            this.removeMIDIToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.removeMIDIToolStripMenuItem.Text = "Remove selected MIDIs";
            this.removeMIDIToolStripMenuItem.Click += new System.EventHandler(this.removeMIDIToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(194, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.moveUpToolStripMenuItem.Text = "Move up (One item)";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.moveDownToolStripMenuItem.Text = "Move down (One item)";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // SettingsBox
            // 
            this.SettingsBox.Controls.Add(this.AdvSettingsButton);
            this.SettingsBox.Controls.Add(this.VoiceLimit);
            this.SettingsBox.Controls.Add(this.label1);
            this.SettingsBox.Location = new System.Drawing.Point(510, 297);
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
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voice limit:";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(420, 60);
            this.label2.TabIndex = 7;
            this.label2.Text = "Load a soundfont first\r\nto see its informations here.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentStatus
            // 
            this.CurrentStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CurrentStatus.Location = new System.Drawing.Point(0, 428);
            this.CurrentStatus.Name = "CurrentStatus";
            this.CurrentStatus.Size = new System.Drawing.Size(652, 23);
            this.CurrentStatus.TabIndex = 14;
            // 
            // SoundfontImportDialog
            // 
            this.SoundfontImportDialog.Filter = "Soundfont files|*.sf2;*.sfz;";
            // 
            // Menu
            // 
            this.Menu.AllowMerge = false;
            this.Menu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem,
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
            this.loadSoundfontToolStripMenuItem,
            this.unloadSoundfontToolStripMenuItem,
            this.toolStripSeparator1,
            this.startRenderingToolStripMenuItem,
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
            this.importMIDIsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.importMIDIsToolStripMenuItem.Text = "Import MIDIs";
            this.importMIDIsToolStripMenuItem.Click += new System.EventHandler(this.importMIDIsToolStripMenuItem_Click);
            // 
            // removeSelectedMIDIsToolStripMenuItem
            // 
            this.removeSelectedMIDIsToolStripMenuItem.Name = "removeSelectedMIDIsToolStripMenuItem";
            this.removeSelectedMIDIsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.removeSelectedMIDIsToolStripMenuItem.Text = "Remove selected MIDIs";
            this.removeSelectedMIDIsToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedMIDIsToolStripMenuItem_Click);
            // 
            // clearMIDIsListToolStripMenuItem
            // 
            this.clearMIDIsListToolStripMenuItem.Name = "clearMIDIsListToolStripMenuItem";
            this.clearMIDIsListToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.clearMIDIsListToolStripMenuItem.Text = "Clear MIDIs list";
            this.clearMIDIsListToolStripMenuItem.Click += new System.EventHandler(this.clearMIDIsListToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(184, 6);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.loadingpic);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 64);
            this.panel1.TabIndex = 13;
            // 
            // loadingpic
            // 
            this.loadingpic.Dock = System.Windows.Forms.DockStyle.Right;
            this.loadingpic.Image = global::KeppyMIDIConverter.Properties.Resources.landing_spinner;
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
            this.labelRMS.Location = new System.Drawing.Point(12, 275);
            this.labelRMS.Name = "labelRMS";
            this.labelRMS.Size = new System.Drawing.Size(470, 13);
            this.labelRMS.TabIndex = 17;
            this.labelRMS.Text = "Peak level: None";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::KeppyMIDIConverter.Properties.Resources.KepperinoChristmas;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.CurrentStatusText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 373);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 55);
            this.panel2.TabIndex = 16;
            // 
            // CurrentStatusText
            // 
            this.CurrentStatusText.BackColor = System.Drawing.Color.Transparent;
            this.CurrentStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentStatusText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentStatusText.Location = new System.Drawing.Point(0, 0);
            this.CurrentStatusText.Name = "CurrentStatusText";
            this.CurrentStatusText.Size = new System.Drawing.Size(652, 55);
            this.CurrentStatusText.TabIndex = 7;
            this.CurrentStatusText.Text = "Loading... Please wait...";
            this.CurrentStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 451);
            this.Controls.Add(this.UsedVoices);
            this.Controls.Add(this.labelRMS);
            this.Controls.Add(this.panel2);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keppy\'s MIDI Converter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DefMenu.ResumeLayout(false);
            this.SettingsBox.ResumeLayout(false);
            this.SettingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceLimit)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingpic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem unloadSoundfontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startRenderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortRenderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem informationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.ComponentModel.BackgroundWorker Converter;
        private System.Windows.Forms.OpenFileDialog MIDIImport;
        private System.Windows.Forms.Timer RenderingTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label UsedVoices;
        private System.Windows.Forms.Label CurrentStatusText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loadSoundfontToolStripMenuItem;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar CurrentStatus;
        private System.Windows.Forms.OpenFileDialog SoundfontImportDialog;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMIDIsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog ExportWhere;
        private System.Windows.Forms.PictureBox loadingpic;
        private System.Windows.Forms.Label labelRMS;
        private System.Windows.Forms.ToolStripMenuItem blackMIDIStuffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem officialBlackMIDIWikiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaleidonKep99sYouTubeChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem wikipediasPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keppyStudiosWebsiteToolStripMenuItem;
    }
}

