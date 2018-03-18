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
    public partial class EmployeeDropper : Form {
        Shift shift;
        DB_Manager db_manager = new DB_Manager();
        List<int> Unused_employee_list = new List<int>();
        bool SYSTEM_IS_CHANGING_INDEXES = false;
        int counter = 0;
        List<ComboBox> combobox_list = new List<ComboBox>();
        List<Label> cross_list = new List<Label>();
        int sizeOfAllEmployees;
        List<int> selected_employees = new List<int>();
        ComboBox last_combobox;

        private void EmployeeDropper_Load(object sender, EventArgs e) {

        }

        public EmployeeDropper(int shift_id) {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            db_manager.connect();

            //Initialize Shift
            shift = db_manager.getItem<Shift>(shift_id);

            //Get unused employeeShift list
            for (int i = 0; i < db_manager.getEmployeeData("").Count; i++) {
                Unused_employee_list.Add(db_manager.getEmployeeData("")[i].id);
            }

            //Get all employees
            sizeOfAllEmployees = db_manager.getEmployeeData("").Count;

            //Restore origin stuff
            loadOriginEntries();


        }
        private void loadOriginEntries() {

            for (int i = 0; i < shift.emplshift_list.Count; i++) {
                addEmployee(shift.emplshift_list[i].employee_id, selected_employees.Count);
            }

            for (int i = 0; i < shift.emplshift_list.Count; i++) {
                ComboBox combobox = addCombobox();
                fillComboBox(combobox, shift.emplshift_list[i].employee_id);
                //seleted_employees.Add(shift.emplshift_list[i].employee_id);
            }
            if (selected_employees.Count != sizeOfAllEmployees) { //only if not all are chosen
                fillComboBox(addCombobox(), 0); //the last combo to add employees
            }
            else {
                addCross();
            }


        }
        private void addCross() {
            try {
                Label new_cross = new Label();
                new_cross.Text = "x";
                new_cross.Name = last_combobox.Name;
                new_cross.Font = new Font("Microsoft Sans Serif", 10);
                new_cross.Location = new Point(last_combobox.Location.X + last_combobox.Width + 5, last_combobox.Location.Y);
                new_cross.MouseClick += new MouseEventHandler(this.label_MouseClickListener);
                new_cross.Cursor = Cursors.No;
                cross_list.Add(new_cross);
                Controls.Add(new_cross);
            } catch { }
        }

        private ComboBox addCombobox() {
            //Generate Cross for previous cb
            addCross();

            //Add new cb
            ComboBox new_combobox = new ComboBox();
            new_combobox.Name = "" + counter;
            new_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            new_combobox.TabIndex = counter + 1;
            try {
                new_combobox.Location = new Point(last_combobox.Location.X, last_combobox.Location.Y + last_combobox.Height * 2);
            } catch {
                //If its the first combobox there is no last_combo
                new_combobox.Location = new Point(54, 25);
            }
            new_combobox.SelectedIndexChanged += new EventHandler(combobox_SelectedIndexChanged);
            Controls.Add(new_combobox);

            combobox_list.Add(new_combobox);

            last_combobox = new_combobox;



            //Resize Form
            Size = new Size(252, Size.Height + last_combobox.Height * 2);


            counter++;
            return new_combobox;
        }

        private void setSelectedValue(int id, ComboBox cb) {
            SYSTEM_IS_CHANGING_INDEXES = true;
            for (int i = 0; i < cb.Items.Count; i++) {
                if (id == (int)((ComboBoxItem)cb.Items[i]).Value) {
                    cb.SelectedIndex = i;
                    return;
                }
            }
            SYSTEM_IS_CHANGING_INDEXES = true;
        }
        private void fillComboBox(ComboBox combobox, int sel_id) {
            SYSTEM_IS_CHANGING_INDEXES = true;
            combobox.Items.Clear();
            combobox.DisplayMember = "Text";
            Employee employee;
            String firstname;
            String lastname;
            ComboBoxItem ci;

            if (sel_id != 0) {
                //Add selected employee
                employee = db_manager.getItem<Employee>(sel_id);
                ci = new ComboBoxItem();
                firstname = employee.firstname;
                lastname = employee.lastname;
                ci.Text = firstname + " " + lastname;
                ci.Value = employee.id;
                combobox.Items.Add(ci);
            }
            //Entry "Keine"
            else {
                //Only the last combobox has this entry
                ComboBoxItem noci = new ComboBoxItem();
                noci.Text = "Weitere wählen";
                noci.Value = -1;
                combobox.Items.Add(noci);
            }


            //Add the others from unused list
            for (int i = 0; i < Unused_employee_list.Count; i++) {
                ci = new ComboBoxItem();
                employee = db_manager.getItem<Employee>(Unused_employee_list[i]);
                firstname = employee.firstname;
                lastname = employee.lastname;
                ci.Text = firstname + " " + lastname;
                ci.Value = Unused_employee_list[i];
                combobox.Items.Add(ci);
            }
            combobox.SelectedIndex = 0;
            SYSTEM_IS_CHANGING_INDEXES = false;





        }
        /*
        private Employee getFromAllEmployees(int id) {
            for (int i = 0; i < all_employees.Count; i++) {
                if (all_employees[i].id == id) {
                    return all_employees[i];
                }
            }
            return new Employee();
        }
        */
        

        private void label_MouseClickListener(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Label cross = (Label)sender;
                for (int i = 0; i < combobox_list.Count; i++) {
                    if (combobox_list[i].Name.Equals(cross.Name)) {
                        int id = selected_employees[i];
                        if (checkForOvertime(db_manager.getItem<Employee>(id))) {
                            deleteEntry(i);
                        }
                        break; //to prevent deleting other controls after renaming

                    }
                }

            }
        }
        private void deleteEntry(int index) {
            ComboBox combobox = combobox_list[index];
            int name = Int32.Parse(combobox.Name);

            int del_id = ((ComboBoxItem)combobox.SelectedItem).Value;

            //Delete Cross
            for (int i = 0; i < cross_list.Count; i++) {
                if (cross_list[i].Name.Equals(name + "")) {
                    Controls.Remove(cross_list[i]);
                    cross_list.RemoveAt(i);
                }
                else if (cross_list[i].Name.Equals(last_combobox.Name)) {
                    //if there was a cross next to the last cb because all employees were selected
                    Controls.Remove(cross_list[i]);
                    cross_list.RemoveAt(i);
                }
            }



            //Remove employee
            removeEmployee(del_id);

            if (!combobox.Name.Equals(last_combobox.Name)) {
                //Delete ComboBox
                Controls.Remove(combobox);
                combobox_list.RemoveAt(index);

                //Change positions of other comboboxes and crosses and rename them
                counter = 0;
                for (int i = 0; i < combobox_list.Count; i++) {
                    combobox_list[i].Name = counter + "";
                    combobox_list[i].TabIndex = counter + 1;
                    try {
                        combobox_list[i].Location = new Point(combobox_list[i-1].Location.X, combobox_list[i - 1].Location.Y + combobox_list[i - 1].Height * 2);
                    } catch {
                        //If its the first combobox
                        combobox_list[i].Location = new Point(54, 25);
                    }
                    try {
                        cross_list[i].Name = counter + "";
                        cross_list[i].Location = new Point(combobox_list[i].Location.X + combobox_list[i].Width + 5, combobox_list[i].Location.Y);
                    } catch {
                    } //if its the last cross there is no cross after
                    counter++;

                }


                //Change form size
                Size = new Size(252, Size.Height - combobox_list[0].Height * 2);

            }
           

            //Refill others
            refillAllComboBoxes();


            //Save all
            saveShift();


        }
        private Employee getOverridedEmployee() {

            
            for (int k = 0; k < selected_employees.Count; k++) {
                bool gefunden = false;

                for (int i = 0; i < combobox_list.Count; i++) {
                    if (((ComboBoxItem)combobox_list[i].SelectedItem).Value == selected_employees[k]) {
                        gefunden = true;
                    }
                }

                if (gefunden == false) {
                    return db_manager.getItem<Employee>(selected_employees[k]);
                }
            }
            return new Employee();
        }
        private void combobox_SelectedIndexChanged(object sender, EventArgs e) {
            if (!SYSTEM_IS_CHANGING_INDEXES) {
                ComboBox cur_combobox = ((ComboBox)sender);
                int sel_id = ((ComboBoxItem)cur_combobox.SelectedItem).Value;


                if (sel_id != -1) { //-1 is only in last cb and has no meaning


                    if (!checkForOvertime(getOverridedEmployee())) {
                        resetComboBox(cur_combobox);
                        return;
                    }
                    Employee empl = db_manager.getItem<Employee>(sel_id);

                    if (!checkHealth(empl)) {
                        resetComboBox(cur_combobox);
                        return;
                    }

                    
                    if (!checkForOtherShifts(empl)) {
                        resetComboBox(cur_combobox);
                        return;
                    }



                    //Create new combobox if last combo hast changed
                    if (cur_combobox.Name.Equals(last_combobox.Name)) {
                        addEmployee(sel_id, selected_employees.Count);
                        if (Unused_employee_list.Count > 0) {
                            ComboBox new_cb = addCombobox();
                            fillComboBox(new_cb, 0);
                        }
                        refillAllComboBoxes();
                    }
                    //If index of an other cb changed
                    else if (!cur_combobox.Name.Equals(last_combobox.Name)) {
                        switchEmployees(sel_id);
                        refillAllComboBoxes();
                    }

                }

                saveShift();

            }


        }
        private void refillAllComboBoxes() {
            for (int i = 0; i < combobox_list.Count - 1; i++) {
                fillComboBox(combobox_list[i], selected_employees[i]);
            }
            if (Unused_employee_list.Count > 0) {
                fillComboBox(last_combobox, 0);
            }
            else {
                //Case: User give all employees to the shift and there is no more new cb
                fillComboBox(last_combobox, selected_employees[selected_employees.Count - 1]);
                addCross();
            }

        }

        private void addEmployee(int id, int index) {
            //delete entry from unusedList
            for (int i = 0; i < Unused_employee_list.Count; i++) {
                if (Unused_employee_list[i] == id) {
                    Unused_employee_list.RemoveAt(i);
                    break;
                }
            }

            //add to employee_list
            if (index == selected_employees.Count) {
                selected_employees.Add(id);
            }
            else if (index < selected_employees.Count) {
                selected_employees[index] = id;
            }


        }
        private void removeEmployee(int id) {
            //delete entry from sel_employee_list
            for (int i = 0; i < selected_employees.Count; i++) {
                if (selected_employees[i] == id) {
                    selected_employees.RemoveAt(i);
                    break;
                }
            }
            Unused_employee_list.Add(id);

        }

        private void switchEmployees(int id) {

            for (int i = 0; i < selected_employees.Count; i++) {
                //Override index if selected v
                if (!checkIfEmployeeIsInList(selected_employees[i])) {
                    //add old employee to the index
                    int old_empl_id = selected_employees[i];
                    addEmployee(id, i);

                    //add other to unused
                    Unused_employee_list.Add(old_empl_id);
                    break;
                }
            }
        }


        private bool checkIfEmployeeIsInList(int id) {
            for (int i = 0; i < combobox_list.Count; i++) {
                int combobox_id = ((ComboBoxItem)combobox_list[i].SelectedItem).Value;
                if (id == combobox_id) {
                    return true;
                }
            }
            return false;
        }




        private void resetComboBox(ComboBox cb) {
            SYSTEM_IS_CHANGING_INDEXES = true;
            int index = Int32.Parse(cb.Name);
            if (shift.emplshift_list.Count > index) {
                setSelectedValue(selected_employees[index], cb);
            }
            else {
                cb.SelectedIndex = 0;
            }
            SYSTEM_IS_CHANGING_INDEXES = false;

        }
        private bool checkForOvertime(Employee empl) {
            if (shift.emplshift_list.Count > 0) {
                bool gefunden = false;
                int index = 0;

                for (int i = 0; i < shift.emplshift_list.Count; i++) {
                    if (shift.emplshift_list[i].employee_id == empl.id && shift.emplshift_list[i].overtime != 0) {
                        index = i;
                        gefunden = true;
                        break;
                    }
                }

                if (gefunden) {
                    String empl_name = empl.firstname + " " + empl.lastname;
                    var message = "Alle Überstunden (" + shift.emplshift_list[index].overtime + ") von " + empl_name + " gehen in dieser Schicht verloren. Wollen Sie fortfahren?";
                    var title = "Personal zugewiesen";
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
                            break;
                    }
                }
                return true;

            }
            else {
                return true;
            }
        }
        private bool checkHealth(Employee employee) {
            if (employee.state == Employee.State.ILL) {
                var message = "Der Mitarbeiter " + employee.firstname + " " + employee.lastname + " ist krank. Wollen Sie ihn trotzdem zuteilen?";
                var title = "Personal krank";
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
                        return true;
                }
            }
            else {
                return true;
            }
        }

        private bool checkForOtherShifts(Employee employee) {
            String sqlcommand = "WHERE";
            List<Shift> all_shifts = db_manager.getShiftData("");
            bool gefunden = false;
            int found_shift_id = 0;
            for (int i = 0; i < all_shifts.Count; i++) {
                //Check if cur shift has a empl list
                if (all_shifts[i].emplshift_list.Count > 0) {
                    if (!((shift.starttime().Ticks > all_shifts[i].endtime().Ticks) || (shift.endtime().Ticks < all_shifts[i].starttime().Ticks))) {
                        for (int k = 0; k < all_shifts[i].emplshift_list.Count; k++) {
                            if (all_shifts[i].emplshift_list[k].employee_id == employee.id) {
                                gefunden = true;
                                found_shift_id = all_shifts[i].id;
                                break;
                            }

                        }

                       
                    }
                }
            }

            if (gefunden) {
                var message = "Der Mitarbeiter " + employee.firstname + " " + employee.lastname + " wurde zu dieser Zeit bereits einer anderen Schicht (ID: " + found_shift_id +") zugeteilt. Wollen Sie fortfahren?";
                var title = "Personal zugewiesen";
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
                        return true;
                }
            }
            else {
                return true;
            }

        }



        private void saveShift() {
            //Reset original list to new list
            shift.emplshift_list = new List<EmployeeOvertime>();
            for (int i = 0; i < selected_employees.Count; i++) {
                EmployeeOvertime eo = new EmployeeOvertime();
                eo.employee_id = selected_employees[i];
                eo.overtime = 0;
                shift.emplshift_list.Add(eo);
            }
            db_manager.update(shift);

        }


        private void employeedropper_Closed(object sender, FormClosedEventArgs e) {
            //notify(e);
        }
        private void notify(FormClosedEventArgs e) {
            if (new ComboBox().SelectedIndex != 0) {
                if (e.CloseReason == CloseReason.UserClosing) {
                    var message = "Personal jetzt benachrichtigen?";
                    var title = "Personal zugewiesen";
                    var result = MessageBox.Show(
                        message,
                        title,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    switch (result) {
                        case DialogResult.Yes:
                            new EmployeeNotifier().notify(shift);
                            break;
                        case DialogResult.No:
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        private void EmployeeDropper_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                this.Close();
            }
        }
    }
}
