using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class TestForms : Form
    {
        public TestForms()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ErrorHandler("Test error", "This is a test error", 0, 0).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DonateMonthlyDialog().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new InfoDialog(0).ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new BecomeAPatron().ShowDialog();
        }
    }
}
