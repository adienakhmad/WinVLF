namespace Simple_VLF
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVLFData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveKarousHjelt = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFraser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveContourAsPNG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readVlfDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelComponent = new System.Windows.Forms.Label();
            this.cboxComponents = new System.Windows.Forms.ComboBox();
            this.vLFEMComponentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.numSpacing = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numSkinDepth = new System.Windows.Forms.NumericUpDown();
            this.buttonFraser = new System.Windows.Forms.Button();
            this.buttonKH = new System.Windows.Forms.Button();
            this.buttonGnu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxGnuPlotAddress = new System.Windows.Forms.TextBox();
            this.buttonBrowseGnu = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.splitContainerTabMeasure = new System.Windows.Forms.SplitContainer();
            this.dgvMeasurement = new System.Windows.Forms.DataGridView();
            this.ColumnDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTilt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEllips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zgcMeasurement = new ZedGraph.ZedGraphControl();
            this.tabPageFraser = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvFraser = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zgcFraser = new ZedGraph.ZedGraphControl();
            this.tabPageKH = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvKH = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picBoxKarous = new System.Windows.Forms.PictureBox();
            this.saveFileKarous = new System.Windows.Forms.SaveFileDialog();
            this.saveFileFraser = new System.Windows.Forms.SaveFileDialog();
            this.saveAsPng = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.mainMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vLFEMComponentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkinDepth)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.splitContainerTabMeasure.Panel1.SuspendLayout();
            this.splitContainerTabMeasure.Panel2.SuspendLayout();
            this.splitContainerTabMeasure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurement)).BeginInit();
            this.tabPageFraser.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFraser)).BeginInit();
            this.tabPageKH.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxKarous)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenuStrip.Size = new System.Drawing.Size(794, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openVLFData,
            this.toolStripSeparator,
            this.saveKarousHjelt,
            this.saveFraser,
            this.toolStripSeparator1,
            this.saveContourAsPNG,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openVLFData
            // 
            this.openVLFData.Image = ((System.Drawing.Image)(resources.GetObject("openVLFData.Image")));
            this.openVLFData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openVLFData.Name = "openVLFData";
            this.openVLFData.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openVLFData.Size = new System.Drawing.Size(198, 22);
            this.openVLFData.Text = "&Open VLF Data";
            this.openVLFData.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(195, 6);
            // 
            // saveKarousHjelt
            // 
            this.saveKarousHjelt.Image = ((System.Drawing.Image)(resources.GetObject("saveKarousHjelt.Image")));
            this.saveKarousHjelt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveKarousHjelt.Name = "saveKarousHjelt";
            this.saveKarousHjelt.Size = new System.Drawing.Size(198, 22);
            this.saveKarousHjelt.Text = "&Save Karous Hajelt Data";
            this.saveKarousHjelt.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveFraser
            // 
            this.saveFraser.Image = ((System.Drawing.Image)(resources.GetObject("saveFraser.Image")));
            this.saveFraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFraser.Name = "saveFraser";
            this.saveFraser.Size = new System.Drawing.Size(198, 22);
            this.saveFraser.Text = "Save Fraser Data";
            this.saveFraser.Click += new System.EventHandler(this.saveFraser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // saveContourAsPNG
            // 
            this.saveContourAsPNG.Name = "saveContourAsPNG";
            this.saveContourAsPNG.Size = new System.Drawing.Size(198, 22);
            this.saveContourAsPNG.Text = "Save KH Plot As PNG";
            this.saveContourAsPNG.Click += new System.EventHandler(this.saveContourAsPNG_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // readVlfDialog
            // 
            this.readVlfDialog.DefaultExt = "vlf";
            this.readVlfDialog.Filter = "VLF Data Files (*.vlf)|*.vlf|Text files (*.txt) |*.txt|All files (*.*) |*.*";
            this.readVlfDialog.Title = "Open VLF Data";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 442);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(790, 438);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.labelComponent);
            this.flowLayoutPanel1.Controls.Add(this.cboxComponents);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.numSpacing);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.numSkinDepth);
            this.flowLayoutPanel1.Controls.Add(this.buttonFraser);
            this.flowLayoutPanel1.Controls.Add(this.buttonKH);
            this.flowLayoutPanel1.Controls.Add(this.buttonGnu);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(201, 438);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComponent.Location = new System.Drawing.Point(13, 10);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(113, 15);
            this.labelComponent.TabIndex = 0;
            this.labelComponent.Text = "Select Components:";
            // 
            // cboxComponents
            // 
            this.cboxComponents.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.vLFEMComponentBindingSource, "Type", true));
            this.cboxComponents.DataSource = this.vLFEMComponentBindingSource;
            this.cboxComponents.DisplayMember = "Name";
            this.cboxComponents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxComponents.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxComponents.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxComponents.FormattingEnabled = true;
            this.cboxComponents.Location = new System.Drawing.Point(15, 30);
            this.cboxComponents.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.cboxComponents.MaxDropDownItems = 2;
            this.cboxComponents.Name = "cboxComponents";
            this.cboxComponents.Size = new System.Drawing.Size(163, 23);
            this.cboxComponents.TabIndex = 1;
            this.cboxComponents.ValueMember = "Type";
            // 
            // vLFEMComponentBindingSource
            // 
            this.vLFEMComponentBindingSource.DataSource = typeof(Simple_VLF.VLF_EMComponent);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Spacing (m)";
            // 
            // numSpacing
            // 
            this.numSpacing.DecimalPlaces = 2;
            this.numSpacing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSpacing.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSpacing.Location = new System.Drawing.Point(15, 83);
            this.numSpacing.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.numSpacing.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numSpacing.Name = "numSpacing";
            this.numSpacing.Size = new System.Drawing.Size(87, 23);
            this.numSpacing.TabIndex = 11;
            this.numSpacing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Skin Depth (m)";
            // 
            // numSkinDepth
            // 
            this.numSkinDepth.DecimalPlaces = 2;
            this.numSkinDepth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSkinDepth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSkinDepth.Location = new System.Drawing.Point(15, 136);
            this.numSkinDepth.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.numSkinDepth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numSkinDepth.Name = "numSkinDepth";
            this.numSkinDepth.Size = new System.Drawing.Size(87, 23);
            this.numSkinDepth.TabIndex = 5;
            this.numSkinDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonFraser
            // 
            this.buttonFraser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonFraser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFraser.Location = new System.Drawing.Point(13, 172);
            this.buttonFraser.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.buttonFraser.Name = "buttonFraser";
            this.buttonFraser.Size = new System.Drawing.Size(118, 25);
            this.buttonFraser.TabIndex = 6;
            this.buttonFraser.Text = "Fraser Filter";
            this.buttonFraser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFraser.UseVisualStyleBackColor = true;
            this.buttonFraser.Click += new System.EventHandler(this.buttonFraser_Click);
            // 
            // buttonKH
            // 
            this.buttonKH.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonKH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKH.Location = new System.Drawing.Point(13, 210);
            this.buttonKH.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.buttonKH.Name = "buttonKH";
            this.buttonKH.Size = new System.Drawing.Size(118, 25);
            this.buttonKH.TabIndex = 3;
            this.buttonKH.Text = "Karous-Hjelt Filter";
            this.buttonKH.UseVisualStyleBackColor = true;
            this.buttonKH.Click += new System.EventHandler(this.buttonKH_Click);
            // 
            // buttonGnu
            // 
            this.buttonGnu.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGnu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGnu.Location = new System.Drawing.Point(13, 248);
            this.buttonGnu.Name = "buttonGnu";
            this.buttonGnu.Size = new System.Drawing.Size(118, 25);
            this.buttonGnu.TabIndex = 7;
            this.buttonGnu.Text = "Open in Gnu Plot";
            this.buttonGnu.UseVisualStyleBackColor = true;
            this.buttonGnu.Click += new System.EventHandler(this.buttonGnu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 291);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Gnu Plot Directory";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.textBoxGnuPlotAddress);
            this.flowLayoutPanel2.Controls.Add(this.buttonBrowseGnu);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(13, 309);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(185, 33);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // textBoxGnuPlotAddress
            // 
            this.textBoxGnuPlotAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGnuPlotAddress.Location = new System.Drawing.Point(3, 3);
            this.textBoxGnuPlotAddress.Name = "textBoxGnuPlotAddress";
            this.textBoxGnuPlotAddress.ReadOnly = true;
            this.textBoxGnuPlotAddress.Size = new System.Drawing.Size(115, 23);
            this.textBoxGnuPlotAddress.TabIndex = 0;
            // 
            // buttonBrowseGnu
            // 
            this.buttonBrowseGnu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBrowseGnu.Location = new System.Drawing.Point(124, 3);
            this.buttonBrowseGnu.Name = "buttonBrowseGnu";
            this.buttonBrowseGnu.Size = new System.Drawing.Size(30, 23);
            this.buttonBrowseGnu.TabIndex = 1;
            this.buttonBrowseGnu.Text = "...";
            this.buttonBrowseGnu.UseVisualStyleBackColor = true;
            this.buttonBrowseGnu.Click += new System.EventHandler(this.buttonBrowseGnu_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabPageFraser);
            this.tabControl1.Controls.Add(this.tabPageKH);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(85, 20);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.splitContainerTabMeasure);
            this.tabPageData.Location = new System.Drawing.Point(4, 24);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(576, 410);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "Measured";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // splitContainerTabMeasure
            // 
            this.splitContainerTabMeasure.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerTabMeasure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerTabMeasure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTabMeasure.IsSplitterFixed = true;
            this.splitContainerTabMeasure.Location = new System.Drawing.Point(3, 3);
            this.splitContainerTabMeasure.Name = "splitContainerTabMeasure";
            this.splitContainerTabMeasure.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTabMeasure.Panel1
            // 
            this.splitContainerTabMeasure.Panel1.Controls.Add(this.dgvMeasurement);
            // 
            // splitContainerTabMeasure.Panel2
            // 
            this.splitContainerTabMeasure.Panel2.Controls.Add(this.zgcMeasurement);
            this.splitContainerTabMeasure.Size = new System.Drawing.Size(570, 404);
            this.splitContainerTabMeasure.SplitterDistance = 200;
            this.splitContainerTabMeasure.TabIndex = 0;
            // 
            // dgvMeasurement
            // 
            this.dgvMeasurement.AllowUserToAddRows = false;
            this.dgvMeasurement.AllowUserToDeleteRows = false;
            this.dgvMeasurement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvMeasurement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMeasurement.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeasurement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMeasurement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasurement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDistance,
            this.ColumnTilt,
            this.ColumnEllips});
            this.dgvMeasurement.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMeasurement.Location = new System.Drawing.Point(7, 8);
            this.dgvMeasurement.Name = "dgvMeasurement";
            this.dgvMeasurement.Size = new System.Drawing.Size(556, 175);
            this.dgvMeasurement.TabIndex = 1;
            // 
            // ColumnDistance
            // 
            this.ColumnDistance.DataPropertyName = "Distance";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnDistance.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnDistance.HeaderText = "Distance (m)";
            this.ColumnDistance.Name = "ColumnDistance";
            // 
            // ColumnTilt
            // 
            this.ColumnTilt.DataPropertyName = "Tilt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "000";
            this.ColumnTilt.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnTilt.HeaderText = "Tilt (%)";
            this.ColumnTilt.Name = "ColumnTilt";
            // 
            // ColumnEllips
            // 
            this.ColumnEllips.DataPropertyName = "Ellips";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "000";
            this.ColumnEllips.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnEllips.HeaderText = "Ellips (%)";
            this.ColumnEllips.Name = "ColumnEllips";
            // 
            // zgcMeasurement
            // 
            this.zgcMeasurement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcMeasurement.EditButtons = System.Windows.Forms.MouseButtons.None;
            this.zgcMeasurement.IsAntiAlias = true;
            this.zgcMeasurement.Location = new System.Drawing.Point(0, 0);
            this.zgcMeasurement.Name = "zgcMeasurement";
            this.zgcMeasurement.ScrollGrace = 0D;
            this.zgcMeasurement.ScrollMaxX = 0D;
            this.zgcMeasurement.ScrollMaxY = 0D;
            this.zgcMeasurement.ScrollMaxY2 = 0D;
            this.zgcMeasurement.ScrollMinX = 0D;
            this.zgcMeasurement.ScrollMinY = 0D;
            this.zgcMeasurement.ScrollMinY2 = 0D;
            this.zgcMeasurement.Size = new System.Drawing.Size(566, 196);
            this.zgcMeasurement.TabIndex = 1;
            // 
            // tabPageFraser
            // 
            this.tabPageFraser.Controls.Add(this.splitContainer2);
            this.tabPageFraser.Location = new System.Drawing.Point(4, 24);
            this.tabPageFraser.Name = "tabPageFraser";
            this.tabPageFraser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFraser.Size = new System.Drawing.Size(576, 410);
            this.tabPageFraser.TabIndex = 1;
            this.tabPageFraser.Text = "Fraser Filtered";
            this.tabPageFraser.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvFraser);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.zgcFraser);
            this.splitContainer2.Size = new System.Drawing.Size(570, 404);
            this.splitContainer2.SplitterDistance = 200;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgvFraser
            // 
            this.dgvFraser.AllowUserToAddRows = false;
            this.dgvFraser.AllowUserToDeleteRows = false;
            this.dgvFraser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvFraser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFraser.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFraser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFraser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFraser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvFraser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFraser.Location = new System.Drawing.Point(7, 8);
            this.dgvFraser.Name = "dgvFraser";
            this.dgvFraser.Size = new System.Drawing.Size(556, 175);
            this.dgvFraser.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Distance";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N2";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column1.HeaderText = "Distance (m)";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Fraser";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column2.HeaderText = "Fraser Value";
            this.Column2.Name = "Column2";
            // 
            // zgcFraser
            // 
            this.zgcFraser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcFraser.EditButtons = System.Windows.Forms.MouseButtons.None;
            this.zgcFraser.IsAntiAlias = true;
            this.zgcFraser.Location = new System.Drawing.Point(0, 0);
            this.zgcFraser.Name = "zgcFraser";
            this.zgcFraser.ScrollGrace = 0D;
            this.zgcFraser.ScrollMaxX = 0D;
            this.zgcFraser.ScrollMaxY = 0D;
            this.zgcFraser.ScrollMaxY2 = 0D;
            this.zgcFraser.ScrollMinX = 0D;
            this.zgcFraser.ScrollMinY = 0D;
            this.zgcFraser.ScrollMinY2 = 0D;
            this.zgcFraser.Size = new System.Drawing.Size(566, 196);
            this.zgcFraser.TabIndex = 1;
            // 
            // tabPageKH
            // 
            this.tabPageKH.Controls.Add(this.splitContainer3);
            this.tabPageKH.Location = new System.Drawing.Point(4, 24);
            this.tabPageKH.Name = "tabPageKH";
            this.tabPageKH.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKH.Size = new System.Drawing.Size(576, 410);
            this.tabPageKH.TabIndex = 2;
            this.tabPageKH.Text = "Karous Hjelt Filtered";
            this.tabPageKH.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvKH);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.picBoxKarous);
            this.splitContainer3.Size = new System.Drawing.Size(570, 404);
            this.splitContainer3.SplitterDistance = 200;
            this.splitContainer3.TabIndex = 1;
            // 
            // dgvKH
            // 
            this.dgvKH.AllowUserToAddRows = false;
            this.dgvKH.AllowUserToDeleteRows = false;
            this.dgvKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKH.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvKH.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvKH.Location = new System.Drawing.Point(7, 8);
            this.dgvKH.Name = "dgvKH";
            this.dgvKH.Size = new System.Drawing.Size(556, 175);
            this.dgvKH.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Distance";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn1.HeaderText = "Distance (m)";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Depth";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "N1";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn2.HeaderText = "Depth (m)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "KH";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "N4";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn3.HeaderText = "KH Value";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // picBoxKarous
            // 
            this.picBoxKarous.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxKarous.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxKarous.Location = new System.Drawing.Point(0, 0);
            this.picBoxKarous.Name = "picBoxKarous";
            this.picBoxKarous.Size = new System.Drawing.Size(566, 196);
            this.picBoxKarous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxKarous.TabIndex = 3;
            this.picBoxKarous.TabStop = false;
            // 
            // saveFileKarous
            // 
            this.saveFileKarous.Filter = "Karous Hjelt Filtered Data (*.kh) |*.kh|Text files (*.txt) |*.txt|All files (*.*)" +
    " |*.*";
            // 
            // saveFileFraser
            // 
            this.saveFileFraser.Filter = "Fraser Files (*.fraser) |*.fraser|Text files (*.txt) |*.txt|All files (*.*) |*.*";
            // 
            // saveAsPng
            // 
            this.saveAsPng.Filter = "Portable Network Graphics (*.ecdPlot_png)|*.ecdPlot_png";
            this.saveAsPng.FileOk += new System.ComponentModel.CancelEventHandler(this.saveAsPng_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(794, 466);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple VLF-EM Filtering";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vLFEMComponentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkinDepth)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.splitContainerTabMeasure.Panel1.ResumeLayout(false);
            this.splitContainerTabMeasure.Panel2.ResumeLayout(false);
            this.splitContainerTabMeasure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurement)).EndInit();
            this.tabPageFraser.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFraser)).EndInit();
            this.tabPageKH.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxKarous)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVLFData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveKarousHjelt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog readVlfDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem saveContourAsPNG;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileKarous;
        private System.Windows.Forms.SaveFileDialog saveFileFraser;
        private System.Windows.Forms.SaveFileDialog saveAsPng;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelComponent;
        private System.Windows.Forms.ComboBox cboxComponents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSkinDepth;
        private System.Windows.Forms.Button buttonFraser;
        private System.Windows.Forms.Button buttonKH;
        private System.Windows.Forms.Button buttonGnu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxGnuPlotAddress;
        private System.Windows.Forms.Button buttonBrowseGnu;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.SplitContainer splitContainerTabMeasure;
        private System.Windows.Forms.DataGridView dgvMeasurement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTilt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEllips;
        private ZedGraph.ZedGraphControl zgcMeasurement;
        private System.Windows.Forms.TabPage tabPageFraser;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvFraser;
        private ZedGraph.ZedGraphControl zgcFraser;
        private System.Windows.Forms.TabPage tabPageKH;
        private System.Windows.Forms.PictureBox picBoxKarous;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSpacing;
        private System.Windows.Forms.BindingSource vLFEMComponentBindingSource;
        private System.Windows.Forms.ToolStripMenuItem saveFraser;
    }
}

