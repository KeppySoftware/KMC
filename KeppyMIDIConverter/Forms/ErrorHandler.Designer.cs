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
            this.Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMenuSys)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ErrorLab
            // 
            this.ErrorLab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorLab.Location = new System.Drawing.Point(68, 12);
            this.ErrorLab.Name = "ErrorLab";
            this.ErrorLab.Size = new System.Drawing.Size(392, 39);
            this.ErrorLab.TabIndex = 7;
            this.ErrorLab.Text = "Type of error here hehe\r\n\r\nWhat happened mate:";
            // 
            // ErrorBox
            // 
            this.ErrorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorBox.BackColor = System.Drawing.Color.White;
            this.ErrorBox.DetectUrls = false;
            this.ErrorBox.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorBox.ForeColor = System.Drawing.Color.Black;
            this.ErrorBox.Location = new System.Drawing.Point(14, 63);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.ReadOnly = true;
            this.ErrorBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ErrorBox.ShortcutsEnabled = false;
            this.ErrorBox.Size = new System.Drawing.Size(447, 100);
            this.ErrorBox.TabIndex = 5;
            this.ErrorBox.Text = "There was an error";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KeppyMIDIConverter.Properties.Resources.worldwideweb;
            this.pictureBox1.Location = new System.Drawing.Point(14, 8);
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
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Well that explains a lot";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.BackColor = System.Drawing.Color.Red;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(389, 16);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 9;
            this.Close.Text = "OK";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Close);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 57);
            this.panel1.TabIndex = 10;
            // 
            // ErrorHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(482, 245);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Panel panel1;

    }
}