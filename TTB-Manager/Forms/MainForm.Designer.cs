namespace TTB_Manager.Forms
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.schichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schichtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vorlageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleVorlagenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.alleAnzeigenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.orteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.alleAnzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrechnungDruckenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.umsatzStatistikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kontenverwaltungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menustrip_masterview = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.table_main = new System.Windows.Forms.DataGridView();
            this.rB_future = new System.Windows.Forms.RadioButton();
            this.rB_week = new System.Windows.Forms.RadioButton();
            this.rB_all = new System.Windows.Forms.RadioButton();
            this.main_ctxmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctx_main_editshift = new System.Windows.Forms.ToolStripMenuItem();
            this.ctx_main_personal = new System.Windows.Forms.ToolStripMenuItem();
            this.ctx_main_comment = new System.Windows.Forms.ToolStripMenuItem();
            this.ctx_main_notifythem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctx_main_overtimeedit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctx_main_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_main)).BeginInit();
            this.main_ctxmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schichtToolStripMenuItem,
            this.personalToolStripMenuItem1,
            this.orteToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.kontoToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.ansichtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1044, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // schichtToolStripMenuItem
            // 
            this.schichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.alleVorlagenToolStripMenuItem});
            this.schichtToolStripMenuItem.Name = "schichtToolStripMenuItem";
            this.schichtToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.schichtToolStripMenuItem.Text = "Schichten";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schichtToolStripMenuItem1,
            this.vorlageToolStripMenuItem});
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            // 
            // schichtToolStripMenuItem1
            // 
            this.schichtToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.schichtToolStripMenuItem1.Name = "schichtToolStripMenuItem1";
            this.schichtToolStripMenuItem1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.schichtToolStripMenuItem1.ShortcutKeyDisplayString = "F3";
            this.schichtToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.schichtToolStripMenuItem1.Text = "Schicht";
            this.schichtToolStripMenuItem1.Click += new System.EventHandler(this.schichtToolStripMenuItem1_Click);
            // 
            // vorlageToolStripMenuItem
            // 
            this.vorlageToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.vorlageToolStripMenuItem.Name = "vorlageToolStripMenuItem";
            this.vorlageToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.vorlageToolStripMenuItem.Text = "Vorlage";
            this.vorlageToolStripMenuItem.Click += new System.EventHandler(this.vorlageToolStripMenuItem_Click);
            // 
            // alleVorlagenToolStripMenuItem
            // 
            this.alleVorlagenToolStripMenuItem.Name = "alleVorlagenToolStripMenuItem";
            this.alleVorlagenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.alleVorlagenToolStripMenuItem.Text = "Vorlagen";
            this.alleVorlagenToolStripMenuItem.Click += new System.EventHandler(this.alleVorlagenToolStripMenuItem_Click);
            // 
            // personalToolStripMenuItem1
            // 
            this.personalToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem2,
            this.alleAnzeigenToolStripMenuItem1});
            this.personalToolStripMenuItem1.Name = "personalToolStripMenuItem1";
            this.personalToolStripMenuItem1.Size = new System.Drawing.Size(64, 20);
            this.personalToolStripMenuItem1.Text = "Personal";
            // 
            // neuToolStripMenuItem2
            // 
            this.neuToolStripMenuItem2.Name = "neuToolStripMenuItem2";
            this.neuToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.neuToolStripMenuItem2.Text = "Neu";
            this.neuToolStripMenuItem2.Click += new System.EventHandler(this.neuToolStripMenuItem2_Click);
            // 
            // alleAnzeigenToolStripMenuItem1
            // 
            this.alleAnzeigenToolStripMenuItem1.Name = "alleAnzeigenToolStripMenuItem1";
            this.alleAnzeigenToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.alleAnzeigenToolStripMenuItem1.Text = "Verwalten";
            this.alleAnzeigenToolStripMenuItem1.Click += new System.EventHandler(this.alleAnzeigenToolStripMenuItem1_Click);
            // 
            // orteToolStripMenuItem
            // 
            this.orteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem1,
            this.alleAnzeigenToolStripMenuItem});
            this.orteToolStripMenuItem.Name = "orteToolStripMenuItem";
            this.orteToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.orteToolStripMenuItem.Text = "Orte";
            // 
            // neuToolStripMenuItem1
            // 
            this.neuToolStripMenuItem1.Name = "neuToolStripMenuItem1";
            this.neuToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.neuToolStripMenuItem1.Text = "Neu";
            this.neuToolStripMenuItem1.Click += new System.EventHandler(this.neuToolStripMenuItem1_Click);
            // 
            // alleAnzeigenToolStripMenuItem
            // 
            this.alleAnzeigenToolStripMenuItem.Name = "alleAnzeigenToolStripMenuItem";
            this.alleAnzeigenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.alleAnzeigenToolStripMenuItem.Text = "Verwalten";
            this.alleAnzeigenToolStripMenuItem.Click += new System.EventHandler(this.alleAnzeigenToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrechnungDruckenToolStripMenuItem,
            this.umsatzStatistikToolStripMenuItem,
            this.backupToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // abrechnungDruckenToolStripMenuItem
            // 
            this.abrechnungDruckenToolStripMenuItem.Name = "abrechnungDruckenToolStripMenuItem";
            this.abrechnungDruckenToolStripMenuItem.ShortcutKeyDisplayString = "F7";
            this.abrechnungDruckenToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.abrechnungDruckenToolStripMenuItem.Text = "Abrechnung drucken";
            this.abrechnungDruckenToolStripMenuItem.Click += new System.EventHandler(this.abrechnungDruckenToolStripMenuItem_Click);
            // 
            // umsatzStatistikToolStripMenuItem
            // 
            this.umsatzStatistikToolStripMenuItem.Name = "umsatzStatistikToolStripMenuItem";
            this.umsatzStatistikToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.umsatzStatistikToolStripMenuItem.Text = "Umsatz-Statistik";
            this.umsatzStatistikToolStripMenuItem.Click += new System.EventHandler(this.umsatzStatistikToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offlineToolStripMenuItem,
            this.onlineToolStripMenuItem});
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // offlineToolStripMenuItem
            // 
            this.offlineToolStripMenuItem.Name = "offlineToolStripMenuItem";
            this.offlineToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.offlineToolStripMenuItem.Text = "Lokal";
            this.offlineToolStripMenuItem.Click += new System.EventHandler(this.offlineToolStripMenuItem_Click);
            // 
            // onlineToolStripMenuItem
            // 
            this.onlineToolStripMenuItem.Name = "onlineToolStripMenuItem";
            this.onlineToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.onlineToolStripMenuItem.Text = "Online";
            // 
            // kontoToolStripMenuItem
            // 
            this.kontoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kontenverwaltungToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.kontoToolStripMenuItem.Name = "kontoToolStripMenuItem";
            this.kontoToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.kontoToolStripMenuItem.Text = "Konto";
            this.kontoToolStripMenuItem.Click += new System.EventHandler(this.kontoToolStripMenuItem_Click);
            // 
            // kontenverwaltungToolStripMenuItem
            // 
            this.kontenverwaltungToolStripMenuItem.Name = "kontenverwaltungToolStripMenuItem";
            this.kontenverwaltungToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.kontenverwaltungToolStripMenuItem.Text = "Kontenverwaltung";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menustrip_masterview});
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // menustrip_masterview
            // 
            this.menustrip_masterview.CheckOnClick = true;
            this.menustrip_masterview.Name = "menustrip_masterview";
            this.menustrip_masterview.Size = new System.Drawing.Size(138, 22);
            this.menustrip_masterview.Text = "Master View";
            this.menustrip_masterview.Click += new System.EventHandler(this.menustrip_masterview_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(921, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Schicht hinzufügen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // table_main
            // 
            this.table_main.AllowUserToAddRows = false;
            this.table_main.AllowUserToDeleteRows = false;
            this.table_main.AllowUserToOrderColumns = true;
            this.table_main.AllowUserToResizeRows = false;
            this.table_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_main.Location = new System.Drawing.Point(12, 78);
            this.table_main.Name = "table_main";
            this.table_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_main.Size = new System.Drawing.Size(1020, 490);
            this.table_main.TabIndex = 6;
            this.table_main.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_main_CellContentClick);
            this.table_main.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_main_CellMouseEnter);
            this.table_main.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_main_CellMouseLeave);
            this.table_main.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_main_Value_Changed);
            this.table_main.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.table_main_columnheadermouseclick);
            this.table_main.DoubleClick += new System.EventHandler(this.table_main_DoubleClick);
            this.table_main.MouseClick += new System.Windows.Forms.MouseEventHandler(this.table_main_MouseClick);
            // 
            // rB_future
            // 
            this.rB_future.AutoSize = true;
            this.rB_future.Location = new System.Drawing.Point(135, 43);
            this.rB_future.Name = "rB_future";
            this.rB_future.Size = new System.Drawing.Size(102, 17);
            this.rB_future.TabIndex = 5;
            this.rB_future.Text = "Alle Zukünftigen";
            this.rB_future.UseVisualStyleBackColor = true;
            this.rB_future.CheckedChanged += new System.EventHandler(this.rB_future_CheckedChanged);
            // 
            // rB_week
            // 
            this.rB_week.AutoSize = true;
            this.rB_week.Checked = true;
            this.rB_week.Location = new System.Drawing.Point(12, 43);
            this.rB_week.Name = "rB_week";
            this.rB_week.Size = new System.Drawing.Size(90, 17);
            this.rB_week.TabIndex = 4;
            this.rB_week.TabStop = true;
            this.rB_week.Text = "Diese Woche";
            this.rB_week.UseVisualStyleBackColor = true;
            this.rB_week.CheckedChanged += new System.EventHandler(this.rB_week_CheckedChanged);
            // 
            // rB_all
            // 
            this.rB_all.AutoSize = true;
            this.rB_all.Location = new System.Drawing.Point(278, 43);
            this.rB_all.Name = "rB_all";
            this.rB_all.Size = new System.Drawing.Size(42, 17);
            this.rB_all.TabIndex = 8;
            this.rB_all.Text = "Alle";
            this.rB_all.UseVisualStyleBackColor = true;
            this.rB_all.CheckedChanged += new System.EventHandler(this.rB_all_CheckedChanged);
            // 
            // main_ctxmenu
            // 
            this.main_ctxmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctx_main_editshift,
            this.ctx_main_personal,
            this.ctx_main_comment,
            this.ctx_main_notifythem,
            this.ctx_main_overtimeedit,
            this.toolStripSeparator1,
            this.ctx_main_delete});
            this.main_ctxmenu.Name = "main_ctxmenu";
            this.main_ctxmenu.Size = new System.Drawing.Size(209, 142);
            this.main_ctxmenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.ctxmenu_main_Closing);
            this.main_ctxmenu.Opening += new System.ComponentModel.CancelEventHandler(this.main_ctxmenu_Opening);
            // 
            // ctx_main_editshift
            // 
            this.ctx_main_editshift.Name = "ctx_main_editshift";
            this.ctx_main_editshift.Size = new System.Drawing.Size(208, 22);
            this.ctx_main_editshift.Text = "Schicht bearbeiten";
            this.ctx_main_editshift.Click += new System.EventHandler(this.ctx_main_editshift_Click);
            // 
            // ctx_main_personal
            // 
            this.ctx_main_personal.Name = "ctx_main_personal";
            this.ctx_main_personal.Size = new System.Drawing.Size(208, 22);
            this.ctx_main_personal.Text = "Personal zuweisen";
            this.ctx_main_personal.Click += new System.EventHandler(this.ctx_main_personal_Click);
            // 
            // ctx_main_comment
            // 
            this.ctx_main_comment.Name = "ctx_main_comment";
            this.ctx_main_comment.Size = new System.Drawing.Size(208, 22);
            this.ctx_main_comment.Text = "Kommentar bearbeiten";
            this.ctx_main_comment.Click += new System.EventHandler(this.ctx_main_comment_Click);
            // 
            // ctx_main_notifythem
            // 
            this.ctx_main_notifythem.Name = "ctx_main_notifythem";
            this.ctx_main_notifythem.Size = new System.Drawing.Size(208, 22);
            this.ctx_main_notifythem.Text = "Personal benachrichtigen";
            this.ctx_main_notifythem.Click += new System.EventHandler(this.ctx_main_notifythem_Click);
            // 
            // ctx_main_overtimeedit
            // 
            this.ctx_main_overtimeedit.Name = "ctx_main_overtimeedit";
            this.ctx_main_overtimeedit.Size = new System.Drawing.Size(208, 22);
            this.ctx_main_overtimeedit.Text = "Überstunden eintragen";
            this.ctx_main_overtimeedit.Click += new System.EventHandler(this.überstundenEintragenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // ctx_main_delete
            // 
            this.ctx_main_delete.Name = "ctx_main_delete";
            this.ctx_main_delete.Size = new System.Drawing.Size(208, 22);
            this.ctx_main_delete.Text = "Löschen";
            this.ctx_main_delete.Click += new System.EventHandler(this.ctx_main_delete_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Test";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 580);
            this.Controls.Add(this.rB_all);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.table_main);
            this.Controls.Add(this.rB_future);
            this.Controls.Add(this.rB_week);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TTB Personal";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_main)).EndInit();
            this.main_ctxmenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kontoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrechnungDruckenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView table_main;
        private System.Windows.Forms.RadioButton rB_future;
        private System.Windows.Forms.RadioButton rB_week;
        private System.Windows.Forms.RadioButton rB_all;
        private System.Windows.Forms.ToolStripMenuItem umsatzStatistikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kontenverwaltungToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip main_ctxmenu;
        private System.Windows.Forms.ToolStripMenuItem ctx_main_comment;
        private System.Windows.Forms.ToolStripMenuItem ctx_main_delete;
        private System.Windows.Forms.ToolStripMenuItem ctx_main_personal;
        private System.Windows.Forms.ToolStripMenuItem ctx_main_editshift;
        private System.Windows.Forms.ToolStripMenuItem ctx_main_notifythem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem schichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem orteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schichtToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vorlageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alleAnzeigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem alleAnzeigenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alleVorlagenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctx_main_overtimeedit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem menustrip_masterview;
    }
}

