using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTB_Manager.Database {
    class DB_Login {

        /// <summary>
        /// String for connecting with Database.
        /// </summary>
        private String connectionString;

        /// <summary>
        /// Database Connection.
        /// </summary>
        private SQLiteConnection connection;

        public DB_Login() {

            // Set up Connection String
            string relativePath = @"DB\Database_TTB-Manager_Login.db";
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
        public bool insert(Login login) {

            // Check if there is wrong or missing Data
            if (login.employee_id == -1 || login.username.Equals("") || login.password.Equals("")) {

                MessageBox.Show("Einige Angaben sind leer, oder fehlerhaft. Login konnte nicht erstellt werden!");
                return false;
            }

            using (connection = new SQLiteConnection(connectionString)) {
                
                try {

                    SQLiteCommand command = new SQLiteCommand();
                    command.CommandText = @"INSERT INTO Login (Rank, EmployeeID, Username, Password, SessionID) VALUES (@Rank, @EmployeeID, @Username, @Password, @SessionID)";

                    command.Parameters.Add(new SQLiteParameter("@Rank", login.rank));
                    command.Parameters.Add(new SQLiteParameter("@EmployeeID", login.employee_id));
                    command.Parameters.Add(new SQLiteParameter("@Username", login.username));
                    command.Parameters.Add(new SQLiteParameter("@Password", login.password));
                    command.Parameters.Add(new SQLiteParameter("@SessionID", login.session_id));

                    command.Connection = connection;

                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    command.ExecuteNonQuery();

                } catch (Exception e) {
       
                    MessageBox.Show("Fehler beim einfügen des Logins in die Datenbank!\n" + e.Message);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Updating Item in Database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool update(Login login) {

            // Check if there is wrong or missing Data
            if (login.id == -1 || login.employee_id == -1 || login.username.Equals("") || login.password.Equals("")) {

                MessageBox.Show("Einige Angaben sind leer, oder fehlerhaft. Login konnte nicht erstellt werden!");
                return false;
            }

            using (connection = new SQLiteConnection(connectionString)) {

                try {

                    SQLiteCommand command = new SQLiteCommand();
                    command.CommandText = @"UPDATE Login Set Rank = @Rank, EmployeeID = @EmployeeID, Username = @Username, Password = @Password, SessionID = @SessionID where ID = " + login.id.ToString();

                    command.Parameters.Add(new SQLiteParameter("@Rank", login.rank));
                    command.Parameters.Add(new SQLiteParameter("@EmployeeID", login.employee_id));
                    command.Parameters.Add(new SQLiteParameter("@Username", login.username));
                    command.Parameters.Add(new SQLiteParameter("@Password", login.password));
                    command.Parameters.Add(new SQLiteParameter("@SessionID", login.session_id));

                    command.Connection = connection;

                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    command.ExecuteNonQuery();

                } catch (Exception e) {

                    MessageBox.Show("Fehler beim updaten eines Logins in die Datenbank!\n" + e.Message);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Deleting Item from Database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool deleteItem(int ID) {

            String sqlCommand = @"DELETE FROM Login WHERE ID = " + ID.ToString();

            using (connection = new SQLiteConnection(connectionString)) {

                try {

                    // If Database is not opened -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    SQLiteCommand command = new SQLiteCommand(sqlCommand, connection);
                    command.ExecuteNonQuery();

                    return true;

                } catch (Exception e) {

                    MessageBox.Show("Fehler beim Löschen des Login´s mit ID:" + ID.ToString() + "!\n" + e.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Getter for next free ID.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int getNextID() {

            using (connection = new SQLiteConnection(connectionString)) {

                String selectMaxId = "Select Max(ID) From Login";

                try {

                    // If Connection not opended -> open
                    if (connection.State != ConnectionState.Open) {

                        connection.Open();
                    }

                    SQLiteCommand selectMaxCmd = new SQLiteCommand(selectMaxId, connection);
                    object val = selectMaxCmd.ExecuteScalar();
                    int ID = int.Parse(val.ToString());

                    return ID + 1;

                } catch (Exception e) {

                    MessageBox.Show("Error getting Next ID from Login!" + e.Message);
                    return -1;
                }
            }
        }

        /// <summary>
        /// Returns Item with specific ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Login getItem(int ID) {

            String sqlCommand = "SELECT * FROM Login WHERE ID = " + ID.ToString();

            try {

                using (connection = new SQLiteConnection(connectionString)) {

                    // If Database is not opedned -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) {

                                // Create new Login
                                Login login = new Login();
                                login.id = reader.GetInt32(0);
                                login.rank = reader.GetInt32(1);
                                login.employee_id = reader.GetInt32(2);
                                login.username = reader.GetString(3);
                                login.password = reader.GetString(4);
                                login.session_id = reader.GetInt32(5);

                                return login;
                            }
                        }
                    }
                }

            } catch (Exception e) {

                MessageBox.Show("Fehler beim laden des Logins (ID: " + ID.ToString() + ") aus der Datenbank!\n" + e.Message);

                // If error in Database return NULL
                return null;
            }

            // Should not be reached!
            MessageBox.Show("Fehler in getItem Function -> ID ist nicht vergeben!");
            return null;
        }

        /// <summary>
        /// Returns a List of all Logins.
        /// </summary>
        /// <returns></returns>
        public List<Login> getLoginData() {

            using (connection = new SQLiteConnection(connectionString)) {

                // Create empty List
                List<Login> list = new List<Login>();

                try {

                    // If Connectin not open -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    String command = "SELECT * FROM Login";

                    using (SQLiteCommand cmd = new SQLiteCommand(command, connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) {

                                // Create new Login
                                Login login = new Login();
                                login.id = reader.GetInt32(0);
                                login.rank = reader.GetInt32(1);
                                login.employee_id = reader.GetInt32(2);
                                login.username = reader.GetString(3);
                                login.password = reader.GetString(4);
                                login.session_id = reader.GetInt32(5);

                                // Add Login to List
                                list.Add(login);
                            }

                            return list;
                        }
                    }

                } catch (Exception e) {

                    MessageBox.Show("Fehler beim auslesen der Login-Datenbank!\n" + e.Message);

                    // If Error return empty List
                    return new List<Login>();
                }
            }
        }

        /// <summary>
        /// Returns the Password of a specific User.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public String getPassByUsername(String username) {

            String sqlCommand = "SELECT * FROM Login WHERE Username = " + username;

            try {

                using (connection = new SQLiteConnection(connectionString)) {

                    // If Database is not opedned -> open
                    if (connection.State != ConnectionState.Open) {
                        connection.Open();
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) {

                                return reader.GetString(3);
                            }
                        }
                    }
                }

            } catch  {

                // If error in Database return NULL
                return null;
            }

            return null;
        }
    }
}
