using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.Database;
using TTB_Manager.Types;

namespace TTB_Manager.Forms {
    public partial class DevTools : Form {
        MainForm main;
        DB_Manager db_manager = new DB_Manager();
        public DevTools(MainForm main) {
            InitializeComponent();

            this.main = main;
        }

        private void DevTools_Load(object sender, EventArgs e) {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(main.Location.X, main.Location.Y - this.Height);
            main.Location = new Point(main.Location.X, main.Location.Y + (this.Height / 2));
            db_manager.connect();
        }

        private void button2_Click(object sender, EventArgs e) {

            string relativePath = @"DB";


            String currentPath = AppDomain.CurrentDomain.BaseDirectory;
            String absolutePath = System.IO.Path.Combine(currentPath, relativePath);
            Process.Start(@absolutePath);
        }

        private void button4_Click(object sender, EventArgs e) {
            Employee empl = new Employee();
            empl.firstname = "Vorname";
            empl.lastname = "Nachname v" + db_manager.getNextID(Database_Type.EMPLOYEE);
            empl.birthdate = 636088032000000000;
            empl.adress.street = "Straße";
            empl.adress.number = "5";
            empl.adress.plz = "00123";
            empl.adress.city = "Dresden";
            empl.adress.country = "Deutschland";
            empl.gender = 0;
            empl.mail = "mail@web.de";
            db_manager.insert(empl);
            main.FillTable(MainForm.TableMode.WEEK);

        }

        private void button5_Click(object sender, EventArgs e) {
            Workplace workplace = new Workplace();
            workplace.name = "TestHotel v" + db_manager.getNextID(Database_Type.WORKPLACE);
            workplace.tax = 19;
            workplace.ust_id = "12STEU";
            workplace.extra = "Extrastraße";
            workplace.gender_of_contact_person = 0;
            workplace.contact_person = "Chef";
            workplace.contact_mail = "info@hotel.de";
            workplace.adress.street = "Straße";
            workplace.adress.number = "4";
            workplace.adress.plz = "00123";
            workplace.adress.city = "Dresden";
            workplace.adress.country = "Deutschland";
            workplace.accounting_adress = workplace.adress;
            db_manager.insert(workplace);
        }

        private void button6_Click(object sender, EventArgs e) {
            Shift_Template shift_template = new Shift_Template();
            shift_template.id_workplace = db_manager.getNextID(Database_Type.WORKPLACE) - 1;
            shift_template.name = "Testvorlage v" + db_manager.getNextID(Database_Type.SHIFT_TEMPLATE);
            shift_template.startTime = "20:15";
            shift_template.duration = 8;
            shift_template.Wage_perHour = 10;
            shift_template.Night_surcharge = 10;
            shift_template.Holiday_surcharge = 10;
            shift_template.Sunday_surcharge = 10;
            shift_template.break_time = 0.5f;
            db_manager.insert(shift_template);
        }

        private void DevTools_Deactivate(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                main.WindowState = FormWindowState.Minimized;
            }
        }

        private void button7_Click(object sender, EventArgs e) {
            try {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"D:\64-bit\DB Browser for SQLite\DB Browser for SQLite.exe";
                startInfo.Arguments = @"E:\Programmieren\TTB\TTB-Manager\bin\Debug\DB\Database_TTB-Manager.db";
                Process.Start(startInfo);
            } catch { }


        }

        private void DevTools_FormClosing(object sender, FormClosingEventArgs e) {
            main.Location = new Point(main.Location.X, main.Location.Y-(this.Height/2));
        }
    }
}
