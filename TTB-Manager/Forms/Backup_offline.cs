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
    public partial class Backup_offline : Form {


        string relativePath = @"DB\Database_TTB-Manager.db";
        string currentPath;
        string absolutePath;


        public Backup_offline() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;


            currentPath = AppDomain.CurrentDomain.BaseDirectory;
            absolutePath = System.IO.Path.Combine(currentPath, relativePath);
        }

        private void Backup_offline_Load(object sender, EventArgs e) {
            MinimizeBox = false;
            MaximizeBox = false;

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {

        }
    }
}
