using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTB_Manager.Types;
using TTB_Manager.Database;

namespace TTB_Manager {
    public class ListManager {
        private List<Shift> all_Shifts = new List<Shift>();
        private List<Employee> all_Employees = new List<Employee>();
        private List<Workplace> all_Worplaces = new List<Workplace>();

        DB_Manager db_manager = new DB_Manager();
        public ListManager() {
            db_manager.connect();
            if (all_Shifts.Count==0) {
                UpdateShiftList();
            }
            if (all_Worplaces.Count == 0) {
                UpdateWorkplaceList();
            }
            if (all_Employees.Count == 0) {
                UpdateEmployeeList();
            }
        }
        public void UpdateShiftList() {
            all_Shifts = db_manager.getShiftData("");
        }
        public void UpdateEmployeeList() {
            all_Employees = db_manager.getEmployeeData("");

        }
        public void UpdateWorkplaceList() {
            all_Worplaces = db_manager.getWorkplaceData("");
        }
    }
}
