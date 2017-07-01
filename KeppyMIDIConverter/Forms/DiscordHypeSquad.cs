using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyMIDIConverter.Forms
{
    public partial class DiscordHypeSquad : Form
    {
        public DiscordHypeSquad()
        {
            InitializeComponent();
        }

        private void DiscordHypeSquad_Load(object sender, EventArgs e)
        {
            // Nothing lel
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ApplyNow_Click(object sender, EventArgs e)
        {
            Process.Start("https://discordapp.com/hypesquad?ref=QYmUfSjnJy");
        }

        private void ApplyNow_MouseEnter(object sender, EventArgs e)
        {
            ApplyNow.Image = KeppyMIDIConverter.Properties.Resources.dsapply2;
        }

        private void ApplyNow_MouseLeave(object sender, EventArgs e)
        {
            ApplyNow.Image = KeppyMIDIConverter.Properties.Resources.dsapply1;
        }
    }
}
