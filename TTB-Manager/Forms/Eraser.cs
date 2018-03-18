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

namespace TTB_Manager.Types {
    public partial class Eraser : Form {
        DB_Manager db_manager = new DB_Manager();
        int delID;
        enum ObjectType { EMPLOYEE, WORKPLACE, SHIFT }
        ObjectType objecttype;
        List<int> error_list = new List<int>();
        enum Errors { OVERTIME, SHIFT }

        public Eraser() {
            StartPosition = FormStartPosition.CenterScreen;
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
        }

        private void Eraser_Load(object sender, EventArgs e) {
            errorlist_box.Visible = false;

        }
        public bool start<ObjectType>(int id) {
            db_manager.connect();
            var message = "Löschen?";
            var title = "";
            var result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            switch (result) {
                case DialogResult.Yes:
                    if (checkIfNeeded<ObjectType>(id)) {
                        this.ShowDialog();
                    }
                    else {
                        db_manager.deleteItem<ObjectType>(id);
                        this.Close();
                        return true;
                    }
                    break;

                case DialogResult.No:
                    return false;
                default:
                    break;
            }
            return false;
        }

        public bool start<ObjectType>(DataGridView table) {
            if (table.SelectedRows.Count == 1) {
                return (start<ObjectType>(Int32.Parse(table.SelectedRows[0].Cells["ID"].Value.ToString())));
            }
            List<int> ID_list = new List<int>();
            for (int i = 0; i < table.SelectedRows.Count; i++) {
                int id = Int32.Parse(table.SelectedRows[i].Cells["ID"].Value.ToString());
                ID_list.Add(id);
            }

            var message = "Alle Löschen?";
            var title = "";
            var result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            switch (result) {
                case DialogResult.Yes:
                    bool deleted = false;
                    for (int i = 0; i < ID_list.Count; i++) {
                        if (checkIfNeeded<ObjectType>(ID_list[i])) {
                            this.ShowDialog();
                        }
                        else {
                            db_manager.deleteItem<ObjectType>(ID_list[i]);
                            this.Close();
                            deleted = true;
                        }
                    }
                    return deleted;
                case DialogResult.No:
                    this.Close();
                    return false;
                default:
                    break;
            }
            return false;
        }
        public bool checkIfNeeded<ObjectType>(int id) {
            delID = id;
            List<Shift> shift_list = db_manager.getShiftData("");

            if (typeof(ObjectType) == typeof(Employee)) {
                objecttype = Eraser.ObjectType.EMPLOYEE;
                for (int i = 0; i < shift_list.Count; i++) {
                    for (int j = 0; j < shift_list[i].emplshift_list.Count; j++) {
                        if (shift_list[i].emplshift_list[j].employee_id == id) {
                            Employee empl = db_manager.getItem<Employee>(id);
                            errorlist_box.Items.Add(empl.firstname + " " + empl.lastname + " in Schicht " + shift_list[i].id + " " + shift_list[i].name);
                            error_list.Add(shift_list[i].id);
                            prepareDialog(Errors.SHIFT);
                            return true;
                        }
                    }
                }
                return false;
            }

            else if (typeof(ObjectType) == typeof(Workplace)) {
                objecttype = Eraser.ObjectType.WORKPLACE;
                for (int i = 0; i < shift_list.Count; i++) {
                    if (shift_list[i].id_workplace == id) {
                        Workplace wpl = db_manager.getItem<Workplace>(id);
                        errorlist_box.Items.Add(wpl.name + " aus Schicht " + shift_list[i].id + " " + shift_list[i].name);
                        error_list.Add(shift_list[i].id);
                        prepareDialog(Errors.SHIFT);
                        return true;

                    }
                }
            }
            else if (typeof(ObjectType) == typeof(Shift)) {
                objecttype = Eraser.ObjectType.SHIFT;
                Shift shift = db_manager.getItem<Shift>(id);
                for (int i = 0; i < shift.emplshift_list.Count; i++) {
                    if (shift.emplshift_list[i].overtime != 0) {
                        Employee empl = db_manager.getItem<Employee>(shift.emplshift_list[i].employee_id);
                        errorlist_box.Items.Add(shift.emplshift_list[i].overtime + "€ von " + empl.firstname + " " + empl.lastname);
                        error_list.Add(shift_list[i].id);
                        prepareDialog(Errors.OVERTIME);
                        return true;
                    }
                }
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (rB_delElement.Checked) {
                switch (objecttype) {
                    case ObjectType.EMPLOYEE:
                        db_manager.deleteItem<Employee>(delID);
                        break;
                    case ObjectType.WORKPLACE:
                        db_manager.deleteItem<Workplace>(delID);
                        break;
                }

            }
            else if (rB_delAll.Checked) {
                switch (objecttype) {
                    case ObjectType.EMPLOYEE:
                        db_manager.deleteItem<Employee>(delID);
                        for (int i = 0; i < error_list.Count; i++) {
                            db_manager.deleteItem<Shift>(error_list[i]);
                        }
                        break;

                    case ObjectType.WORKPLACE:
                        db_manager.deleteItem<Workplace>(delID);
                        for (int i = 0; i < error_list.Count; i++) {
                            db_manager.deleteItem<Shift>(error_list[i]);
                        }
                        break;
                }

            }
            if (objecttype == ObjectType.SHIFT) {
                db_manager.deleteItem<Shift>(delID);
            }

            error_list = new List<int>();
            errorlist_box.Clear();
            this.Close();
        }
        private bool overtimeDetected() {
            var message = "Alle Löschen?";
            var title = "";
            var result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            switch (result) {
                case DialogResult.Yes:
                case DialogResult.No:
                default:
                    break;
            }
            return false;
        }
        private void prepareDialog(Errors error) {
            switch (error) {
                case Errors.SHIFT:
                    this.Height = 208;
                    String shiftError = "Das zu löschende Element wird noch benötigt, \n"
                        + "da mindestens eine Schicht diesen Eintrag beinhaltet. Wie soll fortgefahren werden?";
                    error_title.Text = shiftError;
                    rB_delAll.Visible = true;
                    rB_delElement.Visible = true;
                    btn_ok.Text = "OK";
                    break;
                case Errors.OVERTIME:
                    this.Height = 208;
                    String overtimeError = "Die Schicht enthält Überstunden, \n"
                    + "die damit ebenfalls gelöscht werden würden. Trotzdem löschen?";
                    error_title.Text = overtimeError;
                    rB_delAll.Visible = false;
                    rB_delElement.Visible = false;
                    btn_ok.Enabled = true;
                    btn_ok.Text = "Ja";
                    break;
                default:
                    break;
            }


        }



        private void button2_Click(object sender, EventArgs e) {
            error_list = new List<int>();
            errorlist_box.Clear();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) {
            switch (errorlist_box.Visible) {
                case true:
                    errorlist_box.Visible = false;
                    this.Height = 208;
                    btn_showconflicts.Text = "Konflikte anzeigen";
                    break;
                case false:
                    //If its not visible
                    this.Height = 308;
                    errorlist_box.Visible = true;
                    btn_showconflicts.Text = "Konflikte ausblenden";
                    break;
            }

        }

        private void rB_delElement_CheckedChanged(object sender, EventArgs e) {
            if (rB_delElement.Checked)
                btn_ok.Enabled = true;
        }

        private void rB_delAll_CheckedChanged(object sender, EventArgs e) {
            if (rB_delAll.Checked)
                btn_ok.Enabled = true;
        }
    }
}
