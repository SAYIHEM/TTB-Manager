namespace TTB_Manager.Types {
    partial class Eraser {
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
            this.rB_delElement = new System.Windows.Forms.RadioButton();
            this.error_title = new System.Windows.Forms.Label();
            this.rB_delAll = new System.Windows.Forms.RadioButton();
            this.btn_ok = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_showconflicts = new System.Windows.Forms.Button();
            this.errorlist_box = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // rB_delElement
            // 
            this.rB_delElement.AutoSize = true;
            this.rB_delElement.Location = new System.Drawing.Point(15, 71);
            this.rB_delElement.Name = "rB_delElement";
            this.rB_delElement.Size = new System.Drawing.Size(388, 17);
            this.rB_delElement.TabIndex = 0;
            this.rB_delElement.Text = "Nur das Element löschen (ACHTUNG: Wird Lücken in Schichten aufweisen!)";
            this.rB_delElement.UseVisualStyleBackColor = true;
            this.rB_delElement.CheckedChanged += new System.EventHandler(this.rB_delElement_CheckedChanged);
            // 
            // error_title
            // 
            this.error_title.AutoSize = true;
            this.error_title.Location = new System.Drawing.Point(12, 23);
            this.error_title.Name = "error_title";
            this.error_title.Size = new System.Drawing.Size(36, 13);
            this.error_title.TabIndex = 1;
            this.error_title.Text = "Fehler";
            // 
            // rB_delAll
            // 
            this.rB_delAll.AutoSize = true;
            this.rB_delAll.Location = new System.Drawing.Point(15, 94);
            this.rB_delAll.Name = "rB_delAll";
            this.rB_delAll.Size = new System.Drawing.Size(410, 17);
            this.rB_delAll.TabIndex = 2;
            this.rB_delAll.Text = "Das Element und alle Schichten, die dieses Element beinhalten, ebenfalls löschen";
            this.rB_delAll.UseVisualStyleBackColor = true;
            this.rB_delAll.CheckedChanged += new System.EventHandler(this.rB_delAll_CheckedChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Enabled = false;
            this.btn_ok.Location = new System.Drawing.Point(12, 135);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Abbrechen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_showconflicts
            // 
            this.btn_showconflicts.Location = new System.Drawing.Point(93, 135);
            this.btn_showconflicts.Name = "btn_showconflicts";
            this.btn_showconflicts.Size = new System.Drawing.Size(121, 23);
            this.btn_showconflicts.TabIndex = 5;
            this.btn_showconflicts.Text = "Konflikte anzeigen";
            this.btn_showconflicts.UseVisualStyleBackColor = true;
            this.btn_showconflicts.Click += new System.EventHandler(this.button3_Click);
            // 
            // errorlist_box
            // 
            this.errorlist_box.Location = new System.Drawing.Point(15, 175);
            this.errorlist_box.Name = "errorlist_box";
            this.errorlist_box.Size = new System.Drawing.Size(410, 80);
            this.errorlist_box.TabIndex = 6;
            this.errorlist_box.UseCompatibleStateImageBehavior = false;
            // 
            // Eraser
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 267);
            this.Controls.Add(this.errorlist_box);
            this.Controls.Add(this.btn_showconflicts);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.rB_delAll);
            this.Controls.Add(this.error_title);
            this.Controls.Add(this.rB_delElement);
            this.Name = "Eraser";
            this.Text = "Konflikt";
            this.Load += new System.EventHandler(this.Eraser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rB_delElement;
        private System.Windows.Forms.Label error_title;
        private System.Windows.Forms.RadioButton rB_delAll;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_showconflicts;
        private System.Windows.Forms.ListView errorlist_box;
    }
}