using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.Database;
using TTB_Manager.Types;
using TTB_Manager.PDFCreator;

namespace TTB_Manager.Forms {
    public partial class MainForm : Form {
        String sql_starttime = "Shift.StartTime AS Startzeit",
        sql_duration = "Shift.Duration AS 'Länge (h)'",
        sql_comment = "Shift.Comment AS Kommentar",
        sql_name = "Shift.Name AS Name",
        sql_personal = "COALESCE(Employee.Firstname, '') || COALESCE(null,' ') || COALESCE(Employee.Lastname, '') AS Personal",
        sql_workplace = "Workplace.Name AS Ort",
        sql_date = "Shift.Date AS Datum",
        sql_wage = "Shift.WagePerHour AS Stundenlohn",
        sql_holiday = "Shift.Holidaysurcharge AS FZ",
        sql_night = "Shift.Nightsurcharge AS NZ",
        sql_sunday = "Shift.Sundaysurcharge AS SZ",
        sql_id = "Shift.ID",
        default_query = "";

        DevTools devtools;
        MasterView mv;

        int cur_row = -1;
        int cur_col = -1;
        bool openCTXmenu = false;
        int comment_row = -1;
        int sel_row_id;
        bool nochange = false;


        DB_Manager db_manager = new DB_Manager();
        Login_Form login;
        public enum TableMode { WEEK, FUTURE, ALL }
        TableMode tablemode;
        ToolTip toolTip = new ToolTip();
        //ListManager listmanager = new ListManager();

        public MainForm(Login_Form login) {
            InitializeComponent();
            this.login = login;
            devtools = new DevTools(this);
        }

        private void Form1_Load(object sender, EventArgs e) {

            //Starte aus Mitte
            StartPosition = FormStartPosition.CenterScreen;

            default_query = "SELECT "
                + sql_workplace + ", "
                + sql_name + ", "
                + sql_date + ", "
                + sql_starttime + ", "
                + sql_personal + ", "
                + sql_comment + ", "
                + sql_duration + ", "
                + sql_wage + ", "
                + sql_holiday + ", "
                + sql_night + ", "
                + sql_sunday + ", "
                + sql_id
                + " FROM Shift "
                + " LEFT JOIN Workplace ON Workplace.ID = Shift.ID_Workplace "

               + " LEFT JOIN Shift_Employee ON Shift.ID = Shift_Employee.ID_Shift  "

               + " LEFT JOIN Employee ON Employee.ID = Shift_Employee.ID_Employee ";



            db_manager.connect();
            rB_week.Checked = true;

            FillTable(TableMode.WEEK);

            //Open Masterview
            menustrip_masterview.Checked = true;
            mv = new MasterView(this);
            mv.Show();
           
        }
        public void FillTable(TableMode tablemode) {  //TableMode = WEEK | FUTURE | ALL
            UseWaitCursor = true;
            this.tablemode = tablemode;
            String query = "";
            switch (this.tablemode) {
                case TableMode.WEEK:
                    Console.WriteLine(new Dater().getWeekstart() + "");
                    query = default_query + "WHERE Shift.date BETWEEN '" + new Dater().getWeekstart() + "' AND '" + new Dater().getWeekend() + "' ORDER BY Shift.date";

                    break;
                case TableMode.FUTURE:
                    query = default_query + "WHERE Shift.date >= '" + new Dater().getTickFromDate(DateTime.Today) + "' ORDER BY Shift.date;";

                    break;
                case TableMode.ALL:
                    query = default_query + " ORDER BY Shift.date;";

                    break;
            }
            db_manager.showInTable<Shift>(table_main, query);


            nochange = true; //to prevent ValueChangedEventHandler triggered
            if (tablemode == TableMode.WEEK) {

                for (int i = 0; i < table_main.Rows.Count; i++) {
                    int id = Int32.Parse(table_main.Rows[i].Cells["ID"].Value.ToString());

                    //Make row red if shift has no employee
                    List<EmployeeOvertime> personal_list = db_manager.getItem<Shift>(id).emplshift_list;
                    if (personal_list.Count == 0) {
                        for (int k = 0; k < table_main.Columns.Count; k++) {
                            table_main.Rows[i].Cells[k].Style.BackColor = Color.FromArgb(255, 130, 130);
                        }
                    }
                }

            }

            table_main.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Ort
            table_main.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Name
            table_main.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Datum
            table_main.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Startzeit
            table_main.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Personal
            table_main.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Kommentar
            table_main.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Länge
            table_main.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Stundenlohgn
            table_main.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Feiertag
            table_main.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Nacht
            table_main.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Nacht
            table_main.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; //ID

            for (int i = 0; i < table_main.Columns.Count; i++) {
                table_main.Columns[i].ReadOnly = true;
            }
            for (int i = 0; i < table_main.Rows.Count; i++) {
                int id = Int32.Parse(table_main.Rows[i].Cells["ID"].Value.ToString());
                //Importing the user-friendly date
                table_main.Rows[i].Cells["Datum"].Value = new Dater().getStringFromTimestamp(db_manager.getItem<Shift>(id).date);
            }

            nochange = false;

            UseWaitCursor = false;
        }
        private void table_main_columnheadermouseclick(object sender, DataGridViewCellMouseEventArgs e) {
            //Falls neu sortiert wird
            if (tablemode == TableMode.WEEK) {
                for (int i = 0; i < table_main.Rows.Count; i++) {
                    int id = Int32.Parse(table_main.Rows[i].Cells["ID"].Value.ToString());
                    List<EmployeeOvertime> personal_list = db_manager.getItem<Shift>(id).emplshift_list;

                    if (personal_list.Count == 0) {
                        for (int k = 0; k < table_main.Columns.Count; k++) {
                            table_main.Rows[i].Cells[k].Style.BackColor = Color.FromArgb(255, 130, 130);
                        }
                    }
                }
            }
        }

        private void table_main_CellMouseLeave(object sender, DataGridViewCellEventArgs e) {
            if (!openCTXmenu) {
                cur_row = -1;
                cur_col = -1;
            }

        }

        private void table_main_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            cur_row = e.RowIndex;
            cur_col = e.ColumnIndex;
            table_main.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //



        }
        private void ShowTooltip() {
            //Employee Information
            ToolTip t = new ToolTip();
            t.ShowAlways = true;
            t.SetToolTip(this, "Click");
        }


        private void table_main_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && cur_row != -1) {
                table_main.CurrentCell = table_main.Rows[cur_row].Cells[0];
                main_ctxmenu.Show(Cursor.Position);
            }

        }
        private void table_main_DoubleClick(object sender, EventArgs e) {
            if (cur_row != -1 && cur_col != -1) {
                sel_row_id = Int32.Parse(table_main.Rows[cur_row].Cells["ID"].Value.ToString());
                EmployeeDropper employeedropper = new EmployeeDropper(sel_row_id);
                employeedropper.FormClosed += new FormClosedEventHandler(this.employeedropper_FormClosedEvent);
                employeedropper.FormBorderStyle = FormBorderStyle.FixedDialog;
                employeedropper.ShowDialog();
            }
        }
        private void employeedropper_FormClosedEvent(object sender, FormClosedEventArgs e) {

            FillTable(tablemode);
            mv.RefreshAll();
        }


        private void ctx_main_comment_Click(object sender, EventArgs e) {
            comment_row = cur_row;
            table_main.SelectionMode = DataGridViewSelectionMode.CellSelect;
            table_main.CurrentCell = table_main.Rows[comment_row].Cells["Kommentar"];
            table_main.Rows[comment_row].Cells["Kommentar"].ReadOnly = false;
            table_main.BeginEdit(true);

        }
        private void table_main_Value_Changed(object sender, DataGridViewCellEventArgs e) {

            if (!nochange) {
                String newcomment = table_main.Rows[comment_row].Cells["Kommentar"].Value.ToString();

                Shift shift = db_manager.getItem<Shift>(sel_row_id);
                if (shift.comment != newcomment) {
                    shift.comment = newcomment;
                    db_manager.update(shift);
                }
                try {
                    table_main.CurrentCell = null;
                } catch { }

                table_main.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                table_main.Rows[comment_row].Selected = true;
            }



        }

        private void main_ctxmenu_Opening(object sender, CancelEventArgs e) {
            openCTXmenu = true;

            sel_row_id = Int32.Parse(table_main.Rows[cur_row].Cells["ID"].Value.ToString());
            Shift shift = db_manager.getItem<Shift>(sel_row_id);
            List<EmployeeOvertime> personal_list = shift.emplshift_list;

            if (personal_list.Count == 0) {
                ctx_main_notifythem.Enabled = false;
                ctx_main_overtimeedit.Enabled = false;
            }
            else {
                ctx_main_notifythem.Enabled = true;
                ctx_main_overtimeedit.Enabled = true;
            }

        }
        private void ctx_main_delete_Click(object sender, EventArgs e) {
            Eraser er = new Eraser();
            er.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
            if (er.start<Shift>(sel_row_id)) {
                FillTable(tablemode);
                mv.RefreshShifts();
            }

        }

        private void table_main_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
        private void ctxmenu_main_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
            openCTXmenu = false;
        }

        private void rB_all_CheckedChanged(object sender, EventArgs e) {
            if (rB_all.Checked)
                FillTable(TableMode.ALL);
        }

        private void mainform_FormClosingEvent(object sender, FormClosingEventArgs e) {

            FillTable(tablemode);
            mv.RefreshAll();
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }


        private void button1_Click(object sender, EventArgs e) {
            //Fixed Dialog => Größe kann nicht verändert werden
            EditEmployee personalmanager = new EditEmployee();
            personalmanager.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
            personalmanager.FormBorderStyle = FormBorderStyle.FixedDialog;
            personalmanager.ShowDialog();
        }



        private void ortToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            AddShift addShift = new AddShift();
            addShift.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
            addShift.FormBorderStyle = FormBorderStyle.FixedDialog;
            addShift.ShowDialog();
        }




        private void infoToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Tom G. \nManuel K.",
            "Info",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);
        }

        private void kontoToolStripMenuItem_Click(object sender, EventArgs e) {

        }


        private void abrechnungDruckenToolStripMenuItem_Click(object sender, EventArgs e) {
            printAccounting();
        }

        private void ctx_main_personal_Click(object sender, EventArgs e) {
            EmployeeDropper employeedropper = new EmployeeDropper(sel_row_id);
            employeedropper.FormClosed+= new FormClosedEventHandler(this.employeedropper_FormClosedEvent);
            employeedropper.FormBorderStyle = FormBorderStyle.FixedDialog;
            employeedropper.ShowDialog();
        }

        private void ctx_main_editshift_Click(object sender, EventArgs e) {

        }

        private void ctx_main_notifythem_Click(object sender, EventArgs e) {
            Shift cur_shift = db_manager.getItem<Shift>(sel_row_id);
            new EmployeeNotifier().notify(cur_shift);

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F7) {
                printAccounting();
            }
            else if (e.KeyCode == Keys.Delete) {
                Eraser er = new Eraser();
                er.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
                if (er.start<Shift>(table_main)) {
                    FillTable(tablemode);
                    mv.RefreshAll();
                }
            }
            else if (e.KeyData == (Keys.Control | Keys.Alt | Keys.D0)) {
                try {
                    devtools.Show();
                    devtools.BringToFront();
                } catch {
                    devtools = new DevTools(this);
                    devtools.Show();
                    devtools.BringToFront();
                }

            }

            else if (e.KeyCode == Keys.F3) {
                AddShift addshiift = new AddShift();
                addshiift.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
                addshiift.FormBorderStyle = FormBorderStyle.FixedDialog;
                addshiift.ShowDialog();
            }
            else if (e.KeyCode == Keys.F12) {
                Statistics statistics = new Statistics();
                statistics.FormBorderStyle = FormBorderStyle.FixedDialog;
                statistics.ShowDialog();
            }

        }

        private void schichtToolStripMenuItem1_Click(object sender, EventArgs e) {
            AddShift addshiift = new AddShift();
            addshiift.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
            addshiift.FormBorderStyle = FormBorderStyle.FixedDialog;
            addshiift.ShowDialog();
        }

        private void neuToolStripMenuItem1_Click(object sender, EventArgs e) {
            EditWorkplace editlocation = new EditWorkplace();
            editlocation.FormBorderStyle = FormBorderStyle.FixedDialog;
            editlocation.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
            editlocation.ShowDialog();
        }

        private void alleAnzeigenToolStripMenuItem_Click(object sender, EventArgs e) {
            WorkplaceManager locations = new WorkplaceManager();
            locations.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
            locations.FormBorderStyle = FormBorderStyle.FixedDialog;
            locations.ShowDialog();
        }

        private void alleAnzeigenToolStripMenuItem1_Click(object sender, EventArgs e) {
            EmployeeManager employeemanager = new EmployeeManager();
            employeemanager.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
            employeemanager.FormBorderStyle = FormBorderStyle.FixedDialog;
            employeemanager.ShowDialog();
        }

        private void vorlageToolStripMenuItem_Click(object sender, EventArgs e) {
            AddShiftTemplate addshifttemplate = new AddShiftTemplate();
            addshifttemplate.FormBorderStyle = FormBorderStyle.FixedDialog;
            addshifttemplate.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
            addshifttemplate.Show();
        }

        private void neuToolStripMenuItem2_Click(object sender, EventArgs e) {
            EditEmployee editemployee = new EditEmployee();
            editemployee.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
            editemployee.FormBorderStyle = FormBorderStyle.FixedDialog;
            editemployee.ShowDialog();
        }

        private void alleVorlagenToolStripMenuItem_Click(object sender, EventArgs e) {
            ShiftManager shiftmanager = new ShiftManager();
            shiftmanager.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
            shiftmanager.FormBorderStyle = FormBorderStyle.FixedDialog;
            shiftmanager.ShowDialog();
        }

        private void MainForm_Move(object sender, EventArgs e) { 
            try {
                devtools.Location = new Point(Location.X, Location.Y - devtools.Height);
            } catch { }
            try {
                mv.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            } catch { }
        }

        private void MainForm_Deactivate(object sender, EventArgs e) {
           
        }

        private void MainForm_Activated(object sender, EventArgs e) {
    }


    private void überstundenEintragenToolStripMenuItem_Click(object sender, EventArgs e) {

        OvertimeDropper overtime_dropper = new OvertimeDropper(sel_row_id);
        overtime_dropper.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
        overtime_dropper.FormBorderStyle = FormBorderStyle.FixedDialog;
        overtime_dropper.ShowDialog();
    }

    private void menustrip_masterview_Click(object sender, EventArgs e) {
        if (menustrip_masterview.Checked) {
            mv = new MasterView(this);
            mv.Show();
        }
        else {
                try {
                    mv.Close();
                } catch { }
           
        }
    }



    private void offlineToolStripMenuItem_Click(object sender, EventArgs e) {
        Backup_offline backup_form = new Backup_offline();
        backup_form.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
        backup_form.FormBorderStyle = FormBorderStyle.FixedDialog;
        backup_form.ShowDialog();


    }

    private void entwicklerToolsToolStripMenuItem_Click(object sender, EventArgs e) {

        var message = "Wirklich zu den Entwickler-Tools wechseln? Datenverlust möglich!";
        var title = "Warnung";
        var result = MessageBox.Show(
            message,
            title,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        switch (result) {
            case DialogResult.Yes:
                devtools = new DevTools(this);
                devtools.Show();
                break;
            case DialogResult.No:
                break;
            default:
                break;
        }


    }

    private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {

        this.Visible = false;
        login.Visible = true;
    }

    private void personalManagerToolStripMenuItem_Click(object sender, EventArgs e) {

    }

    private void button2_Click_1(object sender, EventArgs e) {

        AddShift addshift = new AddShift();
        addshift.FormClosing += new FormClosingEventHandler(this.mainform_FormClosingEvent);
        addshift.FormBorderStyle = FormBorderStyle.FixedDialog;
        addshift.ShowDialog();
    }


    private void rB_week_CheckedChanged(object sender, EventArgs e) {
        if (rB_week.Checked)
            FillTable(TableMode.WEEK);
    }



    private void rB_future_CheckedChanged(object sender, EventArgs e) {
        if (rB_future.Checked)
            FillTable(TableMode.FUTURE);
    }

    private void umsatzStatistikToolStripMenuItem_Click(object sender, EventArgs e) {
        Umsatzübersicht wagestats = new Umsatzübersicht();
        wagestats.FormBorderStyle = FormBorderStyle.FixedDialog;
        wagestats.ShowDialog();
    }

    private void orteManagerToolStripMenuItem_Click(object sender, EventArgs e) {

    }

    private void toolsToolStripMenuItem_Click(object sender, EventArgs e) {

    }



    private void personalToolStripMenuItem_Click(object sender, EventArgs e) {

    }
    private void printAccounting() {
        AccountingManager accountingmanager = new AccountingManager();
        accountingmanager.FormBorderStyle = FormBorderStyle.FixedDialog;
        accountingmanager.ShowDialog();

    }


}
}
