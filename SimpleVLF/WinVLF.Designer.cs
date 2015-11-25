using System.ComponentModel;
using System.Windows.Forms;
using Slusser.Components;

namespace WinVLF
{
    partial class WinVLF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tilt Profiles");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Fraser Profiles");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("KH Pseudosections");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("2D Surface Maps");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinVLF));
            this.tsToolBar = new System.Windows.Forms.ToolStrip();
            this.tsAddData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPlotChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsProcessing = new System.Windows.Forms.ToolStripDropDownButton();
            this.reverseSignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipDistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipAndReverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInterpolate = new System.Windows.Forms.ToolStripButton();
            this.tsbMovAvg = new System.Windows.Forms.ToolStripButton();
            this.tsFraserFilter = new System.Windows.Forms.ToolStripButton();
            this.tsKarousHjelt = new System.Windows.Forms.ToolStripButton();
            this.ts2DSurface = new System.Windows.Forms.ToolStripDropDownButton();
            this.usingFraserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLayout = new System.Windows.Forms.ToolStripDropDownButton();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontallyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticallyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmTreeNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmPlot = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteRaw = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mdiClientController1 = new Slusser.Components.MdiClientController();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.krigingProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.importRawDialog = new System.Windows.Forms.OpenFileDialog();
            this.openProjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.krigingWorker = new System.ComponentModel.BackgroundWorker();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsToolBar.SuspendLayout();
            this.cmTreeNode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsToolBar
            // 
            this.tsToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddData,
            this.toolStripSeparator3,
            this.tsPlotChart,
            this.toolStripSeparator1,
            this.tsProcessing,
            this.tsInterpolate,
            this.tsbMovAvg,
            this.tsFraserFilter,
            this.tsKarousHjelt,
            this.ts2DSurface,
            this.toolStripSeparator2,
            this.tsLayout});
            this.tsToolBar.Location = new System.Drawing.Point(0, 24);
            this.tsToolBar.Name = "tsToolBar";
            this.tsToolBar.Size = new System.Drawing.Size(1093, 25);
            this.tsToolBar.TabIndex = 1;
            this.tsToolBar.Text = "toolStrip1";
            // 
            // tsAddData
            // 
            this.tsAddData.Image = global::WinVLF.Properties.Resources.fill_medium_270;
            this.tsAddData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddData.Name = "tsAddData";
            this.tsAddData.Size = new System.Drawing.Size(90, 22);
            this.tsAddData.Text = "Import Data";
            this.tsAddData.Click += new System.EventHandler(this.tsAddData_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsPlotChart
            // 
            this.tsPlotChart.Image = global::WinVLF.Properties.Resources.system_monitor;
            this.tsPlotChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPlotChart.Name = "tsPlotChart";
            this.tsPlotChart.Size = new System.Drawing.Size(48, 22);
            this.tsPlotChart.Text = "Plot";
            this.tsPlotChart.Click += new System.EventHandler(this.tsPlotChart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsProcessing
            // 
            this.tsProcessing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reverseSignToolStripMenuItem,
            this.flipDistanceToolStripMenuItem,
            this.flipAndReverseToolStripMenuItem});
            this.tsProcessing.Image = global::WinVLF.Properties.Resources.chart__arrow;
            this.tsProcessing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsProcessing.Name = "tsProcessing";
            this.tsProcessing.Size = new System.Drawing.Size(103, 22);
            this.tsProcessing.Text = "Change Sign";
            // 
            // reverseSignToolStripMenuItem
            // 
            this.reverseSignToolStripMenuItem.Image = global::WinVLF.Properties.Resources.layer_flip_vertical;
            this.reverseSignToolStripMenuItem.Name = "reverseSignToolStripMenuItem";
            this.reverseSignToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.reverseSignToolStripMenuItem.Text = "Reverse Sign";
            this.reverseSignToolStripMenuItem.Click += new System.EventHandler(this.reverseSignToolStripMenuItem_Click);
            // 
            // flipDistanceToolStripMenuItem
            // 
            this.flipDistanceToolStripMenuItem.Image = global::WinVLF.Properties.Resources.layer_flip;
            this.flipDistanceToolStripMenuItem.Name = "flipDistanceToolStripMenuItem";
            this.flipDistanceToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.flipDistanceToolStripMenuItem.Text = "Flip Distance";
            this.flipDistanceToolStripMenuItem.Click += new System.EventHandler(this.flipDistanceToolStripMenuItem_Click);
            // 
            // flipAndReverseToolStripMenuItem
            // 
            this.flipAndReverseToolStripMenuItem.Image = global::WinVLF.Properties.Resources.task__arrow;
            this.flipAndReverseToolStripMenuItem.Name = "flipAndReverseToolStripMenuItem";
            this.flipAndReverseToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.flipAndReverseToolStripMenuItem.Text = "Flip and Reverse";
            this.flipAndReverseToolStripMenuItem.Click += new System.EventHandler(this.flipAndReverseToolStripMenuItem_Click);
            // 
            // tsInterpolate
            // 
            this.tsInterpolate.Image = global::WinVLF.Properties.Resources.function;
            this.tsInterpolate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsInterpolate.Name = "tsInterpolate";
            this.tsInterpolate.Size = new System.Drawing.Size(84, 22);
            this.tsInterpolate.Text = "Interpolate";
            this.tsInterpolate.ToolTipText = "Interpolate the data to achieve equal spacing between measurement points.";
            this.tsInterpolate.Click += new System.EventHandler(this.tsInterpolate_Click);
            // 
            // tsbMovAvg
            // 
            this.tsbMovAvg.Image = global::WinVLF.Properties.Resources.script_attribute_m;
            this.tsbMovAvg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMovAvg.Name = "tsbMovAvg";
            this.tsbMovAvg.Size = new System.Drawing.Size(98, 22);
            this.tsbMovAvg.Text = "Smooth Filter";
            this.tsbMovAvg.ToolTipText = "Perform Moving Average Filter to generate a smoother profile.";
            this.tsbMovAvg.Click += new System.EventHandler(this.tsbMovAvg_Click);
            // 
            // tsFraserFilter
            // 
            this.tsFraserFilter.Image = global::WinVLF.Properties.Resources.script_attribute_f;
            this.tsFraserFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFraserFilter.Name = "tsFraserFilter";
            this.tsFraserFilter.Size = new System.Drawing.Size(87, 22);
            this.tsFraserFilter.Text = "Fraser Filter";
            this.tsFraserFilter.ToolTipText = "Perform Fraser Filtering";
            this.tsFraserFilter.Click += new System.EventHandler(this.tsFraserFilter_Click);
            // 
            // tsKarousHjelt
            // 
            this.tsKarousHjelt.Image = global::WinVLF.Properties.Resources.script_attribute_k;
            this.tsKarousHjelt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsKarousHjelt.Name = "tsKarousHjelt";
            this.tsKarousHjelt.Size = new System.Drawing.Size(120, 22);
            this.tsKarousHjelt.Text = "Karous Hjelt Filter";
            this.tsKarousHjelt.ToolTipText = "Perform Karous Hjelt Filtering";
            this.tsKarousHjelt.Click += new System.EventHandler(this.tsKarousHjelt_Click);
            // 
            // ts2DSurface
            // 
            this.ts2DSurface.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usingFraserToolStripMenuItem});
            this.ts2DSurface.Image = global::WinVLF.Properties.Resources.map__plus;
            this.ts2DSurface.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts2DSurface.Name = "ts2DSurface";
            this.ts2DSurface.Size = new System.Drawing.Size(92, 22);
            this.ts2DSurface.Text = "2D Surface";
            // 
            // usingFraserToolStripMenuItem
            // 
            this.usingFraserToolStripMenuItem.Name = "usingFraserToolStripMenuItem";
            this.usingFraserToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.usingFraserToolStripMenuItem.Text = "Using Fraser";
            this.usingFraserToolStripMenuItem.Click += new System.EventHandler(this.usingFraserToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.tsLayout.Image = global::WinVLF.Properties.Resources.applications_blue;
            this.tsLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLayout.Name = "tsLayout";
            this.tsLayout.Size = new System.Drawing.Size(72, 22);
            this.tsLayout.Text = "Layout";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Image = global::WinVLF.Properties.Resources.applications_stack;
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
            this.maximizeAllToolStripMenuItem1.Image = global::WinVLF.Properties.Resources.application_resize_full;
            this.maximizeAllToolStripMenuItem1.Name = "maximizeAllToolStripMenuItem1";
            this.maximizeAllToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.maximizeAllToolStripMenuItem1.Text = "Maximize All";
            this.maximizeAllToolStripMenuItem1.Click += new System.EventHandler(this.maximizeAllToolStripMenuItem1_Click);
            // 
            // tileHorizontallyToolStripMenuItem1
            // 
            this.tileHorizontallyToolStripMenuItem1.Image = global::WinVLF.Properties.Resources.application_tile_horizontal;
            this.tileHorizontallyToolStripMenuItem1.Name = "tileHorizontallyToolStripMenuItem1";
            this.tileHorizontallyToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.tileHorizontallyToolStripMenuItem1.Text = "Tile Horizontally";
            this.tileHorizontallyToolStripMenuItem1.Click += new System.EventHandler(this.tileHorizontallyToolStripMenuItem1_Click);
            // 
            // tileVerticallyToolStripMenuItem1
            // 
            this.tileVerticallyToolStripMenuItem1.Image = global::WinVLF.Properties.Resources.application_tile_vertical;
            this.tileVerticallyToolStripMenuItem1.Name = "tileVerticallyToolStripMenuItem1";
            this.tileVerticallyToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.tileVerticallyToolStripMenuItem1.Text = "Tile Vertically";
            this.tileVerticallyToolStripMenuItem1.Click += new System.EventHandler(this.tileVerticallyToolStripMenuItem1_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Image = global::WinVLF.Properties.Resources.cross_button;
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.closeAllToolStripMenuItem.Text = "Close All Window";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // cmTreeNode
            // 
            this.cmTreeNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPlot,
            this.renameToolStripMenuItem,
            this.tsmExport,
            this.tsmDeleteRaw});
            this.cmTreeNode.Name = "cmListView";
            this.cmTreeNode.Size = new System.Drawing.Size(145, 92);
            // 
            // tsmPlot
            // 
            this.tsmPlot.Image = global::WinVLF.Properties.Resources.system_monitor;
            this.tsmPlot.Name = "tsmPlot";
            this.tsmPlot.Size = new System.Drawing.Size(144, 22);
            this.tsmPlot.Text = "Plot";
            this.tsmPlot.Click += new System.EventHandler(this.tsmPlot_Click);
            // 
            // tsmExport
            // 
            this.tsmExport.Name = "tsmExport";
            this.tsmExport.Size = new System.Drawing.Size(144, 22);
            this.tsmExport.Text = "Export To File";
            this.tsmExport.Click += new System.EventHandler(this.tsmExport_Click);
            // 
            // tsmDeleteRaw
            // 
            this.tsmDeleteRaw.Image = global::WinVLF.Properties.Resources.cross_script;
            this.tsmDeleteRaw.Name = "tsmDeleteRaw";
            this.tsmDeleteRaw.Size = new System.Drawing.Size(144, 22);
            this.tsmDeleteRaw.Text = "Delete";
            this.tsmDeleteRaw.Click += new System.EventHandler(this.tsmDelete_Click);
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
            this.openProjectToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Image = global::WinVLF.Properties.Resources.blue_folder_horizontal_open;
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::WinVLF.Properties.Resources.disk_black;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::WinVLF.Properties.Resources.disks_black;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveAsToolStripMenuItem.Text = "Save Project As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeStripMenuItem
            // 
            this.closeStripMenuItem.Name = "closeStripMenuItem";
            this.closeStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.closeStripMenuItem.Text = "Close";
            this.closeStripMenuItem.Click += new System.EventHandler(this.closeStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::WinVLF.Properties.Resources.information_balloon;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mdiClientController1
            // 
            this.mdiClientController1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mdiClientController1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mdiClientController1.ParentForm = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLabel,
            this.krigingProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1093, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusLabel
            // 
            this.tsStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.tsStatusLabel.Name = "tsStatusLabel";
            this.tsStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // krigingProgressBar
            // 
            this.krigingProgressBar.Name = "krigingProgressBar";
            this.krigingProgressBar.Size = new System.Drawing.Size(250, 16);
            this.krigingProgressBar.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.propertyGrid1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.treeViewMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 610);
            this.panel1.TabIndex = 10;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.propertyGrid1.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.propertyGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyGrid1.HelpBackColor = System.Drawing.Color.White;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 346);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(228, 262);
            this.propertyGrid1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(0, 325);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(229, 21);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Property Window";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 21);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object Manager";
            // 
            // treeViewMain
            // 
            this.treeViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewMain.ImageIndex = 0;
            this.treeViewMain.ImageList = this.imageListTreeView;
            this.treeViewMain.ItemHeight = 20;
            this.treeViewMain.LabelEdit = true;
            this.treeViewMain.Location = new System.Drawing.Point(-1, 21);
            this.treeViewMain.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewMain.Name = "treeViewMain";
            treeNode1.ImageKey = "book-open-text.png";
            treeNode1.Name = "NodeTilt";
            treeNode1.SelectedImageKey = "book-open-text.png";
            treeNode1.Text = "Tilt Profiles";
            treeNode1.ToolTipText = "Contains tilt profiles object";
            treeNode2.ImageKey = "chart-up.png";
            treeNode2.Name = "NodeFraser";
            treeNode2.SelectedImageKey = "chart-up.png";
            treeNode2.Text = "Fraser Profiles";
            treeNode2.ToolTipText = "Contain fraser filtered profile";
            treeNode3.ImageKey = "layers-stack-arrange.png";
            treeNode3.Name = "NodeKH";
            treeNode3.SelectedImageKey = "layers-stack-arrange.png";
            treeNode3.Text = "KH Pseudosections";
            treeNode3.ToolTipText = "Contains Pseudosections Objects";
            treeNode4.ImageKey = "maps.png";
            treeNode4.Name = "Node2DSurface";
            treeNode4.SelectedImageKey = "maps.png";
            treeNode4.Text = "2D Surface Maps";
            treeNode4.ToolTipText = "Contains 2D Surface Map Objects";
            this.treeViewMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeViewMain.SelectedImageIndex = 0;
            this.treeViewMain.Size = new System.Drawing.Size(230, 304);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMain_AfterSelect);
            this.treeViewMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewMain_KeyDown);
            this.treeViewMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewMain_MouseUp);
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeView.Images.SetKeyName(0, "status-offline.png");
            this.imageListTreeView.Images.SetKeyName(1, "status.png");
            this.imageListTreeView.Images.SetKeyName(2, "star-small-empty.png");
            this.imageListTreeView.Images.SetKeyName(3, "star-small.png");
            this.imageListTreeView.Images.SetKeyName(4, "chart-up.png");
            this.imageListTreeView.Images.SetKeyName(5, "layers-stack-arrange.png");
            this.imageListTreeView.Images.SetKeyName(6, "maps.png");
            this.imageListTreeView.Images.SetKeyName(7, "map.png");
            this.imageListTreeView.Images.SetKeyName(8, "zone.png");
            this.imageListTreeView.Images.SetKeyName(9, "book-open-text.png");
            // 
            // importRawDialog
            // 
            this.importRawDialog.Filter = "Text Files (*.txt)|*.txt|VLF Files (*.vlf)|*.vlf|Data Files (*.dat)|*.dat";
            this.importRawDialog.Multiselect = true;
            // 
            // openProjectDialog
            // 
            this.openProjectDialog.DefaultExt = "vlfproj";
            this.openProjectDialog.Filter = "VLF Project Files (*.vlfproj)|*.vlfproj";
            // 
            // saveProjectDialog
            // 
            this.saveProjectDialog.DefaultExt = "vlfproj";
            this.saveProjectDialog.Filter = "VLF Project Files (*.vlfproj)|*.vlfproj";
            // 
            // krigingWorker
            // 
            this.krigingWorker.WorkerReportsProgress = true;
            this.krigingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.krigingWorker_DoWork);
            this.krigingWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.krigingWorker_ProgressChanged);
            this.krigingWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.krigingWorker_RunWorkerCompleted);
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.AddExtension = false;
            this.exportFileDialog.Filter = "Out File (*.out)|*.out";
            this.exportFileDialog.Title = "Export To File";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // SVLF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsToolBar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 720);
            this.Name = "SVLF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinVLF - [New Project 1]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SVLF_FormClosing);
            this.Load += new System.EventHandler(this.SVLF_Load);
            this.tsToolBar.ResumeLayout(false);
            this.tsToolBar.PerformLayout();
            this.cmTreeNode.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip tsToolBar;
        private ContextMenuStrip cmTreeNode;
        private ToolStripMenuItem tsmPlot;
        private ToolStripMenuItem tsmExport;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private MdiClientController mdiClientController1;
        private ToolStripButton tsAddData;
        private ToolStripButton tsPlotChart;
        private ToolStripButton tsInterpolate;
        private Panel panel1;
        private StatusStrip statusStrip1;
        private ToolStripDropDownButton tsLayout;
        private ToolStripMenuItem maximizeAllToolStripMenuItem1;
        private ToolStripMenuItem minimizeAllToolStripMenuItem1;
        private ToolStripMenuItem tileHorizontallyToolStripMenuItem1;
        private ToolStripMenuItem tileVerticallyToolStripMenuItem1;
        private ToolStripMenuItem closeAllToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem cascadeToolStripMenuItem;
        private ToolStripButton tsbMovAvg;
        private ToolStripButton tsFraserFilter;
        private ToolStripButton tsKarousHjelt;
        private ToolStripMenuItem tsmDeleteRaw;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private OpenFileDialog importRawDialog;
        private ToolStripMenuItem openProjectToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private OpenFileDialog openProjectDialog;
        private SaveFileDialog saveProjectDialog;
        private ToolStripStatusLabel tsStatusLabel;
        private ToolStripMenuItem closeStripMenuItem;
        private BackgroundWorker krigingWorker;
        private ToolStripProgressBar krigingProgressBar;
        private ToolStripDropDownButton tsProcessing;
        private ToolStripMenuItem reverseSignToolStripMenuItem;
        private ToolStripMenuItem flipDistanceToolStripMenuItem;
        private ToolStripMenuItem flipAndReverseToolStripMenuItem;
        private ToolStripDropDownButton ts2DSurface;
        private TreeView treeViewMain;
        private ImageList imageListTreeView;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Label label2;
        private PropertyGrid propertyGrid1;
        private SaveFileDialog exportFileDialog;
        private ToolStripMenuItem usingFraserToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
    }
}

