namespace KeppyMIDIConverter
{
    partial class InfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoDialog));
            this.CurrentLogo = new System.Windows.Forms.PictureBox();
            this.TaCI = new System.Windows.Forms.Label();
            this.ConverterVerLabel = new System.Windows.Forms.Label();
            this.BASSVerLabel = new System.Windows.Forms.Label();
            this.BASSMIDIVerLabel = new System.Windows.Forms.Label();
            this.CompilerDateLabel = new System.Windows.Forms.Label();
            this.WindowsInstallInfo = new System.Windows.Forms.GroupBox();
            this.WindowsBuild = new System.Windows.Forms.Label();
            this.WindowsBuildLabel = new System.Windows.Forms.Label();
            this.WindowsName = new System.Windows.Forms.Label();
            this.WindowsNameLabel = new System.Windows.Forms.Label();
            this.ConverterInfo = new System.Windows.Forms.GroupBox();
            this.CompilerDate = new System.Windows.Forms.Label();
            this.BASSMIDIVer = new System.Windows.Forms.Label();
            this.BASSVer = new System.Windows.Forms.Label();
            this.ConverterVer = new System.Windows.Forms.Label();
            this.OKClose = new System.Windows.Forms.Button();
            this.CTC = new System.Windows.Forms.Button();
            this.CFU = new System.Windows.Forms.Button();
            this.DonateBtn = new System.Windows.Forms.Button();
            this.BranchToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DisableBB = new System.Windows.Forms.MenuItem();
            this.GitHubLink = new System.Windows.Forms.LinkLabel();
            this.PatreonBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLogo)).BeginInit();
            this.WindowsInstallInfo.SuspendLayout();
            this.ConverterInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurrentLogo
            // 
            this.CurrentLogo.Image = global::KeppyMIDIConverter.Properties.Resources.mainlogo;
            this.CurrentLogo.Location = new System.Drawing.Point(12, 12);
            this.CurrentLogo.Name = "CurrentLogo";
            this.CurrentLogo.Size = new System.Drawing.Size(79, 80);
            this.CurrentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CurrentLogo.TabIndex = 0;
            this.CurrentLogo.TabStop = false;
            // 
            // TaCI
            // 
            this.TaCI.AutoSize = true;
            this.TaCI.Location = new System.Drawing.Point(97, 12);
            this.TaCI.Name = "TaCI";
            this.TaCI.Size = new System.Drawing.Size(38, 13);
            this.TaCI.TabIndex = 1;
            this.TaCI.Text = "{TaCI}";
            // 
            // ConverterVerLabel
            // 
            this.ConverterVerLabel.AutoSize = true;
            this.ConverterVerLabel.Location = new System.Drawing.Point(6, 20);
            this.ConverterVerLabel.Name = "ConverterVerLabel";
            this.ConverterVerLabel.Size = new System.Drawing.Size(77, 13);
            this.ConverterVerLabel.TabIndex = 0;
            this.ConverterVerLabel.Text = "{ConverterVer}";
            // 
            // BASSVerLabel
            // 
            this.BASSVerLabel.AutoSize = true;
            this.BASSVerLabel.Location = new System.Drawing.Point(6, 39);
            this.BASSVerLabel.Name = "BASSVerLabel";
            this.BASSVerLabel.Size = new System.Drawing.Size(59, 13);
            this.BASSVerLabel.TabIndex = 1;
            this.BASSVerLabel.Text = "{BASSVer}";
            // 
            // BASSMIDIVerLabel
            // 
            this.BASSMIDIVerLabel.AutoSize = true;
            this.BASSMIDIVerLabel.Location = new System.Drawing.Point(6, 58);
            this.BASSMIDIVerLabel.Name = "BASSMIDIVerLabel";
            this.BASSMIDIVerLabel.Size = new System.Drawing.Size(82, 13);
            this.BASSMIDIVerLabel.TabIndex = 2;
            this.BASSMIDIVerLabel.Text = "{BASSMIDIVer}";
            // 
            // CompilerDateLabel
            // 
            this.CompilerDateLabel.AutoSize = true;
            this.CompilerDateLabel.Location = new System.Drawing.Point(6, 77);
            this.CompilerDateLabel.Name = "CompilerDateLabel";
            this.CompilerDateLabel.Size = new System.Drawing.Size(78, 13);
            this.CompilerDateLabel.TabIndex = 3;
            this.CompilerDateLabel.Text = "{CompilerDate}";
            // 
            // WindowsInstallInfo
            // 
            this.WindowsInstallInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowsInstallInfo.Controls.Add(this.WindowsBuild);
            this.WindowsInstallInfo.Controls.Add(this.WindowsBuildLabel);
            this.WindowsInstallInfo.Controls.Add(this.WindowsName);
            this.WindowsInstallInfo.Controls.Add(this.WindowsNameLabel);
            this.WindowsInstallInfo.Location = new System.Drawing.Point(10, 201);
            this.WindowsInstallInfo.Name = "WindowsInstallInfo";
            this.WindowsInstallInfo.Size = new System.Drawing.Size(363, 59);
            this.WindowsInstallInfo.TabIndex = 6;
            this.WindowsInstallInfo.TabStop = false;
            this.WindowsInstallInfo.Text = "{WindowsInstallInfo}";
            // 
            // WindowsBuild
            // 
            this.WindowsBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WindowsBuild.AutoSize = true;
            this.WindowsBuild.Location = new System.Drawing.Point(120, 39);
            this.WindowsBuild.Name = "WindowsBuild";
            this.WindowsBuild.Size = new System.Drawing.Size(61, 13);
            this.WindowsBuild.TabIndex = 9;
            this.WindowsBuild.Text = "WIN VERS";
            // 
            // WindowsBuildLabel
            // 
            this.WindowsBuildLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WindowsBuildLabel.AutoSize = true;
            this.WindowsBuildLabel.Location = new System.Drawing.Point(6, 39);
            this.WindowsBuildLabel.Name = "WindowsBuildLabel";
            this.WindowsBuildLabel.Size = new System.Drawing.Size(82, 13);
            this.WindowsBuildLabel.TabIndex = 3;
            this.WindowsBuildLabel.Text = "{WindowsBuild}";
            // 
            // WindowsName
            // 
            this.WindowsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WindowsName.AutoSize = true;
            this.WindowsName.Location = new System.Drawing.Point(120, 20);
            this.WindowsName.Name = "WindowsName";
            this.WindowsName.Size = new System.Drawing.Size(63, 13);
            this.WindowsName.TabIndex = 8;
            this.WindowsName.Text = "WIN NAME";
            // 
            // WindowsNameLabel
            // 
            this.WindowsNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WindowsNameLabel.AutoSize = true;
            this.WindowsNameLabel.Location = new System.Drawing.Point(6, 20);
            this.WindowsNameLabel.Name = "WindowsNameLabel";
            this.WindowsNameLabel.Size = new System.Drawing.Size(87, 13);
            this.WindowsNameLabel.TabIndex = 2;
            this.WindowsNameLabel.Text = "{WindowsName}";
            // 
            // ConverterInfo
            // 
            this.ConverterInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConverterInfo.Controls.Add(this.CompilerDate);
            this.ConverterInfo.Controls.Add(this.BASSMIDIVer);
            this.ConverterInfo.Controls.Add(this.BASSVer);
            this.ConverterInfo.Controls.Add(this.ConverterVer);
            this.ConverterInfo.Controls.Add(this.CompilerDateLabel);
            this.ConverterInfo.Controls.Add(this.BASSMIDIVerLabel);
            this.ConverterInfo.Controls.Add(this.BASSVerLabel);
            this.ConverterInfo.Controls.Add(this.ConverterVerLabel);
            this.ConverterInfo.Location = new System.Drawing.Point(10, 97);
            this.ConverterInfo.Name = "ConverterInfo";
            this.ConverterInfo.Size = new System.Drawing.Size(363, 98);
            this.ConverterInfo.TabIndex = 5;
            this.ConverterInfo.TabStop = false;
            this.ConverterInfo.Text = "{ConverterInfo}";
            // 
            // CompilerDate
            // 
            this.CompilerDate.AutoSize = true;
            this.CompilerDate.Location = new System.Drawing.Point(120, 77);
            this.CompilerDate.Name = "CompilerDate";
            this.CompilerDate.Size = new System.Drawing.Size(63, 13);
            this.CompilerDate.TabIndex = 7;
            this.CompilerDate.Text = "COMP DAT";
            // 
            // BASSMIDIVer
            // 
            this.BASSMIDIVer.AutoSize = true;
            this.BASSMIDIVer.Location = new System.Drawing.Point(120, 58);
            this.BASSMIDIVer.Name = "BASSMIDIVer";
            this.BASSMIDIVer.Size = new System.Drawing.Size(54, 13);
            this.BASSMIDIVer.TabIndex = 6;
            this.BASSMIDIVer.Text = "LIB VER2";
            // 
            // BASSVer
            // 
            this.BASSVer.AutoSize = true;
            this.BASSVer.Location = new System.Drawing.Point(120, 39);
            this.BASSVer.Name = "BASSVer";
            this.BASSVer.Size = new System.Drawing.Size(54, 13);
            this.BASSVer.TabIndex = 5;
            this.BASSVer.Text = "LIB VER1";
            // 
            // ConverterVer
            // 
            this.ConverterVer.AutoSize = true;
            this.ConverterVer.Location = new System.Drawing.Point(120, 20);
            this.ConverterVer.Name = "ConverterVer";
            this.ConverterVer.Size = new System.Drawing.Size(62, 13);
            this.ConverterVer.TabIndex = 4;
            this.ConverterVer.Text = "CON VERS";
            // 
            // OKClose
            // 
            this.OKClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKClose.Location = new System.Drawing.Point(287, 266);
            this.OKClose.Name = "OKClose";
            this.OKClose.Size = new System.Drawing.Size(87, 23);
            this.OKClose.TabIndex = 7;
            this.OKClose.Text = "OK";
            this.OKClose.UseVisualStyleBackColor = true;
            this.OKClose.Click += new System.EventHandler(this.OKClose_Click);
            // 
            // CTC
            // 
            this.CTC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CTC.Location = new System.Drawing.Point(9, 266);
            this.CTC.Name = "CTC";
            this.CTC.Size = new System.Drawing.Size(105, 23);
            this.CTC.TabIndex = 8;
            this.CTC.Text = "Copy to clipboard";
            this.CTC.UseVisualStyleBackColor = true;
            this.CTC.Click += new System.EventHandler(this.CTC_Click);
            // 
            // CFU
            // 
            this.CFU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CFU.Location = new System.Drawing.Point(120, 266);
            this.CFU.Name = "CFU";
            this.CFU.Size = new System.Drawing.Size(105, 23);
            this.CFU.TabIndex = 9;
            this.CFU.Text = "Check for updates";
            this.CFU.UseVisualStyleBackColor = true;
            this.CFU.Click += new System.EventHandler(this.CFU_Click);
            // 
            // DonateBtn
            // 
            this.DonateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DonateBtn.Image = global::KeppyMIDIConverter.Properties.Resources.ppdonate;
            this.DonateBtn.Location = new System.Drawing.Point(286, 12);
            this.DonateBtn.Name = "DonateBtn";
            this.DonateBtn.Size = new System.Drawing.Size(87, 23);
            this.DonateBtn.TabIndex = 11;
            this.DonateBtn.Text = "Donate";
            this.DonateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DonateBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DonateBtn.UseVisualStyleBackColor = true;
            this.DonateBtn.Click += new System.EventHandler(this.DonateBtn_Click);
            // 
            // BranchToolTip
            // 
            this.BranchToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.BranchToolTip.ToolTipTitle = "Branch info";
            // 
            // DisableBB
            // 
            this.DisableBB.Index = -1;
            this.DisableBB.Text = "";
            // 
            // GitHubLink
            // 
            this.GitHubLink.AutoSize = true;
            this.GitHubLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.GitHubLink.Location = new System.Drawing.Point(97, 77);
            this.GitHubLink.Name = "GitHubLink";
            this.GitHubLink.Size = new System.Drawing.Size(95, 13);
            this.GitHubLink.TabIndex = 3;
            this.GitHubLink.TabStop = true;
            this.GitHubLink.Text = "{SourceCodeText}";
            this.GitHubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLink_LinkClicked);
            // 
            // PatreonBtn
            // 
            this.PatreonBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PatreonBtn.Image = global::KeppyMIDIConverter.Properties.Resources.patronsm;
            this.PatreonBtn.Location = new System.Drawing.Point(286, 41);
            this.PatreonBtn.Name = "PatreonBtn";
            this.PatreonBtn.Size = new System.Drawing.Size(87, 23);
            this.PatreonBtn.TabIndex = 13;
            this.PatreonBtn.Text = "Patreon";
            this.PatreonBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PatreonBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PatreonBtn.UseVisualStyleBackColor = true;
            this.PatreonBtn.Click += new System.EventHandler(this.PatreonBtn_Click);
            // 
            // InfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 298);
            this.Controls.Add(this.PatreonBtn);
            this.Controls.Add(this.DonateBtn);
            this.Controls.Add(this.CFU);
            this.Controls.Add(this.CTC);
            this.Controls.Add(this.OKClose);
            this.Controls.Add(this.WindowsInstallInfo);
            this.Controls.Add(this.ConverterInfo);
            this.Controls.Add(this.GitHubLink);
            this.Controls.Add(this.TaCI);
            this.Controls.Add(this.CurrentLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "{IATP}";
            this.Load += new System.EventHandler(this.InfoDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLogo)).EndInit();
            this.WindowsInstallInfo.ResumeLayout(false);
            this.WindowsInstallInfo.PerformLayout();
            this.ConverterInfo.ResumeLayout(false);
            this.ConverterInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CurrentLogo;
        private System.Windows.Forms.Label TaCI;
        private System.Windows.Forms.LinkLabel GitHubLink;
        private System.Windows.Forms.Label ConverterVerLabel;
        private System.Windows.Forms.Label BASSVerLabel;
        private System.Windows.Forms.Label BASSMIDIVerLabel;
        private System.Windows.Forms.Label CompilerDateLabel;
        private System.Windows.Forms.GroupBox WindowsInstallInfo;
        private System.Windows.Forms.Label WindowsBuild;
        private System.Windows.Forms.Label WindowsBuildLabel;
        private System.Windows.Forms.Label WindowsName;
        private System.Windows.Forms.Label WindowsNameLabel;
        private System.Windows.Forms.GroupBox ConverterInfo;
        private System.Windows.Forms.Label CompilerDate;
        private System.Windows.Forms.Label BASSMIDIVer;
        private System.Windows.Forms.Label BASSVer;
        private System.Windows.Forms.Label ConverterVer;
        private System.Windows.Forms.Button OKClose;
        private System.Windows.Forms.Button CTC;
        private System.Windows.Forms.Button CFU;
        private System.Windows.Forms.Button DonateBtn;
        private System.Windows.Forms.ToolTip BranchToolTip;
        private System.Windows.Forms.MenuItem DisableBB;
        private System.Windows.Forms.Button PatreonBtn;
    }
}