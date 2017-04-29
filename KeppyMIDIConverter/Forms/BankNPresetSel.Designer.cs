namespace KeppyMIDIConverter.Forms
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
            this.label6 = new System.Windows.Forms.Label();
            this.SrcPresetVal = new System.Windows.Forms.NumericUpDown();
            this.SrcBankVal = new System.Windows.Forms.NumericUpDown();
            this.SrcPresetLab = new System.Windows.Forms.Label();
            this.SrcBankLab = new System.Windows.Forms.Label();
            this.WikipediaLink = new System.Windows.Forms.LinkLabel();
            this.IgnoreBtn = new System.Windows.Forms.Button();
            this.SelectedSFLabel = new System.Windows.Forms.Label();
            this.DesPresetVal = new System.Windows.Forms.NumericUpDown();
            this.DesBankVal = new System.Windows.Forms.NumericUpDown();
            this.DesPresetLab = new System.Windows.Forms.Label();
            this.DesBankLab = new System.Windows.Forms.Label();
            this.ConfirmBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ToBeTranslated = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SrcPresetVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SrcBankVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesPresetVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesBankVal)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(9, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(342, 52);
            this.label6.TabIndex = 28;
            this.label6.Text = "Src.: Source of the bank/preset to import\r\nDes.: Bank/Preset to assign to the imp" +
    "orted one.\r\n\r\nLeave Src. Bank and Src. Preset to 0 for SFZ files.";
            // 
            // SrcPresetVal
            // 
            this.SrcPresetVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SrcPresetVal.Location = new System.Drawing.Point(258, 86);
            this.SrcPresetVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.SrcPresetVal.Name = "SrcPresetVal";
            this.SrcPresetVal.Size = new System.Drawing.Size(93, 20);
            this.SrcPresetVal.TabIndex = 27;
            this.SrcPresetVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SrcBankVal
            // 
            this.SrcBankVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SrcBankVal.Location = new System.Drawing.Point(258, 67);
            this.SrcBankVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.SrcBankVal.Name = "SrcBankVal";
            this.SrcBankVal.Size = new System.Drawing.Size(93, 20);
            this.SrcBankVal.TabIndex = 26;
            this.SrcBankVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SrcPresetLab
            // 
            this.SrcPresetLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SrcPresetLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrcPresetLab.Location = new System.Drawing.Point(9, 88);
            this.SrcPresetLab.Name = "SrcPresetLab";
            this.SrcPresetLab.Size = new System.Drawing.Size(244, 13);
            this.SrcPresetLab.TabIndex = 25;
            this.SrcPresetLab.Text = "Src. Preset:";
            this.SrcPresetLab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SrcBankLab
            // 
            this.SrcBankLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SrcBankLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrcBankLab.Location = new System.Drawing.Point(9, 69);
            this.SrcBankLab.Name = "SrcBankLab";
            this.SrcBankLab.Size = new System.Drawing.Size(244, 13);
            this.SrcBankLab.TabIndex = 24;
            this.SrcBankLab.Text = "Src. Bank:";
            this.SrcBankLab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WikipediaLink
            // 
            this.WikipediaLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WikipediaLink.Location = new System.Drawing.Point(9, 206);
            this.WikipediaLink.Name = "WikipediaLink";
            this.WikipediaLink.Size = new System.Drawing.Size(168, 13);
            this.WikipediaLink.TabIndex = 23;
            this.WikipediaLink.TabStop = true;
            this.WikipediaLink.Text = "Banks/Presets list";
            this.WikipediaLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WikipediaLink_LinkClicked);
            // 
            // IgnoreBtn
            // 
            this.IgnoreBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.IgnoreBtn.Location = new System.Drawing.Point(201, 201);
            this.IgnoreBtn.Name = "IgnoreBtn";
            this.IgnoreBtn.Size = new System.Drawing.Size(75, 23);
            this.IgnoreBtn.TabIndex = 22;
            this.IgnoreBtn.Text = "Ignore";
            this.IgnoreBtn.UseVisualStyleBackColor = true;
            this.IgnoreBtn.Click += new System.EventHandler(this.IgnoreBtn_Click);
            // 
            // SelectedSFLabel
            // 
            this.SelectedSFLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectedSFLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SelectedSFLabel.Location = new System.Drawing.Point(0, 228);
            this.SelectedSFLabel.Name = "SelectedSFLabel";
            this.SelectedSFLabel.Size = new System.Drawing.Size(360, 40);
            this.SelectedSFLabel.TabIndex = 21;
            this.SelectedSFLabel.Text = "Selected soundfont:\r\nPotato.sf2";
            this.SelectedSFLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DesPresetVal
            // 
            this.DesPresetVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DesPresetVal.Location = new System.Drawing.Point(258, 124);
            this.DesPresetVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.DesPresetVal.Name = "DesPresetVal";
            this.DesPresetVal.Size = new System.Drawing.Size(93, 20);
            this.DesPresetVal.TabIndex = 20;
            this.DesPresetVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DesBankVal
            // 
            this.DesBankVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DesBankVal.Location = new System.Drawing.Point(258, 105);
            this.DesBankVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.DesBankVal.Name = "DesBankVal";
            this.DesBankVal.Size = new System.Drawing.Size(93, 20);
            this.DesBankVal.TabIndex = 19;
            this.DesBankVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DesPresetLab
            // 
            this.DesPresetLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DesPresetLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesPresetLab.Location = new System.Drawing.Point(9, 126);
            this.DesPresetLab.Name = "DesPresetLab";
            this.DesPresetLab.Size = new System.Drawing.Size(244, 13);
            this.DesPresetLab.TabIndex = 18;
            this.DesPresetLab.Text = "Des. Preset:";
            this.DesPresetLab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DesBankLab
            // 
            this.DesBankLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DesBankLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesBankLab.Location = new System.Drawing.Point(9, 107);
            this.DesBankLab.Name = "DesBankLab";
            this.DesBankLab.Size = new System.Drawing.Size(244, 13);
            this.DesBankLab.TabIndex = 17;
            this.DesBankLab.Text = "Des. Bank:";
            this.DesBankLab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConfirmBut
            // 
            this.ConfirmBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBut.Location = new System.Drawing.Point(282, 201);
            this.ConfirmBut.Name = "ConfirmBut";
            this.ConfirmBut.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBut.TabIndex = 16;
            this.ConfirmBut.Text = "Confirm";
            this.ConfirmBut.UseVisualStyleBackColor = true;
            this.ConfirmBut.Click += new System.EventHandler(this.ConfirmBut_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 52);
            this.label1.TabIndex = 15;
            this.label1.Text = "Please select a bank and a preset, from 0 to 127.\r\n\r\nUse \"Bank 0\" and \"Preset 0\" " +
    "for the standard \"Acoustic Grand Piano\",\r\nor if you don\'t know which one you sho" +
    "uld use.";
            // 
            // ToBeTranslated
            // 
            this.ToBeTranslated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ToBeTranslated.AutoSize = true;
            this.ToBeTranslated.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToBeTranslated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToBeTranslated.ForeColor = System.Drawing.Color.Red;
            this.ToBeTranslated.Location = new System.Drawing.Point(274, 9);
            this.ToBeTranslated.Name = "ToBeTranslated";
            this.ToBeTranslated.Size = new System.Drawing.Size(77, 13);
            this.ToBeTranslated.TabIndex = 29;
            this.ToBeTranslated.Text = "Culture error";
            this.ToBeTranslated.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ToBeTranslated.Visible = false;
            this.ToBeTranslated.Click += new System.EventHandler(this.ToBeTranslated_Click);
            // 
            // BankNPresetSel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 268);
            this.ControlBox = false;
            this.Controls.Add(this.ToBeTranslated);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SrcPresetVal);
            this.Controls.Add(this.SrcBankVal);
            this.Controls.Add(this.SrcPresetLab);
            this.Controls.Add(this.SrcBankLab);
            this.Controls.Add(this.WikipediaLink);
            this.Controls.Add(this.IgnoreBtn);
            this.Controls.Add(this.SelectedSFLabel);
            this.Controls.Add(this.DesPresetVal);
            this.Controls.Add(this.DesBankVal);
            this.Controls.Add(this.DesPresetLab);
            this.Controls.Add(this.DesBankLab);
            this.Controls.Add(this.ConfirmBut);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankNPresetSel";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select a bank and a preset for the soundfont";
            this.Load += new System.EventHandler(this.BankNPresetSel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SrcPresetVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SrcBankVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesPresetVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesBankVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown SrcPresetVal;
        private System.Windows.Forms.NumericUpDown SrcBankVal;
        private System.Windows.Forms.Label SrcPresetLab;
        private System.Windows.Forms.Label SrcBankLab;
        private System.Windows.Forms.LinkLabel WikipediaLink;
        private System.Windows.Forms.Button IgnoreBtn;
        private System.Windows.Forms.Label SelectedSFLabel;
        private System.Windows.Forms.NumericUpDown DesPresetVal;
        private System.Windows.Forms.NumericUpDown DesBankVal;
        private System.Windows.Forms.Label DesPresetLab;
        private System.Windows.Forms.Label DesBankLab;
        private System.Windows.Forms.Button ConfirmBut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ToBeTranslated;

    }
}