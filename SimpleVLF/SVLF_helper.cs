using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VLFLib;
using VLFLib.Data;

namespace WinVLF
{
    public partial class SVLF
    {
        private static string FindUniqeName(string originalName, TreeNode node)
        {
            // Find unique name if there is duplicate.
            var num = 2;
            var newname = originalName;

            while (node.Nodes.ContainsKey(newname))
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
                AddNode(tiltData.Title, treeViewMain.Nodes["NodeTilt"], tiltData);
            }

            foreach (var fraserData in proj.FraserDatas)
            {
                AddNode(fraserData.Title, treeViewMain.Nodes["NodeFraser"], fraserData);
            }

            foreach (var karousHjeltData in proj.KarousHjeltDatas)
            {
                AddNode(karousHjeltData.Title, treeViewMain.Nodes["NodeKH"], karousHjeltData);
            }

            Text = $"WinVLF - [{proj.Name}]";
        }

        private VlfProject SaveProject(string name)
        {
            ICollection<TiltData> tiltDatas =
                (from TreeNode node in treeViewMain.Nodes["NodeTilt"].Nodes select node.Tag as TiltData).ToList();
            ICollection<FraserData> fraserDatas =
                (from TreeNode node in treeViewMain.Nodes["NodeFraser"].Nodes select node.Tag as FraserData).ToList();
            ICollection<KarousHjeltData> khDatas =
                (from TreeNode node in treeViewMain.Nodes["NodeKH"].Nodes select node.Tag as KarousHjeltData).ToList();
            return new VlfProject(name, 100, tiltDatas, fraserDatas, khDatas);
        }

        private void SaveProjectNow()
        {
            Debug.WriteLine("Inside save project now.");
            Debug.WriteLine(_currentFile.FullName);
            if (_currentFile.Exists)
            {
                File.Delete(_currentFile.FullName);
                VlfProjectHandler.Save(SaveProject(_currentFile.Name), _currentFile.FullName);
                tsStatusLabel.Text = $"Last saved on: {DateTime.Now}";
                Debug.WriteLine("File exist, saved..");
            }
            else
            {
                SaveAsNow();
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

            treeViewMain.Nodes[0].Nodes.Clear();
            treeViewMain.Nodes[1].Nodes.Clear();
            treeViewMain.Nodes[2].Nodes.Clear();
            treeViewMain.Nodes[3].Nodes.Clear();

            Text = $"WinVLF - [New Project 1]";
            propertyGrid1.SelectedObject = null;
        }

        private void AddNode(string name, TreeNode parentNode, object tag)
        {
            var child = new TreeNode
            {
                Name = name,
                Text = name,
                Tag = tag,
                SelectedImageIndex = 1,
                ImageIndex = 0
            };

            parentNode.Nodes.Add(child);
            parentNode.Expand();
            treeViewMain.SelectedNode = child;
        }

        private DialogResult AskIfSaveFirst(string prompt)
        {
            var aliveObject = treeViewMain.Nodes.Cast<TreeNode>().Sum(node => node.Nodes.Count);
            if (aliveObject == 0) return DialogResult.Abort;

            var dlg = MessageBox.Show($"Do you want to save first before {prompt}?", $"Save before {prompt} ",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            return dlg;
        }
    }
}