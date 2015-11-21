using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VLFLib.Data;

namespace SimpleVLF
{
    public partial class SVLF
    {
        private static string FindUniqeName(string originalName, ListView view)
        {
            // Find unique name if there is duplicate.
            var num = 2;
            var newname = originalName;

            while (view.Items.ContainsKey(newname))
            {
                newname = $"{originalName}({num})";
                num++;
            }

            return newname;
        }

        private void LoadProject(VlfProject proj)
        {
            CloseProject();

            foreach (var tiltData in proj.TiltDatas)
            {
                var item = new ListViewItem()
                {
                    Name = tiltData.Name,
                    Text = tiltData.Name,
                    Tag = tiltData
                };

                item.SubItems.Add(tiltData.Npts.ToString());
                item.SubItems.Add(tiltData.Spacing.ToString(CultureInfo.InvariantCulture));
                if (!tiltData.IsAscending) item.BackColor = Color.Orange;
                listViewRaw.Items.Add(item);
            }

            foreach (var fraserData in proj.FraserDatas)
            {
                var item = new ListViewItem()
                {
                    Name = fraserData.Name,
                    Text = fraserData.Name,
                    Tag = fraserData
                };

                item.SubItems.Add(fraserData.Npts.ToString());
                item.SubItems.Add(fraserData.Spacing.ToString(CultureInfo.InvariantCulture));
                listViewFraser.Items.Add(item);
            }

            foreach (var karousHjeltData in proj.KarousHjeltDatas)
            {
                var item = new ListViewItem()
                {
                    Name = karousHjeltData.Name,
                    Text = karousHjeltData.Name,
                    Tag = karousHjeltData
                };

                item.SubItems.Add(karousHjeltData.Depths.Min().ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(karousHjeltData.Spacing.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(karousHjeltData.SkinDepth.ToString(CultureInfo.InvariantCulture));
                listViewKH.Items.Add(item);
            }

            Text = $"WinVLF - [{proj.Name}]";
        }

        private VlfProject SaveProject(string name)
        {
            ICollection<TiltData> tiltDatas =
                (from ListViewItem item in listViewRaw.Items select item.Tag as TiltData).ToList();
            ICollection<FraserData> fraserDatas =
                (from ListViewItem item in listViewFraser.Items select item.Tag as FraserData).ToList();
            ICollection<KarousHjeltData> khDatas =
                (from ListViewItem item in listViewKH.Items select item.Tag as KarousHjeltData).ToList();

            return new VlfProject(name, 100, tiltDatas, fraserDatas, khDatas);
        }

        private void SaveProjectNow()
        {
            if (_currentFile.Exists)
            {
                File.Delete(_currentFile.FullName);
                VlfProjectHandler.Save(SaveProject(_currentFile.FullName), _currentFile.FullName);
                tsStatusLabel.Text = $"Last saved on: {DateTime.Now}";

            }
            else
            {
                var dlg = saveProjectDialog.ShowDialog();
                if (dlg != DialogResult.OK) return;

                VlfProjectHandler.Save(SaveProject(saveProjectDialog.FileName), saveProjectDialog.FileName);
                _currentFile = new FileInfo(saveProjectDialog.FileName);
                tsStatusLabel.Text = $"Last saved on: {DateTime.Now}";
            }
        }

        private void CloseProject()
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window to close
            foreach (var chform in charr)
                chform.Close();

            listViewRaw.Items.Clear();
            listViewFraser.Items.Clear();
            listViewKH.Items.Clear();

            Text = $"WinVLF - [New Project 1]";
        }
    }
}