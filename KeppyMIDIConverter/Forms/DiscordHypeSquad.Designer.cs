namespace KeppyMIDIConverter.Forms
{
    partial class DiscordHypeSquad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscordHypeSquad));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Desc = new System.Windows.Forms.PictureBox();
            this.ApplyNow = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Desc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KeppyMIDIConverter.Properties.Resources.dslogo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(466, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Desc
            // 
            this.Desc.Image = global::KeppyMIDIConverter.Properties.Resources.dsdesc;
            this.Desc.Location = new System.Drawing.Point(6, 88);
            this.Desc.Name = "Desc";
            this.Desc.Size = new System.Drawing.Size(477, 104);
            this.Desc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Desc.TabIndex = 3;
            this.Desc.TabStop = false;
            // 
            // ApplyNow
            // 
            this.ApplyNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ApplyNow.Image = global::KeppyMIDIConverter.Properties.Resources.dsapply1;
            this.ApplyNow.Location = new System.Drawing.Point(149, 200);
            this.ApplyNow.Name = "ApplyNow";
            this.ApplyNow.Size = new System.Drawing.Size(190, 50);
            this.ApplyNow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ApplyNow.TabIndex = 4;
            this.ApplyNow.TabStop = false;
            this.ApplyNow.Click += new System.EventHandler(this.ApplyNow_Click);
            this.ApplyNow.MouseEnter += new System.EventHandler(this.ApplyNow_MouseEnter);
            this.ApplyNow.MouseLeave += new System.EventHandler(this.ApplyNow_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::KeppyMIDIConverter.Properties.Resources.dsagemin;
            this.pictureBox2.Location = new System.Drawing.Point(149, 252);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(190, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // DiscordHypeSquad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(490, 271);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ApplyNow);
            this.Controls.Add(this.Desc);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscordHypeSquad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Join the Discord HypeSquad!";
            this.Load += new System.EventHandler(this.DiscordHypeSquad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Desc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Desc;
        private System.Windows.Forms.PictureBox ApplyNow;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}