using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass.AddOn.Vst;

namespace KeppyMIDIConverter
{
    public partial class VSTEditor : Form
    {
        public bool VSTEditorEmbedded = false;

        public VSTEditor(int vstHandle, BASS_VST_INFO vstInfo)
        {
            InitializeComponent();

            VSTEditorEmbedded = BassVst.BASS_VST_EmbedEditor(vstHandle, Handle);

            if (VSTEditorEmbedded && vstInfo.hasEditor)
            {
                if (vstInfo.editorWidth > 0 && vstInfo.editorHeight > 0)
                    this.ClientSize = new Size(vstInfo.editorWidth, vstInfo.editorHeight);

                Text = String.Format("{0} {1}", Languages.Parse("DSPSettings"), vstInfo.effectName);
            }
            else Close();
        }
    }
}
