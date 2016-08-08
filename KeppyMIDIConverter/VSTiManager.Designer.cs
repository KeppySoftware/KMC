namespace KeppyMIDIConverter
{
    partial class VSTiManager
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Unload = new System.Windows.Forms.Button();
            this.Load1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.VSTImport = new System.Windows.Forms.Button();
            this.VSTUse = new System.Windows.Forms.CheckBox();
            this.VSTiImportDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Unload);
            this.panel2.Controls.Add(this.Load1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 37);
            this.panel2.TabIndex = 1;
            // 
            // Unload
            // 
            this.Unload.Enabled = false;
            this.Unload.Location = new System.Drawing.Point(497, 6);
            this.Unload.Name = "Unload";
            this.Unload.Size = new System.Drawing.Size(75, 23);
            this.Unload.TabIndex = 2;
            this.Unload.Text = "Unload";
            this.Unload.UseVisualStyleBackColor = true;
            this.Unload.Click += new System.EventHandler(this.Unload_Click);
            // 
            // Load1
            // 
            this.Load1.Location = new System.Drawing.Point(416, 6);
            this.Load1.Name = "Load1";
            this.Load1.Size = new System.Drawing.Size(75, 23);
            this.Load1.TabIndex = 1;
            this.Load1.Text = "Load";
            this.Load1.UseVisualStyleBackColor = true;
            this.Load1.Click += new System.EventHandler(this.Load1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empty slot 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VSTImport
            // 
            this.VSTImport.Enabled = false;
            this.VSTImport.Location = new System.Drawing.Point(208, 57);
            this.VSTImport.Name = "VSTImport";
            this.VSTImport.Size = new System.Drawing.Size(370, 23);
            this.VSTImport.TabIndex = 19;
            this.VSTImport.Text = "Open the VST DSP manager...";
            this.VSTImport.UseVisualStyleBackColor = true;
            this.VSTImport.Click += new System.EventHandler(this.VSTImport_Click);
            // 
            // VSTUse
            // 
            this.VSTUse.AutoSize = true;
            this.VSTUse.Location = new System.Drawing.Point(24, 61);
            this.VSTUse.Name = "VSTUse";
            this.VSTUse.Size = new System.Drawing.Size(179, 17);
            this.VSTUse.TabIndex = 18;
            this.VSTUse.Text = "I want to apply a VST DSPs too.";
            this.VSTUse.UseVisualStyleBackColor = true;
            this.VSTUse.CheckedChanged += new System.EventHandler(this.VSTUse_CheckedChanged);
            // 
            // VSTiImportDialog
            // 
            this.VSTiImportDialog.Filter = "VST instruments (*.dll)|*.dll;";
            // 
            // VSTiManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 92);
            this.Controls.Add(this.VSTImport);
            this.Controls.Add(this.VSTUse);
            this.Controls.Add(this.panel2);
            this.Name = "VSTiManager";
            this.Text = "VSTiManager";
            this.Load += new System.EventHandler(this.VSTiManager_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Unload;
        private System.Windows.Forms.Button Load1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button VSTImport;
        private System.Windows.Forms.CheckBox VSTUse;
        private System.Windows.Forms.OpenFileDialog VSTiImportDialog;

    }
}