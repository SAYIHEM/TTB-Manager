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
    public partial class WorkplaceManager : Form {
        String sql_contact = "Workplace.Contact_Mail AS Mail";
        String sql_street = "Workplace.Street AS Straße";
        String sql_number = "Workplace.Number AS Hausnummer";
        String sql_plz = "Workplace.PLZ AS PLZ";
        String sql_city = "Workplace.City AS Stadt";
        String sql_country = "Workplace.Country AS Land";
        String sql_name = "Workplace.Name AS Name";
        String sql_id = "Workplace.ID";
        String default_query = "";

        int cur_row = -1, cur_col = -1;

        bool openCTXmenu = false;

        DB_Manager db_manager = new DB_Manager();
        public WorkplaceManager() {
            db_manager.connect();
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            default_query = "SELECT "
        + sql_name + ", "
        + sql_street + ", "
        + sql_number + ", "
        + sql_plz + ", "
        + sql_city + ", "
        + sql_country + ", "
        + sql_contact + ", "
        + sql_id
        + " FROM Workplace;";

        }

        private void Locations_Load(object sender, EventArgs e) {
            MinimizeBox = false;
            MaximizeBox = false;
            FillDefaultTable();
        }

        private void button1_Click(object sender, EventArgs e) {
            EditWorkplace editlocation = new EditWorkplace();
            editlocation.FormBorderStyle = FormBorderStyle.FixedDialog;
            editlocation.ShowDialog();
        }
        private void FillDefaultTable() {
           // table_workpl.Rows.Clear();
            db_manager.showInTable<Workplace>(table_workpl, default_query);

            table_workpl.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Name
            table_workpl.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Straße
            table_workpl.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; //Nr
            table_workpl.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //PLZ
            table_workpl.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Stadt
            table_workpl.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Land
            table_workpl.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Mail
            table_workpl.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //ID
        }


        private void table_workpl_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }


        private void table_workpl_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && cur_row != -1) {
                table_workpl.CurrentCell = table_workpl.Rows[cur_row].Cells[0];
                ctx_workpl.Show(Cursor.Position);
            }
            if (e.Button == MouseButtons.Left && cur_row != -1) {
            }
        }

        private void table_workpl_CellEnter(object sender, DataGridViewCellEventArgs e) {
            cur_row = e.RowIndex;
            cur_col = e.ColumnIndex;
        }

        private void ctx_workpl_Opening(object sender, CancelEventArgs e) {
            openCTXmenu = true;
        }

        private void ctx_workpl_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
            openCTXmenu = false;
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e) {
            int sel_id = Int32.Parse(table_workpl.Rows[cur_row].Cells["ID"].Value.ToString());

            if (new Eraser().start<Workplace>(sel_id)) {
                FillDefaultTable();
            }
            return;

        }

        private void table_workpl_CellLeave(object sender, DataGridViewCellEventArgs e) {
            if (!openCTXmenu) {
                cur_row = -1;
                cur_col = -1;
            }
        }

        private void table_workpl_KeyDown(object sender, KeyEventArgs e) {
           if (e.KeyCode == Keys.Delete) {
                if (new Eraser().start<Workplace>(table_workpl)) {
                    FillDefaultTable();
                }
            }
        }

        private bool checkIfShiftExist(int id_workplace) {
            String sqlcommand = "WHERE ID_Workplace = " + id_workplace;
            List<Shift> list = db_manager.getShiftData(sqlcommand);
            if (list.Count>0) {
                return true;
            }
            return false;
            
        }
    }
}
