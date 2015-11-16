using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Antiufo.Controls;
using OxyPlot.Axes;
using VLFLib.Data;
using VLFLib.Processing;

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

            var newname = FindUniqeName(input.Name, listViewRaw);

            var item = new ListViewItem {Text = newname, Name = newname};
            item.SubItems.Add(input.Count.ToString());
            item.SubItems.Add(input.Spacing.ToString(CultureInfo.InvariantCulture));
            item.Tag = input;
            if (!input.IsAscending()) item.BackColor = Color.Orange;
            listViewRaw.Items.Add(item);

            var form2 = new ChartPlot(item.Name, input)
            {
                MdiParent = this
            };
            form2.Show();
        }

        private void tsViewTable_Click(object sender, EventArgs e)
        {
        }

        private void tsPlotChart_Click(object sender, EventArgs e)
        {
            if (listViewRaw.Focused)
            {
                if (listViewRaw.SelectedItems.Count == 0)
                {
                    MessageBox.Show(@"You have not selected any data.");
                    return;
                }

                var selected = listViewRaw.SelectedItems[0];

                var form2 = new ChartPlot(selected.Name, selected.Tag as TiltData)
                {
                    MdiParent = this
                };

                form2.Show();
            }

            else if (listViewFraser.Focused)
            {
                if (listViewFraser.SelectedItems.Count == 0)
                {
                    MessageBox.Show(@"You have not selected any data.");
                    return;
                }

                var selected = listViewFraser.SelectedItems[0];

                var form2 = new ChartPlot(selected.Name, selected.Tag as FraserData)
                {
                    MdiParent = this
                };

                form2.Show();
            }

            else
            {
                MessageBox.Show(@"There is nothing to plot");
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsFraserFilter_Click(object sender, EventArgs e)
        {
            if (listViewRaw.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"You have not selected any data.");
                return;
            }

            var tiltData = listViewRaw.SelectedItems[0].Tag as TiltData;
            if (tiltData != null && tiltData.Count < 4)
            {
                MessageBox.Show(@"There should be minimum of 4 data for this filter to work.");
                return;
            }

            // Do Fraser Filtering
            var fraser = VlfFilter.Fraser(tiltData);

            // Create a new listview item to be added to ListViewFraser
            var name = FindUniqeName(listViewRaw.SelectedItems[0].Name, listViewFraser);
            var item = new ListViewItem
            {
                Name = name,
                Text = name,
                Tag = fraser
            };

            item.SubItems.Add(fraser.Count.ToString());
            item.SubItems.Add(fraser.Spacing.ToString(CultureInfo.InvariantCulture));

            listViewFraser.Items.Add(item);

            // end of creating new item to be added to ListViewFraser

            // Plot the result
            var form2 = new ChartPlot(item.Name, fraser) {MdiParent = this};
            form2.Show();
        }
    }
}