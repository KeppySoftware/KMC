namespace KeppyMIDIConverter
{
    partial class BecomeAPatron
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
            this.BecomeAPatronNow = new System.Windows.Forms.Button();
            this.PatreonDesc = new System.Windows.Forms.Label();
            this.DontShowAnymore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BecomeAPatronNow
            // 
            this.BecomeAPatronNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BecomeAPatronNow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BecomeAPatronNow.Image = global::KeppyMIDIConverter.Properties.Resources.patronbtn;
            this.BecomeAPatronNow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BecomeAPatronNow.Location = new System.Drawing.Point(196, 196);
            this.BecomeAPatronNow.Name = "BecomeAPatronNow";
            this.BecomeAPatronNow.Size = new System.Drawing.Size(136, 33);
            this.BecomeAPatronNow.TabIndex = 8;
            this.BecomeAPatronNow.Text = "BecomeAPatronNow";
            this.BecomeAPatronNow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BecomeAPatronNow.UseVisualStyleBackColor = true;
            this.BecomeAPatronNow.Click += new System.EventHandler(this.BecomeAPatronNow_Click);
            // 
            // PatreonDesc
            // 
            this.PatreonDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatreonDesc.Location = new System.Drawing.Point(12, 9);
            this.PatreonDesc.Name = "PatreonDesc";
            this.PatreonDesc.Size = new System.Drawing.Size(320, 175);
            this.PatreonDesc.TabIndex = 7;
            this.PatreonDesc.Text = "PatreonDesc";
            this.PatreonDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DontShowAnymore
            // 
            this.DontShowAnymore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DontShowAnymore.Image = global::KeppyMIDIConverter.Properties.Resources.clocklater;
            this.DontShowAnymore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DontShowAnymore.Location = new System.Drawing.Point(12, 196);
            this.DontShowAnymore.Name = "DontShowAnymore";
            this.DontShowAnymore.Size = new System.Drawing.Size(136, 33);
            this.DontShowAnymore.TabIndex = 5;
            this.DontShowAnymore.Text = "DontShowAnymore";
            this.DontShowAnymore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DontShowAnymore.UseVisualStyleBackColor = true;
            this.DontShowAnymore.Click += new System.EventHandler(this.DontShowAnymore_Click);
            // 
            // BecomeAPatron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 241);
            this.ControlBox = false;
            this.Controls.Add(this.BecomeAPatronNow);
            this.Controls.Add(this.PatreonDesc);
            this.Controls.Add(this.DontShowAnymore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BecomeAPatron";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BecomeAPatron";
            this.Load += new System.EventHandler(this.BecomeAPatron_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BecomeAPatronNow;
        private System.Windows.Forms.Label PatreonDesc;
        private System.Windows.Forms.Button DontShowAnymore;
    }
}