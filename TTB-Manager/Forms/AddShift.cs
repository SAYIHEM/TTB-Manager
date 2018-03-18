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
    public partial class AddShift : Form {
        DB_Manager db_manager = new DB_Manager();
        Shift shift;
        bool USER_ENTERED_BREAKTIME = false;
        bool SYSTEM_CHANGE_BREAKTIME = false;
        public AddShift() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            rB_template.Checked = true;
            InitializeWorkplaceComboBox();
        }
        public AddShift(int id_shift) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FillFields(id_shift);
        }

        private void AddShift_Load(object sender, EventArgs e) {
            MinimizeBox = false;
            MaximizeBox = false;
            rB_noZ.Checked = true;
            db_manager.connect();

        }

        private void FillFields(int id_shift) {
            Shift shift = db_manager.getItem<Shift>(id_shift);
            if (!shift.name.Equals("")) { //Schicht hat Vorlage

            }
            else { //Schicht hat keine Vorlage

            }
        }


        private void InitializeWorkplaceComboBox() {
            //Fill ComboBox for Workplaces

            cB_Workplace.Items.Clear();
            List<Workplace> workplace_list = db_manager.getWorkplaceData("");
            cB_Workplace.DisplayMember = "Text";
            for (int i = 0; i < workplace_list.Count; i++) {
                ComboBoxItem ci = new ComboBoxItem();
                ci.Text = workplace_list[i].name;
                ci.Value = workplace_list[i].id;
                cB_Workplace.Items.Add(ci);
            }
            if (workplace_list.Count > 0) {
                // cB_Workplace.Text = "Bitte wählen";
                cB_Workplace.Text = "Bitte wählen";
                //cB_Workplace.SelectedIndex = 0;
            }
            else {
                var message = "Keine Orte vordefiniert. Jetz Orte anlegen?";
                var title = "Hinweis";
                var result = MessageBox.Show(
                    message,
                    title,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // the following can be handled as if/else statements as well
                switch (result) {
                    case DialogResult.Yes:
                        EditWorkplace editworkplace = new EditWorkplace();
                        editworkplace.FormBorderStyle = FormBorderStyle.FixedDialog;
                        editworkplace.ShowDialog();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            rB_new.Enabled = true;
            rB_template.Checked = true;
            cB_Template.Items.Clear();
            Console.WriteLine("Text: " + ((ComboBoxItem)cB_Workplace.SelectedItem).Text + "\nValue: " + ((ComboBoxItem)cB_Workplace.SelectedItem).Value);

            List<Shift_Template> template_list = db_manager.getShiftTemplateData();
            cB_Template.DisplayMember = "Text";

            for (int i = 0; i < template_list.Count; i++) {
                ComboBoxItem ci = new ComboBoxItem();
                ci.Text = template_list[i].name;
                ci.Value = template_list[i].id;
                //Falls Workplace ID des Shifts mit dem Value der Combobox (ID des derzeitigen Workplaces) stimmt....
                if (template_list[i].id_workplace == ((ComboBoxItem)cB_Workplace.SelectedItem).Value) {
                    cB_Template.Items.Add(ci);
                }
            }
            try {
                rB_template.Enabled = true;
                cB_Template.SelectedIndex = 0;
            } catch (Exception) {
                rB_new.Checked = true;
                rB_template.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void rB_template_CheckedChanged(object sender, EventArgs e) {
            if (rB_template.Checked) {
                ChangeShiftStyle(true);
            }
            

        }
        private void ChangeShiftStyle(bool boolean) {
            cB_Template.Enabled = boolean;
            rB_Holiday.Enabled = boolean;
            rB_noZ.Enabled = boolean;
            rB_Night.Enabled = boolean;
            rB_sunday.Enabled = boolean;

            tv_length.Enabled = !boolean;
            dtp_time.Enabled = !boolean;
            label3.Enabled = !boolean;
            label4.Enabled = !boolean;
            label7.Enabled = !boolean;
            tv_wage.Enabled = !boolean;
            tv_breaktime.Enabled = !boolean;
            label13.Enabled = !boolean;
            label10.Enabled = !boolean;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            if (rB_new.Checked) {
                ChangeShiftStyle(false);
            }
           
        }


        private void button3_Click(object sender, EventArgs e) {
            ShiftManager shiftmanager = new ShiftManager();
            shiftmanager.FormClosing += new FormClosingEventHandler(this.form_FormClosing);
            shiftmanager.FormBorderStyle = FormBorderStyle.FixedDialog;
            shiftmanager.ShowDialog();

        }
        private void form_FormClosing(object sender, FormClosingEventArgs e) {
            InitializeWorkplaceComboBox();
        }



        private void button1_Click(object sender, EventArgs e) {
            shift = new Shift();

            shift.date = dtp_date.Value.Date.Ticks;
            shift.id_workplace = (int)((ComboBoxItem)cB_Workplace.SelectedItem).Value;
            if (rB_template.Checked) {

                try {
                    int selected_template_id = (int)((ComboBoxItem)cB_Template.SelectedItem).Value;
                    SetTemplateShiftProperties(selected_template_id);
                } catch (Exception ex) {
                    MessageBox.Show("Keine Vorlage ausgewählt",
                    "Fehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    Console.WriteLine("" + ex);
                    return;
                }

            }

            else if (rB_new.Checked) {
                try {
                    shift.startTime = dtp_time.Value.ToString("HH:mm");
                    shift.duration = float.Parse(tv_length.Text);
                    shift.Wage_perHour = float.Parse(tv_wage.Text);
                    shift.break_time = float.Parse(tv_breaktime.Text);
                } catch (FormatException ex) {
                    MessageBox.Show("Falsche Eingaben",
                    "Fehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    Console.WriteLine("" + ex);
                    return;

                }

            }

            if (db_manager.insert(shift)) {
                this.Close();
            }


        }
        private void SetTemplateShiftProperties(int id) {
            Shift_Template templ_shift = db_manager.getItem<Shift_Template>(id);
            if (rB_Holiday.Checked) {
                shift.Holiday_surcharge = templ_shift.Holiday_surcharge;
            }
            else if (rB_Night.Checked) {
                shift.Night_surcharge = templ_shift.Night_surcharge;
            }
            else if (rB_sunday.Checked) {
                shift.Sunday_surcharge = templ_shift.Sunday_surcharge;
            }
            shift.duration = templ_shift.duration;
            shift.Wage_perHour = templ_shift.Wage_perHour;
            shift.name = templ_shift.name;
            shift.startTime = templ_shift.startTime;
            shift.break_time = templ_shift.break_time;


        }


        private void cB_Template_SelectedIndexChanged(object sender, EventArgs e) {
            int sel_template_id = ((ComboBoxItem)cB_Template.SelectedItem).Value;
            List<Shift_Template> template_list = db_manager.getShiftTemplateData();
            group_z.Enabled = true;
            //Radio-Buttons einstellen, dass Benutzer sieht, welche Zuschläge verfügbar sind
            for (int i = 0; i < template_list.Count; i++) {
                if (template_list[i].id == sel_template_id) {
                    //Template mit der ausgewählten ID wird gefunden

                    if (template_list[i].Night_surcharge == 0) {
                        rB_Night.Enabled = false;
                        rB_noZ.Checked = true;
                    }
                    else {
                        rB_Night.Enabled = true;
                    }
                    if (template_list[i].Holiday_surcharge == 0) {
                        rB_Holiday.Enabled = false;
                    }
                    else {
                        rB_Holiday.Enabled = true;
                    }
                    if (template_list[i].Sunday_surcharge == 0) {
                        rB_sunday.Enabled = false;
                    }
                    else {
                        rB_sunday.Enabled = true;
                    }

                    if (!rB_Holiday.Enabled && !rB_Night.Enabled && !rB_sunday.Enabled) { 
                        rB_noZ.Checked = true;
                        group_z.Enabled = false;
                    }
                    else {
                        group_z.Enabled = true;
                    }

                    return;
                }
            }

        }

        private void dtp_date_ValueChanged(object sender, EventArgs e) {

        }

        private void rB_Night_CheckedChanged(object sender, EventArgs e) {

        }

        private void tv_length_TextChanged(object sender, EventArgs e) {
            if (!USER_ENTERED_BREAKTIME) {
                SYSTEM_CHANGE_BREAKTIME = true;
                if (!tv_length.Text.Equals("")) {
                    try {
                        float duration = float.Parse(tv_length.Text);
                        float breaktime = (int)(duration / 6) * 0.5f;
                        tv_breaktime.Text = breaktime + "";
                    } catch {

                    }

                }
                else {
                    tv_breaktime.Text = "";
                }
                SYSTEM_CHANGE_BREAKTIME = false;
            }


        }

        private void tv_breaktime_TextChanged(object sender, EventArgs e) {
            if (!SYSTEM_CHANGE_BREAKTIME) {
                USER_ENTERED_BREAKTIME = true;
            }

        }

        private void button4_Click(object sender, EventArgs e) {
            EditWorkplace editlocation = new EditWorkplace();
            editlocation.FormBorderStyle = FormBorderStyle.FixedDialog;
            editlocation.FormClosing += new FormClosingEventHandler(this.form_FormClosing);
            editlocation.ShowDialog();
        }
    }
}
