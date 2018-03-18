using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTB_Manager.Database {
    class TableManager {

        DataGridView dataGridView;


        public TableManager(DataGridView dataGridView, DataSet data) {

            this.dataGridView = dataGridView;
            dataGridView.Columns.Clear();
            dataGridView.DataSource = data.Tables[0];
        }
    }
}
