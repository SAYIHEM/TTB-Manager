using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.Types;
using TTB_Manager.Database;

namespace TTB_Manager.Forms {
    public partial class OvertimeDropper : Form {
        DB_Manager db_manager = new DB_Manager();
        List<TextBox> textbox_list = new List<TextBox>();
        List<Label> label_list = new List<Label>();
        Shift shift;
        int counter = 0;
        bool DIFFERENT_OVERTIME = false;
        public OvertimeDropper(int shift_id) {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            db_manager.connect();
            shift = db_manager.getItem<Shift>(shift_id);
            if (shift.date>DateTime.Today.Ticks) {
                MessageBox.Show("Achtung, Schicht liegt in der Zukunft!");
            }

        }

        private void OvertimeDropper_Load(object sender, EventArgs e) {
            loadAllEntries();
        }
        private void loadAllEntries() {
            for (int i = 0; i < shift.emplshift_list.Count; i++) {
                Employee empl = db_manager.getItem<Employee>(shift.emplshift_list[i].employee_id);
                String name = empl.firstname + " " + empl.lastname;
                addLine(name, shift.emplshift_list[i].overtime);
                try {
                    if (shift.emplshift_list[i].overtime!= shift.emplshift_list[i-1].overtime) {
                        DIFFERENT_OVERTIME = true;
                    }
                } catch { }
            }
                cB_all.Checked = !DIFFERENT_OVERTIME;
            
        }

        private void addLine(String name, double overtime) {
            //New Label with name
            Label label = new Label();
            label.Text = name;
            label.Width = 200;
            try {
                label.Location = new Point(label_list[counter - 1].Location.X,
                    label_list[counter - 1].Location.Y + label_list[counter - 1].Height + 10);
            } catch {
                label.Location = new Point(12, 45);
            }
            label_list.Add(label);
            Controls.Add(label);

            //New TextBox
            TextBox textbox = new TextBox();
            textbox.Text = overtime + "";
            textbox.Width = 40;
            textbox.Location = new Point(label.Location.X + label.Width + 10 , label.Location.Y);
            textbox_list.Add(textbox);
            Controls.Add(textbox);

            //New Label h
            Label h = new Label();
            h.Text = "h";
            h.Location = new Point(textbox.Location.X + textbox.Width + 2, textbox.Location.Y+2);
            Controls.Add(h);


            //Resize
            this.Height += label.Height + 10;

            counter++;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            for (int i = 0; i < textbox_list.Count; i++) {
                textbox_list[i].Enabled = !cB_all.Checked;
            }
            if (cB_all.Checked && !tv_all.Text.Equals("")) {
                for (int i = 0; i < textbox_list.Count; i++) {
                    textbox_list[i].Text = tv_all.Text;
                }
            }

        }

        private void OvertimeDropper_FormClosing(object sender, FormClosingEventArgs e) {
            saveShift();
        }
        private void saveShift() {
            for (int i = 0; i < textbox_list.Count; i++) {
                if (!textbox_list[i].Text.Equals("")) {
                    shift.emplshift_list[i].overtime = float.Parse(textbox_list[i].Text);
                }
                else {
                    shift.emplshift_list[i].overtime = 0;
                }

            }
            db_manager.update(shift);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (cB_all.Checked) {
                for (int i = 0; i < textbox_list.Count; i++) {
                    textbox_list[i].Text = tv_all.Text;
                }
            }
        }
    }
}
