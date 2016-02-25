namespace KeppySpartanMIDIConverter
{
    partial class Informations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informations));
            this.label1 = new System.Windows.Forms.Label();
            this.Versionlabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.KeppyVer = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BASSINFO = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.InfoPg = new System.Windows.Forms.TabPage();
            this.UpdtPg = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LatestVersion = new System.Windows.Forms.Label();
            this.ThisVersion = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.InfoPg.SuspendLayout();
            this.UpdtPg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 104);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // Versionlabel
            // 
            this.Versionlabel.AutoSize = true;
            this.Versionlabel.Location = new System.Drawing.Point(212, 21);
            this.Versionlabel.Name = "Versionlabel";
            this.Versionlabel.Size = new System.Drawing.Size(122, 13);
            this.Versionlabel.TabIndex = 2;
            this.Versionlabel.Text = "Keppy optimization here";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(460, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(427, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Un4seen website";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(346, 185);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "License";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // KeppyVer
            // 
            this.KeppyVer.AutoSize = true;
            this.KeppyVer.Location = new System.Drawing.Point(212, 8);
            this.KeppyVer.Name = "KeppyVer";
            this.KeppyVer.Size = new System.Drawing.Size(121, 13);
            this.KeppyVer.TabIndex = 6;
            this.KeppyVer.Text = "Keppy Title with version";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Keppy Studios";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::KeppyMIDIConverter.Properties.Resources.mainlogo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Click the logo to visit my official website.");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(212, 151);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(290, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/KaleidonKep99/Keppys-MIDI-Converter";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.BASSINFO);
            this.panel1.Location = new System.Drawing.Point(6, 214);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 58);
            this.panel1.TabIndex = 8;
            // 
            // BASSINFO
            // 
            this.BASSINFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BASSINFO.Location = new System.Drawing.Point(0, 0);
            this.BASSINFO.Name = "BASSINFO";
            this.BASSINFO.Size = new System.Drawing.Size(521, 54);
            this.BASSINFO.TabIndex = 0;
            this.BASSINFO.Text = "A\r\na\r\na\r\na";
            this.BASSINFO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.InfoPg);
            this.tabControl1.Controls.Add(this.UpdtPg);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(545, 304);
            this.tabControl1.TabIndex = 9;
            // 
            // InfoPg
            // 
            this.InfoPg.Controls.Add(this.pictureBox1);
            this.InfoPg.Controls.Add(this.panel1);
            this.InfoPg.Controls.Add(this.label1);
            this.InfoPg.Controls.Add(this.linkLabel1);
            this.InfoPg.Controls.Add(this.Versionlabel);
            this.InfoPg.Controls.Add(this.KeppyVer);
            this.InfoPg.Controls.Add(this.button3);
            this.InfoPg.Controls.Add(this.button2);
            this.InfoPg.Location = new System.Drawing.Point(4, 22);
            this.InfoPg.Name = "InfoPg";
            this.InfoPg.Padding = new System.Windows.Forms.Padding(3);
            this.InfoPg.Size = new System.Drawing.Size(537, 278);
            this.InfoPg.TabIndex = 0;
            this.InfoPg.Text = "Information";
            this.InfoPg.UseVisualStyleBackColor = true;
            // 
            // UpdtPg
            // 
            this.UpdtPg.Controls.Add(this.pictureBox2);
            this.UpdtPg.Controls.Add(this.label2);
            this.UpdtPg.Controls.Add(this.LatestVersion);
            this.UpdtPg.Controls.Add(this.ThisVersion);
            this.UpdtPg.Controls.Add(this.button5);
            this.UpdtPg.Location = new System.Drawing.Point(4, 22);
            this.UpdtPg.Name = "UpdtPg";
            this.UpdtPg.Padding = new System.Windows.Forms.Padding(3);
            this.UpdtPg.Size = new System.Drawing.Size(537, 278);
            this.UpdtPg.TabIndex = 1;
            this.UpdtPg.Text = "Updater";
            this.UpdtPg.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::KeppyMIDIConverter.Properties.Resources.updatebk;
            this.pictureBox2.Location = new System.Drawing.Point(170, 78);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(387, 206);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "KMC\'s Update Checker";
            // 
            // LatestVersion
            // 
            this.LatestVersion.AutoSize = true;
            this.LatestVersion.Location = new System.Drawing.Point(7, 62);
            this.LatestVersion.Name = "LatestVersion";
            this.LatestVersion.Size = new System.Drawing.Size(375, 13);
            this.LatestVersion.TabIndex = 2;
            this.LatestVersion.Text = "Click on \"Check for updates\" to check for the latest version of the converter.";
            // 
            // ThisVersion
            // 
            this.ThisVersion.AutoSize = true;
            this.ThisVersion.Location = new System.Drawing.Point(7, 46);
            this.ThisVersion.Name = "ThisVersion";
            this.ThisVersion.Size = new System.Drawing.Size(340, 13);
            this.ThisVersion.TabIndex = 1;
            this.ThisVersion.Text = "The current version of the driver, installed on your system, is: 10.0.2";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(425, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Check for updates";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Informations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 345);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Informations";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Information";
            this.Load += new System.EventHandler(this.Informations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.InfoPg.ResumeLayout(false);
            this.InfoPg.PerformLayout();
            this.UpdtPg.ResumeLayout(false);
            this.UpdtPg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Versionlabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label KeppyVer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label BASSINFO;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage InfoPg;
        private System.Windows.Forms.TabPage UpdtPg;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label LatestVersion;
        private System.Windows.Forms.Label ThisVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}