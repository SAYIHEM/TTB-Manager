namespace TTB_Manager.Forms
{
    partial class AddShift
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
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.cB_Workplace = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtp_time = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tv_length = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rB_template = new System.Windows.Forms.RadioButton();
            this.rB_new = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.cB_Template = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tv_wage = new System.Windows.Forms.TextBox();
            this.rB_Night = new System.Windows.Forms.RadioButton();
            this.rB_Holiday = new System.Windows.Forms.RadioButton();
            this.rB_noZ = new System.Windows.Forms.RadioButton();
            this.group_z = new System.Windows.Forms.GroupBox();
            this.rB_sunday = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tv_breaktime = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.group_z.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_date
            // 
            this.dtp_date.Location = new System.Drawing.Point(21, 38);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(200, 20);
            this.dtp_date.TabIndex = 1;
            this.dtp_date.ValueChanged += new System.EventHandler(this.dtp_date_ValueChanged);
            // 
            // cB_Workplace
            // 
            this.cB_Workplace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Workplace.Location = new System.Drawing.Point(21, 85);
            this.cB_Workplace.Name = "cB_Workplace";
            this.cB_Workplace.Size = new System.Drawing.Size(121, 21);
            this.cB_Workplace.TabIndex = 2;
            this.cB_Workplace.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ort";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datum";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Hinzufügen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(193, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Abbrechen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dtp_time
            // 
            this.dtp_time.CustomFormat = "HH:mm";
            this.dtp_time.Enabled = false;
            this.dtp_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_time.Location = new System.Drawing.Point(21, 244);
            this.dtp_time.Name = "dtp_time";
            this.dtp_time.Size = new System.Drawing.Size(86, 20);
            this.dtp_time.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(18, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Startzeit";
            // 
            // tv_length
            // 
            this.tv_length.Enabled = false;
            this.tv_length.Location = new System.Drawing.Point(123, 244);
            this.tv_length.Name = "tv_length";
            this.tv_length.Size = new System.Drawing.Size(49, 20);
            this.tv_length.TabIndex = 10;
            this.tv_length.TextChanged += new System.EventHandler(this.tv_length_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(120, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Länge (h)";
            // 
            // rB_template
            // 
            this.rB_template.AutoSize = true;
            this.rB_template.Enabled = false;
            this.rB_template.Location = new System.Drawing.Point(21, 128);
            this.rB_template.Name = "rB_template";
            this.rB_template.Size = new System.Drawing.Size(61, 17);
            this.rB_template.TabIndex = 11;
            this.rB_template.Text = "Vorlage";
            this.rB_template.UseVisualStyleBackColor = true;
            this.rB_template.CheckedChanged += new System.EventHandler(this.rB_template_CheckedChanged);
            // 
            // rB_new
            // 
            this.rB_new.AutoSize = true;
            this.rB_new.Enabled = false;
            this.rB_new.Location = new System.Drawing.Point(21, 208);
            this.rB_new.Name = "rB_new";
            this.rB_new.Size = new System.Drawing.Size(61, 17);
            this.rB_new.TabIndex = 8;
            this.rB_new.Text = "Speziell";
            this.rB_new.UseVisualStyleBackColor = true;
            this.rB_new.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(244, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Schichtvorlagen verwalten";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cB_Template
            // 
            this.cB_Template.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Template.Enabled = false;
            this.cB_Template.FormattingEnabled = true;
            this.cB_Template.Location = new System.Drawing.Point(21, 151);
            this.cB_Template.Name = "cB_Template";
            this.cB_Template.Size = new System.Drawing.Size(121, 21);
            this.cB_Template.TabIndex = 3;
            this.cB_Template.SelectedIndexChanged += new System.EventHandler(this.cB_Template_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(190, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Lohn";
            // 
            // tv_wage
            // 
            this.tv_wage.Enabled = false;
            this.tv_wage.Location = new System.Drawing.Point(193, 244);
            this.tv_wage.Name = "tv_wage";
            this.tv_wage.Size = new System.Drawing.Size(44, 20);
            this.tv_wage.TabIndex = 11;
            // 
            // rB_Night
            // 
            this.rB_Night.AutoSize = true;
            this.rB_Night.Enabled = false;
            this.rB_Night.Location = new System.Drawing.Point(21, 51);
            this.rB_Night.Name = "rB_Night";
            this.rB_Night.Size = new System.Drawing.Size(54, 17);
            this.rB_Night.TabIndex = 6;
            this.rB_Night.TabStop = true;
            this.rB_Night.Text = "Nacht";
            this.rB_Night.UseVisualStyleBackColor = true;
            this.rB_Night.CheckedChanged += new System.EventHandler(this.rB_Night_CheckedChanged);
            // 
            // rB_Holiday
            // 
            this.rB_Holiday.AutoSize = true;
            this.rB_Holiday.Enabled = false;
            this.rB_Holiday.Location = new System.Drawing.Point(96, 23);
            this.rB_Holiday.Name = "rB_Holiday";
            this.rB_Holiday.Size = new System.Drawing.Size(63, 17);
            this.rB_Holiday.TabIndex = 5;
            this.rB_Holiday.TabStop = true;
            this.rB_Holiday.Text = "Feiertag";
            this.rB_Holiday.UseVisualStyleBackColor = true;
            // 
            // rB_noZ
            // 
            this.rB_noZ.AutoSize = true;
            this.rB_noZ.Enabled = false;
            this.rB_noZ.Location = new System.Drawing.Point(21, 23);
            this.rB_noZ.Name = "rB_noZ";
            this.rB_noZ.Size = new System.Drawing.Size(52, 17);
            this.rB_noZ.TabIndex = 4;
            this.rB_noZ.TabStop = true;
            this.rB_noZ.Text = "Keine";
            this.rB_noZ.UseVisualStyleBackColor = true;
            // 
            // group_z
            // 
            this.group_z.Controls.Add(this.rB_sunday);
            this.group_z.Controls.Add(this.rB_noZ);
            this.group_z.Controls.Add(this.rB_Night);
            this.group_z.Controls.Add(this.rB_Holiday);
            this.group_z.Enabled = false;
            this.group_z.Location = new System.Drawing.Point(210, 105);
            this.group_z.Name = "group_z";
            this.group_z.Size = new System.Drawing.Size(177, 105);
            this.group_z.TabIndex = 23;
            this.group_z.TabStop = false;
            this.group_z.Text = "Zuschläge";
            // 
            // rB_sunday
            // 
            this.rB_sunday.AutoSize = true;
            this.rB_sunday.Enabled = false;
            this.rB_sunday.Location = new System.Drawing.Point(96, 51);
            this.rB_sunday.Name = "rB_sunday";
            this.rB_sunday.Size = new System.Drawing.Size(65, 17);
            this.rB_sunday.TabIndex = 7;
            this.rB_sunday.TabStop = true;
            this.rB_sunday.Text = "Sonntag";
            this.rB_sunday.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(237, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 24);
            this.label10.TabIndex = 44;
            this.label10.Text = "€ / h";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Location = new System.Drawing.Point(293, 228);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "Pause (h)";
            // 
            // tv_breaktime
            // 
            this.tv_breaktime.Enabled = false;
            this.tv_breaktime.Location = new System.Drawing.Point(296, 244);
            this.tv_breaktime.Name = "tv_breaktime";
            this.tv_breaktime.Size = new System.Drawing.Size(49, 20);
            this.tv_breaktime.TabIndex = 12;
            this.tv_breaktime.Text = "0,5";
            this.tv_breaktime.TextChanged += new System.EventHandler(this.tv_breaktime_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(151, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 23);
            this.button4.TabIndex = 49;
            this.button4.Text = "Neu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // AddShift
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 321);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tv_breaktime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.group_z);
            this.Controls.Add(this.tv_wage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cB_Template);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.rB_new);
            this.Controls.Add(this.rB_template);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tv_length);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp_time);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cB_Workplace);
            this.Controls.Add(this.dtp_date);
            this.Name = "AddShift";
            this.Text = "Schicht hinzufügen";
            this.Load += new System.EventHandler(this.AddShift_Load);
            this.group_z.ResumeLayout(false);
            this.group_z.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.ComboBox cB_Workplace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtp_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tv_length;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rB_template;
        private System.Windows.Forms.RadioButton rB_new;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cB_Template;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tv_wage;
        private System.Windows.Forms.RadioButton rB_Night;
        private System.Windows.Forms.RadioButton rB_Holiday;
        private System.Windows.Forms.RadioButton rB_noZ;
        private System.Windows.Forms.GroupBox group_z;
        private System.Windows.Forms.RadioButton rB_sunday;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tv_breaktime;
        private System.Windows.Forms.Button button4;
    }
}