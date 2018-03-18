namespace TTB_Manager.Forms {
    partial class ShiftManager {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.table_templ = new System.Windows.Forms.DataGridView();
            this.ctx_menu_shiftmanager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.table_templ)).BeginInit();
            this.ctx_menu_shiftmanager.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Vorlage hinzufügen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // table_templ
            // 
            this.table_templ.AllowUserToAddRows = false;
            this.table_templ.AllowUserToDeleteRows = false;
            this.table_templ.AllowUserToOrderColumns = true;
            this.table_templ.AllowUserToResizeRows = false;
            this.table_templ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table_templ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_templ.Location = new System.Drawing.Point(12, 41);
            this.table_templ.Name = "table_templ";
            this.table_templ.ReadOnly = true;
            this.table_templ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_templ.Size = new System.Drawing.Size(658, 229);
            this.table_templ.TabIndex = 1;
            this.table_templ.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_templ_CellContentClick);
            this.table_templ.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_templ_CellMouseEnter);
            this.table_templ.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_templ_CellMouseLeave);
            this.table_templ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.table_templ_KeyDown);
            this.table_templ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.table_templ_MouseClick);
            // 
            // ctx_menu_shiftmanager
            // 
            this.ctx_menu_shiftmanager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bearbeitenToolStripMenuItem,
            this.löschenToolStripMenuItem});
            this.ctx_menu_shiftmanager.Name = "ctx_menu_shiftmanager";
            this.ctx_menu_shiftmanager.Size = new System.Drawing.Size(131, 48);
            this.ctx_menu_shiftmanager.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStrip1_Closing);
            this.ctx_menu_shiftmanager.Opening += new System.ComponentModel.CancelEventHandler(this.ctx_menu_shiftmanager_Opening);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            this.bearbeitenToolStripMenuItem.Click += new System.EventHandler(this.bearbeitenToolStripMenuItem_Click);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.löschenToolStripMenuItem.Text = "Löschen";
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
            // 
            // ShiftManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 282);
            this.Controls.Add(this.table_templ);
            this.Controls.Add(this.button1);
            this.Name = "ShiftManager";
            this.Text = "Schicht-Vorlagen";
            this.Load += new System.EventHandler(this.ShiftManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_templ)).EndInit();
            this.ctx_menu_shiftmanager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView table_templ;
        private System.Windows.Forms.ContextMenuStrip ctx_menu_shiftmanager;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
    }
}