namespace SimpleVLF
{
    partial class SVLF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Example Text");
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmPlot = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mdiClientController1 = new Slusser.Components.MdiClientController();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddData = new System.Windows.Forms.ToolStripButton();
            this.tsViewTable = new System.Windows.Forms.ToolStripButton();
            this.tsPlotChart = new System.Windows.Forms.ToolStripButton();
            this.tsResample = new System.Windows.Forms.ToolStripButton();
            this.tsFraserFilter = new System.Windows.Forms.ToolStripButton();
            this.tsKHFilter = new System.Windows.Forms.ToolStripButton();
            this.tsLayout = new System.Windows.Forms.ToolStripDropDownButton();
            this.maximizeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontallyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticallyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.cmListView.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddData,
            this.tsViewTable,
            this.tsPlotChart,
            this.tsResample,
            this.tsFraserFilter,
            this.tsKHFilter,
            this.tsLayout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1093, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmListView
            // 
            this.cmListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPlot,
            this.tsmExport});
            this.cmListView.Name = "cmListView";
            this.cmListView.Size = new System.Drawing.Size(124, 48);
            // 
            // tsmPlot
            // 
            this.tsmPlot.Name = "tsmPlot";
            this.tsmPlot.Size = new System.Drawing.Size(123, 22);
            this.tsmPlot.Text = "View Plot";
            // 
            // tsmExport
            // 
            this.tsmExport.Name = "tsmExport";
            this.tsmExport.Size = new System.Drawing.Size(123, 22);
            this.tsmExport.Text = "Export";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.toolStripMenuItem1;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1093, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem1.Text = "Window";
            // 
            // mdiClientController1
            // 
            this.mdiClientController1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mdiClientController1.ParentForm = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 698);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1093, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listView2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.listView4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 649);
            this.panel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "VLF Data";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.cmListView;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(12, 22);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(320, 226);
            this.listView1.TabIndex = 23;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "# n";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Spacing";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Fraser Filtered";
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listView2.ContextMenuStrip = this.cmListView;
            this.listView2.Location = new System.Drawing.Point(12, 267);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(320, 180);
            this.listView2.TabIndex = 24;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Data Points";
            this.columnHeader5.Width = 100;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Karous Hjelt Filtered";
            // 
            // listView4
            // 
            this.listView4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.listView4.ContextMenuStrip = this.cmListView;
            this.listView4.Location = new System.Drawing.Point(12, 466);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(320, 180);
            this.listView4.TabIndex = 25;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Max Dz";
            this.columnHeader8.Width = 100;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tsAddData
            // 
            this.tsAddData.Image = global::SimpleVLF.Properties.Resources.fill_medium_270;
            this.tsAddData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddData.Name = "tsAddData";
            this.tsAddData.Size = new System.Drawing.Size(76, 22);
            this.tsAddData.Text = "Add Data";
            // 
            // tsViewTable
            // 
            this.tsViewTable.Image = global::SimpleVLF.Properties.Resources.table;
            this.tsViewTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsViewTable.Name = "tsViewTable";
            this.tsViewTable.Size = new System.Drawing.Size(84, 22);
            this.tsViewTable.Text = "View Table";
            // 
            // tsPlotChart
            // 
            this.tsPlotChart.Image = global::SimpleVLF.Properties.Resources.system_monitor;
            this.tsPlotChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPlotChart.Name = "tsPlotChart";
            this.tsPlotChart.Size = new System.Drawing.Size(80, 22);
            this.tsPlotChart.Text = "Plot Chart";
            this.tsPlotChart.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // tsResample
            // 
            this.tsResample.Image = global::SimpleVLF.Properties.Resources.application_wave;
            this.tsResample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsResample.Name = "tsResample";
            this.tsResample.Size = new System.Drawing.Size(78, 22);
            this.tsResample.Text = "Resample";
            // 
            // tsFraserFilter
            // 
            this.tsFraserFilter.Image = global::SimpleVLF.Properties.Resources.script_attribute_f;
            this.tsFraserFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFraserFilter.Name = "tsFraserFilter";
            this.tsFraserFilter.Size = new System.Drawing.Size(87, 22);
            this.tsFraserFilter.Text = "Fraser Filter";
            // 
            // tsKHFilter
            // 
            this.tsKHFilter.Image = global::SimpleVLF.Properties.Resources.script_attribute_k;
            this.tsKHFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsKHFilter.Name = "tsKHFilter";
            this.tsKHFilter.Size = new System.Drawing.Size(72, 22);
            this.tsKHFilter.Text = "KH Filter";
            // 
            // tsLayout
            // 
            this.tsLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maximizeAllToolStripMenuItem1,
            this.minimizeAllToolStripMenuItem1,
            this.tileHorizontallyToolStripMenuItem1,
            this.tileVerticallyToolStripMenuItem1,
            this.closeAllToolStripMenuItem});
            this.tsLayout.Image = global::SimpleVLF.Properties.Resources.applications_blue;
            this.tsLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLayout.Name = "tsLayout";
            this.tsLayout.Size = new System.Drawing.Size(72, 22);
            this.tsLayout.Text = "Layout";
            // 
            // maximizeAllToolStripMenuItem1
            // 
            this.maximizeAllToolStripMenuItem1.Image = global::SimpleVLF.Properties.Resources.application_resize_full;
            this.maximizeAllToolStripMenuItem1.Name = "maximizeAllToolStripMenuItem1";
            this.maximizeAllToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.maximizeAllToolStripMenuItem1.Text = "Maximize All";
            // 
            // minimizeAllToolStripMenuItem1
            // 
            this.minimizeAllToolStripMenuItem1.Name = "minimizeAllToolStripMenuItem1";
            this.minimizeAllToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.minimizeAllToolStripMenuItem1.Text = "Minimize All";
            // 
            // tileHorizontallyToolStripMenuItem1
            // 
            this.tileHorizontallyToolStripMenuItem1.Image = global::SimpleVLF.Properties.Resources.application_tile_horizontal;
            this.tileHorizontallyToolStripMenuItem1.Name = "tileHorizontallyToolStripMenuItem1";
            this.tileHorizontallyToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.tileHorizontallyToolStripMenuItem1.Text = "Tile Horizontally";
            // 
            // tileVerticallyToolStripMenuItem1
            // 
            this.tileVerticallyToolStripMenuItem1.Image = global::SimpleVLF.Properties.Resources.application_tile_vertical;
            this.tileVerticallyToolStripMenuItem1.Name = "tileVerticallyToolStripMenuItem1";
            this.tileVerticallyToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.tileVerticallyToolStripMenuItem1.Text = "Tile Vertically";
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Image = global::SimpleVLF.Properties.Resources.cross_button;
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.closeAllToolStripMenuItem.Text = "Close All Window";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::SimpleVLF.Properties.Resources.information_balloon;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // SVLF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 720);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SVLF";
            this.Text = "Simple VLF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SVLF_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmListView.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ContextMenuStrip cmListView;
        private System.Windows.Forms.ToolStripMenuItem tsmPlot;
        private System.Windows.Forms.ToolStripMenuItem tsmExport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private Slusser.Components.MdiClientController mdiClientController1;
        private System.Windows.Forms.ToolStripButton tsAddData;
        private System.Windows.Forms.ToolStripButton tsFraserFilter;
        private System.Windows.Forms.ToolStripButton tsKHFilter;
        private System.Windows.Forms.ToolStripButton tsPlotChart;
        private System.Windows.Forms.ToolStripButton tsResample;
        private System.Windows.Forms.ToolStripButton tsViewTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsLayout;
        private System.Windows.Forms.ToolStripMenuItem maximizeAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem minimizeAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontallyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tileVerticallyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

