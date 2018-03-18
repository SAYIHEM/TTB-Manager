using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using TTB_Manager.Types;
using System.IO;

namespace TTB_Manager.Database {

    /// <summary>
    /// Manager to connect with Database, insert, update, delete and get Items.
    /// </summary>
    class DB_Manager {

        /// <summary>
        /// String for connecting with Database.
        /// </summary>
        private String connectionString;

        /// <summary>
        /// Database Connection.
        /// </summary>
        private SQLiteConnection connection;

        private int INSERT = 1;
        private int UPDATE = 2;

        public DB_Manager() {

            // Set up Connection String
            string relativePath = @"DB\Database_TTB-Manager.db";
            string currentPath;
            string absolutePath;

            currentPath = AppDomain.CurrentDomain.BaseDirectory;
            absolutePath = System.IO.Path.Combine(currentPath, relativePath);

            connectionString = "Data Source = " + absolutePath + "; Version = 3";

        }


        /// <summary>
        /// Etablishe connection with Database.
        /// </summary>
        /// <returns></returns>
        public bool connect() {

            using (connection = new SQLiteConnection(connectionString)) {

                try {

                    connection.Open();

                } catch (Exception e) {

                    MessageBox.Show("Error connecting to Database!\n" + e.Message);
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Inserting Item to Database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool insert(Object data) {

            if (data is Employee) {

                Employee employee = (Employee)data;

                // Check if any Data is empty

                if (employee.check()) {
                    return insert_update_Employee(INSERT, (Employee)data);
                }

                
            }

            else if (data is Workplace) {

                Workplace workplace = (Workplace)data;

                // Check if any Data is empty
                if (workplace.check()) {
                    return insert_update_Workplace(INSERT, (Workplace)data);
                }

                
            }

            else if (data is Shift) {

                Shift shift = (Shift)data;

                // Check if any Data is empty
                if (shift.check()) {
                    return insert_update_Shift(INSERT, (Shift)data);
                }
         
                
            }

            else if (data is Shift_Template) {

                Shift_Template shiftTemplate = (Shift_Template)data;

                // Check if any Data is empty
                if (shiftTemplate.check()) {
                    return insert_update_ShiftTemplate(INSERT, (Shift_Template)data);
                }

              
            }



            // If not one of the given Classes then no Insert possible
            return false;
        }

        /// <summary>
        /// Updating Item in Database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool update(Object data) {

            if (data is Employee) {

                Employee employee = (Employee)data;

                // Check if any Data is empty
                if (employee.id == -1 || employee.firstname.Equals("") || employee.lastname.Equals("") || employee.birthdate.Equals("") || !employee.adress.Check()) {

                    MessageBox.Show("Fehler: Einige Felder sind leer!");
                    return false;
                }

                return insert_update_Employee(UPDATE, (Employee)data);
            }

            else if (data is Workplace) {

                Workplace workplace = (Workplace)data;

                // Check if any Data is empty
                if (workplace.id == -1 || workplace.name.Equals("") || !workplace.adress.Check()) {

                    MessageBox.Show("Fehler: Einige Felder sind leer!");
                    return false;
                }

                return insert_update_Workplace(UPDATE, (Workplace)data);
            }
            else if (data is Shift) {

                Shift shift = (Shift)data;

                // Check if any Data is empty
                if (shift.id == -1 || shift.id_workplace == -1 || shift.date.Equals("") || shift.startTime.Equals("") ||
                    shift.duration == -1 || shift.Wage_perHour == -1) {

                    MessageBox.Show("Fehler: Einige Felder sind leer!");
                    return false;
                }

                return insert_update_Shift(UPDATE, (Shift)data);
            }


            else if (data is Shift_Template) {

                Shift_Template shiftTemplate = (Shift_Template)data;

                // Check if any Data is empty
                if (shiftTemplate.id == -1 || shiftTemplate.name.Equals("") || shiftTemplate.id_workplace == -1 || shiftTemplate.startTime.Equals("") ||
                    shiftTemplate.duration == -1 || shiftTemplate.Wage_perHour == -1) {

                    MessageBox.Show("Fehler: Einige Felder sind leer!");
                    return false;
                }


                return insert_update_ShiftTemplate(UPDATE, (Shift_Template)data);
            }




            // If not one of the given Classes then no Update possible
            return false;
        }

        /// <summary>
        /// Deleting Item from Database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool deleteItem<ObjectType>(int ID) {

            String sqlCommand = "";

            if (typeof(ObjectType) == typeof(Employee)) {

                sqlCommand = @"DELETE FROM Employee WHERE ID = " + ID.ToString();
            }

            if (typeof(ObjectType) == typeof(Workplace)) {

                sqlCommand = @"DELETE FROM Workplace WHERE ID = " + ID.ToString();
            }

            if (typeof(ObjectType) == typeof(Shift)) {

                sqlCommand = @"DELETE FROM Shift WHERE ID = " + ID.ToString();
            }

            if (typeof(ObjectType) == typeof(Shift_Template)) {

                sqlCommand = @"DELETE FROM ShiftTemplate WHERE ID = " + ID.ToString();
            }

            // Check if Valid ObjectType was given
            if (sqlCommand.Equals("")) {

                MessageBox.Show("Falscher ObjectType eingegeben!");

                // If no Valid ObjectType return false
                return false;
            }

            using (connection = new SQLiteConnection(connectionString)) {

                try {

                    // If deleting Shift -> Delete Employee Ids in Shift_Employe Table
                    if (typeof(ObjectType) == typeof(Shift)) {

                        String sql = @"DELETE FROM Shift_Employee WHERE ID_Shift = " + ID.ToString();

                        // If Database is not opedned -> open
                        if (connection.State != ConnectionState.Open) {
                            connection.Open();
                        }

                        SQLiteCommand command = new SQLiteCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }

                } catch (Exception e) {

                    MessageBox.Show("Fehler beim Löschen der Personal IDs aus der Schicht-Personaltabelle!\n" + e.Message);
                    return false;
                }

                try {

                    // If Database is not opedned -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    SQLiteCommand command = new SQLiteCommand(sqlCommand, connection);
                    command.ExecuteNonQuery();

                    return true;

                } catch (Exception e) {

                    if (typeof(ObjectType) == typeof(Employee)) {

                        MessageBox.Show("Fehler beim Löschen des Mitarbeiters mit ID:" + ID.ToString() + "!\n" + e.Message);
                        return false;
                    }
                    if (typeof(ObjectType) == typeof(Workplace)) {

                        MessageBox.Show("Fehler beim Löschen des Arbeitsplatzes mit ID:" + ID.ToString() + "!\n" + e.Message);
                        return false;
                    }
                    if (typeof(ObjectType) == typeof(Shift)) {

                        MessageBox.Show("Fehler beim Löschen der Schicht mit ID:" + ID.ToString() + "!\n" + e.Message);
                        return false;
                    }
                    if (typeof(ObjectType) == typeof(Shift_Template)) {

                        MessageBox.Show("Fehler beim Löschen des Schicht-Templates mit ID:" + ID.ToString() + "!\n" + e.Message);
                        return false;
                    }
                }
            }

            // If not one of the given Types then no Delete possible
            return false;
        }

        /// <summary>
        /// Returns an Object from a specific Table. ObjectTypes are (Employee | Workplace | Shift | Shift_Template).
        /// </summary>
        /// <typeparam name="ObjectType"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ObjectType getItem<ObjectType>(int ID) {

            String sqlCommand = "";

            if (typeof(ObjectType) == typeof(Employee)) {

                sqlCommand = "SELECT * FROM Employee WHERE ID = " + ID.ToString();
            }

            if (typeof(ObjectType) == typeof(Workplace)) {

                sqlCommand = "SELECT * FROM Workplace WHERE ID = " + ID.ToString();
            }

            if (typeof(ObjectType) == typeof(Shift)) {

                sqlCommand = "SELECT * FROM Shift WHERE ID = " + ID.ToString();
            }

            if (typeof(ObjectType) == typeof(Shift_Template)) {

                sqlCommand = "SELECT * FROM ShiftTemplate WHERE ID = " + ID.ToString();
            }



            // Check if Valid ObjectType was given
            if (sqlCommand.Equals("")) {

                MessageBox.Show("Falscher ObjectType eingegeben!");

                // If no Valid ObjectType return null
                return (ObjectType)(object)null;
            }

            try {

                using (connection = new SQLiteConnection(connectionString)) {

                    // If Database is not opedned -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) {

                                // Case of ObjectType is Employee
                                if (typeof(ObjectType) == typeof(Employee)) {

                                    // Create new Employee
                                    Employee employee = new Employee();
                                    employee.id = reader.GetInt32(0);
                                    employee.lastname = reader.GetString(1);
                                    employee.firstname = reader.GetString(2);
                                    employee.birthdate = long.Parse(reader.GetString(3));
                                    employee.adress.street = reader.GetString(4);
                                    employee.adress.number = reader.GetString(5);
                                    employee.adress.plz = reader.GetString(6);
                                    employee.adress.city = reader.GetString(7);
                                    employee.adress.country = reader.GetString(8);
                                    employee.mail = reader.GetString(9);
                                    employee.gender = reader.GetInt32(10);
                                    employee.state = (Employee.State)reader.GetInt32(11);

                                    return (ObjectType)(object)employee;
                                }

                                // Case of ObjectType is Workplace
                                if (typeof(ObjectType) == typeof(Workplace)) {

                                    // Create new Workplace
                                    Workplace workplace = new Workplace();
                                    workplace.id = reader.GetInt32(0);
                                    workplace.name = reader.GetString(1);
                                    workplace.contact_mail = reader.GetString(2);
                                    workplace.adress.street = reader.GetString(3);
                                    workplace.adress.number = reader.GetString(4);
                                    workplace.adress.plz = reader.GetString(5);
                                    workplace.adress.city = reader.GetString(6);
                                    workplace.adress.country = reader.GetString(7);
                                    workplace.contact_person = reader.GetString(8);
                                    workplace.ust_id = reader.GetString(9);
                                    workplace.tax = reader.GetDouble(10);
                                    workplace.accounting_adress.street = reader.GetString(11);
                                    workplace.accounting_adress.number = reader.GetString(12);
                                    workplace.accounting_adress.plz = reader.GetString(13);
                                    workplace.accounting_adress.city = reader.GetString(14);
                                    workplace.accounting_adress.country = reader.GetString(15);
                                    workplace.gender_of_contact_person = reader.GetInt32(16);
                                    workplace.extra = reader.GetString(17);


                                    return (ObjectType)(object)workplace;
                                }

                                // Case of ObjectType is Shift
                                if (typeof(ObjectType) == typeof(Shift)) {

                                    // Create new Workplace
                                    Shift shift = new Shift();
                                    shift.id = reader.GetInt32(0);
                                    shift.name = reader.GetString(1);

                                    // Getting Employee IDs
                                    shift.emplshift_list = getEmployeeIDfromShift(shift.id);

                                    shift.id_workplace = reader.GetInt32(2);
                                    shift.date = long.Parse(reader.GetString(3));
                                    shift.startTime = reader.GetString(4);
                                    shift.duration = reader.GetDouble(5);
                                    shift.comment = reader.GetString(6);
                                    shift.Wage_perHour = reader.GetDouble(7);
                                    shift.Holiday_surcharge = reader.GetDouble(8);
                                    shift.Night_surcharge = reader.GetDouble(9);
                                    shift.Sunday_surcharge = reader.GetDouble(10);
                                    shift.break_time = reader.GetDouble(11);

                                    return (ObjectType)(object)shift;
                                }

                                // Case of ObjectType is Shift-Template
                                if (typeof(ObjectType) == typeof(Shift_Template)) {

                                    // Create new Shift-Template
                                    Shift_Template shiftTemplate = new Shift_Template();
                                    shiftTemplate.id = reader.GetInt32(0);
                                    shiftTemplate.name = reader.GetString(1);
                                    shiftTemplate.id_workplace = reader.GetInt32(2);
                                    shiftTemplate.startTime = reader.GetString(3);
                                    shiftTemplate.duration = reader.GetDouble(4);
                                    shiftTemplate.Wage_perHour = reader.GetDouble(5);
                                    shiftTemplate.Holiday_surcharge = reader.GetDouble(6);
                                    shiftTemplate.Night_surcharge = reader.GetDouble(7);
                                    shiftTemplate.Sunday_surcharge = reader.GetDouble(8);
                                    shiftTemplate.break_time = reader.GetDouble(9);

                                    return (ObjectType)(object)shiftTemplate;
                                }

                              

                            }
                        }
                    }
                }

            } catch (Exception e) {

                MessageBox.Show("Fehler beim laden des Objektes (ID: " + ID.ToString() + ") aus der Datenbank!\n" + e.Message);

                // If error in Database return NULL
                return (ObjectType)(object)null;
            }

            // Should not be reached!
            MessageBox.Show("Fehler in getItem (ID: " + ID.ToString() + ") Function -> ID nicht in Datenbank enthalten!");
            return (ObjectType)(object)null;
        }


        /// <summary>
        /// Filling a DataGridView by executing a SQL-Command.
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public bool showInTable<ObjectType>(DataGridView dataGridView, String sqlCommand) {

            if (dataGridView == null) {

                MessageBox.Show("Eingegebene DataGridView ist NULL!");
                return false;
            }

            if (sqlCommand.Equals("")) {

                MessageBox.Show("Eingegebenes SQL-Kommando leer!");
                return false;
            }

            try {

                using (connection = new SQLiteConnection(connectionString)) {

                    // If Database is not opedned -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    // Get Data from DB with SQL-Command
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sqlCommand, connection);

                    // Fill DataSet
                    DataSet dataSet = new DataSet();
                    try {
                        dataAdapter.Fill(dataSet);
                    } catch (SQLiteException e) {
                        int f = 4;
                        MessageBox.Show(e + "");
                        /*

                        //Copy File from Ressource in case of FileNotFound
                        string relativePath = @"DB\Database_TTB-Manager.db";
                        string currentPath;
                        string absolutePath;
                        connection.Close();
                        currentPath = AppDomain.CurrentDomain.BaseDirectory;
                        absolutePath = System.IO.Path.Combine(currentPath, relativePath);
                        File.WriteAllBytes(absolutePath, TTB_Manager.Properties.Resources.Database_TTB_Manager);

                        MessageBox.Show("Datenbank nicht vorhanden\nSie wurde erstellt. Bitte Programm neu starten!");
                        Console.WriteLine("" + e);
                        System.Environment.Exit(0);
                        */
                    }
                    
                    

                    // Create and execute new TableManager
                    new TableManager(dataGridView, dataSet);
                    return true;
                }

            } catch (Exception e) {
                Console.WriteLine("" + e);
                MessageBox.Show("Fehler beim auslesen der Datenbank in eine DataGridView\n" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Returns a DataSet created by a SQL-Command.
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public DataSet getDataByCommand(String sqlCommand) {

            if (sqlCommand.Equals("")) {

                MessageBox.Show("Eingegebenes SQL-Kommando leer!");
                return new DataSet();
            }

            try {

                using (connection = new SQLiteConnection(connectionString)) {

                    // If Database is not opedned -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    // Get Data from DB with SQL-Command
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sqlCommand, connection);

                    // Fill DataSet
                    DataSet dataSet = new DataSet();
                    try {
                        dataAdapter.Fill(dataSet);
                    } catch (SQLiteException e) {

                        //Copy File from Ressource in case of FileNotFound
                        string relativePath = @"DB\Database_TTB-Manager.db";
                        string currentPath;
                        string absolutePath;
                        connection.Close();
                        currentPath = AppDomain.CurrentDomain.BaseDirectory;
                        absolutePath = System.IO.Path.Combine(currentPath, relativePath);
                        File.WriteAllBytes(absolutePath, TTB_Manager.Properties.Resources.Database_TTB_Manager);

                        MessageBox.Show("Datenbank nicht vorhanden\nSie wurde erstellt. Bitte Programm neu starten!");
                        Console.WriteLine("" + e);
                        System.Environment.Exit(0);
                    }

                    // Return DataSet
                    return dataSet;
                }

            } catch (Exception e) {
                Console.WriteLine("" + e);
                MessageBox.Show("Fehler beim auslesen der Datenbank in ein DataSet\n" + e.Message);
                return new DataSet();
            }


        }


        // -------- Functions to get Table Data as List -------------
        /// <summary>
        /// Returns a List of all Employees.
        /// </summary>
        /// <returns></returns>
        public List<Employee> getEmployeeData(String sqlCommand) {

            using (connection = new SQLiteConnection(connectionString)) {

                // Create empty List
                List<Employee> list = new List<Employee>();

                try {

                    // If Connectin not open -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    String command = "SELECT * FROM Employee " + sqlCommand;

                    using (SQLiteCommand cmd = new SQLiteCommand(command, connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) {

                                // Create new Employee
                                Employee employee = new Employee();
                                employee.id = reader.GetInt32(0);
                                employee.lastname = reader.GetString(1);
                                employee.firstname = reader.GetString(2);
                                employee.birthdate = long.Parse(reader.GetString(3));
                                employee.adress.street = reader.GetString(4);
                                employee.adress.number = reader.GetString(5);
                                employee.adress.plz = reader.GetString(6);
                                employee.adress.city = reader.GetString(7);
                                employee.adress.country = reader.GetString(8);
                                employee.mail = reader.GetString(9);
                                employee.gender = reader.GetInt32(10);
                                employee.state = (Employee.State)reader.GetInt32(11);

                                // Add Employee to List
                                list.Add(employee);
                            }

                            return list;
                        }
                    }

                } catch (Exception e) {

                    MessageBox.Show("Fehler beim auslesen der Mitarbeiter-Datenbank!\n" + e.Message);

                    // If Error return empty List
                    return new List<Employee>();
                }
            }
        }

        /// <summary>
        /// Returns a List of all Workplaces.
        /// </summary>
        /// <returns></returns>
        public List<Workplace> getWorkplaceData(String sqlCommand) {

            using (connection = new SQLiteConnection(connectionString)) {

                // Create empty List
                List<Workplace> list = new List<Workplace>();

                try {

                    // If Connectin not open -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    String command = "SELECT * FROM Workplace " + sqlCommand;

                    using (SQLiteCommand cmd = new SQLiteCommand(command, connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) {

                                // Create new Workplace
                                Workplace workplace = new Workplace();
                                workplace.id = reader.GetInt32(0);
                                workplace.name = reader.GetString(1);
                                workplace.contact_mail = reader.GetString(2);
                                workplace.adress.street = reader.GetString(3);
                                workplace.adress.number = reader.GetString(4);
                                workplace.adress.plz = reader.GetString(5);
                                workplace.adress.city = reader.GetString(6);
                                workplace.adress.country = reader.GetString(7);
                                workplace.contact_person = reader.GetString(8);
                                workplace.ust_id = reader.GetString(9);
                                workplace.tax = reader.GetDouble(10);
                                workplace.accounting_adress.street = reader.GetString(11);
                                workplace.accounting_adress.number = reader.GetString(12);
                                workplace.accounting_adress.plz = reader.GetString(13);
                                workplace.accounting_adress.city = reader.GetString(14);
                                workplace.accounting_adress.country = reader.GetString(15);
                                workplace.gender_of_contact_person = reader.GetInt32(16);
                                workplace.extra = reader.GetString(17);


                                // Add Workplace to List
                                list.Add(workplace);
                            }

                            return list;
                        }
                    }

                } catch (Exception e) {

                    MessageBox.Show("Fehler beim auslesen der Arbeitsplatz-Datenbank!\n" + e.Message);

                    // If Error return empty List
                    return new List<Workplace>();
                }
            }
        }

        /// <summary>
        /// Returns a List of all Shifts.
        /// </summary>
        /// <returns></returns>
        public List<Shift> getShiftData(String parameterSQLcommand) {

            using (connection = new SQLiteConnection(connectionString)) {

                // Create empty List
                List<Shift> list = new List<Shift>();

                try {

                    // If Connectin not open -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    String command = "SELECT * FROM Shift " + parameterSQLcommand;

                    using (SQLiteCommand cmd = new SQLiteCommand(command, connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) {

                                // Create new Shift
                                Shift shift = new Shift();
                                shift.id = reader.GetInt32(0);
                                shift.name = reader.GetString(1);

                                // Get EmployeeID List
                                shift.emplshift_list = getEmployeeIDfromShift(shift.id);

                                shift.id_workplace = reader.GetInt32(2);
                                shift.date = long.Parse(reader.GetString(3));
                                shift.startTime = reader.GetString(4);
                                shift.duration = reader.GetDouble(5);
                                shift.comment = reader.GetString(6);
                                shift.Wage_perHour = reader.GetDouble(7);
                                shift.Holiday_surcharge = reader.GetDouble(8);
                                shift.Night_surcharge = reader.GetDouble(9);
                                shift.Sunday_surcharge = reader.GetDouble(10);
                                shift.break_time = reader.GetDouble(11);

                                // Add Shift to List
                                list.Add(shift);
                            }

                            return list;
                        }
                    }

                } catch (Exception e) {

                    MessageBox.Show("Fehler beim auslesen der Schichten-Datenbank!\n" + e.Message);

                    // If Error return empty List
                    return new List<Shift>();
                }
            }
        }

       

        /// <summary>
        /// Returns a List of all Shift-Templates.
        /// </summary>
        /// <returns></returns>
        public List<Shift_Template> getShiftTemplateData() {

            using (connection = new SQLiteConnection(connectionString)) {

                // Create empty List
                List<Shift_Template> list = new List<Shift_Template>();

                try {

                    // If Connectin not open -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    String command = "SELECT * FROM ShiftTemplate";

                    using (SQLiteCommand cmd = new SQLiteCommand(command, connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) {

                                // Create new Shift-Template
                                Shift_Template shiftTemplate = new Shift_Template();
                                shiftTemplate.id = reader.GetInt32(0);
                                shiftTemplate.name = reader.GetString(1);
                                shiftTemplate.id_workplace = reader.GetInt32(2);
                                shiftTemplate.startTime = reader.GetString(3);
                                shiftTemplate.duration = reader.GetDouble(4);
                                shiftTemplate.Wage_perHour = reader.GetDouble(5);
                                shiftTemplate.Holiday_surcharge = reader.GetDouble(6);
                                shiftTemplate.Night_surcharge = reader.GetDouble(7);
                                shiftTemplate.Sunday_surcharge = reader.GetDouble(8);
                                shiftTemplate.break_time = reader.GetDouble(9);

                                // Add Shift-Template to List
                                list.Add(shiftTemplate);
                            }

                            return list;
                        }
                    }

                } catch (Exception e) {

                    MessageBox.Show("Fehler beim auslesen der Schichten-Template Datenbank!\n" + e.Message);

                    // If Error return empty List
                    return new List<Shift_Template>();
                }
            }
        }

        public List<EmployeeOvertime> getEmployeeIDfromShift(int Shift_ID) {

            using (connection = new SQLiteConnection(connectionString)) {

                // Create empty List
                List<EmployeeOvertime> list = new List<EmployeeOvertime>();

                try {

                    // If Connectin not open -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    String command = "SELECT * FROM Shift_Employee WHERE ID_Shift = " + Shift_ID.ToString();

                    using (SQLiteCommand cmd = new SQLiteCommand(command, connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) {

                                // Insert Employee IDs into List
                                EmployeeOvertime eo = new EmployeeOvertime();
                                eo.employee_id = reader.GetInt32(1);
                                eo.overtime = reader.GetDouble(2);
                                list.Add(eo);
                            }

                            return list;
                        }
                    }

                } catch (Exception e) {

                    MessageBox.Show("Fehler beim Auslesen der Mitarbeiter aus Schicht mit ID: " + Shift_ID.ToString() + "\n" + e.Message);

                    // if error return empty List
                    return new List<EmployeeOvertime>();
                }
            }
        }
        // ----------------------------------------------------------



        /// <summary>
        /// Getter for next free ID of specific Table.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int getNextID(Database_Type type) {

            using (connection = new SQLiteConnection(connectionString)) {

                String selectMaxId = "";

                if (type == Database_Type.EMPLOYEE) {

                    selectMaxId = "Select Max(ID) From Employee";
                }
                if (type == Database_Type.WORKPLACE) {

                    selectMaxId = "Select Max(ID) From Workplace";
                }
                if (type == Database_Type.SHIFT) {

                    selectMaxId = "Select Max(ID) From Shift";
                }
                if (type == Database_Type.SHIFT_TEMPLATE) {

                    selectMaxId = "Select Max(ID) From ShiftTemplate";
                }

                try {

                    // If Connection not opended -> open
                    if (connection.State != ConnectionState.Open) {

                        connection.Open();
                    }

                    SQLiteCommand selectMaxCmd = new SQLiteCommand(selectMaxId, connection);
                    object val = selectMaxCmd.ExecuteScalar();
                    int ID;
                    try {
                        ID = int.Parse(val.ToString());
                    } catch (FormatException) {
                        return 0;
                    }


                    return ID + 1;

                } catch (Exception e) {

                    if (type == Database_Type.EMPLOYEE) {

                        MessageBox.Show("Error getting Next ID from Employee!" + e.Message);
                    }
                    if (type == Database_Type.WORKPLACE) {

                        MessageBox.Show("Error getting Next ID from Workplace!" + e.Message);
                    }
                    if (type == Database_Type.SHIFT) {

                        MessageBox.Show("Error getting Next ID from Shift!" + e.Message);
                    }
                    if (type == Database_Type.SHIFT_TEMPLATE) {

                        MessageBox.Show("Error getting Next ID from Shift-Template!" + e.Message);
                    }

                    return -1;
                }
            }
        }


        // Database internal Insert/Update Functions
        private bool insert_update_Employee(int in_up, Employee employee) {

            using (connection = new SQLiteConnection(connectionString)) {

                try {

                    SQLiteCommand command = new SQLiteCommand();

                    // Create SQL Command for Insert or Update
                    if (in_up == INSERT) {
                        command.CommandText = @"INSERT INTO Employee (Lastname, Firstname, Birthdate, Street, Number, PLZ, City, Country, Mail, Gender, State) VALUES " +
                                                                 @"(@Lastname, @Firstname, @Birthdate, @Street, @Number, @PLZ, @City, @Country, @Mail, @Gender, @State)";
                    }
                    if (in_up == UPDATE) {
                        command.CommandText = @"UPDATE Employee Set Lastname = @Lastname, Firstname = @Firstname, Birthdate = @Birthdate, " +
                                                @"Street = @Street, Number = @Number, PLZ = @PLZ, City = @City, Country = @Country, Mail = @Mail, Gender = @Gender, State = @State where ID = " + employee.id.ToString();


                    }

                    command.Parameters.Add(new SQLiteParameter("@Lastname", employee.lastname));
                    command.Parameters.Add(new SQLiteParameter("@Firstname", employee.firstname));
                    command.Parameters.Add(new SQLiteParameter("@Birthdate", employee.birthdate));
                    command.Parameters.Add(new SQLiteParameter("@Street", employee.adress.street));
                    command.Parameters.Add(new SQLiteParameter("@Number", employee.adress.number));
                    command.Parameters.Add(new SQLiteParameter("@PLZ", employee.adress.plz));
                    command.Parameters.Add(new SQLiteParameter("@City", employee.adress.city));
                    command.Parameters.Add(new SQLiteParameter("@Country", employee.adress.country));
                    command.Parameters.Add(new SQLiteParameter("@Mail", employee.mail));
                    command.Parameters.Add(new SQLiteParameter("@Gender", employee.gender));
                    command.Parameters.Add(new SQLiteParameter("@State", (int)employee.state));



                    command.Connection = connection;

                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    command.ExecuteNonQuery();

                } catch (Exception e) {

                    if (in_up == INSERT) {
                        MessageBox.Show("Error inserting Employee into Database!\n" + e.Message);
                    }
                    if (in_up == UPDATE) {
                        MessageBox.Show("Error updating Employee in Database!\n" + e.Message);
                    }

                    return false;
                }
            }
            return true;
        }

        private bool insert_update_Workplace(int in_up, Workplace workplace) {

            using (connection = new SQLiteConnection(connectionString)) {

                try {

                    SQLiteCommand command = new SQLiteCommand();

                    // Create SQL Command for Insert or Update
                    if (in_up == INSERT) {
                        command.CommandText = @"INSERT INTO Workplace (Name, Contact_Mail, Street, Number, PLZ, City, Country, ContactPerson, UstID, Tax, AccStreet, AccNumber, AccPLZ, AccCity, AccCountry, ContactGender, Extra) VALUES (@Name, @Contact_Mail, @Street, @Number, @PLZ, @City, @Country, @ContactPerson, @UstID, @Tax, @AccStreet, @AccNumber, @AccPLZ, @AccCity, @AccCountry, @ContactGender, @Extra)";
                    }
                    if (in_up == UPDATE) {
                        command.CommandText = @"UPDATE Workplace Set Name = @Name, Contact_Mail = @Contact_Mail, Street = @Street, Number = @Number, PLZ = @PLZ, City = @City, Country = @Country, ContactPerson = @ContactPerson, UstID = @UstID, Tax = @Tax, AccStreet = @AccStreet, AccNumber = @AccNumber, AccPLZ = @AccPLZ, AccCity = @AccCity, AccCountry = @AccCountry, ContactGender = @ContactGender, Extra = @Extra WHERE ID = " + workplace.id.ToString();
                    }

                    command.Parameters.Add(new SQLiteParameter("@Name", workplace.name));
                    command.Parameters.Add(new SQLiteParameter("@Contact_Mail", workplace.contact_mail));
                    command.Parameters.Add(new SQLiteParameter("@Street", workplace.adress.street));
                    command.Parameters.Add(new SQLiteParameter("@Number", workplace.adress.number));
                    command.Parameters.Add(new SQLiteParameter("@PLZ", workplace.adress.plz));
                    command.Parameters.Add(new SQLiteParameter("@City", workplace.adress.city));
                    command.Parameters.Add(new SQLiteParameter("@Country", workplace.adress.country));
                    command.Parameters.Add(new SQLiteParameter("@ContactPerson", workplace.contact_person));
                    command.Parameters.Add(new SQLiteParameter("@UstID", workplace.ust_id));
                    command.Parameters.Add(new SQLiteParameter("@Tax", workplace.tax));
                    command.Parameters.Add(new SQLiteParameter("@AccStreet", workplace.accounting_adress.street));
                    command.Parameters.Add(new SQLiteParameter("@AccNumber", workplace.accounting_adress.number));
                    command.Parameters.Add(new SQLiteParameter("@AccPLZ", workplace.accounting_adress.plz));
                    command.Parameters.Add(new SQLiteParameter("@AccCity", workplace.accounting_adress.city));
                    command.Parameters.Add(new SQLiteParameter("@AccCountry", workplace.accounting_adress.country));
                    command.Parameters.Add(new SQLiteParameter("@ContactGender", workplace.gender_of_contact_person));
                    command.Parameters.Add(new SQLiteParameter("@Extra", workplace.extra));


                    command.Connection = connection;

                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    command.ExecuteNonQuery();

                } catch (Exception e) {

                    if (in_up == INSERT) {
                        MessageBox.Show("Error inserting Workplace into Database!\n" + e.Message);
                    }
                    if (in_up == UPDATE) {
                        MessageBox.Show("Error updating Workplace in Database!\n" + e.Message);
                    }

                    return false;
                }

                return true;
            }
        }

        private bool insert_update_Shift(int in_up, Shift shift) {

            int ID_Shift;



            try {

                // Gettign Shift ID for inserting in Shift_Employee Table
                if (shift.id == -1) {

                    ID_Shift = getNextID(Database_Type.SHIFT);

                }
                else {

                    ID_Shift = shift.id;
                }



                // ---------- Insert Shift ---------------------------------------------------- //
                SQLiteCommand command = new SQLiteCommand();

                if (in_up == INSERT) {
                    command.CommandText = @"INSERT INTO Shift (Name, ID_Workplace, Date, StartTime, Duration, Comment, WagePerHour, Holidaysurcharge, Nightsurcharge, Sundaysurcharge, Breaktime) " +
                                                @"VALUES (@Name, @ID_Workplace, @Date, @StartTime, @Duration, @Comment, @WagePerHour, @Holidaysurcharge, @Nightsurcharge, @Sundaysurcharge, @Breaktime)";
                }
                if (in_up == UPDATE) {
                    command.CommandText = @"UPDATE Shift Set Name = @Name, ID_Workplace = @ID_Workplace, Date = @Date, StartTime = @StartTime, Duration = @Duration, " +
                                                @"Comment = @Comment, WagePerHour = @WagePerHour, Holidaysurcharge = @Holidaysurcharge, Nightsurcharge = @Nightsurcharge, Sundaysurcharge = @Sundaysurcharge, Breaktime = @Breaktime WHERE ID = " + shift.id.ToString();
                }

                command.Parameters.Add(new SQLiteParameter("@Name", shift.name));
                command.Parameters.Add(new SQLiteParameter("@ID_Workplace", shift.id_workplace));
                command.Parameters.Add(new SQLiteParameter("@Date", shift.date));
                command.Parameters.Add(new SQLiteParameter("@StartTime", shift.startTime));
                command.Parameters.Add(new SQLiteParameter("@Duration", shift.duration));
                command.Parameters.Add(new SQLiteParameter("@Comment", shift.comment));
                command.Parameters.Add(new SQLiteParameter("@WagePerHour", shift.Wage_perHour));
                command.Parameters.Add(new SQLiteParameter("@Holidaysurcharge", shift.Holiday_surcharge));
                command.Parameters.Add(new SQLiteParameter("@Nightsurcharge", shift.Night_surcharge));
                command.Parameters.Add(new SQLiteParameter("@Sundaysurcharge", shift.Sunday_surcharge));
                command.Parameters.Add(new SQLiteParameter("@Breaktime", shift.break_time));


                using (connection = new SQLiteConnection(connectionString)) {

                    command.Connection = connection;

                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    command.ExecuteNonQuery();
                }



            } catch (Exception e) {

                if (in_up == INSERT) {
                    MessageBox.Show("Error inserting Shift into Database!\n" + e.Message);
                }
                if (in_up == UPDATE) {
                    MessageBox.Show("Error updating Shift in Database!\n" + e.Message);
                }

                return false;
            }

            // ------------------------------------------------------------------------------- //


            // ---------- Insert Employee ---------------------------------------------------- //
            using (connection = new SQLiteConnection(connectionString)) {

                try {

                    // if Update, delete old entries first
                    if (in_up == UPDATE) {

                        String sqlCommand = @"DELETE FROM Shift_Employee WHERE ID_Shift = " + ID_Shift.ToString();

                        // If Database is not opedned -> open
                        if (connection.State != ConnectionState.Open) {
                            connection.Open();
                        }

                        SQLiteCommand command = new SQLiteCommand(sqlCommand, connection);
                        command.ExecuteNonQuery();
                    }


                    // Insert every Employee in reference to the Shift
                        for (int i=0;i<shift.emplshift_list.Count;i++) {
                            SQLiteCommand command = new SQLiteCommand();

                            command.CommandText = @"INSERT INTO Shift_Employee (ID_Shift, ID_Employee, Overtime) VALUES (@ID_Shift, @ID_Employee, @Overtime)";

                            command.Parameters.Add(new SQLiteParameter("@ID_Shift", ID_Shift));
                            command.Parameters.Add(new SQLiteParameter("@ID_Employee", shift.emplshift_list[i].employee_id));
                            command.Parameters.Add(new SQLiteParameter("@Overtime", shift.emplshift_list[i].overtime));


                            command.Connection = connection;

                            if (connection.State != ConnectionState.Open) {
                                connection.Open();
                            }

                            command.ExecuteNonQuery();
                        }


                    return true;

                } catch (Exception e) {

                    if (in_up == INSERT) {
                        MessageBox.Show("Fehler beim einfügen des Personals in die Schicht_Personal Verknüpfungstabelle!\n" + e.Message);
                    }
                    if (in_up == UPDATE) {
                        MessageBox.Show("Fehler beim updaten des Personals in die Schicht_Personal Verknüpfungstabelle!\n" + e.Message);
                    }

                    return false;
                }
            }
            // ------------------------------------------------------------------------------- //
        }

        private bool insert_update_ShiftTemplate(int in_up, Shift_Template shiftTemplate) {

            using (connection = new SQLiteConnection(connectionString)) {

                try {

                    SQLiteCommand command = new SQLiteCommand();

                    if (in_up == INSERT) {
                        command.CommandText = @"INSERT INTO ShiftTemplate (Name, ID_Workplace, StartTime, Duration, WagePerHour, Holidaysurcharge, Nightsurcharge, Sundaysurcharge, Breaktime)" +
                                                    @"VALUES (@Name, @ID_Workplace, @StartTime, @Duration, @WagePerHour, @Holidaysurcharge, @Nightsurcharge, @Sundaysurcharge, @Breaktime)";
                    }
                    if (in_up == UPDATE) {
                        command.CommandText = @"UPDATE ShiftTemplate Set Name = @Name, ID_Workplace = @ID_Workplace, StartTime = @StartTime, Duration = @Duration, " +
                                                    @"WagePerHour = @WagePerHour, Holidaysurcharge = @Holidaysurcharge, Nightsurcharge = @Nightsurcharge, Sundaysurcharge = @Sundaysurcharge, Breaktime = @Breaktime WHERE ID = " + shiftTemplate.id.ToString();
                    }

                    command.Parameters.Add(new SQLiteParameter("@Name", shiftTemplate.name));
                    command.Parameters.Add(new SQLiteParameter("@ID_Workplace", shiftTemplate.id_workplace));
                    command.Parameters.Add(new SQLiteParameter("@StartTime", shiftTemplate.startTime));
                    command.Parameters.Add(new SQLiteParameter("@Duration", shiftTemplate.duration));
                    command.Parameters.Add(new SQLiteParameter("@WagePerHour", shiftTemplate.Wage_perHour));
                    command.Parameters.Add(new SQLiteParameter("@Holidaysurcharge", shiftTemplate.Holiday_surcharge));
                    command.Parameters.Add(new SQLiteParameter("@Nightsurcharge", shiftTemplate.Night_surcharge));
                    command.Parameters.Add(new SQLiteParameter("@Sundaysurcharge", shiftTemplate.Sunday_surcharge));
                    command.Parameters.Add(new SQLiteParameter("@Breaktime", shiftTemplate.break_time));


                    command.Connection = connection;

                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    int status = command.ExecuteNonQuery();

                    if (status == 1) {

                        if (in_up == INSERT) {
                            MessageBox.Show("Shift-Template erfolgreich erstellt.");
                        }
                    }

                } catch (Exception e) {

                    if (in_up == INSERT) {
                        MessageBox.Show("Error inserting Shift-Template into Database!\n" + e.Message);
                    }
                    if (in_up == UPDATE) {
                        MessageBox.Show("Error updating Shift-Template in Database!\n" + e.Message);
                    }

                    return false;
                }
            }
            return true;
        }


    }
}
