using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.Database;
using TTB_Manager.Types;

namespace TTB_Manager {
    class Shift : Shift_Template{

        public long date = -1;
        public String comment = "";
        public List<EmployeeOvertime> emplshift_list = new List<EmployeeOvertime>();

        public Shift() {

        }

        public Shift(String name, int id_workplace, long date, String startTime, double duration) {

            this.name = name;
            this.id_workplace = id_workplace;
            this.date = date;
            this.startTime = startTime;
            this.duration = duration;
        }
        public new bool check() {
            if (id_workplace == -1 || startTime.Equals("") || duration <= 0 || Wage_perHour <= 0 || date <=0 ) {

                MessageBox.Show("Fehler: Mindestens ein Feld ist nicht korrekt ausgefüllt oder leer! Erlaubt sind keine negativen Zahlen");
                return false;
            }
            return true;
        }
        public DateTime starttime() {
            DateTime hours = DateTime.ParseExact(startTime, "HH:mm",
                                            CultureInfo.InvariantCulture);
            DateTime dt = new DateTime(date).AddHours(hours.Hour).AddMinutes(hours.Minute);


            return dt;
        }
        public DateTime endtime() {
            return starttime().AddHours(duration);
        }

    }
}
