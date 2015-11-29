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
            this.startBenchmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abortBenchmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversionModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.benchmarkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.officialBlackMIDIWikiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Converter = new System.ComponentModel.BackgroundWorker();
            this.MIDIImport = new System.Windows.Forms.OpenFileDialog();
            this.RenderingTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.UsedVoices = new System.Windows.Forms.Label();
            this.CurrentStatusText = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Benchmarker = new System.ComponentModel.BackgroundWorker();
            this.loadSoundfontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MIDIList = new System.Windows.Forms.ListBox();
            this.DefMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMIDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AdvSettingsButton = new System.Windows.Forms.Button();
            this.VoiceLimit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentStatus = new System.Windows.Forms.ProgressBar();
            this.SoundfontImportDialog = new System.Windows.Forms.OpenFileDialog();
            this.LeftBut = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMIDIsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadingpic = new System.Windows.Forms.PictureBox();
            this.ExportWhere = new System.Windows.Forms.SaveFileDialog();
            this.labelRMS = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.DefMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceLimit)).BeginInit();
            this.LeftBut.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingpic)).BeginInit();
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
            // startBenchmarkToolStripMenuItem
            // 
            this.startBenchmarkToolStripMenuItem.Name = "startBenchmarkToolStripMenuItem";
            this.startBenchmarkToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.startBenchmarkToolStripMenuItem.Text = "Start benchmark";
            this.startBenchmarkToolStripMenuItem.Visible = false;
            this.startBenchmarkToolStripMenuItem.Click += new System.EventHandler(this.startBenchmarkToolStripMenuItem_Click);
            // 
            // abortBenchmarkToolStripMenuItem
            // 
            this.abortBenchmarkToolStripMenuItem.Enabled = false;
            this.abortBenchmarkToolStripMenuItem.Name = "abortBenchmarkToolStripMenuItem";
            this.abortBenchmarkToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.abortBenchmarkToolStripMenuItem.Text = "Abort benchmark";
            this.abortBenchmarkToolStripMenuItem.Visible = false;
            this.abortBenchmarkToolStripMenuItem.Click += new System.EventHandler(this.abortBenchmarkToolStripMenuItem_Click);
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
            // modesToolStripMenuItem
            // 
            this.modesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conversionModeToolStripMenuItem,
            this.benchmarkModeToolStripMenuItem});
            this.modesToolStripMenuItem.Name = "modesToolStripMenuItem";
            this.modesToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modesToolStripMenuItem.Text = "Modes";
            // 
            // conversionModeToolStripMenuItem
            // 
            this.conversionModeToolStripMenuItem.Enabled = false;
            this.conversionModeToolStripMenuItem.Name = "conversionModeToolStripMenuItem";
            this.conversionModeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.conversionModeToolStripMenuItem.Text = "Conversion mode";
            this.conversionModeToolStripMenuItem.Click += new System.EventHandler(this.conversionModeToolStripMenuItem_Click);
            // 
            // benchmarkModeToolStripMenuItem
            // 
            this.benchmarkModeToolStripMenuItem.Name = "benchmarkModeToolStripMenuItem";
            this.benchmarkModeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.benchmarkModeToolStripMenuItem.Text = "Benchmark mode";
            this.benchmarkModeToolStripMenuItem.Click += new System.EventHandler(this.benchmarkModeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationsToolStripMenuItem,
            this.toolStripSeparator3,
            this.officialBlackMIDIWikiaToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // informationsToolStripMenuItem
            // 
            this.informationsToolStripMenuItem.Name = "informationsToolStripMenuItem";
            this.informationsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.informationsToolStripMenuItem.Text = "Informations";
            this.informationsToolStripMenuItem.Click += new System.EventHandler(this.informationsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // officialBlackMIDIWikiaToolStripMenuItem
            // 
            this.officialBlackMIDIWikiaToolStripMenuItem.Name = "officialBlackMIDIWikiaToolStripMenuItem";
            this.officialBlackMIDIWikiaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.officialBlackMIDIWikiaToolStripMenuItem.Text = "Official Black MIDI Wikia";
            this.officialBlackMIDIWikiaToolStripMenuItem.Click += new System.EventHandler(this.officialBlackMIDIWikiaToolStripMenuItem_Click);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.UsedVoices);
            this.panel2.Controls.Add(this.CurrentStatusText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 373);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 55);
            this.panel2.TabIndex = 16;
            // 
            // UsedVoices
            // 
            this.UsedVoices.Dock = System.Windows.Forms.DockStyle.Right;
            this.UsedVoices.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsedVoices.Location = new System.Drawing.Point(510, 0);
            this.UsedVoices.Name = "UsedVoices";
            this.UsedVoices.Size = new System.Drawing.Size(142, 55);
            this.UsedVoices.TabIndex = 8;
            this.UsedVoices.Text = "Loading...";
            this.UsedVoices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UsedVoices.UseCompatibleTextRendering = true;
            // 
            // CurrentStatusText
            // 
            this.CurrentStatusText.Location = new System.Drawing.Point(0, 0);
            this.CurrentStatusText.Name = "CurrentStatusText";
            this.CurrentStatusText.Size = new System.Drawing.Size(509, 55);
            this.CurrentStatusText.TabIndex = 7;
            this.CurrentStatusText.Text = "Loading...\r\nPlease wait...";
            this.CurrentStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CurrentStatusText.UseCompatibleTextRendering = true;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // Benchmarker
            // 
            this.Benchmarker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Benchmarker_DoWork);
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
            this.MIDIList.ContextMenuStrip = this.DefMenu;
            this.MIDIList.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDIList.FormattingEnabled = true;
            this.MIDIList.HorizontalScrollbar = true;
            this.MIDIList.ItemHeight = 18;
            this.MIDIList.Location = new System.Drawing.Point(12, 40);
            this.MIDIList.Name = "MIDIList";
            this.MIDIList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.MIDIList.Size = new System.Drawing.Size(628, 238);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AdvSettingsButton);
            this.groupBox1.Controls.Add(this.VoiceLimit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(510, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 70);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // AdvSettingsButton
            // 
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
            this.VoiceLimit.Location = new System.Drawing.Point(63, 14);
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
            // LeftBut
            // 
            this.LeftBut.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftBut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem,
            this.modesToolStripMenuItem,
            this.toolStripMenuItem1});
            this.LeftBut.Location = new System.Drawing.Point(0, 0);
            this.LeftBut.Name = "LeftBut";
            this.LeftBut.Size = new System.Drawing.Size(652, 24);
            this.LeftBut.TabIndex = 15;
            this.LeftBut.Text = "menuStrip1";
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
            this.startBenchmarkToolStripMenuItem,
            this.abortBenchmarkToolStripMenuItem,
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
            this.loadingpic.ErrorImage = global::KeppyMIDIConverter.Properties.Resources.loading_gallery;
            this.loadingpic.Image = global::KeppyMIDIConverter.Properties.Resources.loading_gallery;
            this.loadingpic.InitialImage = global::KeppyMIDIConverter.Properties.Resources.loading_gallery;
            this.loadingpic.Location = new System.Drawing.Point(426, 0);
            this.loadingpic.Name = "loadingpic";
            this.loadingpic.Size = new System.Drawing.Size(62, 60);
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
            this.labelRMS.AutoSize = true;
            this.labelRMS.Location = new System.Drawing.Point(13, 284);
            this.labelRMS.Name = "labelRMS";
            this.labelRMS.Size = new System.Drawing.Size(87, 13);
            this.labelRMS.TabIndex = 17;
            this.labelRMS.Text = "Peak level: None";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 451);
            this.Controls.Add(this.labelRMS);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MIDIList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CurrentStatus);
            this.Controls.Add(this.LeftBut);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keppy\'s MIDI Converter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panel2.ResumeLayout(false);
            this.DefMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceLimit)).EndInit();
            this.LeftBut.ResumeLayout(false);
            this.LeftBut.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem unloadSoundfontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startRenderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortRenderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startBenchmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortBenchmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conversionModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem benchmarkModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem informationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem officialBlackMIDIWikiaToolStripMenuItem;
        public System.ComponentModel.BackgroundWorker Converter;
        private System.Windows.Forms.OpenFileDialog MIDIImport;
        private System.Windows.Forms.Timer RenderingTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label UsedVoices;
        private System.Windows.Forms.Label CurrentStatusText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.ComponentModel.BackgroundWorker Benchmarker;
        private System.Windows.Forms.ToolStripMenuItem loadSoundfontToolStripMenuItem;
        private System.Windows.Forms.ListBox MIDIList;
        private System.Windows.Forms.ContextMenuStrip DefMenu;
        private System.Windows.Forms.ToolStripMenuItem addMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMIDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AdvSettingsButton;
        private System.Windows.Forms.NumericUpDown VoiceLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar CurrentStatus;
        private System.Windows.Forms.OpenFileDialog SoundfontImportDialog;
        private System.Windows.Forms.MenuStrip LeftBut;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMIDIsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog ExportWhere;
        private System.Windows.Forms.PictureBox loadingpic;
        private System.Windows.Forms.Label labelRMS;
    }
}

