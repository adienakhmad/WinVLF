using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Antiufo.Controls;
using VLFLib.Data;

namespace SimpleVLF
{
    public partial class SVLF : Form
    {
        public static int Count;

        public SVLF()
        {
            InitializeComponent();
        }

        private void SVLF_Load(object sender, EventArgs e)
        {
            tsToolBar.Renderer = Windows7Renderer.Instance;
            menuStrip1.Renderer = Windows7Renderer.Instance;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void maximizeAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window state to Maximized
            foreach (var chform in charr)
                chform.WindowState = FormWindowState.Maximized;
        }

        private void minimizeAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window state to Minimized
            foreach (var chform in charr)
                chform.WindowState = FormWindowState.Minimized;
        }

        private void tileHorizontallyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window state to Normal
            foreach (var chform in charr)
                chform.WindowState = FormWindowState.Normal;

            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window state to Normal
            foreach (var chform in charr)
                chform.WindowState = FormWindowState.Normal;

            LayoutMdi(MdiLayout.TileVertical);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window to close
            foreach (var chform in charr)
                chform.Close();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window state to Normal
            foreach (var chform in charr)
                chform.WindowState = FormWindowState.Normal;

            LayoutMdi(MdiLayout.Cascade);
        }

        private void tsAddData_Click(object sender, EventArgs e)
        {
            var dlg = importRawDialog.ShowDialog();
            if (dlg != DialogResult.OK) return;
            TiltData input;

            try
            {
                input = VlfDataReader.Read(importRawDialog.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show(@"An error has occured on your file. Please check your file.");
                return;
            }
            
            // Find unique name if there is duplicate.
            var num = 2;
            var newname = input.Name;

            while (listViewRaw.Items.ContainsKey(newname))
            {
                newname = $"{input.Name}({num})";
                num++;
            }

            // end of finding unique name

            var item = new ListViewItem {Text = newname, Name = newname};
            item.SubItems.Add(input.Count.ToString());
            item.SubItems.Add(input.Spacing.ToString(CultureInfo.InvariantCulture));
            item.Tag = input;
            if (!input.IsAscending()) item.BackColor = Color.Orange;
            listViewRaw.Items.Add(item);
        }

        private void tsViewTable_Click(object sender, EventArgs e)
        {
        }

        private void tsPlotChart_Click(object sender, EventArgs e)
        {
            var selected = listViewRaw.SelectedItems[0];
            if (selected == null) return;
            var form2 = new PlotForm(selected.Name,selected.Tag as TiltData)
            {
                MdiParent = this
            };

            form2.Show();
        }
    }
}