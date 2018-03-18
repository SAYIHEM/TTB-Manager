using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TTB_Manager {
    class Shift_Template {
        public String name = "";

        public String startTime;
        public double duration = -1;

        public int id_workplace = -1;
        public int id = -1;

        public double Wage_perHour = -1;
        public double Holiday_surcharge = 0;
        public double Night_surcharge = 0;
        public double Sunday_surcharge = 0;
        public double break_time = 0;

        public Shift_Template() {

        }
        public bool check() {
            if (id_workplace == -1 || startTime.Equals("") || duration <= 0 || Wage_perHour <= 0 || name.Equals("") ) {

                MessageBox.Show("Fehler: Mindestens ein Feld ist nicht korrekt ausgefüllt oder leer! Erlaubt sind keine negativen Zahlen");
                return false;
            }
            return true;
        }

    }
}
