namespace TTB_Manager.Forms {
    partial class OvertimeDropper {
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
            this.cB_all = new System.Windows.Forms.CheckBox();
            this.tv_all = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cB_all
            // 
            this.cB_all.AutoSize = true;
            this.cB_all.Location = new System.Drawing.Point(12, 12);
            this.cB_all.Name = "cB_all";
            this.cB_all.Size = new System.Drawing.Size(96, 17);
            this.cB_all.TabIndex = 0;
            this.cB_all.Text = "Für alle ändern";
            this.cB_all.UseVisualStyleBackColor = true;
            this.cB_all.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tv_all
            // 
            this.tv_all.Location = new System.Drawing.Point(134, 12);
            this.tv_all.Name = "tv_all";
            this.tv_all.Size = new System.Drawing.Size(42, 20);
            this.tv_all.TabIndex = 1;
            this.tv_all.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "h";
            // 
            // OvertimeDropper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 82);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tv_all);
            this.Controls.Add(this.cB_all);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OvertimeDropper";
            this.Text = "Überstunden";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OvertimeDropper_FormClosing);
            this.Load += new System.EventHandler(this.OvertimeDropper_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cB_all;
        private System.Windows.Forms.TextBox tv_all;
        private System.Windows.Forms.Label label1;
    }
}