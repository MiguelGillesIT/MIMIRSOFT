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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lancerLeScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carteRéseauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.deviceName = new System.Windows.Forms.ColumnHeader();
            this.ipAddress = new System.Windows.Forms.ColumnHeader();
            this.macAddress = new System.Windows.Forms.ColumnHeader();
            this.adaptateurProvider = new System.Windows.Forms.ColumnHeader();
            this.status = new System.Windows.Forms.ColumnHeader();
            this.firstDetection = new System.Windows.Forms.ColumnHeader();
            this.lastDetection = new System.Windows.Forms.ColumnHeader();
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
            this.menuStrip1.Size = new System.Drawing.Size(1058, 24);
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
            this.carteRéseauToolStripMenuItem,
            this.typeDeRéseauToolStripMenuItem,
            this.protocoleDeTransportToolStripMenuItem,
            this.périodeDeRafraîchissementToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // carteRéseauToolStripMenuItem
            // 
            this.carteRéseauToolStripMenuItem.Name = "carteRéseauToolStripMenuItem";
            this.carteRéseauToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.carteRéseauToolStripMenuItem.Text = "Carte Réseau";
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
            this.iPV4ToolStripMenuItem.Name = "iPV4ToolStripMenuItem";
            this.iPV4ToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.iPV4ToolStripMenuItem.Text = "IPV4";
            // 
            // iPV6ToolStripMenuItem
            // 
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
            this.tCPToolStripMenuItem.Name = "tCPToolStripMenuItem";
            this.tCPToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.tCPToolStripMenuItem.Text = "TCP ";
            // 
            // uDPToolStripMenuItem
            // 
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
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.sToolStripMenuItem.Text = "10 s";
            // 
            // sToolStripMenuItem1
            // 
            this.sToolStripMenuItem1.Name = "sToolStripMenuItem1";
            this.sToolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.sToolStripMenuItem1.Text = "20 s";
            // 
            // sToolStripMenuItem2
            // 
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
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1058, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Lancer le scan";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripButton1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Stopper le scan";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Sauvegarder l\'élément";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Détails de l\'élément";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Filtrer";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Rafraîchir ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 139);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1058, 423);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1050, 395);
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
            this.adaptateurProvider,
            this.status,
            this.firstDetection,
            this.lastDetection});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1044, 389);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // adaptateurProvider
            // 
            this.adaptateurProvider.Text = "Fournisseur ";
            this.adaptateurProvider.Width = 150;
            // 
            // status
            // 
            this.status.Text = "Activité";
            this.status.Width = 150;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1050, 395);
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
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1044, 389);
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
            this.ClientSize = new System.Drawing.Size(1058, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "   MIMRSOFT";
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
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
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
        private ToolStripMenuItem carteRéseauToolStripMenuItem;
        private ListView listView1;
        private ColumnHeader deviceName;
        private ColumnHeader ipAddress;
        private ColumnHeader macAddress;
        private ColumnHeader adaptateurProvider;
        private ColumnHeader status;
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
    }
}