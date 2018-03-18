namespace TTB_Manager.Forms {
    partial class WorkplaceManager {
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
            this.table_workpl = new System.Windows.Forms.DataGridView();
            this.workpl_col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workpl_col_adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workpl_col_mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workpl_col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctx_workpl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.table_workpl)).BeginInit();
            this.ctx_workpl.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ort hinzufügen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // table_workpl
            // 
            this.table_workpl.AllowUserToAddRows = false;
            this.table_workpl.AllowUserToDeleteRows = false;
            this.table_workpl.AllowUserToOrderColumns = true;
            this.table_workpl.AllowUserToResizeRows = false;
            this.table_workpl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_workpl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.workpl_col_name,
            this.workpl_col_adress,
            this.workpl_col_mail,
            this.workpl_col_id});
            this.table_workpl.Location = new System.Drawing.Point(12, 41);
            this.table_workpl.Name = "table_workpl";
            this.table_workpl.ReadOnly = true;
            this.table_workpl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_workpl.Size = new System.Drawing.Size(787, 378);
            this.table_workpl.TabIndex = 1;
            this.table_workpl.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_workpl_CellContentClick);
            this.table_workpl.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_workpl_CellEnter);
            this.table_workpl.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_workpl_CellLeave);
            this.table_workpl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.table_workpl_KeyDown);
            this.table_workpl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.table_workpl_MouseClick);
            // 
            // workpl_col_name
            // 
            this.workpl_col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.workpl_col_name.HeaderText = "Name";
            this.workpl_col_name.Name = "workpl_col_name";
            this.workpl_col_name.ReadOnly = true;
            // 
            // workpl_col_adress
            // 
            this.workpl_col_adress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.workpl_col_adress.HeaderText = "Adresse";
            this.workpl_col_adress.Name = "workpl_col_adress";
            this.workpl_col_adress.ReadOnly = true;
            this.workpl_col_adress.Width = 70;
            // 
            // workpl_col_mail
            // 
            this.workpl_col_mail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.workpl_col_mail.HeaderText = "Mail-Adresse";
            this.workpl_col_mail.Name = "workpl_col_mail";
            this.workpl_col_mail.ReadOnly = true;
            this.workpl_col_mail.Width = 92;
            // 
            // workpl_col_id
            // 
            this.workpl_col_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.workpl_col_id.HeaderText = "ID";
            this.workpl_col_id.Name = "workpl_col_id";
            this.workpl_col_id.ReadOnly = true;
            this.workpl_col_id.Width = 43;
            // 
            // ctx_workpl
            // 
            this.ctx_workpl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bearbeitenToolStripMenuItem,
            this.toolStripSeparator1,
            this.löschenToolStripMenuItem});
            this.ctx_workpl.Name = "ctx_workpl";
            this.ctx_workpl.Size = new System.Drawing.Size(131, 54);
            this.ctx_workpl.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.ctx_workpl_Closing);
            this.ctx_workpl.Opening += new System.ComponentModel.CancelEventHandler(this.ctx_workpl_Opening);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.löschenToolStripMenuItem.Text = "Löschen";
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
            // 
            // WorkplaceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 431);
            this.Controls.Add(this.table_workpl);
            this.Controls.Add(this.button1);
            this.Name = "WorkplaceManager";
            this.Text = "Ort-Manager";
            this.Load += new System.EventHandler(this.Locations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_workpl)).EndInit();
            this.ctx_workpl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView table_workpl;
        private System.Windows.Forms.DataGridViewTextBoxColumn workpl_col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn workpl_col_adress;
        private System.Windows.Forms.DataGridViewTextBoxColumn workpl_col_mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn workpl_col_id;
        private System.Windows.Forms.ContextMenuStrip ctx_workpl;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
    }
}