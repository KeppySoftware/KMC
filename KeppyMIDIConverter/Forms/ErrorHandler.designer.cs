namespace KeppyMIDIConverter
{
    partial class ErrorHandler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorHandler));
            this.ErrorLab = new System.Windows.Forms.Label();
            this.ErrorBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RBTMenu = new System.Windows.Forms.ContextMenu();
            this.copyErrorMessageToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.VistaMenuSys = new wyDay.Controls.VistaMenu(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.OKBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMenuSys)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorLab
            // 
            this.ErrorLab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorLab.Location = new System.Drawing.Point(68, 12);
            this.ErrorLab.Name = "ErrorLab";
            this.ErrorLab.Size = new System.Drawing.Size(402, 39);
            this.ErrorLab.TabIndex = 7;
            this.ErrorLab.Text = "{desc}";
            // 
            // ErrorBox
            // 
            this.ErrorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorBox.BackColor = System.Drawing.Color.White;
            this.ErrorBox.DetectUrls = false;
            this.ErrorBox.ForeColor = System.Drawing.Color.Black;
            this.ErrorBox.Location = new System.Drawing.Point(12, 63);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.ReadOnly = true;
            this.ErrorBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ErrorBox.ShortcutsEnabled = false;
            this.ErrorBox.Size = new System.Drawing.Size(458, 129);
            this.ErrorBox.TabIndex = 5;
            this.ErrorBox.Text = "{details}";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KeppyMIDIConverter.Properties.Resources.worldwideweb;
            this.pictureBox1.Location = new System.Drawing.Point(13, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // RBTMenu
            // 
            this.RBTMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.copyErrorMessageToolStripMenuItem});
            // 
            // copyErrorMessageToolStripMenuItem
            // 
            this.copyErrorMessageToolStripMenuItem.DefaultItem = true;
            this.VistaMenuSys.SetImage(this.copyErrorMessageToolStripMenuItem, global::KeppyMIDIConverter.Properties.Resources.down_icon);
            this.copyErrorMessageToolStripMenuItem.Index = 0;
            this.copyErrorMessageToolStripMenuItem.Text = "Copy the error to clipboard";
            this.copyErrorMessageToolStripMenuItem.Click += new System.EventHandler(this.copyErrorMessageToolStripMenuItem_Click);
            // 
            // VistaMenuSys
            // 
            this.VistaMenuSys.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(10, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "{guide}";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OKBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OKBtn.ForeColor = System.Drawing.Color.White;
            this.OKBtn.Location = new System.Drawing.Point(395, 198);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 9;
            this.OKBtn.Text = "OKBtn";
            this.OKBtn.UseVisualStyleBackColor = false;
            this.OKBtn.Click += new System.EventHandler(this.Close_Click);
            // 
            // ErrorHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(482, 233);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ErrorLab);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ErrorBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 272);
            this.Name = "ErrorHandler";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ErrorHandler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMenuSys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ErrorLab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox ErrorBox;
        private System.Windows.Forms.ContextMenu RBTMenu;
        private System.Windows.Forms.MenuItem copyErrorMessageToolStripMenuItem;
        private wyDay.Controls.VistaMenu VistaMenuSys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OKBtn;

    }
}