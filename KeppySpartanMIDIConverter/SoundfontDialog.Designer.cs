namespace KeppyMIDIConverter
{
    partial class SoundfontDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundfontDialog));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoadBP1 = new System.Windows.Forms.CheckBox();
            this.ImportBtn1 = new System.Windows.Forms.Button();
            this.Preset1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.Bank1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SFPathText1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LoadBP2 = new System.Windows.Forms.CheckBox();
            this.ImportBtn2 = new System.Windows.Forms.Button();
            this.Preset2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.Bank2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.SFPathText2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LoadBP3 = new System.Windows.Forms.CheckBox();
            this.ImportBtn3 = new System.Windows.Forms.Button();
            this.Preset3 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.Bank3 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.SFPathText3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SoundfontImportDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SoundfontImportDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SoundfontImportDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.Unload1 = new System.Windows.Forms.Button();
            this.Unload2 = new System.Windows.Forms.Button();
            this.Unload3 = new System.Windows.Forms.Button();
            this.SFLoadCheck = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Preset1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bank1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Preset2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bank2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Preset3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bank3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LoadBP1);
            this.groupBox1.Controls.Add(this.ImportBtn1);
            this.groupBox1.Controls.Add(this.Preset1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Bank1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SFPathText1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Soundfont 1";
            // 
            // LoadBP1
            // 
            this.LoadBP1.AutoSize = true;
            this.LoadBP1.Enabled = false;
            this.LoadBP1.Location = new System.Drawing.Point(187, 66);
            this.LoadBP1.Name = "LoadBP1";
            this.LoadBP1.Size = new System.Drawing.Size(168, 17);
            this.LoadBP1.TabIndex = 7;
            this.LoadBP1.Text = "Load specific bank and preset";
            this.LoadBP1.UseVisualStyleBackColor = true;
            this.LoadBP1.CheckedChanged += new System.EventHandler(this.LoadBP1_CheckedChanged);
            // 
            // ImportBtn1
            // 
            this.ImportBtn1.Location = new System.Drawing.Point(430, 61);
            this.ImportBtn1.Name = "ImportBtn1";
            this.ImportBtn1.Size = new System.Drawing.Size(121, 23);
            this.ImportBtn1.TabIndex = 6;
            this.ImportBtn1.Text = "Import a soundfont...";
            this.ImportBtn1.UseVisualStyleBackColor = true;
            this.ImportBtn1.Click += new System.EventHandler(this.ImportBtn1_Click);
            // 
            // Preset1
            // 
            this.Preset1.Enabled = false;
            this.Preset1.Location = new System.Drawing.Point(136, 64);
            this.Preset1.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Preset1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Preset1.Name = "Preset1";
            this.Preset1.Size = new System.Drawing.Size(39, 21);
            this.Preset1.TabIndex = 5;
            this.Preset1.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Preset1.ValueChanged += new System.EventHandler(this.Preset1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(95, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Preset:";
            // 
            // Bank1
            // 
            this.Bank1.Enabled = false;
            this.Bank1.Location = new System.Drawing.Point(41, 64);
            this.Bank1.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Bank1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Bank1.Name = "Bank1";
            this.Bank1.Size = new System.Drawing.Size(39, 21);
            this.Bank1.TabIndex = 3;
            this.Bank1.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Bank1.ValueChanged += new System.EventHandler(this.Bank1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bank:";
            // 
            // SFPathText1
            // 
            this.SFPathText1.Location = new System.Drawing.Point(9, 32);
            this.SFPathText1.Name = "SFPathText1";
            this.SFPathText1.ReadOnly = true;
            this.SFPathText1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SFPathText1.Size = new System.Drawing.Size(542, 21);
            this.SFPathText1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Soundfont path:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 87);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LoadBP2);
            this.groupBox2.Controls.Add(this.ImportBtn2);
            this.groupBox2.Controls.Add(this.Preset2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Bank2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.SFPathText2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 92);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Soundfont 2";
            // 
            // LoadBP2
            // 
            this.LoadBP2.AutoSize = true;
            this.LoadBP2.Enabled = false;
            this.LoadBP2.Location = new System.Drawing.Point(187, 66);
            this.LoadBP2.Name = "LoadBP2";
            this.LoadBP2.Size = new System.Drawing.Size(168, 17);
            this.LoadBP2.TabIndex = 8;
            this.LoadBP2.Text = "Load specific bank and preset";
            this.LoadBP2.UseVisualStyleBackColor = true;
            this.LoadBP2.CheckedChanged += new System.EventHandler(this.LoadBP2_CheckedChanged);
            // 
            // ImportBtn2
            // 
            this.ImportBtn2.Location = new System.Drawing.Point(430, 61);
            this.ImportBtn2.Name = "ImportBtn2";
            this.ImportBtn2.Size = new System.Drawing.Size(121, 23);
            this.ImportBtn2.TabIndex = 6;
            this.ImportBtn2.Text = "Import a soundfont...";
            this.ImportBtn2.UseVisualStyleBackColor = true;
            this.ImportBtn2.Click += new System.EventHandler(this.ImportBtn2_Click);
            // 
            // Preset2
            // 
            this.Preset2.Enabled = false;
            this.Preset2.Location = new System.Drawing.Point(136, 64);
            this.Preset2.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Preset2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Preset2.Name = "Preset2";
            this.Preset2.Size = new System.Drawing.Size(39, 21);
            this.Preset2.TabIndex = 5;
            this.Preset2.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Preset2.ValueChanged += new System.EventHandler(this.Preset2_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(95, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Preset:";
            // 
            // Bank2
            // 
            this.Bank2.Enabled = false;
            this.Bank2.Location = new System.Drawing.Point(41, 64);
            this.Bank2.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Bank2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Bank2.Name = "Bank2";
            this.Bank2.Size = new System.Drawing.Size(39, 21);
            this.Bank2.TabIndex = 3;
            this.Bank2.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Bank2.ValueChanged += new System.EventHandler(this.Bank2_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Bank:";
            // 
            // SFPathText2
            // 
            this.SFPathText2.Location = new System.Drawing.Point(9, 32);
            this.SFPathText2.Name = "SFPathText2";
            this.SFPathText2.ReadOnly = true;
            this.SFPathText2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SFPathText2.Size = new System.Drawing.Size(542, 21);
            this.SFPathText2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Soundfont path:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LoadBP3);
            this.groupBox3.Controls.Add(this.ImportBtn3);
            this.groupBox3.Controls.Add(this.Preset3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.Bank3);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.SFPathText3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(12, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(557, 92);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Soundfont 3";
            // 
            // LoadBP3
            // 
            this.LoadBP3.AutoSize = true;
            this.LoadBP3.Enabled = false;
            this.LoadBP3.Location = new System.Drawing.Point(187, 66);
            this.LoadBP3.Name = "LoadBP3";
            this.LoadBP3.Size = new System.Drawing.Size(168, 17);
            this.LoadBP3.TabIndex = 9;
            this.LoadBP3.Text = "Load specific bank and preset";
            this.LoadBP3.UseVisualStyleBackColor = true;
            this.LoadBP3.CheckedChanged += new System.EventHandler(this.LoadBP3_CheckedChanged);
            // 
            // ImportBtn3
            // 
            this.ImportBtn3.Location = new System.Drawing.Point(430, 61);
            this.ImportBtn3.Name = "ImportBtn3";
            this.ImportBtn3.Size = new System.Drawing.Size(121, 23);
            this.ImportBtn3.TabIndex = 6;
            this.ImportBtn3.Text = "Import a soundfont...";
            this.ImportBtn3.UseVisualStyleBackColor = true;
            this.ImportBtn3.Click += new System.EventHandler(this.ImportBtn3_Click);
            // 
            // Preset3
            // 
            this.Preset3.Enabled = false;
            this.Preset3.Location = new System.Drawing.Point(136, 64);
            this.Preset3.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Preset3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Preset3.Name = "Preset3";
            this.Preset3.Size = new System.Drawing.Size(39, 21);
            this.Preset3.TabIndex = 5;
            this.Preset3.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Preset3.ValueChanged += new System.EventHandler(this.Preset3_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(95, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Preset:";
            // 
            // Bank3
            // 
            this.Bank3.Enabled = false;
            this.Bank3.Location = new System.Drawing.Point(41, 64);
            this.Bank3.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Bank3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Bank3.Name = "Bank3";
            this.Bank3.Size = new System.Drawing.Size(39, 21);
            this.Bank3.TabIndex = 3;
            this.Bank3.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Bank3.ValueChanged += new System.EventHandler(this.Bank3_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(6, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Bank:";
            // 
            // SFPathText3
            // 
            this.SFPathText3.Location = new System.Drawing.Point(9, 32);
            this.SFPathText3.Name = "SFPathText3";
            this.SFPathText3.ReadOnly = true;
            this.SFPathText3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SFPathText3.Size = new System.Drawing.Size(542, 21);
            this.SFPathText3.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Soundfont path:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SoundfontImportDialog1
            // 
            this.SoundfontImportDialog1.Filter = "Soundfont files|*.sf2;*.sfz;";
            // 
            // SoundfontImportDialog2
            // 
            this.SoundfontImportDialog2.Filter = "Soundfont files|*.sf2;*.sfz;";
            // 
            // SoundfontImportDialog3
            // 
            this.SoundfontImportDialog3.Filter = "Soundfont files|*.sf2;*.sfz;";
            // 
            // Unload1
            // 
            this.Unload1.Enabled = false;
            this.Unload1.Location = new System.Drawing.Point(12, 395);
            this.Unload1.Name = "Unload1";
            this.Unload1.Size = new System.Drawing.Size(110, 23);
            this.Unload1.TabIndex = 8;
            this.Unload1.Text = "Unload soundfont 1";
            this.Unload1.UseVisualStyleBackColor = true;
            this.Unload1.Click += new System.EventHandler(this.Unload1_Click);
            // 
            // Unload2
            // 
            this.Unload2.Enabled = false;
            this.Unload2.Location = new System.Drawing.Point(128, 395);
            this.Unload2.Name = "Unload2";
            this.Unload2.Size = new System.Drawing.Size(110, 23);
            this.Unload2.TabIndex = 9;
            this.Unload2.Text = "Unload soundfont 2";
            this.Unload2.UseVisualStyleBackColor = true;
            this.Unload2.Click += new System.EventHandler(this.Unload2_Click);
            // 
            // Unload3
            // 
            this.Unload3.Enabled = false;
            this.Unload3.Location = new System.Drawing.Point(244, 395);
            this.Unload3.Name = "Unload3";
            this.Unload3.Size = new System.Drawing.Size(110, 23);
            this.Unload3.TabIndex = 10;
            this.Unload3.Text = "Unload soundfont 3";
            this.Unload3.UseVisualStyleBackColor = true;
            this.Unload3.Click += new System.EventHandler(this.Unload3_Click);
            // 
            // SFLoadCheck
            // 
            this.SFLoadCheck.Enabled = true;
            this.SFLoadCheck.Interval = 1;
            this.SFLoadCheck.Tick += new System.EventHandler(this.SFLoadCheck_Tick);
            // 
            // SoundfontDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 429);
            this.Controls.Add(this.Unload2);
            this.Controls.Add(this.Unload3);
            this.Controls.Add(this.Unload1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoundfontDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Soundfonts manager";
            this.Load += new System.EventHandler(this.SoundfontDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Preset1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bank1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Preset2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bank2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Preset3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bank3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ImportBtn1;
        private System.Windows.Forms.NumericUpDown Preset1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Bank1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SFPathText1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ImportBtn2;
        private System.Windows.Forms.NumericUpDown Preset2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Bank2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SFPathText2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ImportBtn3;
        private System.Windows.Forms.NumericUpDown Preset3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown Bank3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SFPathText3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog SoundfontImportDialog1;
        private System.Windows.Forms.OpenFileDialog SoundfontImportDialog2;
        private System.Windows.Forms.OpenFileDialog SoundfontImportDialog3;
        private System.Windows.Forms.CheckBox LoadBP1;
        private System.Windows.Forms.CheckBox LoadBP2;
        private System.Windows.Forms.CheckBox LoadBP3;
        private System.Windows.Forms.Button Unload1;
        private System.Windows.Forms.Button Unload2;
        private System.Windows.Forms.Button Unload3;
        private System.Windows.Forms.Timer SFLoadCheck;
    }
}