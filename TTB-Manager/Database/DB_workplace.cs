using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using TTB_Manager.Workplace;
using System.Data.SqlClient;
using System.Data;

namespace TTB_Manager.Database
{


    class DB_Workplace { 

        private const String DB_WORKSPACE_NAME = "DB_WORKPLACE";
        private const String ROW_ID = "ID";
        private const String ROW_Name = "Name";
        private const String ROW_Adress = "Adress";

        private const String DB_PAYMENT_INFORMATION_NAME = "DB_PAYMENT_INFORMATION";
        private const String ROW_WAGE_PER_HOUR = "Wage/Hour";
        private const String ROW_HOLIDAY_SURCHAGE = "Holidaysurcharge";
        private const String ROW_NIGHT_SURCHAGE = "Nightsurcharge";


        private string dataSource_Workplace = "DB_Workplace.sqlite";
        private string dataSource_PaymentInformation = "DB_PaymentInformation.sqlite";

        // Database Connections
        private SQLiteConnection connection_workplace;
        private SQLiteConnection connection_paymentInformation;

        public DB_Workplace() {
            // Open Database Connection
            //openDatabase();


        }

        public String insertWorkplace(Workplace.Workplace workplace) {
            SQLiteCommand command = new SQLiteCommand(connection_workplace);

            // Insert Workspace
            command.CommandText = "INSERT INTO " + DB_WORKSPACE_NAME + "(" + ROW_ID + ", " + ROW_Name + ", " +
                                   ROW_Adress + ") VALUES(NULL, " + workplace.ID + ", " + workplace.adress.getAdressForDatabase() + ")";


            command.ExecuteNonQuery();

            String s = command.CommandText;

            // Insert PaymentInformation
            command.CommandText = "INSERT INTO " + DB_PAYMENT_INFORMATION_NAME + "(" + ROW_ID + ", " + ROW_WAGE_PER_HOUR + ", " +
                       ROW_HOLIDAY_SURCHAGE + ", " + ROW_NIGHT_SURCHAGE + ") VALUES(" + workplace.ID + ", " + workplace.PaymentInformation.Wage_perHour +
                       ", " + workplace.PaymentInformation.Holiday_surcharge + ", " + workplace.PaymentInformation.Night_surcharge + ")";

            command.ExecuteNonQuery();


            return s + "\n" + command.CommandText;

        }

        private void openDatabase() {
            SQLiteCommand command;

            // ----------- Open DB_WORKPLACE ----------------------------------------
            SQLiteConnection.CreateFile(dataSource_Workplace);
            this.connection_workplace = new SQLiteConnection();

            this.connection_workplace.ConnectionString = "Data Source=" + dataSource_Workplace;
            this.connection_workplace.Open();

            command = new SQLiteCommand(this.connection_workplace);

            // Creating Database if it not exists
            command.CommandText = "CREATE TABLE IF NOT EXISTS" + DB_WORKSPACE_NAME + "( " + ROW_ID + " INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " + ROW_Name + " VARCHAR(20), " +
                                  ROW_Adress + " VARCHAR(20));";

            command.ExecuteNonQuery();
            // ----------------------------------------------------------------------

            
            // ----------- Open DB_PAYMENT_INFORMATION ------------------------------
            SQLiteConnection.CreateFile(dataSource_PaymentInformation);
            this.connection_paymentInformation = new SQLiteConnection();

            this.connection_paymentInformation.ConnectionString = "Data Source=" + dataSource_PaymentInformation;
            this.connection_paymentInformation.Open();

            command = new SQLiteCommand(this.connection_paymentInformation);

            // Creating Database if it not exists
            command.CommandText = "CREATE TABLE IF NOT EXISTS" + DB_PAYMENT_INFORMATION_NAME + "( " + ROW_ID + " INTEGER NOT NULL, " + ROW_WAGE_PER_HOUR + " FLOAT, " +
                                   ROW_HOLIDAY_SURCHAGE + " FLOAT, " + ROW_NIGHT_SURCHAGE + " FLOAT); ";

            command.ExecuteNonQuery();
            // ----------------------------------------------------------------------

        }

        public void open() {


        }
    }
}
