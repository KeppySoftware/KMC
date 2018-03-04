namespace KeppyMIDIConverter
{
    partial class OverrideLanguage
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
            this.OverrideLanguageCheck = new System.Windows.Forms.CheckBox();
            this.LangSel = new System.Windows.Forms.ComboBox();
            this.OK = new System.Windows.Forms.Button();
            this.Flag = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Flag)).BeginInit();
            this.SuspendLayout();
            // 
            // OverrideLanguageCheck
            // 
            this.OverrideLanguageCheck.AutoSize = true;
            this.OverrideLanguageCheck.Location = new System.Drawing.Point(12, 12);
            this.OverrideLanguageCheck.Name = "OverrideLanguageCheck";
            this.OverrideLanguageCheck.Size = new System.Drawing.Size(40, 17);
            this.OverrideLanguageCheck.TabIndex = 0;
            this.OverrideLanguageCheck.Text = "OL";
            this.OverrideLanguageCheck.UseVisualStyleBackColor = true;
            this.OverrideLanguageCheck.CheckedChanged += new System.EventHandler(this.OverrideLanguageCheck_CheckedChanged);
            // 
            // LangSel
            // 
            this.LangSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LangSel.FormattingEnabled = true;
            this.LangSel.Location = new System.Drawing.Point(39, 35);
            this.LangSel.Name = "LangSel";
            this.LangSel.Size = new System.Drawing.Size(303, 21);
            this.LangSel.TabIndex = 1;
            this.LangSel.SelectedIndexChanged += new System.EventHandler(this.LangSel_SelectedIndexChanged);
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OK.Location = new System.Drawing.Point(267, 67);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Flag
            // 
            this.Flag.BackgroundImage = global::KeppyMIDIConverter.Properties.Resources.Italy;
            this.Flag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Flag.Location = new System.Drawing.Point(10, 36);
            this.Flag.Name = "Flag";
            this.Flag.Size = new System.Drawing.Size(23, 18);
            this.Flag.TabIndex = 3;
            this.Flag.TabStop = false;
            // 
            // OverrideLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OK;
            this.ClientSize = new System.Drawing.Size(354, 102);
            this.Controls.Add(this.Flag);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.LangSel);
            this.Controls.Add(this.OverrideLanguageCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverrideLanguage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OverrideLanguage";
            this.Load += new System.EventHandler(this.OverrideLanguage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Flag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox OverrideLanguageCheck;
        private System.Windows.Forms.ComboBox LangSel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.PictureBox Flag;
    }
}