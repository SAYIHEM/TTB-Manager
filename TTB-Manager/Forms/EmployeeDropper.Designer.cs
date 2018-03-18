namespace TTB_Manager.Forms {
    partial class EmployeeDropper {
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
            this.SuspendLayout();
            // 
            // EmployeeDropper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 43);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeDropper";
            this.Text = "Personal zuweisen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.employeedropper_Closed);
            this.Load += new System.EventHandler(this.EmployeeDropper_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EmployeeDropper_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}