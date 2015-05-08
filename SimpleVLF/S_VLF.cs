using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleVLF
{
    public partial class S_VLF : Form
    {
        public S_VLF()
        {
            InitializeComponent();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            var form2 = new PlotForm ();
            form2.Show();
            Debug.WriteLine("Fireeeee");
        }
    }
}
