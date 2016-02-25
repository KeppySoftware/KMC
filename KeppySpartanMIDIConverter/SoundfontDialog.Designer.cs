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
            this.SFList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MvUp = new System.Windows.Forms.Button();
            this.MvDwn = new System.Windows.Forms.Button();
            this.SFListCheck = new System.Windows.Forms.Timer(this.components);
            this.SFZCompliant = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SFZCompliant)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
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
            this.SoundfontImportDialog.Filter = "Soundfont files|*.sf2;*.sfz;*.sf3;*.sfpack;";
            this.SoundfontImportDialog.Multiselect = true;
            this.SoundfontImportDialog.ShowReadOnly = true;
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
            this.ImportBtn.Location = new System.Drawing.Point(12, 395);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(119, 23);
            this.ImportBtn.TabIndex = 9;
            this.ImportBtn.Text = "Import soundfont(s)";
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Location = new System.Drawing.Point(137, 395);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(119, 23);
            this.RemoveBtn.TabIndex = 10;
            this.RemoveBtn.Text = "Remove soundfont(s)";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // SFList
            // 
            this.SFList.AllowDrop = true;
            this.SFList.FormattingEnabled = true;
            this.SFList.HorizontalScrollbar = true;
            this.SFList.Location = new System.Drawing.Point(12, 96);
            this.SFList.Name = "SFList";
            this.SFList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.SFList.Size = new System.Drawing.Size(557, 290);
            this.SFList.TabIndex = 11;
            this.SFList.DragDrop += new System.Windows.Forms.DragEventHandler(this.SFList_DragDrop);
            this.SFList.DragEnter += new System.Windows.Forms.DragEventHandler(this.SFList_DragEnter);
            this.SFList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SFList_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(196, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "SF2, SF3 (No full support), SFZ, SFPACK";
            // 
            // MvUp
            // 
            this.MvUp.Location = new System.Drawing.Point(283, 395);
            this.MvUp.Name = "MvUp";
            this.MvUp.Size = new System.Drawing.Size(88, 23);
            this.MvUp.TabIndex = 13;
            this.MvUp.Text = "Move Up ▲";
            this.MvUp.UseVisualStyleBackColor = true;
            this.MvUp.Click += new System.EventHandler(this.MvUp_Click);
            // 
            // MvDwn
            // 
            this.MvDwn.Location = new System.Drawing.Point(377, 395);
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
            // SFZCompliant
            // 
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
            // SoundfontDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 429);
            this.Controls.Add(this.SFZCompliant);
            this.Controls.Add(this.MvDwn);
            this.Controls.Add(this.MvUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SFList);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.ImportBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoundfontDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Soundfonts manager";
            this.Load += new System.EventHandler(this.SoundfontDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SFZCompliant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog SoundfontImportDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ImportBtn;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListBox SFList;
        private System.Windows.Forms.Button MvUp;
        private System.Windows.Forms.Button MvDwn;
        private System.Windows.Forms.Timer SFListCheck;
        private System.Windows.Forms.PictureBox SFZCompliant;
    }
}