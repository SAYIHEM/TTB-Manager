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

namespace TTB_Manager.Forms {
    public partial class EmployeeManager : Form {

        int sel_id;
        DB_Manager db_manager = new DB_Manager();
        String default_query = "";
        String sql_birth = "Employee.Birthdate AS Geburtstag";
        String sql_firstname = "Employee.Firstname AS Vorname";
        String sql_lastname = "Employee.Lastname AS Nachname";
        String sql_street = "Employee.Street AS Straße";
        String sql_number = "Employee.Number AS Hausnummer";
        String sql_plz = "Employee.PLZ AS PLZ";
        String sql_city = "Employee.City AS Stadt";
        String sql_country = "Employee.Country AS Land";
        String sql_id = "Employee.ID As ID";
        String sql_mail = "Employee.Mail AS Mail";

        int cur_row = -1, cur_col = -1;
        bool openCTXmenu = false;
        public EmployeeManager() {
            default_query = "SELECT "
                + sql_firstname + ", "
                + sql_lastname + ", "
                + sql_mail + ", "
                + sql_street + ", "
                + sql_number + ", "
                + sql_plz + ", "
                + sql_city + ", "
                + sql_country + ", "
                + sql_birth + ", "
                + sql_id
                +  " FROM Employee ";
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            db_manager.connect();
            
        }

        private void table_employee_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void EmployeeManager_Load(object sender, EventArgs e) {
            MinimizeBox = false;
            MaximizeBox = false;
            FillDefaultTable();


        }
        private void setColumnSize() {
            table_employee.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Vorname
            table_employee.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Nachname
            table_employee.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Straße
            table_employee.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader; //Nr.
            table_employee.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //PLZ
            table_employee.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Stadt
            table_employee.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Land
            table_employee.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Geburtstag
            table_employee.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //ID

            for (int i = 0; i < table_employee.Rows.Count; i++) {
                int id = Int32.Parse(table_employee.Rows[i].Cells["ID"].Value.ToString());
                try {
                    table_employee.Rows[i].Cells["Geburtstag"].Value = new Dater().getStringFromTimestamp(db_manager.getItem<Employee>(id).birthdate);
                } catch { }

            }
        }
        private void FillDefaultTable() {
            db_manager.showInTable<Employee>(table_employee, default_query);
            setColumnSize();
        }

        private void button1_Click(object sender, EventArgs e) {
            EditEmployee editemployee = new EditEmployee();
            editemployee.FormClosing += new FormClosingEventHandler(this.form_FormClosing);
            editemployee.FormBorderStyle = FormBorderStyle.FixedDialog;
            editemployee.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e) {
            FillDefaultTable();
        }

        private void bearbeienToolStripMenuItem_Click(object sender, EventArgs e) {
            EditEmployee editemployee = new EditEmployee(sel_id);
            editemployee.FormClosing += new FormClosingEventHandler(this.form_FormClosing);
            editemployee.FormBorderStyle = FormBorderStyle.FixedDialog;
            editemployee.ShowDialog();
        }


        private void table_employee_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && cur_row != -1) {
                table_employee.CurrentCell = table_employee.Rows[cur_row].Cells[0];
                ctx_menu_empl.Show(Cursor.Position);
            }
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e) {            


            if (new Eraser().start<Employee>(sel_id)) {
                FillDefaultTable();
            }
            return;
        }

        private void ctx_menu_empl_Opening(object sender, CancelEventArgs e) {
            openCTXmenu = true;
            sel_id = Int32.Parse(table_employee.Rows[cur_row].Cells["ID"].Value.ToString());
            if (db_manager.getItem<Employee>(sel_id).state == Employee.State.ILL) {
                krankToolStripMenuItem.Checked = true;
            } else {
                krankToolStripMenuItem.Checked = false;
            }
        }

        private void ctx_menu_empl_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
            openCTXmenu = false;
        }

        private void table_employee_CellMouseLeave(object sender, DataGridViewCellEventArgs e) {
            if (!openCTXmenu) {
                cur_row = -1;
                cur_col = -1;
            }
        }

        private void table_employee_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                if (new Eraser().start<Employee>(table_employee)) {
                    FillDefaultTable();
                }
            }
        }

        private void urlaubEintragenToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void krankToolStripMenuItem_Click(object sender, EventArgs e) {
            Employee empl = db_manager.getItem<Employee>(sel_id);
            if (krankToolStripMenuItem.Checked == true) {
                empl.state = Employee.State.ILL;
                db_manager.update(empl);
            }
            else {
                empl.state = Employee.State.FRE;
                db_manager.update(empl);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (!tv_search.Text.Equals("")) {
            
                String user_search = tv_search.Text;
                String search_query = default_query;
                search_query += " WHERE (Firstname LIKE '%" + user_search + "%') OR (Lastname LIKE '%" + user_search + "%')";
                db_manager.showInTable<Employee>(table_employee, search_query);
                setColumnSize();
            }
            else {
                FillDefaultTable();
            }
        }

        private void table_employee_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            cur_row = e.RowIndex;
            cur_col = e.ColumnIndex;
        }

    }
}
