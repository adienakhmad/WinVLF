using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleVLF
{
    public partial class SVLF : Form
    {
        public static int Count;
        public SVLF()
        {
            InitializeComponent();
            
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Count += 1;
            var text = string.Format("Plot {0}", Count);
            var form2 = new PlotForm(text)
            {
                MdiParent = this
            };

            form2.Show();
        }

        private void SVLF_Load(object sender, EventArgs e)
        {
            toolStrip1.Renderer = Antiufo.Controls.Windows7Renderer.Instance;
            menuStrip1.Renderer = Antiufo.Controls.Windows7Renderer.Instance;
        }
    }
}
