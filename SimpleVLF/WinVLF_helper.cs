using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VLFLib;
using VLFLib.Data;

namespace WinVLF
{
    public partial class WinVLF
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
            var count = 0;

            // Load all data as node tag object, without names.

            foreach (var tiltData in proj.TiltDatas)
            {
                AddNode(proj.NodeNames[count], treeViewMain.Nodes["NodeTilt"], tiltData);
                count++;
            }

            foreach (var fraserData in proj.FraserDatas)
            {
                AddNode(proj.NodeNames[count], treeViewMain.Nodes["NodeFraser"], fraserData);
                count++;
            }

            foreach (var karousHjeltData in proj.KarousHjeltDatas)
            {
                AddNode(proj.NodeNames[count], treeViewMain.Nodes["NodeKH"], karousHjeltData);
                count++;
            }

            foreach (var surf2D in proj.Surface2DDatas)
            {
                AddNode(proj.NodeNames[count], treeViewMain.Nodes["Node2DSurface"], surf2D);
                count++;
            }

            Text = $"WinVLF - [{proj.Name}]";
        }

        private VlfProject SaveProject(string name)
        {
            var nodeNames =
                (from TreeNode rootNode in treeViewMain.Nodes
                    from TreeNode childNode in rootNode.Nodes
                    select childNode.Name).ToList();
            ICollection<TiltData> tiltDatas =
                (from TreeNode node in treeViewMain.Nodes["NodeTilt"].Nodes select node.Tag as TiltData).ToList();
            ICollection<FraserData> fraserDatas =
                (from TreeNode node in treeViewMain.Nodes["NodeFraser"].Nodes select node.Tag as FraserData).ToList();
            ICollection<KarousHjeltData> khDatas =
                (from TreeNode node in treeViewMain.Nodes["NodeKH"].Nodes select node.Tag as KarousHjeltData).ToList();
            ICollection<Surface2D> surfDatas =
                (from TreeNode node in treeViewMain.Nodes["Node2DSurface"].Nodes select node.Tag as Surface2D).ToList();
            return new VlfProject(name, 101, nodeNames, tiltDatas, fraserDatas, khDatas, surfDatas);
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
            _currentFile = new FileInfo(Application.StartupPath + "New Project.vlf");
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

        private void StartGriddingWorker(Surface2D surf)
        {
            tsStatusLabel.Text = @"Building grid..";
            krigingProgressBar.Visible = true;
            krigingWorker.RunWorkerAsync(surf);
        }
    }
}