using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.PDFCreator;
using TTB_Manager.Database;
using TTB_Manager.Types;
using System.Globalization;

namespace TTB_Manager.Forms {
    public partial class AccountingManager : Form {
        AccountingCreator ac = new AccountingCreator();
        WorkProofCreator wc = new WorkProofCreator();
        enum Mode { WEEK, MONTH, CUSTOM }
        DB_Manager db_manager = new DB_Manager();
        Mode mode;
        List<Shift> sortedList = new List<Shift>();
        int id_workplace = 0;
        Workplace workplace;

        long date_start, date_end = 0;
        public AccountingManager() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MinimizeBox = false;
            MaximizeBox = false;
            db_manager.connect();
            mode = Mode.WEEK;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void rB_week_CheckedChanged(object sender, EventArgs e) {
            if (rB_week.Checked) {
                dtp_1.Enabled = false;
                dtp_2.Enabled = false;
                bis.Enabled = false;
                mode = Mode.WEEK;
                getDates();
                DateTime dt = new DateTime(date_start);
                dtp_1.Value = dt;
                dt = new DateTime(date_end);
                dtp_2.Value = dt;

                //Falls nachweis nur für woche funktionieren soll
                //cB_printproof.Enabled = true;
            }
            else {
                //cB_printproof.Enabled = false;
                //cB_printproof.Checked = false;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            if (rB_other.Checked) {
                dtp_1.Enabled = true;
                dtp_2.Enabled = true;
                bis.Enabled = true;
                mode = Mode.CUSTOM;
            }
        }

        private void rB_month_CheckedChanged(object sender, EventArgs e) {
            if (rB_month.Checked) {
                dtp_1.Enabled = false;
                dtp_2.Enabled = false;
                bis.Enabled = false;
                mode = Mode.MONTH;
                getDates();
                dtp_1.Value = new DateTime(date_start);
                dtp_2.Value = new DateTime(date_end);
            }
        }
        private void startAccounting() {

            
            ac.workplace = workplace;
            try {
                ac.position_list = getPositionList(mode);
            } catch (NullReferenceException) {
                MessageBox.Show("Keine Schichten vorhanden");
                return;
            }
            //Sending Bill-Nr.
            ac.bill_nr = getBillName();

            //Sending the period
            ac.date_end_string = new Dater().getStringFromTimestamp(date_end);
            ac.date_start_string = new Dater().getStringFromTimestamp(date_start);

            //Sending the deadline
            if (cb_deadline.Checked) {
                DateTime dt = DateTime.Now;
                ac.deadline = new Dater().getStringFromTimestamp(dt.AddMonths(1).Ticks);
            }
            else {
                ac.deadline = new Dater().getStringFromTimestamp(dtp_deadline.Value.Ticks);
            }


            //Create and receive result
            switch (ac.create()) {
                case -1:
                    MessageBox.Show("Kann nicht auf Datei zugreifen! Sie ist möglicherweise nocht geöffnet");
                    break;
                case 0:
                    MessageBox.Show("Keine Schichten vorhanden");
                    break;
                case 1:
                    if (!ac.open()) {
                        MessageBox.Show("Abrechnung wurde erstellt, kann aber nicht geöffnet werden!");
                    }
                    else {
                        this.Close();
                    }
                    break;

            }
        }

        private String getBillName() {
            String bill_nr = "";
            switch (mode) {
                case Mode.WEEK:
                    DateTime dst = new DateTime(date_start);
                    CultureInfo ciCurr = CultureInfo.CurrentCulture;
                    int weekNum = ciCurr.Calendar.GetWeekOfYear(dst, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    bill_nr = "09-AU-02-" + DateTime.Now.Year + "-01-01-" + weekNum.ToString("00");
                    //andere Orte erst Name Ort, Jahr, KW
                    break;
                case Mode.MONTH:
                    bill_nr = "09-AU-02-" + DateTime.Now.Year + "-" + new DateTime(date_start).Month.ToString("00");
                    break;
                case Mode.CUSTOM:
                    bill_nr = "09-AU-02";
                    break;
            }
            return bill_nr;
        }
        public void startPrintProof() {
            
            Workplace workplace = db_manager.getItem<Workplace>(id_workplace);
            wc.workplace = workplace;
            wc.bill_nr = getBillName();

            wc.enddate = new Dater().getStringFromTimestamp(date_end);
            wc.startdate = new Dater().getStringFromTimestamp(date_start);
            try {
                wc.wp_list = getWorkProofList(id_workplace);
            } catch {
                return;
            }


            switch (wc.create()) {
                case -1:
                    MessageBox.Show("Kann nicht auf Datei zugreifen! Sie ist möglicherweise nocht geöffnet");
                    break;
                case 1:
                    if (!wc.open()) {
                        MessageBox.Show("Abrechnung wurde erstellt, kann aber nicht geöffnet werden!");
                    }
                    else {
                        this.Close();
                    }
                    break;

            }

        }
        private void button1_Click(object sender, EventArgs e) {
            getDates();
            
            
            id_workplace = ((ComboBoxItem)cB_workplaces.SelectedItem).Value;
            workplace = db_manager.getItem<Workplace>(id_workplace);

            if (cB_printproof.Checked) {
                String sqlcommand = "WHERE (Date BETWEEN " + date_start + " AND " + date_end + ") AND (ID_Workplace = " + id_workplace + ") ORDER BY Date";
                sortedList = db_manager.getShiftData(sqlcommand);
                startPrintProof();
            }
            if (cB_bill.Checked) {
                String sqlcommand = "WHERE (Date BETWEEN " + date_start + " AND " + date_end + ") AND (ID_Workplace = " + id_workplace + ") ORDER BY Name";
                sortedList = db_manager.getShiftData(sqlcommand);
                startAccounting();
            }

        }

        private void AccountingManager_Load(object sender, EventArgs e) {
            for (int i = 0; i < db_manager.getWorkplaceData("").Count; i++) {
                ComboBoxItem ci = new ComboBoxItem();
                cB_workplaces.DisplayMember = "Text";
                ci.Text = db_manager.getWorkplaceData("")[i].name + "";
                ci.Value = db_manager.getWorkplaceData("")[i].id;
                cB_workplaces.Items.Add(ci);
            }
            cB_workplaces.SelectedIndex = 0;
        }

        private void cb_deadline_CheckedChanged(object sender, EventArgs e) {
            if (cb_deadline.Checked) {
                dtp_deadline.Visible = false;
            }
            else {
                dtp_deadline.Visible = true;
                dtp_deadline.Value = DateTime.Now.AddMonths(1);
            }
        }

        private void AccountingManager_KeyDown(object sender, KeyEventArgs e) {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e) {

        }
        private List<WorkProof> getWorkProofList(int workplace_id) {
            bool alreadyWarned = false;


            List<WorkProof> workproof_list = new List<WorkProof>();

            for (int i = 0; i < sortedList.Count; i++) {
                WorkProof wp = new WorkProof();
                wp.break_time = sortedList[i].break_time;
                wp.date = new Dater().getStringFromTimestamp(sortedList[i].date);
                wp.day = getWeekDay(sortedList[i].date);
                wp.duration = sortedList[i].duration;
                wp.starttime = sortedList[i].startTime;
                DateTime dT = DateTime.ParseExact(sortedList[i].startTime, "HH:mm",
                                        CultureInfo.InvariantCulture);
                wp.enddtime = dT.AddHours(wp.duration).Hour.ToString("00") + ":" + dT.AddHours(wp.duration).Minute.ToString("00");

                wp.name = sortedList[i].name;
                for (int k = 0; k < sortedList[i].emplshift_list.Count; k++) {
                    wp.firstnames.Add(db_manager.getItem<Employee>(sortedList[i].emplshift_list[k].employee_id).firstname);
                    wp.lastnames.Add(db_manager.getItem<Employee>(sortedList[i].emplshift_list[k].employee_id).lastname);
                }
                if (sortedList[i].emplshift_list.Count == 0) {
                    if (!alreadyWarned) {
                        var message = "Die Arbeitsnachweisliste enthält mindestens eine Schicht, welcher noch kein Personal zugewiesen wurde. Soll trotzdem fortgefahren werden?";
                        var title = "";
                        var result = MessageBox.Show(
                            message,
                            title,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        switch (result) {
                            case DialogResult.Yes:
                                break;
                            case DialogResult.No:
                                throw new NullReferenceException();
                            default:
                                break;
                        }
                        alreadyWarned = true;
                    }

                }
                workproof_list.Add(wp);

            }

            return workproof_list;
        }
        private WorkProof.Days getWeekDay(long timestamp) {
            switch (new DateTime(timestamp).DayOfWeek) {
                case DayOfWeek.Monday:
                    return WorkProof.Days.Mo;
                case DayOfWeek.Tuesday:
                    return WorkProof.Days.Di;
                case DayOfWeek.Wednesday:
                    return WorkProof.Days.Mi;
                case DayOfWeek.Thursday:
                    return WorkProof.Days.Do;
                case DayOfWeek.Friday:
                    return WorkProof.Days.Fr;
                case DayOfWeek.Saturday:
                    return WorkProof.Days.Sa;
                case DayOfWeek.Sunday:
                    return WorkProof.Days.So;

            }

            return WorkProof.Days.Mo;
        }


        private void getDates() {

            switch (mode) {
                case Mode.WEEK:
                    date_start = new Dater().getWeekstart();
                    date_end = new Dater().getWeekend();
                    break;
                case Mode.MONTH:
                    date_start = new Dater().getMonthstart();
                    date_end = new Dater().getMonthend();
                    break;
                case Mode.CUSTOM:
                    date_start = dtp_1.Value.Date.Ticks;
                    date_end = dtp_2.Value.Date.Ticks;
                    break;
            }
        }

        private void cB_bill_CheckedChanged(object sender, EventArgs e) {
            cb_deadline.Enabled = cB_bill.Checked;
        }

        private List<Accounting_Position> getPositionList(Mode mode) {
            List<Accounting_Position> list = new List<Accounting_Position>();

            Accounting_Position ap = new Accounting_Position();
            Accounting_Position nap = new Accounting_Position();
            Accounting_Position hap = new Accounting_Position();
            Accounting_Position sap = new Accounting_Position();

            for (int i = 0; i < sortedList.Count; i++) {
                Shift shift = sortedList[i];

                if (i > 0 && shift.name != sortedList[i - 1].name) {
                    list.Add(ap);
                    ap = new Accounting_Position();
                }

                double sum_overtime = 0;
                for (int k = 0; k < shift.emplshift_list.Count; k++) {
                    sum_overtime += shift.emplshift_list[k].overtime;
                }

                ap.description = sortedList[i].name;
                ap.amount += (shift.duration - shift.break_time) * getEmployeeAmount(shift.emplshift_list) + sum_overtime;
                ap.price = shift.Wage_perHour;
                ap.unit = Unit.Std;
                ap.tax = ac.workplace.tax;




                if (shift.id_workplace == ac.workplace.id && shift.Night_surcharge != 0) {
                    nap.description = "Nachtzuschlag " + shift.name;
                    nap.amount += (shift.duration - shift.break_time) * getEmployeeAmount(shift.emplshift_list) + sum_overtime;
                    nap.price = (shift.Night_surcharge / 100) * shift.Wage_perHour;
                    nap.unit = Unit.Std;
                    nap.tax = ac.workplace.tax;

                }
                if (shift.id_workplace == ac.workplace.id && shift.Holiday_surcharge != 0) {
                    hap.amount += (shift.duration - shift.break_time) * getEmployeeAmount(shift.emplshift_list) + sum_overtime;
                    hap.description = "Feiertagszuschlag " + shift.name;
                    hap.price = (shift.Holiday_surcharge / 100) * shift.Wage_perHour;
                    hap.tax = ac.workplace.tax;
                    hap.unit = Unit.Std;
                }
                if (shift.id_workplace == ac.workplace.id && shift.Sunday_surcharge != 0) {
                    sap.amount += (shift.duration - shift.break_time) * getEmployeeAmount(shift.emplshift_list) + sum_overtime;
                    sap.description = "Sonntagszuschlag " + shift.name;
                    sap.price = (shift.Sunday_surcharge / 100) * shift.Wage_perHour;
                    sap.tax = ac.workplace.tax;
                    sap.unit = Unit.Std;
                }
            }
            if (!(ap.amount == 0)) {
                list.Add(ap);
            }

            if (!nap.description.Equals("")) {
                list.Add(nap);
            }
            if (!hap.description.Equals("")) {
                list.Add(hap);
            }
            if (!sap.description.Equals("")) {
                list.Add(sap);
            }
            if (list.Count == 0) {
                throw new NullReferenceException();
            }

            return list;
        }
        private int getEmployeeAmount(List<EmployeeOvertime> list) {
            if (list.Count>0) {
                return list.Count;
            }
            else {
                return 1;
            }
        }
    }
    
}
