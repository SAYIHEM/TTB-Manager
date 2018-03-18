namespace TTB_Manager.Forms {

    partial class EditEmployee {

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
            this.btn_add = new System.Windows.Forms.Button();
            this.tv_firstname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tv_lastname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tv_street = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tv_nr = new System.Windows.Forms.TextBox();
            this.tv_city = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tv_plz = new System.Windows.Forms.TextBox();
            this.dtp_birth = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tv_country = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tv_mail = new System.Windows.Forms.TextBox();
            this.cB_title = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(15, 264);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 11;
            this.btn_add.Text = "Hinzufügen";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.button1_Click);
            // 
            // tv_firstname
            // 
            this.tv_firstname.Location = new System.Drawing.Point(82, 25);
            this.tv_firstname.Name = "tv_firstname";
            this.tv_firstname.Size = new System.Drawing.Size(190, 20);
            this.tv_firstname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vorname";
            // 
            // tv_lastname
            // 
            this.tv_lastname.Location = new System.Drawing.Point(282, 25);
            this.tv_lastname.Name = "tv_lastname";
            this.tv_lastname.Size = new System.Drawing.Size(194, 20);
            this.tv_lastname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nachname";
            // 
            // tv_street
            // 
            this.tv_street.Location = new System.Drawing.Point(15, 74);
            this.tv_street.Name = "tv_street";
            this.tv_street.Size = new System.Drawing.Size(253, 20);
            this.tv_street.TabIndex = 4;
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(579, 9);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(18, 13);
            this.label_id.TabIndex = 6;
            this.label_id.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Straße";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nr.";
            // 
            // tv_nr
            // 
            this.tv_nr.Location = new System.Drawing.Point(282, 74);
            this.tv_nr.Name = "tv_nr";
            this.tv_nr.Size = new System.Drawing.Size(48, 20);
            this.tv_nr.TabIndex = 5;
            // 
            // tv_city
            // 
            this.tv_city.Location = new System.Drawing.Point(136, 123);
            this.tv_city.Name = "tv_city";
            this.tv_city.Size = new System.Drawing.Size(195, 20);
            this.tv_city.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Stadt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "PLZ";
            // 
            // tv_plz
            // 
            this.tv_plz.Location = new System.Drawing.Point(15, 123);
            this.tv_plz.Name = "tv_plz";
            this.tv_plz.Size = new System.Drawing.Size(103, 20);
            this.tv_plz.TabIndex = 6;
            // 
            // dtp_birth
            // 
            this.dtp_birth.CustomFormat = "dd.MM.yy";
            this.dtp_birth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_birth.Location = new System.Drawing.Point(15, 224);
            this.dtp_birth.Name = "dtp_birth";
            this.dtp_birth.Size = new System.Drawing.Size(84, 20);
            this.dtp_birth.TabIndex = 9;
            this.dtp_birth.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Geburtstag";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(533, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Abbrechen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tv_country
            // 
            this.tv_country.Location = new System.Drawing.Point(15, 173);
            this.tv_country.Name = "tv_country";
            this.tv_country.Size = new System.Drawing.Size(190, 20);
            this.tv_country.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Land";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Mail";
            // 
            // tv_mail
            // 
            this.tv_mail.Location = new System.Drawing.Point(158, 227);
            this.tv_mail.Name = "tv_mail";
            this.tv_mail.Size = new System.Drawing.Size(100, 20);
            this.tv_mail.TabIndex = 10;
            // 
            // cB_title
            // 
            this.cB_title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_title.FormattingEnabled = true;
            this.cB_title.Location = new System.Drawing.Point(15, 25);
            this.cB_title.Name = "cB_title";
            this.cB_title.Size = new System.Drawing.Size(57, 21);
            this.cB_title.TabIndex = 1;
            // 
            // EditEmployee
            // 
            this.AcceptButton = this.btn_add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 301);
            this.Controls.Add(this.cB_title);
            this.Controls.Add(this.tv_mail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tv_country);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtp_birth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tv_plz);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tv_city);
            this.Controls.Add(this.tv_nr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.tv_street);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tv_lastname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tv_firstname);
            this.Controls.Add(this.btn_add);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditEmployee";
            this.Text = "Personal hinzufügen";
            this.Load += new System.EventHandler(this.AddPersonal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion



        private System.Windows.Forms.Button btn_add;

        private System.Windows.Forms.TextBox tv_firstname;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox tv_lastname;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox tv_street;

        private System.Windows.Forms.Label label_id;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.TextBox tv_nr;

        private System.Windows.Forms.TextBox tv_city;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.TextBox tv_plz;

        private System.Windows.Forms.DateTimePicker dtp_birth;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.TextBox tv_country;

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tv_mail;
        private System.Windows.Forms.ComboBox cB_title;
    }

}