namespace TTB_Manager.Forms {
    partial class MasterView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterView));
            this.panel_employees = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_time = new System.Windows.Forms.Label();
            this.clock_timer = new System.Windows.Forms.Timer(this.components);
            this.lab_nextshift = new System.Windows.Forms.Label();
            this.panel_curshifts = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_date = new System.Windows.Forms.Label();
            this.tv_empl_search = new System.Windows.Forms.TextBox();
            this.employee_state_timer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_employees
            // 
            this.panel_employees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_employees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_employees.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel_employees.Location = new System.Drawing.Point(12, 398);
            this.panel_employees.Name = "panel_employees";
            this.panel_employees.Size = new System.Drawing.Size(215, 170);
            this.panel_employees.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Personal";
            // 
            // lab_time
            // 
            this.lab_time.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lab_time.AutoSize = true;
            this.lab_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_time.Location = new System.Drawing.Point(84, 24);
            this.lab_time.Name = "lab_time";
            this.lab_time.Size = new System.Drawing.Size(64, 33);
            this.lab_time.TabIndex = 3;
            this.lab_time.Text = "Zeit";
            // 
            // clock_timer
            // 
            this.clock_timer.Tick += new System.EventHandler(this.clock_timer_Tick);
            // 
            // lab_nextshift
            // 
            this.lab_nextshift.AutoSize = true;
            this.lab_nextshift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_nextshift.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_nextshift.Location = new System.Drawing.Point(6, 9);
            this.lab_nextshift.Name = "lab_nextshift";
            this.lab_nextshift.Size = new System.Drawing.Size(49, 20);
            this.lab_nextshift.TabIndex = 5;
            this.lab_nextshift.Text = "Keine";
            // 
            // panel_curshifts
            // 
            this.panel_curshifts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_curshifts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_curshifts.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel_curshifts.Location = new System.Drawing.Point(12, 237);
            this.panel_curshifts.Name = "panel_curshifts";
            this.panel_curshifts.Size = new System.Drawing.Size(215, 114);
            this.panel_curshifts.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Laufende Schichten";
            // 
            // lab_date
            // 
            this.lab_date.AutoSize = true;
            this.lab_date.Location = new System.Drawing.Point(93, 10);
            this.lab_date.Name = "lab_date";
            this.lab_date.Size = new System.Drawing.Size(38, 13);
            this.lab_date.TabIndex = 10;
            this.lab_date.Text = "Datum";
            // 
            // tv_empl_search
            // 
            this.tv_empl_search.HideSelection = false;
            this.tv_empl_search.Location = new System.Drawing.Point(12, 366);
            this.tv_empl_search.Name = "tv_empl_search";
            this.tv_empl_search.Size = new System.Drawing.Size(215, 20);
            this.tv_empl_search.TabIndex = 0;
            this.tv_empl_search.TabStop = false;
            this.tv_empl_search.TextChanged += new System.EventHandler(this.tv_empl_search_TextChanged);
            this.tv_empl_search.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_empl_search_MouseDown);
            this.tv_empl_search.MouseLeave += new System.EventHandler(this.tv_empl_search_MouseLeave);
            // 
            // employee_state_timer
            // 
            this.employee_state_timer.Interval = 60000;
            this.employee_state_timer.Tick += new System.EventHandler(this.employee_state_timer_Tick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lab_nextshift);
            this.panel2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(12, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 37);
            this.panel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nächste Schicht";
            // 
            // MasterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 580);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tv_empl_search);
            this.Controls.Add(this.lab_date);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel_curshifts);
            this.Controls.Add(this.lab_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_employees);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MasterView";
            this.Text = "MasterView";
            this.Deactivate += new System.EventHandler(this.MasterView_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterView_FormClosing);
            this.Load += new System.EventHandler(this.MasterView_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_employees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_time;
        private System.Windows.Forms.Timer clock_timer;
        private System.Windows.Forms.Label lab_nextshift;
        private System.Windows.Forms.Panel panel_curshifts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab_date;
        private System.Windows.Forms.TextBox tv_empl_search;
        private System.Windows.Forms.Timer employee_state_timer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}