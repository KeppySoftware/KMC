namespace KeppyMIDIConverter
{
    partial class BankNPresetSel
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
            this.BNPSelDesc = new System.Windows.Forms.Label();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.DesBankLabel = new System.Windows.Forms.Label();
            this.DesPresetLabel = new System.Windows.Forms.Label();
            this.DesBankVal = new System.Windows.Forms.NumericUpDown();
            this.DesPresetVal = new System.Windows.Forms.NumericUpDown();
            this.SelectedSFLabel = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.BNPSelWiki = new System.Windows.Forms.LinkLabel();
            this.SrcBankVal = new System.Windows.Forms.NumericUpDown();
            this.SrcPresetLabel = new System.Windows.Forms.Label();
            this.SrcBankLabel = new System.Windows.Forms.Label();
            this.SrcPresetVal = new System.Windows.Forms.NumericUpDown();
            this.BNPSelHelp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DesBankVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesPresetVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SrcBankVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SrcPresetVal)).BeginInit();
            this.SuspendLayout();
            // 
            // BNPSelDesc
            // 
            this.BNPSelDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BNPSelDesc.Location = new System.Drawing.Point(11, 9);
            this.BNPSelDesc.Name = "BNPSelDesc";
            this.BNPSelDesc.Size = new System.Drawing.Size(337, 55);
            this.BNPSelDesc.TabIndex = 0;
            this.BNPSelDesc.Text = "BNPSelDesc";
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBtn.Location = new System.Drawing.Point(277, 220);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.TabIndex = 1;
            this.ConfirmBtn.Text = "ConfirmBtn";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBut_Click);
            // 
            // DesBankLabel
            // 
            this.DesBankLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DesBankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesBankLabel.Location = new System.Drawing.Point(9, 115);
            this.DesBankLabel.Name = "DesBankLabel";
            this.DesBankLabel.Size = new System.Drawing.Size(286, 13);
            this.DesBankLabel.TabIndex = 2;
            this.DesBankLabel.Text = "DesBankLabel";
            this.DesBankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DesPresetLabel
            // 
            this.DesPresetLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DesPresetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesPresetLabel.Location = new System.Drawing.Point(9, 138);
            this.DesPresetLabel.Name = "DesPresetLabel";
            this.DesPresetLabel.Size = new System.Drawing.Size(286, 13);
            this.DesPresetLabel.TabIndex = 3;
            this.DesPresetLabel.Text = "DesPresetLabel";
            this.DesPresetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DesBankVal
            // 
            this.DesBankVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DesBankVal.Location = new System.Drawing.Point(301, 113);
            this.DesBankVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.DesBankVal.Name = "DesBankVal";
            this.DesBankVal.Size = new System.Drawing.Size(47, 20);
            this.DesBankVal.TabIndex = 4;
            this.DesBankVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DesPresetVal
            // 
            this.DesPresetVal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DesPresetVal.Location = new System.Drawing.Point(301, 136);
            this.DesPresetVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.DesPresetVal.Name = "DesPresetVal";
            this.DesPresetVal.Size = new System.Drawing.Size(47, 20);
            this.DesPresetVal.TabIndex = 5;
            this.DesPresetVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SelectedSFLabel
            // 
            this.SelectedSFLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectedSFLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SelectedSFLabel.Location = new System.Drawing.Point(0, 251);
            this.SelectedSFLabel.Name = "SelectedSFLabel";
            this.SelectedSFLabel.Size = new System.Drawing.Size(360, 40);
            this.SelectedSFLabel.TabIndex = 6;
            this.SelectedSFLabel.Text = "SelectedSFLabel";
            this.SelectedSFLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.Location = new System.Drawing.Point(196, 220);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "CancelBtn";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // BNPSelWiki
            // 
            this.BNPSelWiki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BNPSelWiki.AutoSize = true;
            this.BNPSelWiki.Location = new System.Drawing.Point(12, 225);
            this.BNPSelWiki.Name = "BNPSelWiki";
            this.BNPSelWiki.Size = new System.Drawing.Size(65, 13);
            this.BNPSelWiki.TabIndex = 8;
            this.BNPSelWiki.TabStop = true;
            this.BNPSelWiki.Text = "BNPSelWiki";
            this.BNPSelWiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WikipediaLink_LinkClicked);
            // 
            // SrcBankVal
            // 
            this.SrcBankVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SrcBankVal.Location = new System.Drawing.Point(301, 67);
            this.SrcBankVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.SrcBankVal.Name = "SrcBankVal";
            this.SrcBankVal.Size = new System.Drawing.Size(47, 20);
            this.SrcBankVal.TabIndex = 11;
            this.SrcBankVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SrcPresetLabel
            // 
            this.SrcPresetLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SrcPresetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrcPresetLabel.Location = new System.Drawing.Point(9, 92);
            this.SrcPresetLabel.Name = "SrcPresetLabel";
            this.SrcPresetLabel.Size = new System.Drawing.Size(286, 13);
            this.SrcPresetLabel.TabIndex = 10;
            this.SrcPresetLabel.Text = "SrcPresetLabel";
            this.SrcPresetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SrcBankLabel
            // 
            this.SrcBankLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SrcBankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrcBankLabel.Location = new System.Drawing.Point(9, 69);
            this.SrcBankLabel.Name = "SrcBankLabel";
            this.SrcBankLabel.Size = new System.Drawing.Size(286, 13);
            this.SrcBankLabel.TabIndex = 9;
            this.SrcBankLabel.Text = "SrcBankLabel";
            this.SrcBankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SrcPresetVal
            // 
            this.SrcPresetVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SrcPresetVal.Location = new System.Drawing.Point(301, 90);
            this.SrcPresetVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.SrcPresetVal.Name = "SrcPresetVal";
            this.SrcPresetVal.Size = new System.Drawing.Size(47, 20);
            this.SrcPresetVal.TabIndex = 13;
            this.SrcPresetVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BNPSelHelp
            // 
            this.BNPSelHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BNPSelHelp.Location = new System.Drawing.Point(10, 159);
            this.BNPSelHelp.Name = "BNPSelHelp";
            this.BNPSelHelp.Size = new System.Drawing.Size(338, 55);
            this.BNPSelHelp.TabIndex = 14;
            this.BNPSelHelp.Text = "BNPSelHelp";
            // 
            // BankNPresetSel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(360, 291);
            this.ControlBox = false;
            this.Controls.Add(this.BNPSelHelp);
            this.Controls.Add(this.SrcPresetVal);
            this.Controls.Add(this.SrcBankVal);
            this.Controls.Add(this.SrcPresetLabel);
            this.Controls.Add(this.SrcBankLabel);
            this.Controls.Add(this.BNPSelWiki);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SelectedSFLabel);
            this.Controls.Add(this.DesPresetVal);
            this.Controls.Add(this.DesBankVal);
            this.Controls.Add(this.DesPresetLabel);
            this.Controls.Add(this.DesBankLabel);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.BNPSelDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankNPresetSel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BNPSel";
            ((System.ComponentModel.ISupportInitialize)(this.DesBankVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesPresetVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SrcBankVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SrcPresetVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BNPSelDesc;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Label DesBankLabel;
        private System.Windows.Forms.Label DesPresetLabel;
        private System.Windows.Forms.NumericUpDown DesBankVal;
        private System.Windows.Forms.NumericUpDown DesPresetVal;
        private System.Windows.Forms.Label SelectedSFLabel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.LinkLabel BNPSelWiki;
        private System.Windows.Forms.NumericUpDown SrcBankVal;
        private System.Windows.Forms.Label SrcPresetLabel;
        private System.Windows.Forms.Label SrcBankLabel;
        private System.Windows.Forms.NumericUpDown SrcPresetVal;
        private System.Windows.Forms.Label BNPSelHelp;
    }
}