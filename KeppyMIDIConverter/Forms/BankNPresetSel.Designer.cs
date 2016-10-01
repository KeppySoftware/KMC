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
            this.DesPresetVal = new System.Windows.Forms.NumericUpDown();
            this.DesBankVal = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.WikipediaLink = new System.Windows.Forms.LinkLabel();
            this.IgnoreBtn = new System.Windows.Forms.Button();
            this.SelectedSFLabel = new System.Windows.Forms.Label();
            this.PresetVal = new System.Windows.Forms.NumericUpDown();
            this.BankVal = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfirmBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ToBeTranslated = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DesPresetVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesBankVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PresetVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankVal)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(9, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(339, 52);
            this.label6.TabIndex = 28;
            this.label6.Text = "Src.: Source of the bank/preset to import\r\nDes.: Bank/Preset to assign to the imp" +
    "orted one.\r\n\r\nLeave Src. Bank and Src. Preset to 0 for SFZ files.";
            // 
            // DesPresetVal
            // 
            this.DesPresetVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DesPresetVal.Location = new System.Drawing.Point(277, 88);
            this.DesPresetVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.DesPresetVal.Name = "DesPresetVal";
            this.DesPresetVal.Size = new System.Drawing.Size(80, 20);
            this.DesPresetVal.TabIndex = 27;
            this.DesPresetVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DesBankVal
            // 
            this.DesBankVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DesBankVal.Location = new System.Drawing.Point(277, 69);
            this.DesBankVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.DesBankVal.Name = "DesBankVal";
            this.DesBankVal.Size = new System.Drawing.Size(80, 20);
            this.DesBankVal.TabIndex = 26;
            this.DesBankVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Src. Preset:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Src. Bank:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WikipediaLink
            // 
            this.WikipediaLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WikipediaLink.Location = new System.Drawing.Point(9, 219);
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
            this.IgnoreBtn.Location = new System.Drawing.Point(204, 214);
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
            this.SelectedSFLabel.Location = new System.Drawing.Point(0, 239);
            this.SelectedSFLabel.Name = "SelectedSFLabel";
            this.SelectedSFLabel.Size = new System.Drawing.Size(359, 40);
            this.SelectedSFLabel.TabIndex = 21;
            this.SelectedSFLabel.Text = "Selected soundfont:\r\nPotato.sf2";
            this.SelectedSFLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PresetVal
            // 
            this.PresetVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetVal.Location = new System.Drawing.Point(277, 126);
            this.PresetVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.PresetVal.Name = "PresetVal";
            this.PresetVal.Size = new System.Drawing.Size(80, 20);
            this.PresetVal.TabIndex = 20;
            this.PresetVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BankVal
            // 
            this.BankVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BankVal.Location = new System.Drawing.Point(277, 107);
            this.BankVal.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.BankVal.Name = "BankVal";
            this.BankVal.Size = new System.Drawing.Size(80, 20);
            this.BankVal.TabIndex = 19;
            this.BankVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Des. Preset:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Des. Bank:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConfirmBut
            // 
            this.ConfirmBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBut.Location = new System.Drawing.Point(283, 214);
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
            this.label1.Size = new System.Drawing.Size(348, 52);
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
            this.ToBeTranslated.Location = new System.Drawing.Point(280, 195);
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
            this.ClientSize = new System.Drawing.Size(359, 279);
            this.ControlBox = false;
            this.Controls.Add(this.ToBeTranslated);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DesPresetVal);
            this.Controls.Add(this.DesBankVal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.WikipediaLink);
            this.Controls.Add(this.IgnoreBtn);
            this.Controls.Add(this.SelectedSFLabel);
            this.Controls.Add(this.PresetVal);
            this.Controls.Add(this.BankVal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConfirmBut);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankNPresetSel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select a bank and a preset for the soundfont";
            this.Load += new System.EventHandler(this.BankNPresetSel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DesPresetVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesBankVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PresetVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown DesPresetVal;
        private System.Windows.Forms.NumericUpDown DesBankVal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel WikipediaLink;
        private System.Windows.Forms.Button IgnoreBtn;
        private System.Windows.Forms.Label SelectedSFLabel;
        private System.Windows.Forms.NumericUpDown PresetVal;
        private System.Windows.Forms.NumericUpDown BankVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConfirmBut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ToBeTranslated;

    }
}