namespace TTB_Manager.Forms {
    partial class AddShiftTemplate {
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
            this.tv_wage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tv_length = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_time = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cB_Workplace = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tv_name = new System.Windows.Forms.TextBox();
            this.group_z = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tv_sunday = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tv_holiday = new System.Windows.Forms.TextBox();
            this.tv_night = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chBx_zuschlaege = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tv_breaktime = new System.Windows.Forms.TextBox();
            this.group_z.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_wage
            // 
            this.tv_wage.Location = new System.Drawing.Point(15, 175);
            this.tv_wage.Name = "tv_wage";
            this.tv_wage.Size = new System.Drawing.Size(42, 20);
            this.tv_wage.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Lohn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Länge (h)";
            // 
            // tv_length
            // 
            this.tv_length.Location = new System.Drawing.Point(113, 126);
            this.tv_length.Name = "tv_length";
            this.tv_length.Size = new System.Drawing.Size(49, 20);
            this.tv_length.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Startzeit";
            // 
            // dtp_time
            // 
            this.dtp_time.CustomFormat = "HH:mm";
            this.dtp_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_time.Location = new System.Drawing.Point(15, 126);
            this.dtp_time.Name = "dtp_time";
            this.dtp_time.Size = new System.Drawing.Size(86, 20);
            this.dtp_time.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Abbrechen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Hinzufügen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ort";
            // 
            // cB_Workplace
            // 
            this.cB_Workplace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Workplace.Location = new System.Drawing.Point(15, 25);
            this.cB_Workplace.Name = "cB_Workplace";
            this.cB_Workplace.Size = new System.Drawing.Size(121, 21);
            this.cB_Workplace.TabIndex = 1;
            this.cB_Workplace.SelectedIndexChanged += new System.EventHandler(this.cB_workplace_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Name";
            // 
            // tv_name
            // 
            this.tv_name.Location = new System.Drawing.Point(15, 76);
            this.tv_name.Name = "tv_name";
            this.tv_name.Size = new System.Drawing.Size(198, 20);
            this.tv_name.TabIndex = 2;
            // 
            // group_z
            // 
            this.group_z.Controls.Add(this.label11);
            this.group_z.Controls.Add(this.label12);
            this.group_z.Controls.Add(this.tv_sunday);
            this.group_z.Controls.Add(this.label9);
            this.group_z.Controls.Add(this.label8);
            this.group_z.Controls.Add(this.label6);
            this.group_z.Controls.Add(this.tv_holiday);
            this.group_z.Controls.Add(this.tv_night);
            this.group_z.Controls.Add(this.label5);
            this.group_z.Location = new System.Drawing.Point(15, 243);
            this.group_z.Name = "group_z";
            this.group_z.Size = new System.Drawing.Size(235, 77);
            this.group_z.TabIndex = 42;
            this.group_z.TabStop = false;
            this.group_z.Text = "Zuschläge";
            this.group_z.Enter += new System.EventHandler(this.group_z_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(202, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 24);
            this.label11.TabIndex = 9;
            this.label11.Text = "%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(156, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Sonntag";
            // 
            // tv_sunday
            // 
            this.tv_sunday.Location = new System.Drawing.Point(158, 41);
            this.tv_sunday.Name = "tv_sunday";
            this.tv_sunday.Size = new System.Drawing.Size(43, 20);
            this.tv_sunday.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(127, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(53, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 24);
            this.label8.TabIndex = 4;
            this.label8.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Feiertag";
            // 
            // tv_holiday
            // 
            this.tv_holiday.Location = new System.Drawing.Point(83, 41);
            this.tv_holiday.Name = "tv_holiday";
            this.tv_holiday.Size = new System.Drawing.Size(43, 20);
            this.tv_holiday.TabIndex = 9;
            // 
            // tv_night
            // 
            this.tv_night.Location = new System.Drawing.Point(9, 41);
            this.tv_night.Name = "tv_night";
            this.tv_night.Size = new System.Drawing.Size(43, 20);
            this.tv_night.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nacht";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(59, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 24);
            this.label10.TabIndex = 43;
            this.label10.Text = "€ / h";
            // 
            // chBx_zuschlaege
            // 
            this.chBx_zuschlaege.AutoSize = true;
            this.chBx_zuschlaege.Location = new System.Drawing.Point(15, 220);
            this.chBx_zuschlaege.Name = "chBx_zuschlaege";
            this.chBx_zuschlaege.Size = new System.Drawing.Size(76, 17);
            this.chBx_zuschlaege.TabIndex = 7;
            this.chBx_zuschlaege.Text = "Zuschläge";
            this.chBx_zuschlaege.UseVisualStyleBackColor = true;
            this.chBx_zuschlaege.CheckedChanged += new System.EventHandler(this.chBx_zuschlaege_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(171, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 46;
            this.label13.Text = "Pause (h)";
            // 
            // tv_breaktime
            // 
            this.tv_breaktime.Location = new System.Drawing.Point(174, 126);
            this.tv_breaktime.Name = "tv_breaktime";
            this.tv_breaktime.Size = new System.Drawing.Size(49, 20);
            this.tv_breaktime.TabIndex = 5;
            this.tv_breaktime.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AddShiftTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 414);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tv_breaktime);
            this.Controls.Add(this.chBx_zuschlaege);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.group_z);
            this.Controls.Add(this.tv_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tv_wage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tv_length);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp_time);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cB_Workplace);
            this.Name = "AddShiftTemplate";
            this.Text = "Vorlage hinzufügen";
            this.Load += new System.EventHandler(this.ShiftTemplates_Load);
            this.group_z.ResumeLayout(false);
            this.group_z.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tv_wage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tv_length;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_time;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cB_Workplace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tv_name;
        private System.Windows.Forms.GroupBox group_z;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tv_holiday;
        private System.Windows.Forms.TextBox tv_night;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chBx_zuschlaege;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tv_sunday;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tv_breaktime;
    }
}