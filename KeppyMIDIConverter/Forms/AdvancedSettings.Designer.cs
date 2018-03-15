namespace KeppyMIDIConverter
{
    partial class AdvancedSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OKBtn = new System.Windows.Forms.Button();
            this.StreamSettings = new System.Windows.Forms.GroupBox();
            this.RTFPS = new System.Windows.Forms.NumericUpDown();
            this.TempoCurrent = new System.Windows.Forms.Label();
            this.TempoValue = new System.Windows.Forms.TrackBar();
            this.RTFPSLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ConstantBitrate = new System.Windows.Forms.CheckBox();
            this.BitrateBox = new System.Windows.Forms.ComboBox();
            this.BitrateLabel = new System.Windows.Forms.Label();
            this.OverrideTempoNow = new System.Windows.Forms.CheckBox();
            this.FXDisable = new System.Windows.Forms.CheckBox();
            this.Noteoff1 = new System.Windows.Forms.CheckBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.FrequencyBox = new System.Windows.Forms.ComboBox();
            this.AudioFreqLabel = new System.Windows.Forms.Label();
            this.CheckTempo = new System.Windows.Forms.Timer(this.components);
            this.AudioSettings = new System.Windows.Forms.GroupBox();
            this.SincInter = new System.Windows.Forms.CheckBox();
            this.MaxVoicesLabel = new System.Windows.Forms.Label();
            this.MaxVoices = new System.Windows.Forms.NumericUpDown();
            this.ChannelsSettings = new System.Windows.Forms.Button();
            this.StreamSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RTFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempoValue)).BeginInit();
            this.AudioSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxVoices)).BeginInit();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OKBtn.Location = new System.Drawing.Point(315, 315);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(79, 23);
            this.OKBtn.TabIndex = 8;
            this.OKBtn.Text = "OKBtn";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // StreamSettings
            // 
            this.StreamSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StreamSettings.Controls.Add(this.RTFPS);
            this.StreamSettings.Controls.Add(this.TempoCurrent);
            this.StreamSettings.Controls.Add(this.TempoValue);
            this.StreamSettings.Controls.Add(this.RTFPSLabel);
            this.StreamSettings.Controls.Add(this.label4);
            this.StreamSettings.Controls.Add(this.ConstantBitrate);
            this.StreamSettings.Controls.Add(this.BitrateBox);
            this.StreamSettings.Controls.Add(this.BitrateLabel);
            this.StreamSettings.Controls.Add(this.OverrideTempoNow);
            this.StreamSettings.Controls.Add(this.FXDisable);
            this.StreamSettings.Controls.Add(this.Noteoff1);
            this.StreamSettings.Location = new System.Drawing.Point(12, 129);
            this.StreamSettings.Name = "StreamSettings";
            this.StreamSettings.Size = new System.Drawing.Size(382, 180);
            this.StreamSettings.TabIndex = 0;
            this.StreamSettings.TabStop = false;
            this.StreamSettings.Text = "StreamSettings";
            // 
            // RTFPS
            // 
            this.RTFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RTFPS.DecimalPlaces = 1;
            this.RTFPS.Location = new System.Drawing.Point(300, 19);
            this.RTFPS.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.RTFPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RTFPS.Name = "RTFPS";
            this.RTFPS.Size = new System.Drawing.Size(72, 20);
            this.RTFPS.TabIndex = 1;
            this.RTFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RTFPS.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.RTFPS.ValueChanged += new System.EventHandler(this.RTFPS_ValueChanged);
            // 
            // TempoCurrent
            // 
            this.TempoCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TempoCurrent.Enabled = false;
            this.TempoCurrent.Location = new System.Drawing.Point(160, 118);
            this.TempoCurrent.Name = "TempoCurrent";
            this.TempoCurrent.Size = new System.Drawing.Size(58, 15);
            this.TempoCurrent.TabIndex = 32;
            this.TempoCurrent.Text = "999bpm";
            this.TempoCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TempoValue
            // 
            this.TempoValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TempoValue.Location = new System.Drawing.Point(213, 104);
            this.TempoValue.Maximum = 80;
            this.TempoValue.Name = "TempoValue";
            this.TempoValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TempoValue.RightToLeftLayout = true;
            this.TempoValue.Size = new System.Drawing.Size(165, 45);
            this.TempoValue.TabIndex = 5;
            this.TempoValue.TickFrequency = 8;
            this.TempoValue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TempoValue.Value = 40;
            this.TempoValue.Scroll += new System.EventHandler(this.TempoValue_Scroll);
            // 
            // RTFPSLabel
            // 
            this.RTFPSLabel.Location = new System.Drawing.Point(7, 22);
            this.RTFPSLabel.Name = "RTFPSLabel";
            this.RTFPSLabel.Size = new System.Drawing.Size(287, 13);
            this.RTFPSLabel.TabIndex = 18;
            this.RTFPSLabel.Text = "RTFPS";
            this.RTFPSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(346, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "kbps";
            // 
            // ConstantBitrate
            // 
            this.ConstantBitrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConstantBitrate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ConstantBitrate.Location = new System.Drawing.Point(9, 148);
            this.ConstantBitrate.Name = "ConstantBitrate";
            this.ConstantBitrate.Size = new System.Drawing.Size(200, 24);
            this.ConstantBitrate.TabIndex = 6;
            this.ConstantBitrate.Text = "ConstantBitrate";
            this.ConstantBitrate.UseVisualStyleBackColor = true;
            this.ConstantBitrate.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // BitrateBox
            // 
            this.BitrateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BitrateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BitrateBox.Enabled = false;
            this.BitrateBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BitrateBox.FormattingEnabled = true;
            this.BitrateBox.Items.AddRange(new object[] {
            "500",
            "480",
            "450",
            "320",
            "256",
            "192",
            "128",
            "96",
            "64"});
            this.BitrateBox.Location = new System.Drawing.Point(291, 150);
            this.BitrateBox.Name = "BitrateBox";
            this.BitrateBox.Size = new System.Drawing.Size(55, 21);
            this.BitrateBox.TabIndex = 7;
            this.BitrateBox.SelectedIndexChanged += new System.EventHandler(this.BitrateBox_SelectedIndexChanged);
            // 
            // BitrateLabel
            // 
            this.BitrateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BitrateLabel.Enabled = false;
            this.BitrateLabel.Location = new System.Drawing.Point(213, 131);
            this.BitrateLabel.Name = "BitrateLabel";
            this.BitrateLabel.Size = new System.Drawing.Size(86, 13);
            this.BitrateLabel.TabIndex = 14;
            this.BitrateLabel.Text = "Bitrate:";
            this.BitrateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OverrideTempoNow
            // 
            this.OverrideTempoNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OverrideTempoNow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OverrideTempoNow.Location = new System.Drawing.Point(9, 111);
            this.OverrideTempoNow.Name = "OverrideTempoNow";
            this.OverrideTempoNow.Size = new System.Drawing.Size(146, 28);
            this.OverrideTempoNow.TabIndex = 4;
            this.OverrideTempoNow.Text = "OverrideMIDITempo";
            this.OverrideTempoNow.UseVisualStyleBackColor = true;
            this.OverrideTempoNow.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FXDisable
            // 
            this.FXDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FXDisable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FXDisable.Location = new System.Drawing.Point(9, 83);
            this.FXDisable.Name = "FXDisable";
            this.FXDisable.Size = new System.Drawing.Size(361, 18);
            this.FXDisable.TabIndex = 3;
            this.FXDisable.Text = "DisableEffects";
            this.FXDisable.UseVisualStyleBackColor = true;
            this.FXDisable.CheckedChanged += new System.EventHandler(this.FXDisable_CheckedChanged);
            // 
            // Noteoff1
            // 
            this.Noteoff1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Noteoff1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Noteoff1.Location = new System.Drawing.Point(9, 40);
            this.Noteoff1.Name = "Noteoff1";
            this.Noteoff1.Size = new System.Drawing.Size(364, 37);
            this.Noteoff1.TabIndex = 2;
            this.Noteoff1.Text = "NoteOff1";
            this.Noteoff1.UseVisualStyleBackColor = true;
            this.Noteoff1.CheckedChanged += new System.EventHandler(this.Noteoff1_CheckedChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(356, 51);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(20, 13);
            this.Label6.TabIndex = 10;
            this.Label6.Text = "Hz";
            // 
            // FrequencyBox
            // 
            this.FrequencyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FrequencyBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FrequencyBox.FormattingEnabled = true;
            this.FrequencyBox.Items.AddRange(new object[] {
            "192000",
            "176400",
            "142180",
            "96000",
            "88200",
            "74750",
            "66150",
            "50400",
            "50000",
            "48000",
            "47250 ",
            "44100",
            "44056 ",
            "37800",
            "32000",
            "22050",
            "16000",
            "11025",
            "8000",
            "4000"});
            this.FrequencyBox.Location = new System.Drawing.Point(291, 47);
            this.FrequencyBox.Name = "FrequencyBox";
            this.FrequencyBox.Size = new System.Drawing.Size(66, 21);
            this.FrequencyBox.TabIndex = 0;
            this.FrequencyBox.SelectedIndexChanged += new System.EventHandler(this.FrequencyBox_SelectedIndexChanged);
            // 
            // AudioFreqLabel
            // 
            this.AudioFreqLabel.AutoSize = true;
            this.AudioFreqLabel.Location = new System.Drawing.Point(6, 51);
            this.AudioFreqLabel.Name = "AudioFreqLabel";
            this.AudioFreqLabel.Size = new System.Drawing.Size(55, 13);
            this.AudioFreqLabel.TabIndex = 8;
            this.AudioFreqLabel.Text = "AudioFreq";
            // 
            // CheckTempo
            // 
            this.CheckTempo.Enabled = true;
            this.CheckTempo.Tick += new System.EventHandler(this.CheckTempo_Tick);
            // 
            // AudioSettings
            // 
            this.AudioSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioSettings.Controls.Add(this.SincInter);
            this.AudioSettings.Controls.Add(this.MaxVoicesLabel);
            this.AudioSettings.Controls.Add(this.MaxVoices);
            this.AudioSettings.Controls.Add(this.AudioFreqLabel);
            this.AudioSettings.Controls.Add(this.FrequencyBox);
            this.AudioSettings.Controls.Add(this.Label6);
            this.AudioSettings.Location = new System.Drawing.Point(12, 12);
            this.AudioSettings.Name = "AudioSettings";
            this.AudioSettings.Size = new System.Drawing.Size(382, 111);
            this.AudioSettings.TabIndex = 9;
            this.AudioSettings.TabStop = false;
            this.AudioSettings.Text = "AudioSettings";
            // 
            // SincInter
            // 
            this.SincInter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SincInter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SincInter.Location = new System.Drawing.Point(9, 80);
            this.SincInter.Name = "SincInter";
            this.SincInter.Size = new System.Drawing.Size(361, 18);
            this.SincInter.TabIndex = 35;
            this.SincInter.Text = "SincInter";
            this.SincInter.UseVisualStyleBackColor = true;
            this.SincInter.CheckedChanged += new System.EventHandler(this.SincInter_CheckedChanged);
            // 
            // MaxVoicesLabel
            // 
            this.MaxVoicesLabel.AutoSize = true;
            this.MaxVoicesLabel.Location = new System.Drawing.Point(6, 21);
            this.MaxVoicesLabel.Name = "MaxVoicesLabel";
            this.MaxVoicesLabel.Size = new System.Drawing.Size(85, 13);
            this.MaxVoicesLabel.TabIndex = 34;
            this.MaxVoicesLabel.Text = "MaxVoicesLabel";
            // 
            // MaxVoices
            // 
            this.MaxVoices.Location = new System.Drawing.Point(291, 19);
            this.MaxVoices.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MaxVoices.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxVoices.Name = "MaxVoices";
            this.MaxVoices.Size = new System.Drawing.Size(80, 20);
            this.MaxVoices.TabIndex = 33;
            this.MaxVoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaxVoices.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MaxVoices.ValueChanged += new System.EventHandler(this.MaxVoices_ValueChanged);
            // 
            // ChannelsSettings
            // 
            this.ChannelsSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChannelsSettings.Location = new System.Drawing.Point(12, 315);
            this.ChannelsSettings.Name = "ChannelsSettings";
            this.ChannelsSettings.Size = new System.Drawing.Size(140, 23);
            this.ChannelsSettings.TabIndex = 10;
            this.ChannelsSettings.Text = "ChannelsSettings";
            this.ChannelsSettings.UseVisualStyleBackColor = true;
            this.ChannelsSettings.Click += new System.EventHandler(this.ChannelsSettings_Click);
            // 
            // AdvancedSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(406, 350);
            this.ControlBox = false;
            this.Controls.Add(this.ChannelsSettings);
            this.Controls.Add(this.AudioSettings);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.StreamSettings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdvancedSettings";
            this.StreamSettings.ResumeLayout(false);
            this.StreamSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RTFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempoValue)).EndInit();
            this.AudioSettings.ResumeLayout(false);
            this.AudioSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxVoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OKBtn;
        internal System.Windows.Forms.GroupBox StreamSettings;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox FrequencyBox;
        internal System.Windows.Forms.Label AudioFreqLabel;
        internal System.Windows.Forms.CheckBox FXDisable;
        internal System.Windows.Forms.CheckBox Noteoff1;
        internal System.Windows.Forms.CheckBox OverrideTempoNow;
        internal System.Windows.Forms.ComboBox BitrateBox;
        private System.Windows.Forms.Label BitrateLabel;
        internal System.Windows.Forms.CheckBox ConstantBitrate;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RTFPS;
        private System.Windows.Forms.Label RTFPSLabel;
        private System.Windows.Forms.TrackBar TempoValue;
        private System.Windows.Forms.Label TempoCurrent;
        private System.Windows.Forms.Timer CheckTempo;
        private System.Windows.Forms.GroupBox AudioSettings;
        internal System.Windows.Forms.Label MaxVoicesLabel;
        public System.Windows.Forms.NumericUpDown MaxVoices;
        private System.Windows.Forms.Button ChannelsSettings;
        internal System.Windows.Forms.CheckBox SincInter;
    }
}