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
    public partial class AddShiftTemplate : Form {
        DB_Manager db_manager = new DB_Manager();
        public AddShiftTemplate() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            db_manager.connect();
        }

        private void ShiftTemplates_Load(object sender, EventArgs e) {
            MinimizeBox = false;
            MaximizeBox = false;
            chBx_zuschlaege.Checked = true;
            tv_breaktime.Text = "0,5";
            //Fill ComboBox

            List<Workplace> workplace_list = db_manager.getWorkplaceData("");
            cB_Workplace.DisplayMember = "Text";
            for (int i = 0; i < workplace_list.Count; i++) {
                ComboBoxItem ci = new ComboBoxItem();
                ci.Text = workplace_list[i].name;
                ci.Value = workplace_list[i].id;
                cB_Workplace.Items.Add(ci);
            }
            if (workplace_list.Count > 0) {
                cB_Workplace.SelectedIndex = 0;
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

        private void button1_Click(object sender, EventArgs e) {
            //Check if Template with specified name is already in database (prevents puzzle in accounting)
            List<Shift_Template> template_list = db_manager.getShiftTemplateData();
            for (int i=0;i<template_list.Count;i++) {
                if (tv_name.Text.Equals(template_list[i].name) && (int)((ComboBoxItem)cB_Workplace.SelectedItem).Value == template_list[i].id_workplace) {
                    MessageBox.Show("Vorlage in diesem Ort bereits vorhanden");
                    return;
                }
            }

            try {
                Shift_Template shift_template = new Shift_Template();
                shift_template.id_workplace = (int)((ComboBoxItem)cB_Workplace.SelectedItem).Value;
                shift_template.name = tv_name.Text;
                shift_template.startTime = dtp_time.Value.ToString("HH:mm");
                shift_template.duration = double.Parse(tv_length.Text);
                shift_template.Wage_perHour = double.Parse(tv_wage.Text);
                shift_template.break_time = double.Parse(tv_breaktime.Text); 

                

                if (chBx_zuschlaege.Checked) {
                    if (!tv_night.Text.Equals("")) {
                        shift_template.Night_surcharge = float.Parse(tv_night.Text);
                        
                    }
                    if (!tv_holiday.Text.Equals("")) {
                        shift_template.Holiday_surcharge = float.Parse(tv_holiday.Text);
                    }
                    if (!tv_sunday.Text.Equals("")) {
                        shift_template.Sunday_surcharge = float.Parse(tv_sunday.Text);
                    }
                    
                }
                if (db_manager.insert(shift_template)) {
                    this.Close();
                }
              
            } catch (FormatException) {
                MessageBox.Show("Falsche Eingaben",
                "Fehler",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }


        }

        private void chBx_zuschlaege_CheckedChanged(object sender, EventArgs e) {
            if (chBx_zuschlaege.Checked) {
                group_z.Enabled = true;
            }
            else {
                group_z.Enabled = false;
            }
        }

        private void cB_workplace_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void group_z_Enter(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }
        private float toFloat(String strg) {
            float a = float.Parse(strg);
            Math.Round((Decimal)a, 2, MidpointRounding.AwayFromZero);
            return a;
        }
    }
}
