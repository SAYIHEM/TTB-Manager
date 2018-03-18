using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTB_Manager.Forms {
    public partial class Statistics : Form {

        // Database init
        private Database.DB_Manager database = new Database.DB_Manager();

        // Filterlist init
        private List<String> filterNames = new List<String>();
        private List<bool> filterStates = new List<bool>();

        public Statistics() {
            InitializeComponent();

            initialize();

            database.connect();


            // Initialize Widgets like DateTimePicker
        }

        private void initialize() {

            // Check RadBtnMonth
            radBtnMonth.Checked = true;

            dtpStartDate.CustomFormat = "dd.MM.yyyy";
            dtpEndDate.CustomFormat = "dd.MM.yyyy";


            // Set Time to one Month
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);

            // Set Filter to FilterList

            updateChart();
        }

        private void radBtnMonth_CheckedChanged(object sender, EventArgs e) {

            if (radBtnMonth.Checked) {

                // Disable Datetime Picker
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;

                // Set Time to one Month
                dtpEndDate.Value = DateTime.Now;
                dtpStartDate.Value = DateTime.Now.AddMonths(-1);

                updateChart();
            }
        }

        private void radBtnWeek_CheckedChanged(object sender, EventArgs e) {

            if (radBtnWeek.Checked) {

                // Disable Datetime Picker
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;

                // Set Time to one Week
                dtpEndDate.Value = DateTime.Now;
                dtpStartDate.Value = DateTime.Now.AddDays(-7);

                updateChart();
            }
        }

        private void radBtnCustom_CheckedChanged(object sender, EventArgs e) {

            if (radBtnCustom.Checked) {

                // Enable Datetime Picker
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;

                updateChart();
            }
        }

        private void updateChart() {



            DataSet dataSet = new DataSet();

            // Getting Start und Endtime
            long startTime = dtpStartDate.Value.AddDays(-1).Ticks;
            long endTime = dtpEndDate.Value.AddDays(1).Ticks;

            foreach (String filterItem in filterNames) {

                // Clear chart
                chart.Series[filterItem].Points.Clear();

                int filterID = filterItem.IndexOf(filterItem);

                // 
                if (filterItem.Equals("Einnahmen") && filterStates[filterID]) {

                    // Prepare SQL-Command
                    String sqlCommand = @"SELECT Shift.Date AS Date, Shift.WagePerHour AS Wage, Shift.Duration as Duration
                        FROM Shift
                        WHERE Shift.date BETWEEN '" + startTime + "' AND '" + endTime + "' ORDER BY Shift.date";

                    // Execute SQL-Command
                    dataSet = database.getDataByCommand(sqlCommand);

                    DateTime actualDate = new DateTime(Convert.ToInt64(dataSet.Tables[0].Rows[0]["Date"]));
                    double wageOnDay = 0;

                    // Iteratate through Dataset
                    foreach (DataRow row in dataSet.Tables[0].Rows) {

                        DateTime rowDate = new DateTime(Convert.ToInt64(row["Date"]));
                        
                        // If Shift is not on the Same Day
                        if (actualDate.Date != rowDate.Date) {

                            // Add a entry in Chart
                            chart.Series[filterItem].Points.AddXY(new Dater().getStringFromTimestamp(actualDate.Ticks), wageOnDay);

                            actualDate = rowDate;
                            wageOnDay = 0;
                        }

                        // Add Shift Wage to the WageOnDay
                        wageOnDay += Convert.ToDouble(row["Wage"]) * Convert.ToDouble(row["Duration"]);


                    }
                }
            }

            
        }

        
        /// <summary>
        /// Updating the Filter States.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkListBox_Filter_SelectedIndexChanged(object sender, EventArgs e) {

            int actualID = 0;

            filterNames.Clear();
            filterStates.Clear();

            // Set new Filter
            foreach (Object item in checkListBox_Filter.Items) {

                // Adding filter Names and States to the Lists
                filterNames.Add(item.ToString());
                filterStates.Add(checkListBox_Filter.GetItemChecked(actualID));

                actualID++;
            }

            updateChart();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e) {

            updateChart();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e) {

            updateChart();
        }
    }
}
