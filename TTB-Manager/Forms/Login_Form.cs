using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.Database;

namespace TTB_Manager.Forms {
    public partial class Login_Form : Form {
        MainForm mainform;
        DB_Login db_login = new DB_Login();
        
        public Login_Form() {
            mainform = new MainForm(this);
            mainform.FormClosing += new FormClosingEventHandler(mainform_FormClosing);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            db_login.connect();

        }

        private void Login_Load(object sender, EventArgs e) {
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e) {
            mainform.Show();
            mainform.Visible = true;
            Visible = false;
            return;
            String user = tv_name.Text;
            String pass = tv_pass.Text;
            String pass_db;

            if (!(db_login.getPassByUsername(user) == null))
            {
                pass_db = db_login.getPassByUsername(user);
            } else  {
                WrongInput();
                return;
            }

            if (CalculateMD5Hash(pass).Equals("")) {
                mainform.Show();
                mainform.Visible = true;
                Visible = false;
            }
            else {
                WrongInput();
                return;
            }


        }

        private void mainform_FormClosing(object sender, FormClosingEventArgs e) {
            this.Close();
        }
        private void WrongInput() {
            MessageBox.Show("Falscher Username oder Passwort",
            "Fehler",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);
            tv_pass.Clear();
        }
        public string CalculateMD5Hash(string input) {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++) {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();

        }
    }
}
