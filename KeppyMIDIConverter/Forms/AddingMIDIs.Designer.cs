namespace KeppyMIDIConverter
{
    partial class AddingMIDIs
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
            this.AnalyzerProgressBar = new System.Windows.Forms.ProgressBar();
            this.ParsingMIDIInfoStatus = new System.Windows.Forms.Label();
            this.AnalyzeMIDIs = new System.ComponentModel.BackgroundWorker();
            this.AnalyzerProgress = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // AnalyzerProgressBar
            // 
            this.AnalyzerProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnalyzerProgressBar.Location = new System.Drawing.Point(12, 69);
            this.AnalyzerProgressBar.Name = "AnalyzerProgressBar";
            this.AnalyzerProgressBar.Size = new System.Drawing.Size(332, 23);
            this.AnalyzerProgressBar.TabIndex = 0;
            // 
            // ParsingMIDIInfoStatus
            // 
            this.ParsingMIDIInfoStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParsingMIDIInfoStatus.Location = new System.Drawing.Point(12, 9);
            this.ParsingMIDIInfoStatus.Name = "ParsingMIDIInfoStatus";
            this.ParsingMIDIInfoStatus.Size = new System.Drawing.Size(332, 57);
            this.ParsingMIDIInfoStatus.TabIndex = 1;
            this.ParsingMIDIInfoStatus.Text = "ParsingMIDIInfoStatus";
            this.ParsingMIDIInfoStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnalyzeMIDIs
            // 
            this.AnalyzeMIDIs.WorkerReportsProgress = true;
            this.AnalyzeMIDIs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AnalyzeMIDIs_DoWork);
            this.AnalyzeMIDIs.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AnalyzeMIDIs_RunWorkerCompleted);
            // 
            // AnalyzerProgress
            // 
            this.AnalyzerProgress.Enabled = true;
            this.AnalyzerProgress.Interval = 1;
            this.AnalyzerProgress.Tick += new System.EventHandler(this.AnalyzerProgress_Tick);
            // 
            // AddingMIDIs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 104);
            this.ControlBox = false;
            this.Controls.Add(this.ParsingMIDIInfoStatus);
            this.Controls.Add(this.AnalyzerProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddingMIDIs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddingMIDIs";
            this.Load += new System.EventHandler(this.AddingMIDIs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar AnalyzerProgressBar;
        private System.Windows.Forms.Label ParsingMIDIInfoStatus;
        private System.ComponentModel.BackgroundWorker AnalyzeMIDIs;
        private System.Windows.Forms.Timer AnalyzerProgress;
    }
}