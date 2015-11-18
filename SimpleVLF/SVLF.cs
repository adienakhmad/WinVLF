using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Antiufo.Controls;
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

            else if (listViewKH.Focused)
            {
                if (listViewKH.SelectedItems.Count == 0)
                {
                    MessageBox.Show(@"You have not seleced any data.");
                    return;
                }
                var selected = listViewKH.SelectedItems[0];
                var form2 = new ChartPlot(selected.Name, selected.Tag as KarousHjeltData) {MdiParent = this};
                form2.Show();
            }

            else
            {
                MessageBox.Show(@"There is nothing to plot");
            }
        }

        private void tsbMovAvg_Click(object sender, EventArgs e)
        {
            if (!listViewRaw.Focused || listViewRaw.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"You have not selected any data.");
                return;
            }

            var order = 3;
            if (InputPrompt.InputNumberBox("Moving Average Filter", "Filter Order", ref order) != DialogResult.OK)
                return;


            var data = listViewRaw.SelectedItems[0].Tag as TiltData;
            if (data != null && ((Math.Abs(order)) <= 1 || order > data.Count))
            {
                MessageBox.Show(@"Invalid filter order.");
                return;
            }

            if (data == null) return;
            var newname = FindUniqeName($"{data.Name}_MovAvg Order {Convert.ToInt32(order)}", listViewRaw);
            if (InputPrompt.InputStringBox("Moving Average Filter", "Enter a name.", ref newname) != DialogResult.OK)
                return;

            var smooth = VlfFilter.MovingAverage(data, Convert.ToInt32(order));

            var item = new ListViewItem {Text = newname, Name = newname};
            item.SubItems.Add(smooth.Count.ToString());
            item.SubItems.Add(smooth.Spacing.ToString(CultureInfo.InvariantCulture));
            item.Tag = smooth;
            listViewRaw.Items.Add(item);

            var form2 = new ChartPlot(item.Name, smooth)
            {
                MdiParent = this
            };
            form2.Show();
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
            if (InputPrompt.InputStringBox("Fraser Filter", "Enter a name.", ref name) != DialogResult.OK)
                return;
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

        private void tsKarousHjelt_Click(object sender, EventArgs e)
        {
            if (listViewRaw.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"You have not selected any data.");
                return;
            }

            var tiltData = listViewRaw.SelectedItems[0].Tag as TiltData;
            if (tiltData != null && tiltData.Count < 6)
            {
                MessageBox.Show(@"There should be minimum of 7 data for this filter to work.");
                return;
            }

            var name = FindUniqeName(listViewRaw.SelectedItems[0].Name, listViewKH);
            if (InputPrompt.InputStringBox("Karous Hjelt-Filter", "Enter a name.", ref name) != DialogResult.OK)
                return;

            var skin = 0f;
            if (
                InputPrompt.InputNumberBox("Karous Hjelt-Filter",
                    "Skin depth normalization. Enter 0 to ignore skin depth", ref skin) != DialogResult.OK)
                return;

            var kh = VlfFilter.KarousHjelt(tiltData, skin);


            var item = new ListViewItem()
            {
                Name = name,
                Text = name,
                Tag = kh
            };
            item.SubItems.Add(kh.DepthArray.Min().ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(kh.Spacing.ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(kh.SkinDepth.ToString(CultureInfo.InvariantCulture));
            listViewKH.Items.Add(item);

            var form2 = new ChartPlot(item.Name, kh) {MdiParent = this};
            form2.Show();
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

        private void tsViewTable_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            var lv = sender as ListView;
            if (e.KeyCode == Keys.Delete)
            {
                if (lv == null) return;
                foreach (ListViewItem item in lv.SelectedItems)
                {
                    lv.Items.Remove(item);
                }
            }

            else if (e.Control && e.KeyCode == Keys.A)
            {
                if (lv == null) return;
                foreach (ListViewItem item in lv.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private void tsmDeleteFraser_Click(object sender, EventArgs e)
        {
            if (listViewFraser.SelectedItems.Count == 0) return;
            foreach (ListViewItem item in listViewFraser.SelectedItems)
            {
                listViewFraser.Items.Remove(item);
            }
        }

        private void tsmDeleteKH_Click(object sender, EventArgs e)
        {
            if (listViewKH.SelectedItems.Count == 0) return;
            foreach (ListViewItem item in listViewKH.SelectedItems)
            {
                listViewKH.Items.Remove(item);
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            var cm = sender as ContextMenuStrip;
            var lv = cm?.SourceControl as ListView;

            if (lv == null) return;
            foreach (ListViewItem item in lv.SelectedItems)
            {
                lv.Items.Remove(item);
            }
        }

        private void tsInterpolate_Click(object sender, EventArgs e)
        {
            if(!listViewRaw.Focused || listViewRaw.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"You have not selected any data.");
                return;
            }

            var data = listViewRaw.SelectedItems[0].Tag as TiltData;

            if (data == null) return;

            var spacing = Convert.ToSingle(Math.Floor(data.Spacing));

            if (InputPrompt.InputNumberBox("Cubic Spline Interpolation", "Enter the new spacing", ref spacing) != DialogResult.OK)
                return;

            var npt = ((data.MaxDistance() - data.MinDistance())/spacing) + 1;
            if (InputPrompt.InputNumberBox("Cubic Spline Interpolation", "Enter the new npts (number of points).", ref npt) != DialogResult.OK)
                return;

            if ((data.MinDistance() + ((npt-1)*spacing) > data.MaxDistance()))
            {
                MessageBox.Show(@"npts is too large, maximum distance exceeds original data.");
                Debug.WriteLine((data.MinDistance() + (npt * spacing)));
                return;
            }


            var newname = FindUniqeName($"{data.Name}_Interpolated", listViewRaw);
            if (InputPrompt.InputStringBox("Cubic Spline Interpolation", "Enter a name.", ref newname) != DialogResult.OK)
                return;

            var tiltData = VlfInterpolation.CubicSplineNatural(data, Convert.ToSingle(spacing),Convert.ToInt32(npt));
            var item = new ListViewItem { Text = newname, Name = newname };
            item.SubItems.Add(tiltData.Count.ToString());
            item.SubItems.Add(tiltData.Spacing.ToString(CultureInfo.InvariantCulture));
            item.Tag = tiltData;
            listViewRaw.Items.Add(item);

            var form2 = new ChartPlot(item.Name, tiltData)
            {
                MdiParent = this
            };
            form2.Show();
        }
    }
}