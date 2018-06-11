namespace KeppyMIDIConverter
{
    partial class TracksToIgnore
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
            this.TracksCheckboxes = new System.Windows.Forms.CheckedListBox();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TracksCheckboxes
            // 
            this.TracksCheckboxes.BackColor = System.Drawing.Color.Black;
            this.TracksCheckboxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TracksCheckboxes.Dock = System.Windows.Forms.DockStyle.Top;
            this.TracksCheckboxes.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TracksCheckboxes.ForeColor = System.Drawing.Color.White;
            this.TracksCheckboxes.FormattingEnabled = true;
            this.TracksCheckboxes.Location = new System.Drawing.Point(0, 0);
            this.TracksCheckboxes.Name = "TracksCheckboxes";
            this.TracksCheckboxes.Size = new System.Drawing.Size(508, 240);
            this.TracksCheckboxes.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.Location = new System.Drawing.Point(418, 254);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // TracksToIgnore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 292);
            this.ControlBox = false;
            this.Controls.Add(this.OK);
            this.Controls.Add(this.TracksCheckboxes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TracksToIgnore";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TracksToIgnore";
            this.Load += new System.EventHandler(this.TracksToIgnore_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox TracksCheckboxes;
        private System.Windows.Forms.Button OK;
    }
}