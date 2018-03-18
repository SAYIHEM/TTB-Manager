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
    public partial class ShiftManager : Form {
        String sql_name = "ShiftTemplate.Name AS Name";
        String sql_workplace = "Workplace.Name AS Ort";
        String sql_starttime = "ShiftTemplate.StartTime AS Startzeit";
        String sql_duration = "ShiftTemplate.Duration AS 'Länge (h)'";
        String sql_wage = "ShiftTemplate.WagePerHour AS Stundenlohn";
        String sql_holiday = "ShiftTemplate.Holidaysurcharge AS FZ";
        String sql_night = "ShiftTemplate.Nightsurcharge AS NZ";
        String sql_sunday = "ShiftTemplate.Sundaysurcharge AS SZ";
        String sql_id = "ShiftTemplate.ID";
        String default_query = "";

        int cur_row = -1;
        int cur_col = -1;
        bool openCTXmenu = false;

        DB_Manager db_manager = new DB_Manager();
        public ShiftManager() {
            InitializeComponent();
            db_manager.connect();
            StartPosition = FormStartPosition.CenterScreen;
            default_query = "SELECT "
                + sql_name + ", "
                + sql_workplace + ", "
                + sql_starttime + ", "
                + sql_duration + ", "
                + sql_wage + ", "
                + sql_holiday + ", "
                + sql_night + ", "
                + sql_sunday + ", "
                + sql_id
                + " FROM ShiftTemplate INNER JOIN Workplace ON Workplace.ID = ShiftTemplate.ID_Workplace; ";
        }

        private void ShiftManager_Load(object sender, EventArgs e) {
            MinimizeBox = false;
            MaximizeBox = false;
            FillDefaultTable();

        }

        private void button1_Click(object sender, EventArgs e) {
            AddShiftTemplate addshifttemplate = new AddShiftTemplate();
            addshifttemplate.FormBorderStyle = FormBorderStyle.FixedDialog;
            addshifttemplate.FormClosing += new FormClosingEventHandler(this.form_FormClosing);
            addshifttemplate.Show();
        }
        private void FillDefaultTable() {
            db_manager.showInTable<Shift>(table_templ, default_query);

            table_templ.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Name
            table_templ.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Ort
            table_templ.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Startzeit
            table_templ.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Länge
            table_templ.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Lohn
            table_templ.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Feiertag
            table_templ.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Nacht
            table_templ.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Sonntag
            table_templ.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //ID

        }

        private void form_FormClosing(object sender, FormClosingEventArgs e) {
            FillDefaultTable();
        }

        private void table_templ_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        }



        private void table_templ_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && cur_row != -1) {
                table_templ.CurrentCell = table_templ.Rows[cur_row].Cells[0];
                ctx_menu_shiftmanager.Show(Cursor.Position);
            }
        }

        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
            openCTXmenu = false;
        }

        private void ctx_menu_shiftmanager_Opening(object sender, CancelEventArgs e) {
            openCTXmenu = true;
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e) {
            int sel_id = Int32.Parse(table_templ.Rows[cur_row].Cells["ID"].Value.ToString());
            if (new Eraser().start<Shift_Template>(sel_id)) {
                FillDefaultTable();
            }
            return;
        }

        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void table_templ_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            cur_row = e.RowIndex;
            cur_col = e.ColumnIndex;
        }

        private void table_templ_CellMouseLeave(object sender, DataGridViewCellEventArgs e) {
            if (!openCTXmenu) {
                cur_row = -1;
                cur_col = -1;
            }
        }

        private void table_templ_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                if (new Eraser().start<Shift_Template>(table_templ)) {
                    FillDefaultTable();
                }
            }
        }
    }
}
