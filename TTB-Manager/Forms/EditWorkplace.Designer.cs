namespace TTB_Manager.Forms {
    partial class EditWorkplace {
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
            this.label1 = new System.Windows.Forms.Label();
            this.tv_name = new System.Windows.Forms.TextBox();
            this.tv_street = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tv_nr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tv_plz = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tv_city = new System.Windows.Forms.TextBox();
            this.next_id = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tv_country = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tv_mail = new System.Windows.Forms.TextBox();
            this.gB_acc_adress = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tv_acc_country = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tv_acc_city = new System.Windows.Forms.TextBox();
            this.tv_acc_plz = new System.Windows.Forms.TextBox();
            this.tv_acc_nr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tv_acc_street = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cB_accA = new System.Windows.Forms.CheckBox();
            this.tv_ustid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tv_contact_person = new System.Windows.Forms.TextBox();
            this.cB_title = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tv_extra = new System.Windows.Forms.TextBox();
            this.label_mwst = new System.Windows.Forms.Label();
            this.tv_mwst = new System.Windows.Forms.TextBox();
            this.cB_mwst = new System.Windows.Forms.CheckBox();
            this.gB_acc_adress.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tv_name
            // 
            this.tv_name.Location = new System.Drawing.Point(15, 25);
            this.tv_name.Name = "tv_name";
            this.tv_name.Size = new System.Drawing.Size(311, 20);
            this.tv_name.TabIndex = 1;
            this.tv_name.TextChanged += new System.EventHandler(this.tv_name_TextChanged);
            // 
            // tv_street
            // 
            this.tv_street.Location = new System.Drawing.Point(15, 73);
            this.tv_street.Name = "tv_street";
            this.tv_street.Size = new System.Drawing.Size(220, 20);
            this.tv_street.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Straße";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nr.";
            // 
            // tv_nr
            // 
            this.tv_nr.Location = new System.Drawing.Point(255, 73);
            this.tv_nr.Name = "tv_nr";
            this.tv_nr.Size = new System.Drawing.Size(71, 20);
            this.tv_nr.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "PLZ";
            // 
            // tv_plz
            // 
            this.tv_plz.Location = new System.Drawing.Point(15, 124);
            this.tv_plz.Name = "tv_plz";
            this.tv_plz.Size = new System.Drawing.Size(100, 20);
            this.tv_plz.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stadt";
            // 
            // tv_city
            // 
            this.tv_city.Location = new System.Drawing.Point(135, 124);
            this.tv_city.Name = "tv_city";
            this.tv_city.Size = new System.Drawing.Size(191, 20);
            this.tv_city.TabIndex = 5;
            // 
            // next_id
            // 
            this.next_id.AutoSize = true;
            this.next_id.Location = new System.Drawing.Point(750, 9);
            this.next_id.Name = "next_id";
            this.next_id.Size = new System.Drawing.Size(18, 13);
            this.next_id.TabIndex = 10;
            this.next_id.Text = "ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Hinzufügen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(693, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Abbrechen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tv_country
            // 
            this.tv_country.Location = new System.Drawing.Point(15, 222);
            this.tv_country.Name = "tv_country";
            this.tv_country.Size = new System.Drawing.Size(311, 20);
            this.tv_country.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Land";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(371, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "E-Mail";
            // 
            // tv_mail
            // 
            this.tv_mail.Location = new System.Drawing.Point(374, 116);
            this.tv_mail.Name = "tv_mail";
            this.tv_mail.Size = new System.Drawing.Size(304, 20);
            this.tv_mail.TabIndex = 14;
            // 
            // gB_acc_adress
            // 
            this.gB_acc_adress.Controls.Add(this.label14);
            this.gB_acc_adress.Controls.Add(this.tv_acc_country);
            this.gB_acc_adress.Controls.Add(this.label12);
            this.gB_acc_adress.Controls.Add(this.label13);
            this.gB_acc_adress.Controls.Add(this.tv_acc_city);
            this.gB_acc_adress.Controls.Add(this.tv_acc_plz);
            this.gB_acc_adress.Controls.Add(this.tv_acc_nr);
            this.gB_acc_adress.Controls.Add(this.label10);
            this.gB_acc_adress.Controls.Add(this.label11);
            this.gB_acc_adress.Controls.Add(this.tv_acc_street);
            this.gB_acc_adress.Enabled = false;
            this.gB_acc_adress.Location = new System.Drawing.Point(374, 158);
            this.gB_acc_adress.Name = "gB_acc_adress";
            this.gB_acc_adress.Size = new System.Drawing.Size(328, 182);
            this.gB_acc_adress.TabIndex = 17;
            this.gB_acc_adress.TabStop = false;
            this.gB_acc_adress.Text = "Rechnungsadresse";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Land";
            // 
            // tv_acc_country
            // 
            this.tv_acc_country.Location = new System.Drawing.Point(6, 152);
            this.tv_acc_country.Name = "tv_acc_country";
            this.tv_acc_country.Size = new System.Drawing.Size(204, 20);
            this.tv_acc_country.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(123, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Stadt";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "PLZ";
            // 
            // tv_acc_city
            // 
            this.tv_acc_city.Location = new System.Drawing.Point(126, 100);
            this.tv_acc_city.Name = "tv_acc_city";
            this.tv_acc_city.Size = new System.Drawing.Size(162, 20);
            this.tv_acc_city.TabIndex = 18;
            // 
            // tv_acc_plz
            // 
            this.tv_acc_plz.Location = new System.Drawing.Point(6, 100);
            this.tv_acc_plz.Name = "tv_acc_plz";
            this.tv_acc_plz.Size = new System.Drawing.Size(100, 20);
            this.tv_acc_plz.TabIndex = 817;
            // 
            // tv_acc_nr
            // 
            this.tv_acc_nr.Location = new System.Drawing.Point(248, 49);
            this.tv_acc_nr.Name = "tv_acc_nr";
            this.tv_acc_nr.Size = new System.Drawing.Size(71, 20);
            this.tv_acc_nr.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(245, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Nr.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Straße";
            // 
            // tv_acc_street
            // 
            this.tv_acc_street.Location = new System.Drawing.Point(6, 49);
            this.tv_acc_street.Name = "tv_acc_street";
            this.tv_acc_street.Size = new System.Drawing.Size(220, 20);
            this.tv_acc_street.TabIndex = 15;
            this.tv_acc_street.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(376, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "USt-ID";
            // 
            // cB_accA
            // 
            this.cB_accA.AutoSize = true;
            this.cB_accA.Checked = true;
            this.cB_accA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_accA.Location = new System.Drawing.Point(15, 258);
            this.cB_accA.Name = "cB_accA";
            this.cB_accA.Size = new System.Drawing.Size(261, 17);
            this.cB_accA.TabIndex = 8;
            this.cB_accA.Text = "Diese Adresse als Rechnungsadresse verwenden";
            this.cB_accA.UseVisualStyleBackColor = true;
            this.cB_accA.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tv_ustid
            // 
            this.tv_ustid.Location = new System.Drawing.Point(374, 77);
            this.tv_ustid.Name = "tv_ustid";
            this.tv_ustid.Size = new System.Drawing.Size(304, 20);
            this.tv_ustid.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Ansprechpartner";
            // 
            // tv_contact_person
            // 
            this.tv_contact_person.Location = new System.Drawing.Point(95, 306);
            this.tv_contact_person.Name = "tv_contact_person";
            this.tv_contact_person.Size = new System.Drawing.Size(231, 20);
            this.tv_contact_person.TabIndex = 10;
            // 
            // cB_title
            // 
            this.cB_title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_title.FormattingEnabled = true;
            this.cB_title.Location = new System.Drawing.Point(15, 306);
            this.cB_title.Name = "cB_title";
            this.cB_title.Size = new System.Drawing.Size(67, 21);
            this.cB_title.TabIndex = 9;
            this.cB_title.SelectedIndexChanged += new System.EventHandler(this.cB_title_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Adresszusatz";
            // 
            // tv_extra
            // 
            this.tv_extra.Location = new System.Drawing.Point(15, 174);
            this.tv_extra.Name = "tv_extra";
            this.tv_extra.Size = new System.Drawing.Size(311, 20);
            this.tv_extra.TabIndex = 6;
            // 
            // label_mwst
            // 
            this.label_mwst.AutoSize = true;
            this.label_mwst.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mwst.Location = new System.Drawing.Point(593, 23);
            this.label_mwst.Name = "label_mwst";
            this.label_mwst.Size = new System.Drawing.Size(25, 24);
            this.label_mwst.TabIndex = 49;
            this.label_mwst.Text = "%";
            this.label_mwst.Visible = false;
            // 
            // tv_mwst
            // 
            this.tv_mwst.Location = new System.Drawing.Point(548, 26);
            this.tv_mwst.Name = "tv_mwst";
            this.tv_mwst.Size = new System.Drawing.Size(43, 20);
            this.tv_mwst.TabIndex = 12;
            this.tv_mwst.Visible = false;
            // 
            // cB_mwst
            // 
            this.cB_mwst.AutoSize = true;
            this.cB_mwst.Checked = true;
            this.cB_mwst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_mwst.Location = new System.Drawing.Point(450, 28);
            this.cB_mwst.Name = "cB_mwst";
            this.cB_mwst.Size = new System.Drawing.Size(79, 17);
            this.cB_mwst.TabIndex = 11;
            this.cB_mwst.Text = "19% MwSt.";
            this.cB_mwst.UseVisualStyleBackColor = true;
            this.cB_mwst.CheckedChanged += new System.EventHandler(this.cB_mwst_CheckedChanged);
            // 
            // EditWorkplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 388);
            this.Controls.Add(this.label_mwst);
            this.Controls.Add(this.tv_mwst);
            this.Controls.Add(this.cB_mwst);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tv_extra);
            this.Controls.Add(this.cB_title);
            this.Controls.Add(this.tv_contact_person);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tv_ustid);
            this.Controls.Add(this.cB_accA);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gB_acc_adress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tv_mail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tv_country);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.next_id);
            this.Controls.Add(this.tv_city);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tv_plz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tv_nr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tv_street);
            this.Controls.Add(this.tv_name);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditWorkplace";
            this.Text = "Orte";
            this.Load += new System.EventHandler(this.EditLocation_Load);
            this.gB_acc_adress.ResumeLayout(false);
            this.gB_acc_adress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tv_name;
        private System.Windows.Forms.TextBox tv_street;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tv_nr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tv_plz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tv_city;
        private System.Windows.Forms.Label next_id;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tv_country;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tv_mail;
        private System.Windows.Forms.GroupBox gB_acc_adress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tv_acc_country;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tv_acc_city;
        private System.Windows.Forms.TextBox tv_acc_plz;
        private System.Windows.Forms.TextBox tv_acc_nr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tv_acc_street;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cB_accA;
        private System.Windows.Forms.TextBox tv_ustid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tv_contact_person;
        private System.Windows.Forms.ComboBox cB_title;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tv_extra;
        private System.Windows.Forms.Label label_mwst;
        private System.Windows.Forms.TextBox tv_mwst;
        private System.Windows.Forms.CheckBox cB_mwst;
    }
}