using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTB_Manager.Types;
using TTB_Manager.Database;


namespace TTB_Manager.Forms
{
    public partial class EditWorkplace : Form {
        DB_Manager db_manager = new DB_Manager();
        public EditWorkplace()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void EditLocation_Load(object sender, EventArgs e)
        {
            db_manager.connect();
            next_id.Text = db_manager.getNextID(Database_Type.WORKPLACE) + "";

            ComboBoxItem ci = new ComboBoxItem();
            ci.Text = "Herr";
            ci.Value = 0;
            cB_title.Items.Add(ci);
            ci = new ComboBoxItem();
            ci.Text = "Frau";
            ci.Value = 1;
            cB_title.Items.Add(ci);
            cB_title.DisplayMember = "Text";
            cB_title.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e) {
            Workplace workplace = new Workplace();
            workplace.adress.street = tv_street.Text;
            workplace.adress.plz = tv_plz.Text;
            workplace.adress.number = tv_nr.Text;
            workplace.name = tv_name.Text;
            workplace.adress.city = tv_city.Text;
            workplace.extra = tv_extra.Text;
            workplace.adress.country = tv_country.Text;
            workplace.contact_mail = tv_mail.Text;
            workplace.ust_id = tv_ustid.Text;
            workplace.contact_person = tv_contact_person.Text;
            workplace.gender_of_contact_person = ((ComboBoxItem)cB_title.SelectedItem).Value;
            if (!cB_mwst.Checked && !tv_mwst.Text.Equals(""))
                workplace.tax = double.Parse(tv_mwst.Text);

            if (cB_accA.Checked) {
                workplace.accounting_adress = workplace.adress;
            }
            else {
                workplace.accounting_adress.street = tv_acc_street.Text;
                workplace.accounting_adress.number = tv_acc_nr.Text;
                workplace.accounting_adress.plz = tv_acc_plz.Text;
                workplace.accounting_adress.city = tv_acc_city.Text;
                workplace.accounting_adress.country = tv_acc_country.Text;

            }
           

            if (db_manager.insert(workplace)) {
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void tv_name_TextChanged(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (cB_accA.Checked) {
                gB_acc_adress.Enabled = false;
            }
            else {
                gB_acc_adress.Enabled = true;
            }
        }

        private void cB_title_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void cB_mwst_CheckedChanged(object sender, EventArgs e) {
            if (!cB_mwst.Checked) {
                tv_mwst.Visible = true;
                label_mwst.Visible = true;
            }
            else {
                tv_mwst.Visible = false;
                label_mwst.Visible = false;
            }
        }

    }
}
