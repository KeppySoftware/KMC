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
            this.button1 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TempoCurrent = new System.Windows.Forms.Label();
            this.TempoValue = new System.Windows.Forms.TrackBar();
            this.RTFPS = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.BitrateBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OverrideTempoNow = new System.Windows.Forms.CheckBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.FrequencyBox = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.FXDisable = new System.Windows.Forms.CheckBox();
            this.Noteoff1 = new System.Windows.Forms.CheckBox();
            this.CheckTempo = new System.Windows.Forms.Timer(this.components);
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TempoValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTFPS)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(315, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.TempoCurrent);
            this.GroupBox1.Controls.Add(this.TempoValue);
            this.GroupBox1.Controls.Add(this.RTFPS);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.checkBox3);
            this.GroupBox1.Controls.Add(this.BitrateBox);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.OverrideTempoNow);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.FrequencyBox);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.FXDisable);
            this.GroupBox1.Controls.Add(this.Noteoff1);
            this.GroupBox1.Location = new System.Drawing.Point(5, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(396, 180);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Settings";
            // 
            // TempoCurrent
            // 
            this.TempoCurrent.Enabled = false;
            this.TempoCurrent.Location = new System.Drawing.Point(150, 123);
            this.TempoCurrent.Name = "TempoCurrent";
            this.TempoCurrent.Size = new System.Drawing.Size(58, 15);
            this.TempoCurrent.TabIndex = 32;
            this.TempoCurrent.Text = "999bpm";
            this.TempoCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TempoValue
            // 
            this.TempoValue.Location = new System.Drawing.Point(213, 109);
            this.TempoValue.Maximum = 80;
            this.TempoValue.Name = "TempoValue";
            this.TempoValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TempoValue.RightToLeftLayout = true;
            this.TempoValue.Size = new System.Drawing.Size(180, 45);
            this.TempoValue.TabIndex = 5;
            this.TempoValue.TickFrequency = 8;
            this.TempoValue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TempoValue.Value = 40;
            this.TempoValue.Scroll += new System.EventHandler(this.TempoValue_Scroll);
            // 
            // RTFPS
            // 
            this.RTFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RTFPS.DecimalPlaces = 1;
            this.RTFPS.Location = new System.Drawing.Point(321, 17);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Real-Time framerate:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(364, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "kbps";
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox3.Location = new System.Drawing.Point(7, 154);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(200, 24);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "Force constant bitrate (OGG Vorbis)";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // BitrateBox
            // 
            this.BitrateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.BitrateBox.Location = new System.Drawing.Point(298, 156);
            this.BitrateBox.Name = "BitrateBox";
            this.BitrateBox.Size = new System.Drawing.Size(66, 21);
            this.BitrateBox.TabIndex = 7;
            this.BitrateBox.SelectedIndexChanged += new System.EventHandler(this.BitrateBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(213, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Bitrate:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OverrideTempoNow
            // 
            this.OverrideTempoNow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OverrideTempoNow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OverrideTempoNow.Location = new System.Drawing.Point(7, 102);
            this.OverrideTempoNow.Name = "OverrideTempoNow";
            this.OverrideTempoNow.Size = new System.Drawing.Size(146, 58);
            this.OverrideTempoNow.TabIndex = 4;
            this.OverrideTempoNow.Text = "Override MIDI tempo";
            this.OverrideTempoNow.UseVisualStyleBackColor = true;
            this.OverrideTempoNow.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(170, 20);
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
            this.FrequencyBox.Location = new System.Drawing.Point(104, 16);
            this.FrequencyBox.Name = "FrequencyBox";
            this.FrequencyBox.Size = new System.Drawing.Size(66, 21);
            this.FrequencyBox.TabIndex = 0;
            this.FrequencyBox.SelectedIndexChanged += new System.EventHandler(this.FrequencyBox_SelectedIndexChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(7, 20);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(87, 13);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Audio frequency:";
            // 
            // FXDisable
            // 
            this.FXDisable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FXDisable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FXDisable.Location = new System.Drawing.Point(7, 85);
            this.FXDisable.Name = "FXDisable";
            this.FXDisable.Size = new System.Drawing.Size(380, 18);
            this.FXDisable.TabIndex = 3;
            this.FXDisable.Text = "Disable sound effects";
            this.FXDisable.UseVisualStyleBackColor = true;
            this.FXDisable.CheckedChanged += new System.EventHandler(this.FXDisable_CheckedChanged);
            // 
            // Noteoff1
            // 
            this.Noteoff1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Noteoff1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Noteoff1.Location = new System.Drawing.Point(7, 42);
            this.Noteoff1.Name = "Noteoff1";
            this.Noteoff1.Size = new System.Drawing.Size(383, 44);
            this.Noteoff1.TabIndex = 2;
            this.Noteoff1.Text = "Only release the oldest instance upon a note off event when there\r\nare overlappin" +
    "g instances of the note.";
            this.Noteoff1.UseVisualStyleBackColor = true;
            this.Noteoff1.CheckedChanged += new System.EventHandler(this.Noteoff1_CheckedChanged);
            // 
            // CheckTempo
            // 
            this.CheckTempo.Enabled = true;
            this.CheckTempo.Tick += new System.EventHandler(this.CheckTempo_Tick);
            // 
            // AdvancedSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(406, 221);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GroupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Advanced settings";
            this.Load += new System.EventHandler(this.AdvancedSettings_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TempoValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTFPS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox FrequencyBox;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.CheckBox FXDisable;
        internal System.Windows.Forms.CheckBox Noteoff1;
        internal System.Windows.Forms.CheckBox OverrideTempoNow;
        internal System.Windows.Forms.ComboBox BitrateBox;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.CheckBox checkBox3;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RTFPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar TempoValue;
        private System.Windows.Forms.Label TempoCurrent;
        private System.Windows.Forms.Timer CheckTempo;
    }
}