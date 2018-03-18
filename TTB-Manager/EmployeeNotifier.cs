using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.Database;
using TTB_Manager.Types;

namespace TTB_Manager {
    class EmployeeNotifier {
        public String mail_subject = "Schichtzuteilung TTB";
        public String mail_text = "";
        DB_Manager db_manager = new DB_Manager();


        public EmployeeNotifier() {
            db_manager.connect();
        }
        private bool warnPast() {
            var message = "Die Schicht lag in der Vergangenheit. Soll trotzdem benachrichtigt werden?";
            var title = "Hinweis";
            var result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            switch (result) {
                case DialogResult.Yes:
                    return true;
                case DialogResult.No:
                    return false;
                default:
                    return false;
            }
        }
        public void notify(Shift shift) {
            if (shift.starttime().Ticks <= DateTime.Now.Ticks) {
                if (!warnPast()) {
                    return;
                }
            }
            int cur_empl_id = shift.emplshift_list[0].employee_id;
            Employee cur_empl = db_manager.getItem<Employee>(cur_empl_id);
            Workplace cur_workpl = db_manager.getItem<Workplace>(shift.id_workplace);

            if (cur_empl.gender == 0) {
                mail_text = "Sehr geehrter Herr ";
            }
            else {
                mail_text = "Sehr geehrte Frau ";
            }
            mail_text += cur_empl.lastname + ", \n"
                + "ihnen wurde folgende Schicht zugeteilt: \n";
            if (!shift.name.Equals("")) {
                mail_text += shift.name + " \n";
            }
            mail_text += "Datum: " + new Dater().getStringFromTimestamp(shift.date) + " \n";
            mail_text += "Uhrzeit: " + shift.startTime + " \n"
            + "Ort: " + cur_workpl.name + " \n"
            + "Adresse: " + cur_workpl.adress.street + " " + cur_workpl.adress.number + " " + cur_workpl.adress.plz + " " + cur_workpl.adress.city;
            if (!shift.comment.Equals("")) {
                mail_text += "\n" + shift.comment;
            }

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "mailto:" + cur_empl.mail + "?subject=" + mail_subject + "&body=" + mail_text;
            proc.Start();
        }
    }
}
