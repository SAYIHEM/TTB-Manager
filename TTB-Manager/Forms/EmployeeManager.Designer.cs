namespace TTB_Manager.Forms {
    partial class EmployeeManager {
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
            this.table_employee = new System.Windows.Forms.DataGridView();
            this.ctx_menu_empl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bearbeienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urlaubEintragenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tv_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.table_employee)).BeginInit();
            this.ctx_menu_empl.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Neuer Angestellter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // table_employee
            // 
            this.table_employee.AllowUserToAddRows = false;
            this.table_employee.AllowUserToDeleteRows = false;
            this.table_employee.AllowUserToOrderColumns = true;
            this.table_employee.AllowUserToResizeRows = false;
            this.table_employee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table_employee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_employee.Location = new System.Drawing.Point(12, 41);
            this.table_employee.Name = "table_employee";
            this.table_employee.ReadOnly = true;
            this.table_employee.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.table_employee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_employee.Size = new System.Drawing.Size(917, 452);
            this.table_employee.TabIndex = 4;
            this.table_employee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_employee_CellContentClick);
            this.table_employee.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_employee_CellMouseEnter);
            this.table_employee.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_employee_CellMouseLeave);
            this.table_employee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.table_employee_KeyDown);
            this.table_employee.MouseClick += new System.Windows.Forms.MouseEventHandler(this.table_employee_MouseClick);
            // 
            // ctx_menu_empl
            // 
            this.ctx_menu_empl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bearbeienToolStripMenuItem,
            this.krankToolStripMenuItem,
            this.urlaubEintragenToolStripMenuItem,
            this.toolStripSeparator1,
            this.löschenToolStripMenuItem});
            this.ctx_menu_empl.Name = "ctx_menu_empl";
            this.ctx_menu_empl.Size = new System.Drawing.Size(163, 98);
            this.ctx_menu_empl.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.ctx_menu_empl_Closing);
            this.ctx_menu_empl.Opening += new System.ComponentModel.CancelEventHandler(this.ctx_menu_empl_Opening);
            // 
            // bearbeienToolStripMenuItem
            // 
            this.bearbeienToolStripMenuItem.Name = "bearbeienToolStripMenuItem";
            this.bearbeienToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.bearbeienToolStripMenuItem.Text = "Bearbeiten";
            this.bearbeienToolStripMenuItem.Click += new System.EventHandler(this.bearbeienToolStripMenuItem_Click);
            // 
            // krankToolStripMenuItem
            // 
            this.krankToolStripMenuItem.CheckOnClick = true;
            this.krankToolStripMenuItem.Name = "krankToolStripMenuItem";
            this.krankToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.krankToolStripMenuItem.Text = "Krank";
            this.krankToolStripMenuItem.Click += new System.EventHandler(this.krankToolStripMenuItem_Click);
            // 
            // urlaubEintragenToolStripMenuItem
            // 
            this.urlaubEintragenToolStripMenuItem.Name = "urlaubEintragenToolStripMenuItem";
            this.urlaubEintragenToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.urlaubEintragenToolStripMenuItem.Text = "Urlaub eintragen";
            this.urlaubEintragenToolStripMenuItem.Click += new System.EventHandler(this.urlaubEintragenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.löschenToolStripMenuItem.Text = "Entlassen";
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
            // 
            // tv_search
            // 
            this.tv_search.Location = new System.Drawing.Point(712, 14);
            this.tv_search.Name = "tv_search";
            this.tv_search.Size = new System.Drawing.Size(217, 20);
            this.tv_search.TabIndex = 5;
            this.tv_search.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(655, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Suchen";
            // 
            // EmployeeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 505);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tv_search);
            this.Controls.Add(this.table_employee);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeManager";
            this.ShowInTaskbar = false;
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.EmployeeManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_employee)).EndInit();
            this.ctx_menu_empl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView table_employee;
        private System.Windows.Forms.ContextMenuStrip ctx_menu_empl;
        private System.Windows.Forms.ToolStripMenuItem bearbeienToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urlaubEintragenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem krankToolStripMenuItem;
        private System.Windows.Forms.TextBox tv_search;
        private System.Windows.Forms.Label label1;
    }
}