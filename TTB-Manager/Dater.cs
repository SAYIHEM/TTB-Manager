using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.Types;

namespace TTB_Manager {
    class Dater {
        public Dater() {

        }
        public long getWeekstart() {
            int monday;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) {
                monday = (int)DateTime.Now.DayOfWeek - 6;
            }
            else {
                monday = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
            }

            DateTime week_start_date = DateTime.Now.AddDays(monday);

            //return GetStringFromDate(week_start_date);
            Console.WriteLine("Monday: " + week_start_date.Ticks);

            DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Monday);

            return dt.Ticks;

        }
        public long getWeekend() {
            int sunday;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) {
                sunday = (int)DateTime.Now.DayOfWeek;
            }
            else {
                sunday = DayOfWeek.Sunday - DateTime.Now.DayOfWeek + 7;
            }

            DateTime week_end_date = DateTime.Now.AddDays(sunday);
            //return GetStringFromDate(week_end_date);
            return week_end_date.Ticks;
        }
        public long getMonthstart() {

            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, 1);
            return startDate.Ticks;
        }
        public long getMonthend() {
            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            return endDate.Ticks;
        }

        public String getTickFromDate(DateTime datetime) {

            return datetime.Ticks + "";
        }

        public String getStringFromTimestamp(long timestamp) {

            try {

                if (timestamp == 0) {
                    throw new Exception("Fehler beim konvertieren des Timestamp zu einem Datum, Timestamp war 0 oder NULL!");
                } 

            } catch (Exception e) {

                MessageBox.Show(e.Message);
                return "";
            }

            DateTime datetime = new DateTime(timestamp);

            return datetime.ToString("dd.MM.yyyy");
        }

    }
}
