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
            this.ErrorLab = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.ErrorBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorLab
            // 
            this.ErrorLab.AutoSize = true;
            this.ErrorLab.Location = new System.Drawing.Point(68, 12);
            this.ErrorLab.Name = "ErrorLab";
            this.ErrorLab.Size = new System.Drawing.Size(219, 39);
            this.ErrorLab.TabIndex = 7;
            this.ErrorLab.Text = "Error during the execution of the converter!\r\n\r\nMore information down below:";
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(381, 34);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 4;
            this.Close.Text = "OK";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // ErrorBox
            // 
            this.ErrorBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorBox.Location = new System.Drawing.Point(12, 63);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.ReadOnly = true;
            this.ErrorBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ErrorBox.ShortcutsEnabled = false;
            this.ErrorBox.Size = new System.Drawing.Size(444, 96);
            this.ErrorBox.TabIndex = 5;
            this.ErrorBox.Text = "There was an error";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KeppyMIDIConverter.Properties.Resources.erroricon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // ErrorHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(468, 171);
            this.Controls.Add(this.ErrorLab);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.ErrorBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorHandler";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ErrorHandler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ErrorLab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.RichTextBox ErrorBox;

    }
}