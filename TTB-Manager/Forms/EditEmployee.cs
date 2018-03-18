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
    public partial class EditEmployee : Form {
        enum Mode { UPDATE,NEW}
        Mode mode = Mode.NEW;
        int id;
        DB_Manager db_manager = new DB_Manager();
        //Wenn geupdated wird (Personal wird aus Liste angeklickt), wird Form mit Parametern gecallt und Textfelder gefüllt und mode = UPDATE
        public EditEmployee(int id) {
            InitializeComponent();
            InitializeComboBox();
            StartPosition = FormStartPosition.CenterScreen;

            this.id = id;
            mode = Mode.UPDATE;
            btn_add.Text = "Ändern";
            
            Employee employee = db_manager.getItem<Employee>(id);
            tv_firstname.Text = employee.firstname + "";
            tv_lastname.Text = employee.lastname + "";
            tv_street.Text = employee.adress.street + "";
            tv_nr.Text = employee.adress.number + "";
            tv_plz.Text = employee.adress.plz + "";
            tv_city.Text = employee.adress.city + "";
            tv_country.Text = employee.adress.country + "";
            tv_mail.Text = employee.mail + "";
            cB_title.SelectedIndex = employee.gender; 
            dtp_birth.Value = new DateTime(employee.birthdate);

            //State Label
            Label l = employee.stateLabel();
            l.Location = new Point(567, 33);
            Controls.Add(l);

        }
        //Wenn ein neuer Kontakt angelegt wird, wird Form ohne Parameter gecallt und mode = NEW
        public EditEmployee() {
            InitializeComponent();
            InitializeComboBox();
            StartPosition = FormStartPosition.CenterScreen;
            mode = Mode.NEW;
        }
        private void InitializeComboBox() {
            ComboBoxItem ci = new ComboBoxItem();
            ci.Text = "Herr";
            ci.Value = 0;
            cB_title.Items.Add(ci);
            ci = new ComboBoxItem();
            ci.Text = "Frau";
            ci.Value = 1;
            cB_title.Items.Add(ci);
            cB_title.DisplayMember = "Text";
            cB_title.SelectedIndex = 0;
        }


        private void AddPersonal_Load(object sender, EventArgs e) {
            db_manager.connect();

           if (mode==Mode.NEW) {
                id = db_manager.getNextID(Database_Type.EMPLOYEE);
            }
            label_id.Text = "ID: " + id;

        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            //Save Employee personal data
            Employee employee = new Employee();
            employee.firstname = tv_firstname.Text;
            employee.lastname = tv_lastname.Text;
            employee.adress.street = tv_street.Text;
            employee.adress.number = tv_nr.Text;
            employee.adress.plz = tv_plz.Text;
            employee.adress.city = tv_city.Text;
            employee.adress.country = tv_country.Text;
            employee.birthdate = dtp_birth.Value.Date.Ticks;
            employee.mail = tv_mail.Text;
            employee.gender = ((ComboBoxItem)cB_title.SelectedItem).Value;

            if (mode == Mode.NEW) {
                DB_Login db_login = new DB_Login();
                Login login = new Login();
                login.employee_id = db_manager.getNextID(Database_Type.EMPLOYEE);
                login.username = "username";
                login.password = "pass";
                db_login.insert(login);
                if (db_manager.insert(employee)) {
                    this.Close();
                }
            }
            else {
                employee.id = id;
                if (db_manager.update(employee)) {
                    this.Close();
                }
            }

        }


        private void PersonalManager_Load(object sender, EventArgs e) {

        }
    }
}
