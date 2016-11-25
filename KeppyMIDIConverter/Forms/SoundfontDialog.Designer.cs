namespace KeppyMIDIConverter
{
    partial class SoundfontDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundfontDialog));
            this.button1 = new System.Windows.Forms.Button();
            this.SoundfontImportDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.MvUp = new System.Windows.Forms.Button();
            this.MvDwn = new System.Windows.Forms.Button();
            this.SFListCheck = new System.Windows.Forms.Timer(this.components);
            this.VSTUse = new System.Windows.Forms.CheckBox();
            this.VSTImport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SFZCompliant = new System.Windows.Forms.PictureBox();
            this.SFMenu = new System.Windows.Forms.ContextMenu();
            this.importSoundfontsToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.removeSoundfontsToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.clearSoundfontListToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.VistaMenuSys = new wyDay.Controls.VistaMenu(this.components);
            this.SFList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SFZCompliant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMenuSys)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(494, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SoundfontImportDialog
            // 
            this.SoundfontImportDialog.Filter = "Soundfont files|*.sf2;*.sfz;*.sf3;*.sfpack;|Soundfont lists|*.sflist;*.txt;";
            this.SoundfontImportDialog.Multiselect = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 87);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // ImportBtn
            // 
            this.ImportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ImportBtn.Location = new System.Drawing.Point(12, 395);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(145, 23);
            this.ImportBtn.TabIndex = 9;
            this.ImportBtn.Text = "Import soundfont(s)";
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveBtn.Location = new System.Drawing.Point(156, 395);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(145, 23);
            this.RemoveBtn.TabIndex = 10;
            this.RemoveBtn.Text = "Remove soundfont(s)";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // MvUp
            // 
            this.MvUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MvUp.Location = new System.Drawing.Point(313, 395);
            this.MvUp.Name = "MvUp";
            this.MvUp.Size = new System.Drawing.Size(88, 23);
            this.MvUp.TabIndex = 13;
            this.MvUp.Text = "Move Up ▲";
            this.MvUp.UseVisualStyleBackColor = true;
            this.MvUp.Click += new System.EventHandler(this.MvUp_Click);
            // 
            // MvDwn
            // 
            this.MvDwn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MvDwn.Location = new System.Drawing.Point(400, 395);
            this.MvDwn.Name = "MvDwn";
            this.MvDwn.Size = new System.Drawing.Size(88, 23);
            this.MvDwn.TabIndex = 14;
            this.MvDwn.Text = "Move Down ▼";
            this.MvDwn.UseVisualStyleBackColor = true;
            this.MvDwn.Click += new System.EventHandler(this.MvDwn_Click);
            // 
            // SFListCheck
            // 
            this.SFListCheck.Enabled = true;
            this.SFListCheck.Interval = 1;
            this.SFListCheck.Tick += new System.EventHandler(this.SFListCheck_Tick);
            // 
            // VSTUse
            // 
            this.VSTUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VSTUse.Location = new System.Drawing.Point(12, 361);
            this.VSTUse.Name = "VSTUse";
            this.VSTUse.Size = new System.Drawing.Size(295, 35);
            this.VSTUse.TabIndex = 16;
            this.VSTUse.Text = "I want to apply a VST DSPs too.";
            this.VSTUse.UseVisualStyleBackColor = true;
            this.VSTUse.CheckedChanged += new System.EventHandler(this.VSTUse_CheckedChanged);
            // 
            // VSTImport
            // 
            this.VSTImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VSTImport.Enabled = false;
            this.VSTImport.Location = new System.Drawing.Point(313, 366);
            this.VSTImport.Name = "VSTImport";
            this.VSTImport.Size = new System.Drawing.Size(256, 23);
            this.VSTImport.TabIndex = 17;
            this.VSTImport.Text = "Open the VST DSP manager...";
            this.VSTImport.UseVisualStyleBackColor = true;
            this.VSTImport.Click += new System.EventHandler(this.VSTImport_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::KeppyMIDIConverter.Properties.Resources.vstlogo;
            this.pictureBox1.Location = new System.Drawing.Point(471, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.VSTReady_Click);
            // 
            // SFZCompliant
            // 
            this.SFZCompliant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SFZCompliant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SFZCompliant.Image = global::KeppyMIDIConverter.Properties.Resources.sfzcomp;
            this.SFZCompliant.Location = new System.Drawing.Point(523, 57);
            this.SFZCompliant.Name = "SFZCompliant";
            this.SFZCompliant.Size = new System.Drawing.Size(46, 37);
            this.SFZCompliant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SFZCompliant.TabIndex = 15;
            this.SFZCompliant.TabStop = false;
            this.SFZCompliant.Click += new System.EventHandler(this.SFZCompliant_Click);
            // 
            // SFMenu
            // 
            this.SFMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.importSoundfontsToolStripMenuItem,
            this.removeSoundfontsToolStripMenuItem,
            this.menuItem3,
            this.clearSoundfontListToolStripMenuItem});
            // 
            // importSoundfontsToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.importSoundfontsToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.add_icon);
            this.importSoundfontsToolStripMenuItem.Index = 0;
            this.importSoundfontsToolStripMenuItem.Text = "Import soundfont(s)";
            this.importSoundfontsToolStripMenuItem.Click += new System.EventHandler(this.importSoundfontsToolStripMenuItem_Click);
            // 
            // removeSoundfontsToolStripMenuItem
            // 
            this.VistaMenuSys.SetImage(this.removeSoundfontsToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.remove_icon);
            this.removeSoundfontsToolStripMenuItem.Index = 1;
            this.removeSoundfontsToolStripMenuItem.Text = "Remove soundfont(s)";
            this.removeSoundfontsToolStripMenuItem.Click += new System.EventHandler(this.removeSoundfontsToolStripMenuItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "-";
            // 
            // clearSoundfontListToolStripMenuItem
            // 
            this.clearSoundfontListToolStripMenuItem.Index = 3;
            this.clearSoundfontListToolStripMenuItem.Text = "Clear soundfont lists";
            this.clearSoundfontListToolStripMenuItem.Click += new System.EventHandler(this.clearSoundfontListToolStripMenuItem_Click);
            // 
            // VistaMenuSys
            // 
            this.VistaMenuSys.ContainerControl = this;
            // 
            // SFList
            // 
            this.SFList.AllowDrop = true;
            this.SFList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SFList.HorizontalScrollbar = true;
            this.SFList.IntegralHeight = false;
            this.SFList.Location = new System.Drawing.Point(12, 96);
            this.SFList.Name = "SFList";
            this.SFList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.SFList.Size = new System.Drawing.Size(557, 264);
            this.SFList.TabIndex = 11;
            this.SFList.DragDrop += new System.Windows.Forms.DragEventHandler(this.SFList_DragDrop);
            this.SFList.DragEnter += new System.Windows.Forms.DragEventHandler(this.SFList_DragEnter);
            this.SFList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SFList_KeyPress);
            // 
            // SoundfontDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(581, 429);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.VSTImport);
            this.Controls.Add(this.VSTUse);
            this.Controls.Add(this.SFZCompliant);
            this.Controls.Add(this.MvDwn);
            this.Controls.Add(this.MvUp);
            this.Controls.Add(this.SFList);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.ImportBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(597, 468);
            this.Name = "SoundfontDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Soundfonts/VST DSP manager";
            this.Load += new System.EventHandler(this.SoundfontDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SFZCompliant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMenuSys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog SoundfontImportDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ImportBtn;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.Button MvUp;
        private System.Windows.Forms.Button MvDwn;
        private System.Windows.Forms.Timer SFListCheck;
        private System.Windows.Forms.PictureBox SFZCompliant;
        private System.Windows.Forms.CheckBox VSTUse;
        private System.Windows.Forms.Button VSTImport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenu SFMenu;
        private System.Windows.Forms.MenuItem importSoundfontsToolStripMenuItem;
        private System.Windows.Forms.MenuItem removeSoundfontsToolStripMenuItem;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem clearSoundfontListToolStripMenuItem;
        private wyDay.Controls.VistaMenu VistaMenuSys;
        public System.Windows.Forms.ListBox SFList;
    }
}