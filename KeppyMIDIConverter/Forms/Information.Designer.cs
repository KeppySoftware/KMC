namespace KeppyMIDIConverter
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
            this.Credits = new System.Windows.Forms.Label();
            this.Versionlabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.KeppyVer = new System.Windows.Forms.Label();
            this.Tipperino = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.TranslationInfo = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.InfoPg = new System.Windows.Forms.TabPage();
            this.UpdtPg = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.LatestVersion = new System.Windows.Forms.Label();
            this.ThisVersion = new System.Windows.Forms.Label();
            this.CFU = new System.Windows.Forms.Button();
            this.DonateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.InfoPg.SuspendLayout();
            this.UpdtPg.SuspendLayout();
            this.SuspendLayout();
            // 
            // Credits
            // 
            this.Credits.Location = new System.Drawing.Point(212, 46);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(317, 104);
            this.Credits.TabIndex = 1;
            this.Credits.Text = resources.GetString("Credits.Text");
            // 
            // Versionlabel
            // 
            this.Versionlabel.Location = new System.Drawing.Point(212, 20);
            this.Versionlabel.Name = "Versionlabel";
            this.Versionlabel.Size = new System.Drawing.Size(317, 13);
            this.Versionlabel.TabIndex = 2;
            this.Versionlabel.Text = "Keppy optimization here";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(460, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(241, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Un4seen website";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(379, 230);
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
            this.KeppyVer.Location = new System.Drawing.Point(212, 7);
            this.KeppyVer.Name = "KeppyVer";
            this.KeppyVer.Size = new System.Drawing.Size(119, 13);
            this.KeppyVer.TabIndex = 6;
            this.KeppyVer.Text = "Keppy Title with version";
            // 
            // Tipperino
            // 
            this.Tipperino.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tipperino.ToolTipTitle = "Keppy Studios";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = global::KeppyMIDIConverter.Properties.Resources.mainlogo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(212, 150);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(287, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/KaleidonKep99/Keppys-MIDI-Converter";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // TranslationInfo
            // 
            this.TranslationInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TranslationInfo.AutoSize = true;
            this.TranslationInfo.Location = new System.Drawing.Point(212, 177);
            this.TranslationInfo.Name = "TranslationInfo";
            this.TranslationInfo.Size = new System.Drawing.Size(83, 13);
            this.TranslationInfo.TabIndex = 1;
            this.TranslationInfo.Text = "Translation by A";
            this.TranslationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TranslationInfo.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.InfoPg);
            this.tabControl1.Controls.Add(this.UpdtPg);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(545, 222);
            this.tabControl1.TabIndex = 9;
            // 
            // InfoPg
            // 
            this.InfoPg.Controls.Add(this.TranslationInfo);
            this.InfoPg.Controls.Add(this.pictureBox1);
            this.InfoPg.Controls.Add(this.Credits);
            this.InfoPg.Controls.Add(this.linkLabel1);
            this.InfoPg.Controls.Add(this.Versionlabel);
            this.InfoPg.Controls.Add(this.KeppyVer);
            this.InfoPg.Location = new System.Drawing.Point(4, 22);
            this.InfoPg.Name = "InfoPg";
            this.InfoPg.Padding = new System.Windows.Forms.Padding(3);
            this.InfoPg.Size = new System.Drawing.Size(537, 196);
            this.InfoPg.TabIndex = 0;
            this.InfoPg.Text = "Information";
            this.InfoPg.UseVisualStyleBackColor = true;
            // 
            // UpdtPg
            // 
            this.UpdtPg.BackgroundImage = global::KeppyMIDIConverter.Properties.Resources.updatebk;
            this.UpdtPg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdtPg.Controls.Add(this.label2);
            this.UpdtPg.Controls.Add(this.LatestVersion);
            this.UpdtPg.Controls.Add(this.ThisVersion);
            this.UpdtPg.Controls.Add(this.CFU);
            this.UpdtPg.Location = new System.Drawing.Point(4, 22);
            this.UpdtPg.Name = "UpdtPg";
            this.UpdtPg.Padding = new System.Windows.Forms.Padding(3);
            this.UpdtPg.Size = new System.Drawing.Size(537, 196);
            this.UpdtPg.TabIndex = 1;
            this.UpdtPg.Text = "Updater";
            this.UpdtPg.UseVisualStyleBackColor = true;
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
            this.LatestVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LatestVersion.Location = new System.Drawing.Point(7, 62);
            this.LatestVersion.Name = "LatestVersion";
            this.LatestVersion.Size = new System.Drawing.Size(375, 134);
            this.LatestVersion.TabIndex = 2;
            this.LatestVersion.Text = "Click on \"Check for updates\" to check for the latest version of the converter.";
            // 
            // ThisVersion
            // 
            this.ThisVersion.AutoSize = true;
            this.ThisVersion.Location = new System.Drawing.Point(7, 46);
            this.ThisVersion.Name = "ThisVersion";
            this.ThisVersion.Size = new System.Drawing.Size(324, 13);
            this.ThisVersion.TabIndex = 1;
            this.ThisVersion.Text = "The current version of the driver, installed on your system, is: 10.0.2";
            // 
            // CFU
            // 
            this.CFU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CFU.Location = new System.Drawing.Point(401, 6);
            this.CFU.Name = "CFU";
            this.CFU.Size = new System.Drawing.Size(130, 39);
            this.CFU.TabIndex = 0;
            this.CFU.Text = "Check for updates";
            this.CFU.UseVisualStyleBackColor = true;
            this.CFU.Click += new System.EventHandler(this.button5_Click);
            // 
            // DonateBtn
            // 
            this.DonateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DonateBtn.Image = global::KeppyMIDIConverter.Properties.Resources.ppdonate;
            this.DonateBtn.Location = new System.Drawing.Point(10, 230);
            this.DonateBtn.Name = "DonateBtn";
            this.DonateBtn.Size = new System.Drawing.Size(174, 23);
            this.DonateBtn.TabIndex = 11;
            this.DonateBtn.Text = "Donate with PayPal";
            this.DonateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DonateBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DonateBtn.UseVisualStyleBackColor = true;
            this.DonateBtn.Click += new System.EventHandler(this.DonateBtn_Click);
            // 
            // Informations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(545, 263);
            this.Controls.Add(this.DonateBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Informations";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Information";
            this.Load += new System.EventHandler(this.Informations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.InfoPg.ResumeLayout(false);
            this.InfoPg.PerformLayout();
            this.UpdtPg.ResumeLayout(false);
            this.UpdtPg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Credits;
        private System.Windows.Forms.Label Versionlabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label KeppyVer;
        private System.Windows.Forms.ToolTip Tipperino;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage InfoPg;
        private System.Windows.Forms.TabPage UpdtPg;
        private System.Windows.Forms.Button CFU;
        private System.Windows.Forms.Label LatestVersion;
        private System.Windows.Forms.Label ThisVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TranslationInfo;
        private System.Windows.Forms.Button DonateBtn;
    }
}