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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundfontDialog));
            this.button1 = new System.Windows.Forms.Button();
            this.SoundfontImportDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.SFList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.SoundfontImportDialog.Filter = "Soundfont files|*.sf2;*.sfz;";
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
            // SoundfontDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 429);
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
    }
}