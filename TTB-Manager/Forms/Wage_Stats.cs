using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.Database;

namespace TTB_Manager.Forms {
    public partial class Umsatzübersicht : Form {
        DB_Manager db_manager = new DB_Manager();
        public Umsatzübersicht() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            db_manager.connect();
        }

        private void Wage_Stats_Load(object sender, EventArgs e) {
            MinimizeBox = false;
            MaximizeBox = false;
        }
    }
}
