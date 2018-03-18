using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.Database;
using TTB_Manager.Types;

namespace TTB_Manager.Forms {
    public partial class MasterView : Form {
        MainForm mainform;
        DB_Manager db_manager = new DB_Manager();
        String search_empl_hint = "Personal suchen";
        bool SYSTEM_CHANGE = true;
        List<Employee> sortedEmplList = new List<Employee>();
        List<Employee> working_empls = new List<Employee>();

        ToolTip shift_tooltip = new ToolTip();
        ToolTip cur_shift_tooltip = new ToolTip();

        public MasterView(MainForm mainform) {
            this.mainform = mainform;
            db_manager.connect();
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.Manual;
            if (mainform.WindowState != FormWindowState.Maximized) {
                this.Location = new Point(mainform.Location.X + mainform.Width, mainform.Location.Y);
            }

            this.Height = mainform.Height;

        }

        private void MasterView_Load(object sender, EventArgs e) {
            CreateWorkingEmployeesList();
            RefreshAll();
            //RefreshEmployeeStates();


            mainform.Location = new Point(mainform.Location.X - (this.Width / 2), mainform.Location.Y);

            //Import Scrollbar
            ScrollBar vScrollBar1 = new VScrollBar();
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Scroll += (senderr, ee) => { panel_employees.VerticalScroll.Value = vScrollBar1.Value; };
            panel_employees.Controls.Add(vScrollBar1);
            clock_timer.Start();
            employee_state_timer.Start();

            //FIll hint in search box
            tv_empl_search.Text = search_empl_hint;
            tv_empl_search.ForeColor = SystemColors.GrayText;
            SYSTEM_CHANGE = false;
        }
        private void CreateWorkingEmployeesList() {
            String sqlcommand = "WHERE State = " + (int)Employee.State.WKS;
            working_empls = db_manager.getEmployeeData(sqlcommand);
        }

        private void MasterView_Deactivate(object sender, EventArgs e) {
        }

        public void RefreshEmployees() {
            //Import all employees
            String sql_command = "ORDER BY Lastname";
            sortedEmplList = db_manager.getEmployeeData(sql_command);
            FillEmployeePanel(sortedEmplList);

        }
        public void RefreshEmployeeStates() {
            showRefreshLabel(panel_employees);
            for (int i = 0; i < sortedEmplList.Count; i++) {
                Employee empl = sortedEmplList[i];
                if (new EmployeeInformation(empl.id).isAtWork() != -1) {
                    empl.state = Employee.State.WKS;
                    working_empls.Add(empl); //To set him from wks to fre after work
                    db_manager.update(empl);
                }
                else {
                    for (int k = 0; k < working_empls.Count; k++) {
                        if (working_empls[k].id == sortedEmplList[i].id) {
                            empl.state = Employee.State.FRE;
                            db_manager.update(empl);
                            working_empls.RemoveAt(k);
                        }
                    }

                }
            }
            FillEmployeePanel(sortedEmplList);
        }
        private void showRefreshLabel(Panel panel) {
            panel.Controls.Clear();
            Label label = new Label();
            label.Text = "Aktualisieren ...";
            label.ForeColor = Color.Black;
            label.Location = new Point(label.Location.X, 10);
            panel.Controls.Add(label);
            Refresh();

        }
        public void RefreshAll() {
            RefreshShifts();
            RefreshEmployees();
            RefreshEmployeeStates();
        }
        public void RefreshShifts() {
            panel_curshifts.Controls.Clear();
            bool FOUND_NEXT_SHIFT = false;
            List<Shift> cur_shift_list = new List<Shift>();
            //Get shifts
            List<Shift> sortedShiftList = db_manager.getShiftData("").OrderBy(o => o.starttime()).ToList();
            for (int i = 0; i < sortedShiftList.Count; i++) {
                if (sortedShiftList[i].starttime().Ticks > DateTime.Now.Ticks && !FOUND_NEXT_SHIFT) {
                    //Get next shift
                    String datetime = sortedShiftList[i].starttime().ToString("dd.MM.yyy  HH:mm");
                    lab_nextshift.Text = datetime + " Uhr";
                    FOUND_NEXT_SHIFT = true;
                    //Tooltip for next shift

                    shift_tooltip.ShowAlways = true;
                    String tool_text = "";
                    if (!sortedShiftList[i].name.Equals("")) {
                        tool_text += sortedShiftList[i].name + "\n";
                    }
                    tool_text += db_manager.getItem<Workplace>(sortedShiftList[i].id_workplace).name;
                    shift_tooltip.SetToolTip(lab_nextshift, tool_text);
                    break;
                }
                //Get current shift
                if (sortedShiftList[i].starttime().Ticks <= DateTime.Now.Ticks && sortedShiftList[i].endtime().Ticks >= DateTime.Now.Ticks) {
                    cur_shift_list.Add(sortedShiftList[i]);
                }
            }
            if (!FOUND_NEXT_SHIFT) {
                lab_nextshift.Text = "Keine zukünftige Schicht";
            }

            String cur_shift_text = "";
            int y = 13;
            for (int i = 0; i < cur_shift_list.Count; i++) {

                //Set Label
                cur_shift_text = db_manager.getItem<Workplace>(cur_shift_list[i].id_workplace).name + " (" + cur_shift_list[i].id + ")";
                Label lab_curShift = new Label();
                lab_curShift.Location = new Point(12, y);
                lab_curShift.Text = cur_shift_text;
                lab_curShift.Width = 100;
                lab_curShift.Name = cur_shift_list[i].id + "";
                lab_curShift.ForeColor = Color.Black;
                panel_curshifts.Controls.Add(lab_curShift);

                if (cur_shift_list[i].emplshift_list.Count == 0) {
                    lab_curShift.ForeColor = Color.Red;
                    Label att = new Label();
                    att.Location = new Point(lab_curShift.Location.X - 10, y - 4);
                    att.Text = "!";
                    att.Font = new Font("Microsoft Sans Serif", 13);
                    att.Width = 20;
                    att.Height = lab_curShift.Height;
                    att.ForeColor = Color.Red;
                    lab_curShift.DoubleClick += new EventHandler(this.cur_shift_DoubleClickEvent);
                    panel_curshifts.Controls.Add(att);
                }

                //Generate ToolTip
                cur_shift_tooltip.ShowAlways = true;
                String tool_text = "";
                tool_text = cur_shift_list[i].name;
                tool_text += cur_shift_list[i].startTime;
                tool_text += " bis " + cur_shift_list[i].endtime().ToShortTimeString();
                cur_shift_tooltip.SetToolTip(lab_curShift, tool_text);

                y += lab_curShift.Height;
            }
            if (cur_shift_text.Equals("")) {
                Label l = new Label();
                l.Text = cur_shift_text;
                l.ForeColor = Color.Black;
                l.Location = new Point(12, 13);
                l.Text = "Keine laufende Schicht";
                l.Width = panel_curshifts.Width;
                panel_curshifts.Controls.Add(l);
            }
        }
        /// <summary>
        /// Just if the shift has no employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cur_shift_DoubleClickEvent(object sender, EventArgs e) {
            int shift_id = Int32.Parse(((Label)sender).Name);
            EmployeeDropper ed = new EmployeeDropper(shift_id);
            ed.Name = shift_id + "";
            ed.FormClosed += new FormClosedEventHandler(this.EmployeeDropper_Closed_Event);
            ed.Show();


        }
        /// <summary>
        /// If Employee Dropper is closed, notify the personal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeDropper_Closed_Event(object sender, FormClosedEventArgs e) {
            int shift_id = Int32.Parse(((Form)sender).Name);
            Shift shift = db_manager.getItem<Shift>(shift_id);
            if (shift.emplshift_list.Count>0) {
                RefreshAll();
                EmployeeNotifier en = new EmployeeNotifier();
                en.notify(shift);
            }

        }

        private void clock_timer_Tick(object sender, EventArgs e) {
            lab_time.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            lab_time.Location = new Point((this.Width - lab_time.Width) / 2, lab_time.Location.Y);

            lab_date.Text = DateTime.Now.ToLongDateString();
            lab_date.Location = new Point((this.Width - lab_date.Width) / 2, lab_date.Location.Y);
        }

        private void MasterView_FormClosing(object sender, FormClosingEventArgs e) {
            mainform.Location = new Point(mainform.Location.X + (this.Width / 2), mainform.Location.Y);
            mainform.menustrip_masterview.Checked = false;
        }



        private void tv_empl_search_MouseLeave(object sender, EventArgs e) {
            if (tv_empl_search.Text.Length == 0) {
                tv_empl_search.Text = search_empl_hint;
                tv_empl_search.ForeColor = SystemColors.GrayText;
                this.ActiveControl = null;

            }
        }

        private void tv_empl_search_TextChanged(object sender, EventArgs e) {
            if (!tv_empl_search.Text.Equals(search_empl_hint)) {
                int tv_length = tv_empl_search.Text.Length;
                String user_search = tv_empl_search.Text;
                String sqlcommand = "WHERE Lastname LIKE '%" + user_search + "%' OR Firstname LIKE '%" + user_search + "%' OR ID = '" + user_search + "'";
                List<Employee> search_list = db_manager.getEmployeeData(sqlcommand);
                FillEmployeePanel(search_list);

            }
            else {
                FillEmployeePanel(sortedEmplList);
            }
        }
        private void FillEmployeePanel(List<Employee> list) {
            const int GAB_BETWEEN_ELEMENTS = 0;
            const int LABEL_WIDTH = 145;
            panel_employees.Controls.Clear();
            int y = 10;

            for (int i = 0; i < list.Count; i++) {
                Label label = new Label();
                label.ForeColor = Color.Black;
                label.Width = LABEL_WIDTH;
                label.Location = new Point(label.Location.X, y);
                label.Text = list[i].lastname + ", " + list[i].firstname;
                panel_employees.Controls.Add(label);

                Label state = list[i].stateLabel();
                if (state.Text.Equals("WKS")) {
                    //Select current shift in table
                }
                state.Location = new Point(label.Location.X + label.Width + GAB_BETWEEN_ELEMENTS, label.Location.Y);

                panel_employees.Controls.Add(state);

                y += label.Height + 10;
            }
        }

        private void employee_state_timer_Tick(object sender, EventArgs e) {
            RefreshAll();

        }

        private void tv_empl_search_MouseDown(object sender, MouseEventArgs e) {
            if (tv_empl_search.Text == search_empl_hint) {
                tv_empl_search.Text = "";
                tv_empl_search.ForeColor = SystemColors.WindowText;
            }
        }
    }


}
