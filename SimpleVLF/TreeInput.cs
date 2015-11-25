using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Antiufo.Controls;

namespace WinVLF
{
    public partial class TreeInput : Form
    {
        public TreeInput(IEnumerable<TreeNode> nodes)
        {
            InitializeComponent();

            foreach (var node in nodes)
            {
                treeView1.Nodes.Add(node);
            }
        }

        private void TreeInput_Load(object sender, EventArgs e)
        {
            toolStrip1.Renderer = Windows7Renderer.Instance;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                node.Checked = true;
            }
        }

        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                node.Checked = true;
            }
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                node.Checked = !node.Checked;
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var count = treeView1.Nodes.Cast<TreeNode>().Count(node => node.Checked);
            toolStripButton4.Enabled = count > 1;
        }
    }
}
