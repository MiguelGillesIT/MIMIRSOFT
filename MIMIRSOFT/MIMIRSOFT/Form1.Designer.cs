namespace MIMIRSOFT
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
            this.lancerLeScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.searchBtn = new System.Windows.Forms.ToolStripButton();
            this.refreshBtn = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.deviceName = new System.Windows.Forms.ColumnHeader();
            this.ipAddress = new System.Windows.Forms.ColumnHeader();
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
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1063, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lancerLeScanToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // lancerLeScanToolStripMenuItem
            // 
            this.lancerLeScanToolStripMenuItem.Name = "lancerLeScanToolStripMenuItem";
            this.lancerLeScanToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.lancerLeScanToolStripMenuItem.Text = "Sauvegarder les éléments";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NetAdaptToolStripMenuItem,
            this.typeDeRéseauToolStripMenuItem,
            this.protocoleDeTransportToolStripMenuItem,
            this.périodeDeRafraîchissementToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // NetAdaptToolStripMenuItem
            // 
            this.NetAdaptToolStripMenuItem.Name = "NetAdaptToolStripMenuItem";
            this.NetAdaptToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.NetAdaptToolStripMenuItem.Text = "Carte Réseau";
            this.NetAdaptToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.NetAdaptToolStripMenuItem_DropDownItemClicked);
            // 
            // typeDeRéseauToolStripMenuItem
            // 
            this.typeDeRéseauToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iPV4ToolStripMenuItem,
            this.iPV6ToolStripMenuItem});
            this.typeDeRéseauToolStripMenuItem.Name = "typeDeRéseauToolStripMenuItem";
            this.typeDeRéseauToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.typeDeRéseauToolStripMenuItem.Text = "Version IP";
            // 
            // iPV4ToolStripMenuItem
            // 
            this.iPV4ToolStripMenuItem.Checked = true;
            this.iPV4ToolStripMenuItem.CheckOnClick = true;
            this.iPV4ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iPV4ToolStripMenuItem.Name = "iPV4ToolStripMenuItem";
            this.iPV4ToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.iPV4ToolStripMenuItem.Text = "IPV4";
            // 
            // iPV6ToolStripMenuItem
            // 
            this.iPV6ToolStripMenuItem.CheckOnClick = true;
            this.iPV6ToolStripMenuItem.Name = "iPV6ToolStripMenuItem";
            this.iPV6ToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.iPV6ToolStripMenuItem.Text = "IPV6";
            // 
            // protocoleDeTransportToolStripMenuItem
            // 
            this.protocoleDeTransportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tCPToolStripMenuItem,
            this.uDPToolStripMenuItem});
            this.protocoleDeTransportToolStripMenuItem.Name = "protocoleDeTransportToolStripMenuItem";
            this.protocoleDeTransportToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.protocoleDeTransportToolStripMenuItem.Text = "Protocole de transport";
            // 
            // tCPToolStripMenuItem
            // 
            this.tCPToolStripMenuItem.CheckOnClick = true;
            this.tCPToolStripMenuItem.Name = "tCPToolStripMenuItem";
            this.tCPToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.tCPToolStripMenuItem.Text = "TCP ";
            // 
            // uDPToolStripMenuItem
            // 
            this.uDPToolStripMenuItem.CheckOnClick = true;
            this.uDPToolStripMenuItem.Name = "uDPToolStripMenuItem";
            this.uDPToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.uDPToolStripMenuItem.Text = "UDP";
            // 
            // périodeDeRafraîchissementToolStripMenuItem
            // 
            this.périodeDeRafraîchissementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sToolStripMenuItem,
            this.sToolStripMenuItem1,
            this.sToolStripMenuItem2});
            this.périodeDeRafraîchissementToolStripMenuItem.Name = "périodeDeRafraîchissementToolStripMenuItem";
            this.périodeDeRafraîchissementToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.périodeDeRafraîchissementToolStripMenuItem.Text = "Période de rafraîchissement ";
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.CheckOnClick = true;
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.sToolStripMenuItem.Text = "10 s";
            // 
            // sToolStripMenuItem1
            // 
            this.sToolStripMenuItem1.CheckOnClick = true;
            this.sToolStripMenuItem1.Name = "sToolStripMenuItem1";
            this.sToolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.sToolStripMenuItem1.Text = "20 s";
            // 
            // sToolStripMenuItem2
            // 
            this.sToolStripMenuItem2.CheckOnClick = true;
            this.sToolStripMenuItem2.Name = "sToolStripMenuItem2";
            this.sToolStripMenuItem2.Size = new System.Drawing.Size(94, 22);
            this.sToolStripMenuItem2.Text = "30 s";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.àProposToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // àProposToolStripMenuItem
            // 
            this.àProposToolStripMenuItem.Name = "àProposToolStripMenuItem";
            this.àProposToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.àProposToolStripMenuItem.Text = "À propos";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startBtn,
            this.stopBtn,
            this.saveBtn,
            this.detailBtn,
            this.searchBtn,
            this.refreshBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1063, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // startBtn
            // 
            this.startBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
            this.startBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(23, 22);
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
            this.stopBtn.Size = new System.Drawing.Size(23, 22);
            this.stopBtn.Text = "Stopper le scan";
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(23, 22);
            this.saveBtn.Text = "Sauvegarder l\'élément";
            // 
            // detailBtn
            // 
            this.detailBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.detailBtn.Image = ((System.Drawing.Image)(resources.GetObject("detailBtn.Image")));
            this.detailBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.detailBtn.Name = "detailBtn";
            this.detailBtn.Size = new System.Drawing.Size(23, 22);
            this.detailBtn.Text = "Détails de l\'élément";
            // 
            // searchBtn
            // 
            this.searchBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchBtn.Image")));
            this.searchBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(23, 22);
            this.searchBtn.Text = "Filtrer";
            // 
            // refreshBtn
            // 
            this.refreshBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshBtn.Image")));
            this.refreshBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(23, 22);
            this.refreshBtn.Text = "Rafraîchir ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 139);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1184, 423);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1176, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Réseau";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.deviceName,
            this.ipAddress,
            this.macAddress,
            this.Info,
            this.adaptateurProvider,
            this.firstDetection,
            this.lastDetection});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1170, 389);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // deviceName
            // 
            this.deviceName.Text = "Périphérique";
            this.deviceName.Width = 150;
            // 
            // ipAddress
            // 
            this.ipAddress.Text = "Adresse IP";
            this.ipAddress.Width = 150;
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
            this.adaptateurProvider.Width = 150;
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
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1176, 395);
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
            this.state});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1170, 389);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1063, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "   MIMRSOFT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fichierToolStripMenuItem;
        private ToolStripMenuItem lancerLeScanToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton startBtn;
        private ToolStripButton stopBtn;
        private ToolStripButton saveBtn;
        private ToolStripButton detailBtn;
        private ToolStripButton searchBtn;
        private ToolStripButton refreshBtn;
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
        private ListView listView1;
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
    }
}