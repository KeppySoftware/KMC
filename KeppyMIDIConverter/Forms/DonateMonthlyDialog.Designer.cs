namespace KeppyMIDIConverter
{
    partial class DonateMonthlyDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonateMonthlyDialog));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DontShowAnymore = new System.Windows.Forms.Button();
            this.ShowMeNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::KeppyMIDIConverter.Properties.Resources.donatewin;
            this.pictureBox1.Location = new System.Drawing.Point(178, 207);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // DontShowAnymore
            // 
            this.DontShowAnymore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DontShowAnymore.Location = new System.Drawing.Point(12, 234);
            this.DontShowAnymore.Name = "DontShowAnymore";
            this.DontShowAnymore.Size = new System.Drawing.Size(150, 23);
            this.DontShowAnymore.TabIndex = 1;
            this.DontShowAnymore.Text = "Do not show this ever again";
            this.DontShowAnymore.UseVisualStyleBackColor = true;
            this.DontShowAnymore.Click += new System.EventHandler(this.DontShowAnymore_Click);
            // 
            // ShowMeNext
            // 
            this.ShowMeNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowMeNext.Location = new System.Drawing.Point(12, 207);
            this.ShowMeNext.Name = "ShowMeNext";
            this.ShowMeNext.Size = new System.Drawing.Size(150, 23);
            this.ShowMeNext.TabIndex = 2;
            this.ShowMeNext.Text = "Show me the next month";
            this.ShowMeNext.UseVisualStyleBackColor = true;
            this.ShowMeNext.Click += new System.EventHandler(this.ShowMeNext_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 191);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DonateMonthlyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 269);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowMeNext);
            this.Controls.Add(this.DontShowAnymore);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DonateMonthlyDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Donate to keep the project alive";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button DontShowAnymore;
        private System.Windows.Forms.Button ShowMeNext;
        private System.Windows.Forms.Label label1;
    }
}