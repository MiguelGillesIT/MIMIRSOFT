﻿namespace MIMIRSOFT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NetAdaptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDeRéseauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPV4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPV6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protocoleDeTransportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.périodeDeRafraîchissementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.àProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.startBtn = new System.Windows.Forms.ToolStripButton();
            this.stopBtn = new System.Windows.Forms.ToolStripButton();
            this.saveBtn = new System.Windows.Forms.ToolStripButton();
            this.detailBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.searchBtn = new System.Windows.Forms.ToolStripButton();
            this.resetBtn = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ipAddress = new System.Windows.Forms.ColumnHeader();
            this.deviceName = new System.Windows.Forms.ColumnHeader();
            this.macAddress = new System.Windows.Forms.ColumnHeader();
            this.Info = new System.Windows.Forms.ColumnHeader();
            this.adaptateurProvider = new System.Windows.Forms.ColumnHeader();
            this.firstDetection = new System.Windows.Forms.ColumnHeader();
            this.lastDetection = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.processName = new System.Windows.Forms.ColumnHeader();
            this.PID = new System.Windows.Forms.ColumnHeader();
            this.protocol = new System.Windows.Forms.ColumnHeader();
            this.localPort = new System.Windows.Forms.ColumnHeader();
            this.localAddress = new System.Windows.Forms.ColumnHeader();
            this.remotePort = new System.Windows.Forms.ColumnHeader();
            this.remoteAddress = new System.Windows.Forms.ColumnHeader();
            this.state = new System.Windows.Forms.ColumnHeader();
            this.processPath = new System.Windows.Forms.ColumnHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.index = new System.Windows.Forms.ColumnHeader();
            this.sourceIpAddr = new System.Windows.Forms.ColumnHeader();
            this.remoteIpAddr = new System.Windows.Forms.ColumnHeader();
            this.sourceMacAddr = new System.Windows.Forms.ColumnHeader();
            this.remoteMacAddr = new System.Windows.Forms.ColumnHeader();
            this.sourcePort = new System.Windows.Forms.ColumnHeader();
            this.remotePport = new System.Windows.Forms.ColumnHeader();
            this.Pprotocol = new System.Windows.Forms.ColumnHeader();
            this.length = new System.Windows.Forms.ColumnHeader();
            this.ArrivalTime = new System.Windows.Forms.ColumnHeader();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1215, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveElementsToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // saveElementsToolStripMenuItem
            // 
            this.saveElementsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveElementsToolStripMenuItem.Image")));
            this.saveElementsToolStripMenuItem.Name = "saveElementsToolStripMenuItem";
            this.saveElementsToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.saveElementsToolStripMenuItem.Text = "Sauvegarder les éléments";
            this.saveElementsToolStripMenuItem.Click += new System.EventHandler(this.saveElementsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NetAdaptToolStripMenuItem,
            this.typeDeRéseauToolStripMenuItem,
            this.protocoleDeTransportToolStripMenuItem,
            this.périodeDeRafraîchissementToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // NetAdaptToolStripMenuItem
            // 
            this.NetAdaptToolStripMenuItem.Name = "NetAdaptToolStripMenuItem";
            this.NetAdaptToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.NetAdaptToolStripMenuItem.Text = "Carte Réseau";
            this.NetAdaptToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.NetAdaptToolStripMenuItem_DropDownItemClicked);
            // 
            // typeDeRéseauToolStripMenuItem
            // 
            this.typeDeRéseauToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iPV4ToolStripMenuItem,
            this.iPV6ToolStripMenuItem});
            this.typeDeRéseauToolStripMenuItem.Name = "typeDeRéseauToolStripMenuItem";
            this.typeDeRéseauToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.typeDeRéseauToolStripMenuItem.Text = "Version IP";
            // 
            // iPV4ToolStripMenuItem
            // 
            this.iPV4ToolStripMenuItem.Checked = true;
            this.iPV4ToolStripMenuItem.CheckOnClick = true;
            this.iPV4ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iPV4ToolStripMenuItem.Name = "iPV4ToolStripMenuItem";
            this.iPV4ToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.iPV4ToolStripMenuItem.Text = "IPV4";
            // 
            // iPV6ToolStripMenuItem
            // 
            this.iPV6ToolStripMenuItem.CheckOnClick = true;
            this.iPV6ToolStripMenuItem.Name = "iPV6ToolStripMenuItem";
            this.iPV6ToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.iPV6ToolStripMenuItem.Text = "IPV6";
            // 
            // protocoleDeTransportToolStripMenuItem
            // 
            this.protocoleDeTransportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tCPToolStripMenuItem,
            this.uDPToolStripMenuItem});
            this.protocoleDeTransportToolStripMenuItem.Name = "protocoleDeTransportToolStripMenuItem";
            this.protocoleDeTransportToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.protocoleDeTransportToolStripMenuItem.Text = "Protocole de transport";
            // 
            // tCPToolStripMenuItem
            // 
            this.tCPToolStripMenuItem.CheckOnClick = true;
            this.tCPToolStripMenuItem.Name = "tCPToolStripMenuItem";
            this.tCPToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.tCPToolStripMenuItem.Text = "TCP ";
            // 
            // uDPToolStripMenuItem
            // 
            this.uDPToolStripMenuItem.CheckOnClick = true;
            this.uDPToolStripMenuItem.Name = "uDPToolStripMenuItem";
            this.uDPToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.uDPToolStripMenuItem.Text = "UDP";
            // 
            // périodeDeRafraîchissementToolStripMenuItem
            // 
            this.périodeDeRafraîchissementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sToolStripMenuItem,
            this.sToolStripMenuItem1,
            this.sToolStripMenuItem2});
            this.périodeDeRafraîchissementToolStripMenuItem.Name = "périodeDeRafraîchissementToolStripMenuItem";
            this.périodeDeRafraîchissementToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.périodeDeRafraîchissementToolStripMenuItem.Text = "Période de rafraîchissement ";
            this.périodeDeRafraîchissementToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.périodeDeRafraîchissementToolStripMenuItem_DropDownItemClicked);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Checked = true;
            this.sToolStripMenuItem.CheckOnClick = true;
            this.sToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.sToolStripMenuItem.Text = "20 sec";
            // 
            // sToolStripMenuItem1
            // 
            this.sToolStripMenuItem1.CheckOnClick = true;
            this.sToolStripMenuItem1.Name = "sToolStripMenuItem1";
            this.sToolStripMenuItem1.Size = new System.Drawing.Size(133, 26);
            this.sToolStripMenuItem1.Text = "30 sec";
            // 
            // sToolStripMenuItem2
            // 
            this.sToolStripMenuItem2.CheckOnClick = true;
            this.sToolStripMenuItem2.Name = "sToolStripMenuItem2";
            this.sToolStripMenuItem2.Size = new System.Drawing.Size(133, 26);
            this.sToolStripMenuItem2.Text = "50 sec";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.àProposToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // àProposToolStripMenuItem
            // 
            this.àProposToolStripMenuItem.Name = "àProposToolStripMenuItem";
            this.àProposToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.àProposToolStripMenuItem.Text = "À propos";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startBtn,
            this.stopBtn,
            this.saveBtn,
            this.detailBtn,
            this.deleteBtn,
            this.searchBtn,
            this.resetBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1215, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // startBtn
            // 
            this.startBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
            this.startBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(29, 24);
            this.startBtn.Text = "Lancer le scan";
            this.startBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.startBtn.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopBtn.Image = ((System.Drawing.Image)(resources.GetObject("stopBtn.Image")));
            this.stopBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(29, 24);
            this.stopBtn.Text = "Stopper le scan";
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveBtn.Enabled = false;
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(29, 24);
            this.saveBtn.Text = "Sauvegarder l\'élément";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // detailBtn
            // 
            this.detailBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.detailBtn.Enabled = false;
            this.detailBtn.Image = ((System.Drawing.Image)(resources.GetObject("detailBtn.Image")));
            this.detailBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.detailBtn.Name = "detailBtn";
            this.detailBtn.Size = new System.Drawing.Size(29, 24);
            this.detailBtn.Text = "Copier";
            this.detailBtn.Click += new System.EventHandler(this.detailBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(29, 24);
            this.deleteBtn.Text = "Supprimer l\'élément";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchBtn.Image")));
            this.searchBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(29, 24);
            this.searchBtn.Text = "Filtrer";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resetBtn.Image = ((System.Drawing.Image)(resources.GetObject("resetBtn.Image")));
            this.resetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(29, 24);
            this.resetBtn.Text = "Reinitialiser";
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 185);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1215, 564);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(1207, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Réseau";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ipAddress,
            this.deviceName,
            this.macAddress,
            this.Info,
            this.adaptateurProvider,
            this.firstDetection,
            this.lastDetection});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 4);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1201, 523);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // ipAddress
            // 
            this.ipAddress.Text = "Adresse IP";
            this.ipAddress.Width = 100;
            // 
            // deviceName
            // 
            this.deviceName.Text = "Périphérique";
            this.deviceName.Width = 150;
            // 
            // macAddress
            // 
            this.macAddress.Text = "Adresse MAC ";
            this.macAddress.Width = 150;
            // 
            // Info
            // 
            this.Info.Text = "Info";
            this.Info.Width = 150;
            // 
            // adaptateurProvider
            // 
            this.adaptateurProvider.Text = "Fournisseur ";
            this.adaptateurProvider.Width = 190;
            // 
            // firstDetection
            // 
            this.firstDetection.Text = "Première détection";
            this.firstDetection.Width = 150;
            // 
            // lastDetection
            // 
            this.lastDetection.Text = "Dernière détection";
            this.lastDetection.Width = 150;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Button-Blank-Red-icon.png");
            this.imageList1.Images.SetKeyName(1, "Button-Blank-Green-icon.png");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(1207, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ports";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processName,
            this.PID,
            this.protocol,
            this.localPort,
            this.localAddress,
            this.remotePort,
            this.remoteAddress,
            this.state,
            this.processPath});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(3, 4);
            this.listView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1201, 523);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // processName
            // 
            this.processName.Text = "Processus";
            this.processName.Width = 100;
            // 
            // PID
            // 
            this.PID.Text = "PID";
            this.PID.Width = 100;
            // 
            // protocol
            // 
            this.protocol.Text = "Protocol";
            this.protocol.Width = 100;
            // 
            // localPort
            // 
            this.localPort.Text = "Port local";
            this.localPort.Width = 100;
            // 
            // localAddress
            // 
            this.localAddress.Text = "Adresse locale";
            this.localAddress.Width = 100;
            // 
            // remotePort
            // 
            this.remotePort.Text = "Port distant";
            this.remotePort.Width = 100;
            // 
            // remoteAddress
            // 
            this.remoteAddress.Text = "Adresse distante";
            this.remoteAddress.Width = 100;
            // 
            // state
            // 
            this.state.Text = "Etat";
            this.state.Width = 100;
            // 
            // processPath
            // 
            this.processPath.Text = "Chemin du processus";
            this.processPath.Width = 200;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(1207, 531);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Paquets";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.sourceIpAddr,
            this.remoteIpAddr,
            this.sourceMacAddr,
            this.remoteMacAddr,
            this.sourcePort,
            this.remotePport,
            this.Pprotocol,
            this.length,
            this.ArrivalTime});
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.FullRowSelect = true;
            this.listView3.Location = new System.Drawing.Point(3, 4);
            this.listView3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(1201, 523);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView3_ColumnClick);
            this.listView3.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView3_ItemSelectionChanged);
            // 
            // index
            // 
            this.index.Text = "Index";
            this.index.Width = 50;
            // 
            // sourceIpAddr
            // 
            this.sourceIpAddr.Text = "Adresse IP Source";
            this.sourceIpAddr.Width = 110;
            // 
            // remoteIpAddr
            // 
            this.remoteIpAddr.Text = "Adresse IP distante";
            this.remoteIpAddr.Width = 130;
            // 
            // sourceMacAddr
            // 
            this.sourceMacAddr.Text = "Adresse MAC Source";
            this.sourceMacAddr.Width = 140;
            // 
            // remoteMacAddr
            // 
            this.remoteMacAddr.Text = "Adresse MAC distante";
            this.remoteMacAddr.Width = 140;
            // 
            // sourcePort
            // 
            this.sourcePort.Text = "Port Source";
            this.sourcePort.Width = 80;
            // 
            // remotePport
            // 
            this.remotePport.Text = "Port distant";
            this.remotePport.Width = 80;
            // 
            // Pprotocol
            // 
            this.Pprotocol.Text = "Protocole";
            this.Pprotocol.Width = 90;
            // 
            // length
            // 
            this.length.Text = "Taille";
            this.length.Width = 70;
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.Text = "Temps d\'arrivée";
            this.ArrivalTime.Width = 140;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1215, 749);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "   MIMIRSOFT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fichierToolStripMenuItem;
        private ToolStripMenuItem saveElementsToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton startBtn;
        private ToolStripButton stopBtn;
        private ToolStripButton saveBtn;
        private ToolStripButton detailBtn;
        private ToolStripButton searchBtn;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem périodeDeRafraîchissementToolStripMenuItem;
        private ToolStripMenuItem sToolStripMenuItem;
        private ToolStripMenuItem sToolStripMenuItem1;
        private ToolStripMenuItem sToolStripMenuItem2;
        private ToolStripMenuItem typeDeRéseauToolStripMenuItem;
        private ToolStripMenuItem iPV4ToolStripMenuItem;
        private ToolStripMenuItem iPV6ToolStripMenuItem;
        private ToolStripMenuItem protocoleDeTransportToolStripMenuItem;
        private ToolStripMenuItem tCPToolStripMenuItem;
        private ToolStripMenuItem uDPToolStripMenuItem;
        private ToolStripMenuItem aideToolStripMenuItem;
        private ToolStripMenuItem àProposToolStripMenuItem;
        private ToolStripMenuItem NetAdaptToolStripMenuItem;
        public ListView listView1;
        private ColumnHeader deviceName;
        private ColumnHeader ipAddress;
        private ColumnHeader macAddress;
        private ColumnHeader adaptateurProvider;
        private ColumnHeader firstDetection;
        private ColumnHeader lastDetection;
        private ListView listView2;
        private ColumnHeader processName;
        private ColumnHeader PID;
        private ColumnHeader protocol;
        private ColumnHeader localPort;
        private ColumnHeader localAddress;
        private ColumnHeader remotePort;
        private ColumnHeader remoteAddress;
        private ColumnHeader state;
        private ImageList imageList1;
        private ColumnHeader Info;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private ToolStripButton resetBtn;
        private ToolStripButton deleteBtn;
        private TabPage tabPage3;
        private ListView listView3;
        private ColumnHeader index;
        private ColumnHeader sourceIpAddr;
        private ColumnHeader remoteIpAddr;
        private ColumnHeader sourceMacAddr;
        private ColumnHeader remoteMacAddr;
        private ColumnHeader sourcePort;
        private ColumnHeader remotePport;
        private ColumnHeader Pprotocol;
        private ColumnHeader length;
        private ColumnHeader ArrivalTime;
        private ColumnHeader processPath;
        private System.Windows.Forms.Timer timer2;
    }
}