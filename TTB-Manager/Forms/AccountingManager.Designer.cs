namespace TTB_Manager.Forms {
    partial class AccountingManager {
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
            this.cB_workplaces = new System.Windows.Forms.ComboBox();
            this.rB_week = new System.Windows.Forms.RadioButton();
            this.rB_month = new System.Windows.Forms.RadioButton();
            this.rB_other = new System.Windows.Forms.RadioButton();
            this.btn_start = new System.Windows.Forms.Button();
            this.dtp_1 = new System.Windows.Forms.DateTimePicker();
            this.dtp_2 = new System.Windows.Forms.DateTimePicker();
            this.bis = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_deadline = new System.Windows.Forms.CheckBox();
            this.dtp_deadline = new System.Windows.Forms.DateTimePicker();
            this.cB_printproof = new System.Windows.Forms.CheckBox();
            this.cB_bill = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cB_workplaces
            // 
            this.cB_workplaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_workplaces.FormattingEnabled = true;
            this.cB_workplaces.Location = new System.Drawing.Point(12, 41);
            this.cB_workplaces.Name = "cB_workplaces";
            this.cB_workplaces.Size = new System.Drawing.Size(121, 21);
            this.cB_workplaces.TabIndex = 0;
            this.cB_workplaces.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // rB_week
            // 
            this.rB_week.AutoSize = true;
            this.rB_week.Checked = true;
            this.rB_week.Location = new System.Drawing.Point(12, 78);
            this.rB_week.Name = "rB_week";
            this.rB_week.Size = new System.Drawing.Size(60, 17);
            this.rB_week.TabIndex = 1;
            this.rB_week.TabStop = true;
            this.rB_week.Text = "Woche";
            this.rB_week.UseVisualStyleBackColor = true;
            this.rB_week.CheckedChanged += new System.EventHandler(this.rB_week_CheckedChanged);
            // 
            // rB_month
            // 
            this.rB_month.AutoSize = true;
            this.rB_month.Location = new System.Drawing.Point(96, 78);
            this.rB_month.Name = "rB_month";
            this.rB_month.Size = new System.Drawing.Size(55, 17);
            this.rB_month.TabIndex = 2;
            this.rB_month.Text = "Monat";
            this.rB_month.UseVisualStyleBackColor = true;
            this.rB_month.CheckedChanged += new System.EventHandler(this.rB_month_CheckedChanged);
            // 
            // rB_other
            // 
            this.rB_other.AutoSize = true;
            this.rB_other.Location = new System.Drawing.Point(186, 78);
            this.rB_other.Name = "rB_other";
            this.rB_other.Size = new System.Drawing.Size(64, 17);
            this.rB_other.TabIndex = 3;
            this.rB_other.Text = "Anderes";
            this.rB_other.UseVisualStyleBackColor = true;
            this.rB_other.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(12, 248);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(243, 23);
            this.btn_start.TabIndex = 9;
            this.btn_start.Text = "Rechnung erzeugen";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtp_1
            // 
            this.dtp_1.CustomFormat = "dd.MM.yy";
            this.dtp_1.Enabled = false;
            this.dtp_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_1.Location = new System.Drawing.Point(12, 101);
            this.dtp_1.Name = "dtp_1";
            this.dtp_1.Size = new System.Drawing.Size(98, 20);
            this.dtp_1.TabIndex = 4;
            // 
            // dtp_2
            // 
            this.dtp_2.CustomFormat = "dd.MM.yy";
            this.dtp_2.Enabled = false;
            this.dtp_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_2.Location = new System.Drawing.Point(152, 101);
            this.dtp_2.Name = "dtp_2";
            this.dtp_2.Size = new System.Drawing.Size(98, 20);
            this.dtp_2.TabIndex = 5;
            // 
            // bis
            // 
            this.bis.AutoSize = true;
            this.bis.Enabled = false;
            this.bis.Location = new System.Drawing.Point(120, 104);
            this.bis.Name = "bis";
            this.bis.Size = new System.Drawing.Size(20, 13);
            this.bis.TabIndex = 7;
            this.bis.Text = "bis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ort";
            // 
            // cb_deadline
            // 
            this.cb_deadline.AutoSize = true;
            this.cb_deadline.Checked = true;
            this.cb_deadline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_deadline.Location = new System.Drawing.Point(15, 148);
            this.cb_deadline.Name = "cb_deadline";
            this.cb_deadline.Size = new System.Drawing.Size(162, 17);
            this.cb_deadline.TabIndex = 6;
            this.cb_deadline.Text = "Standard-Deadline (1 Monat)";
            this.cb_deadline.UseVisualStyleBackColor = true;
            this.cb_deadline.CheckedChanged += new System.EventHandler(this.cb_deadline_CheckedChanged);
            // 
            // dtp_deadline
            // 
            this.dtp_deadline.CustomFormat = "dd.MM.yy";
            this.dtp_deadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_deadline.Location = new System.Drawing.Point(187, 146);
            this.dtp_deadline.Name = "dtp_deadline";
            this.dtp_deadline.Size = new System.Drawing.Size(63, 20);
            this.dtp_deadline.TabIndex = 6;
            this.dtp_deadline.Visible = false;
            // 
            // cB_printproof
            // 
            this.cB_printproof.AutoSize = true;
            this.cB_printproof.Checked = true;
            this.cB_printproof.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_printproof.Location = new System.Drawing.Point(15, 210);
            this.cB_printproof.Name = "cB_printproof";
            this.cB_printproof.Size = new System.Drawing.Size(181, 17);
            this.cB_printproof.TabIndex = 8;
            this.cB_printproof.Text = "Arbeitszeitennachweis  erzeugen";
            this.cB_printproof.UseVisualStyleBackColor = true;
            this.cB_printproof.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cB_bill
            // 
            this.cB_bill.AutoSize = true;
            this.cB_bill.Checked = true;
            this.cB_bill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_bill.Location = new System.Drawing.Point(15, 179);
            this.cB_bill.Name = "cB_bill";
            this.cB_bill.Size = new System.Drawing.Size(123, 17);
            this.cB_bill.TabIndex = 7;
            this.cB_bill.Text = "Rechnung erzeugen";
            this.cB_bill.UseVisualStyleBackColor = true;
            this.cB_bill.CheckedChanged += new System.EventHandler(this.cB_bill_CheckedChanged);
            // 
            // AccountingManager
            // 
            this.AcceptButton = this.btn_start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 283);
            this.Controls.Add(this.cB_bill);
            this.Controls.Add(this.cB_printproof);
            this.Controls.Add(this.dtp_deadline);
            this.Controls.Add(this.cb_deadline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bis);
            this.Controls.Add(this.dtp_2);
            this.Controls.Add(this.dtp_1);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.rB_other);
            this.Controls.Add(this.rB_month);
            this.Controls.Add(this.rB_week);
            this.Controls.Add(this.cB_workplaces);
            this.KeyPreview = true;
            this.Name = "AccountingManager";
            this.Text = "Rechnung";
            this.Load += new System.EventHandler(this.AccountingManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cB_workplaces;
        private System.Windows.Forms.RadioButton rB_week;
        private System.Windows.Forms.RadioButton rB_month;
        private System.Windows.Forms.RadioButton rB_other;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.DateTimePicker dtp_1;
        private System.Windows.Forms.DateTimePicker dtp_2;
        private System.Windows.Forms.Label bis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_deadline;
        private System.Windows.Forms.DateTimePicker dtp_deadline;
        private System.Windows.Forms.CheckBox cB_printproof;
        private System.Windows.Forms.CheckBox cB_bill;
    }
}