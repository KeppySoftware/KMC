namespace KeppyMIDIConverter
{
    partial class AdvancedVoices
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 1",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 2",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 3",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 4",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 5",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 6",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 7",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 8",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 9",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "Drums",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 11",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 12",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 13",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 14",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 15",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel 16",
            "0"}, -1);
            this.CVList = new System.Windows.Forms.ListView();
            this.CheckVoices = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CVList
            // 
            this.CVList.AllowDrop = true;
            this.CVList.BackColor = System.Drawing.Color.White;
            this.CVList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CVList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CVList.FullRowSelect = true;
            this.CVList.GridLines = true;
            this.CVList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.CVList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16});
            this.CVList.Location = new System.Drawing.Point(0, 0);
            this.CVList.MultiSelect = false;
            this.CVList.Name = "CVList";
            this.CVList.ShowGroups = false;
            this.CVList.Size = new System.Drawing.Size(381, 300);
            this.CVList.TabIndex = 1;
            this.CVList.UseCompatibleStateImageBehavior = false;
            this.CVList.View = System.Windows.Forms.View.Details;
            // 
            // CheckVoices
            // 
            this.CheckVoices.Enabled = true;
            this.CheckVoices.Tick += new System.EventHandler(this.CheckVoices_Tick);
            // 
            // AdvancedVoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 300);
            this.Controls.Add(this.CVList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedVoices";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Active voices - Advanced";
            this.Load += new System.EventHandler(this.AdvancedVoices_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView CVList;
        private System.Windows.Forms.Timer CheckVoices;
    }
}