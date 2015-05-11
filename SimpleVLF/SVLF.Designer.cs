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
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Example Text",
            "100",
            "20"}, -1);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Fraser 1");
            this.tsToolBar = new System.Windows.Forms.ToolStrip();
            this.cmListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tsmPlot = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddData = new System.Windows.Forms.ToolStripButton();
            this.tsViewTable = new System.Windows.Forms.ToolStripButton();
            this.tsPlotChart = new System.Windows.Forms.ToolStripButton();
            this.tsResample = new System.Windows.Forms.ToolStripButton();
            this.tsFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.movingAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fraserFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.karousHjeltFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tsLayout = new System.Windows.Forms.ToolStripDropDownButton();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontallyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticallyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsToolBar.SuspendLayout();
            this.cmListView.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsToolBar
            // 
            this.tsToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddData,
            this.toolStripSeparator3,
            this.tsViewTable,
            this.tsPlotChart,
            this.toolStripSeparator1,
            this.tsResample,
            this.tsFilter,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.tsLayout});
            this.tsToolBar.Location = new System.Drawing.Point(0, 24);
            this.tsToolBar.Name = "tsToolBar";
            this.tsToolBar.Size = new System.Drawing.Size(1093, 25);
            this.tsToolBar.TabIndex = 1;
            this.tsToolBar.Text = "toolStrip1";
            // 
            // cmListView
            // 
            this.cmListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPlot,
            this.viewToolStripMenuItem,
            this.tsmExport,
            this.deleteToolStripMenuItem});
            this.cmListView.Name = "cmListView";
            this.cmListView.Size = new System.Drawing.Size(148, 92);
            // 
            // tsmExport
            // 
            this.tsmExport.Name = "tsmExport";
            this.tsmExport.Size = new System.Drawing.Size(147, 22);
            this.tsmExport.Text = "Export To File";
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
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem1.Text = "Window";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
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
            listViewItem3});
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
            this.columnHeader5,
            this.columnHeader6});
            this.listView2.ContextMenuStrip = this.cmListView;
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView2.Location = new System.Drawing.Point(12, 267);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(320, 180);
            this.listView2.TabIndex = 24;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "#n";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Spacing";
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
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
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
            this.columnHeader7.Width = 135;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Max Dz";
            this.columnHeader8.Width = 50;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Spacing";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Skin Depth";
            this.columnHeader10.Width = 65;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tsmPlot
            // 
            this.tsmPlot.Image = global::SimpleVLF.Properties.Resources.system_monitor;
            this.tsmPlot.Name = "tsmPlot";
            this.tsmPlot.Size = new System.Drawing.Size(147, 22);
            this.tsmPlot.Text = "Plot Chart";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Image = global::SimpleVLF.Properties.Resources.table;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.viewToolStripMenuItem.Text = "View As Table";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::SimpleVLF.Properties.Resources.cross_script;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // tsAddData
            // 
            this.tsAddData.Image = global::SimpleVLF.Properties.Resources.fill_medium_270;
            this.tsAddData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddData.Name = "tsAddData";
            this.tsAddData.Size = new System.Drawing.Size(90, 22);
            this.tsAddData.Text = "Import Data";
            // 
            // tsViewTable
            // 
            this.tsViewTable.Image = global::SimpleVLF.Properties.Resources.table;
            this.tsViewTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsViewTable.Name = "tsViewTable";
            this.tsViewTable.Size = new System.Drawing.Size(100, 22);
            this.tsViewTable.Text = "View As Table";
            // 
            // tsPlotChart
            // 
            this.tsPlotChart.Image = global::SimpleVLF.Properties.Resources.system_monitor;
            this.tsPlotChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPlotChart.Name = "tsPlotChart";
            this.tsPlotChart.Size = new System.Drawing.Size(48, 22);
            this.tsPlotChart.Text = "Plot";
            this.tsPlotChart.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // tsResample
            // 
            this.tsResample.Image = global::SimpleVLF.Properties.Resources.function;
            this.tsResample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsResample.Name = "tsResample";
            this.tsResample.Size = new System.Drawing.Size(78, 22);
            this.tsResample.Text = "Resample";
            // 
            // tsFilter
            // 
            this.tsFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movingAverageToolStripMenuItem,
            this.fraserFilterToolStripMenuItem,
            this.karousHjeltFilterToolStripMenuItem});
            this.tsFilter.Image = global::SimpleVLF.Properties.Resources.application_wave;
            this.tsFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFilter.Name = "tsFilter";
            this.tsFilter.Size = new System.Drawing.Size(62, 22);
            this.tsFilter.Text = "Filter";
            this.tsFilter.Visible = false;
            // 
            // movingAverageToolStripMenuItem
            // 
            this.movingAverageToolStripMenuItem.Image = global::SimpleVLF.Properties.Resources.script_attribute_m;
            this.movingAverageToolStripMenuItem.Name = "movingAverageToolStripMenuItem";
            this.movingAverageToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.movingAverageToolStripMenuItem.Text = "Moving Average";
            // 
            // fraserFilterToolStripMenuItem
            // 
            this.fraserFilterToolStripMenuItem.Image = global::SimpleVLF.Properties.Resources.script_attribute_f;
            this.fraserFilterToolStripMenuItem.Name = "fraserFilterToolStripMenuItem";
            this.fraserFilterToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.fraserFilterToolStripMenuItem.Text = "Fraser Filter";
            // 
            // karousHjeltFilterToolStripMenuItem
            // 
            this.karousHjeltFilterToolStripMenuItem.Image = global::SimpleVLF.Properties.Resources.script_attribute_k;
            this.karousHjeltFilterToolStripMenuItem.Name = "karousHjeltFilterToolStripMenuItem";
            this.karousHjeltFilterToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.karousHjeltFilterToolStripMenuItem.Text = "Karous Hjelt Filter";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::SimpleVLF.Properties.Resources.script_attribute_m;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(143, 22);
            this.toolStripButton1.Text = "Moving Average Filter";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::SimpleVLF.Properties.Resources.script_attribute_f;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(87, 22);
            this.toolStripButton2.Text = "Fraser Filter";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::SimpleVLF.Properties.Resources.script_attribute_k;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(120, 22);
            this.toolStripButton3.Text = "Karous Hjelt Filter";
            // 
            // tsLayout
            // 
            this.tsLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.minimizeAllToolStripMenuItem1,
            this.maximizeAllToolStripMenuItem1,
            this.tileHorizontallyToolStripMenuItem1,
            this.tileVerticallyToolStripMenuItem1,
            this.closeAllToolStripMenuItem});
            this.tsLayout.Image = global::SimpleVLF.Properties.Resources.applications_blue;
            this.tsLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLayout.Name = "tsLayout";
            this.tsLayout.Size = new System.Drawing.Size(72, 22);
            this.tsLayout.Text = "Layout";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Image = global::SimpleVLF.Properties.Resources.applications_stack;
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // minimizeAllToolStripMenuItem1
            // 
            this.minimizeAllToolStripMenuItem1.Name = "minimizeAllToolStripMenuItem1";
            this.minimizeAllToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.minimizeAllToolStripMenuItem1.Text = "Minimize All";
            this.minimizeAllToolStripMenuItem1.Click += new System.EventHandler(this.minimizeAllToolStripMenuItem1_Click);
            // 
            // maximizeAllToolStripMenuItem1
            // 
            this.maximizeAllToolStripMenuItem1.Image = global::SimpleVLF.Properties.Resources.application_resize_full;
            this.maximizeAllToolStripMenuItem1.Name = "maximizeAllToolStripMenuItem1";
            this.maximizeAllToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.maximizeAllToolStripMenuItem1.Text = "Maximize All";
            this.maximizeAllToolStripMenuItem1.Click += new System.EventHandler(this.maximizeAllToolStripMenuItem1_Click);
            // 
            // tileHorizontallyToolStripMenuItem1
            // 
            this.tileHorizontallyToolStripMenuItem1.Image = global::SimpleVLF.Properties.Resources.application_tile_horizontal;
            this.tileHorizontallyToolStripMenuItem1.Name = "tileHorizontallyToolStripMenuItem1";
            this.tileHorizontallyToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.tileHorizontallyToolStripMenuItem1.Text = "Tile Horizontally";
            this.tileHorizontallyToolStripMenuItem1.Click += new System.EventHandler(this.tileHorizontallyToolStripMenuItem1_Click);
            // 
            // tileVerticallyToolStripMenuItem1
            // 
            this.tileVerticallyToolStripMenuItem1.Image = global::SimpleVLF.Properties.Resources.application_tile_vertical;
            this.tileVerticallyToolStripMenuItem1.Name = "tileVerticallyToolStripMenuItem1";
            this.tileVerticallyToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.tileVerticallyToolStripMenuItem1.Text = "Tile Vertically";
            this.tileVerticallyToolStripMenuItem1.Click += new System.EventHandler(this.tileVerticallyToolStripMenuItem1_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Image = global::SimpleVLF.Properties.Resources.cross_button;
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.closeAllToolStripMenuItem.Text = "Close All Window";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::SimpleVLF.Properties.Resources.information_balloon;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // SVLF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 720);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsToolBar);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SVLF";
            this.Text = "Simple VLF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SVLF_Load);
            this.tsToolBar.ResumeLayout(false);
            this.tsToolBar.PerformLayout();
            this.cmListView.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsToolBar;
        private System.Windows.Forms.ContextMenuStrip cmListView;
        private System.Windows.Forms.ToolStripMenuItem tsmPlot;
        private System.Windows.Forms.ToolStripMenuItem tsmExport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private Slusser.Components.MdiClientController mdiClientController1;
        private System.Windows.Forms.ToolStripButton tsAddData;
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
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsFilter;
        private System.Windows.Forms.ToolStripMenuItem movingAverageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fraserFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem karousHjeltFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

