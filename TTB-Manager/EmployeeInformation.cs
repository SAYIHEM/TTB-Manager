using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TTB_Manager.Database;

namespace TTB_Manager {
    class EmployeeInformation {
        int employee_id;
        DB_Manager db_manager = new DB_Manager();
        List<Shift> shifts_of_sel_employee = new List<Shift>();

        public EmployeeInformation(int empl_id) {
            db_manager.connect();
            this.employee_id = empl_id;
            List<Shift> allshifts = db_manager.getShiftData("");
            //Create SQL!!!
            for (int i = 0; i < allshifts.Count; i++) {
                Shift shift = allshifts[i];
                for (int k = 0; k < shift.emplshift_list.Count; k++) {
                    if (shift.emplshift_list[k].employee_id == employee_id) {
                        shifts_of_sel_employee.Add(shift);
                    }
                }

            }
        }
        public double sum_workhours(DateTime start, DateTime end) {
            double sum = 0;
            for (int i = 0; i < shifts_of_sel_employee.Count; i++) {
                Shift shift = shifts_of_sel_employee[i];
                if (shift.date >= start.Ticks && shift.date <= end.Ticks) {
                    sum += shift.duration;
                    for (int k = 0; k < shift.emplshift_list.Count; k++) {
                        if (shift.emplshift_list[k].employee_id == employee_id) {
                            sum += shift.emplshift_list[k].overtime;
                        }
                    }
                }

            }
            return sum;
        }

        public Shift nextShift() {
            List<Shift> sortedList = shifts_of_sel_employee.OrderBy(o => o.date).ToList();

            for (int i = 0; i < sortedList.Count; i++) {
                if (sortedList[i].date >= DateTime.Today.Ticks) {
                    return sortedList[i];
                }
            }
           
            return new Shift();
        }

        public double sum_overtime() {
            double sum = 0;
            for (int i = 0; i < shifts_of_sel_employee.Count; i++) {
                for (int k = 0; k < shifts_of_sel_employee[i].emplshift_list.Count; k++) {
                    if (employee_id == shifts_of_sel_employee[i].emplshift_list[k].employee_id) {
                        sum += shifts_of_sel_employee[i].emplshift_list[k].overtime;
                    }
                }

            }
            return sum;

        }
        public double sum_overtime(DateTime start, DateTime end) {
            double sum = 0;
            for (int i = 0; i < shifts_of_sel_employee.Count; i++) {
                Shift shift = shifts_of_sel_employee[i];
                for (int k = 0; k < shift.emplshift_list.Count; k++) {
                    if (employee_id == shift.emplshift_list[k].employee_id
                        && shift.date >= start.Ticks && shift.date <= end.Ticks) {
                        sum += shift.emplshift_list[k].overtime;
                    }
                }

            }
            return sum;
        }
        public double wageInPeriod(DateTime start, DateTime end) {
            double sum = 0;
            for (int i = 0; i < shifts_of_sel_employee.Count; i++) {
                Shift shift = shifts_of_sel_employee[i];
                if (shift.date >= start.Ticks && shift.date <= end.Ticks) {
                    double default_wage = shift.duration * shift.Wage_perHour;
                    double extras = default_wage * ((shift.Sunday_surcharge + shift.Night_surcharge + shift.Holiday_surcharge) / 100);
                    sum += (extras + default_wage);
                }
            }
            return sum;
        }
        public int isAtWork() {
            for (int i=0;i<shifts_of_sel_employee.Count;i++) {
                if (shifts_of_sel_employee[i].starttime().Ticks<DateTime.Now.Ticks
                    && shifts_of_sel_employee[i].endtime().Ticks > DateTime.Now.Ticks) {
                    return shifts_of_sel_employee[i].id;
                }
            }
            return -1;
        }

    }
}
