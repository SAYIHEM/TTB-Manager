namespace TTB_Manager.Forms {
    partial class Umsatzübersicht {
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_time = new System.Windows.Forms.Label();
            this.tv_week = new System.Windows.Forms.Label();
            this.tv_month = new System.Windows.Forms.Label();
            this.tv_year = new System.Windows.Forms.Label();
            this.tv_sum = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Woche";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Jahr";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gesamt";
            // 
            // dtp_start
            // 
            this.dtp_start.CustomFormat = "dd.MM.yy";
            this.dtp_start.Location = new System.Drawing.Point(6, 23);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(200, 24);
            this.dtp_start.TabIndex = 5;
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "dd.MM.yy";
            this.dtp_end.Location = new System.Drawing.Point(6, 53);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(200, 24);
            this.dtp_end.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_time);
            this.groupBox1.Controls.Add(this.dtp_start);
            this.groupBox1.Controls.Add(this.dtp_end);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 97);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zeitraum";
            // 
            // tv_time
            // 
            this.tv_time.AutoSize = true;
            this.tv_time.Location = new System.Drawing.Point(223, 40);
            this.tv_time.Name = "tv_time";
            this.tv_time.Size = new System.Drawing.Size(51, 18);
            this.tv_time.TabIndex = 7;
            this.tv_time.Text = "Betrag";
            // 
            // tv_week
            // 
            this.tv_week.AutoSize = true;
            this.tv_week.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_week.Location = new System.Drawing.Point(106, 24);
            this.tv_week.Name = "tv_week";
            this.tv_week.Size = new System.Drawing.Size(51, 18);
            this.tv_week.TabIndex = 8;
            this.tv_week.Text = "Betrag";
            // 
            // tv_month
            // 
            this.tv_month.AutoSize = true;
            this.tv_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_month.Location = new System.Drawing.Point(106, 64);
            this.tv_month.Name = "tv_month";
            this.tv_month.Size = new System.Drawing.Size(51, 18);
            this.tv_month.TabIndex = 9;
            this.tv_month.Text = "Betrag";
            // 
            // tv_year
            // 
            this.tv_year.AutoSize = true;
            this.tv_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_year.Location = new System.Drawing.Point(106, 104);
            this.tv_year.Name = "tv_year";
            this.tv_year.Size = new System.Drawing.Size(51, 18);
            this.tv_year.TabIndex = 10;
            this.tv_year.Text = "Betrag";
            // 
            // tv_sum
            // 
            this.tv_sum.AutoSize = true;
            this.tv_sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_sum.Location = new System.Drawing.Point(106, 144);
            this.tv_sum.Name = "tv_sum";
            this.tv_sum.Size = new System.Drawing.Size(51, 18);
            this.tv_sum.TabIndex = 11;
            this.tv_sum.Text = "Betrag";
            // 
            // Umsatzübersicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 298);
            this.Controls.Add(this.tv_sum);
            this.Controls.Add(this.tv_year);
            this.Controls.Add(this.tv_month);
            this.Controls.Add(this.tv_week);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Umsatzübersicht";
            this.Text = "Wage_Stats";
            this.Load += new System.EventHandler(this.Wage_Stats_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label tv_time;
        private System.Windows.Forms.Label tv_week;
        private System.Windows.Forms.Label tv_month;
        private System.Windows.Forms.Label tv_year;
        private System.Windows.Forms.Label tv_sum;
    }
}