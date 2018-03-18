using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TTB_Manager.Types {

    /// <summary>
    /// Class for managing a Workplace.
    /// </summary>
    class Workplace {

        public int id = -1;
        public string name;
        public string contact_mail;
        internal Adress adress = new Adress();
        internal Adress accounting_adress = new Adress();
        public String ust_id;
        public double tax = 19;
        public String contact_person = "";
        public String extra;
        public int gender_of_contact_person = -1;


        public Workplace() {

        }

        public Workplace(int ID, String name, Adress adress, String contact_mail) {

            this.id = ID;
            this.name = name;
            this.adress = adress;
            this.contact_mail = contact_mail;
        }
        public bool check() {
            if (name.Equals("") || !adress.Check() || !accounting_adress.Check() || ust_id.Equals("") || ((!contact_person.Equals("") && gender_of_contact_person == -1))) {

                MessageBox.Show("Fehler: Mindestens ein Feld ist nicht korrekt ausgefüllt oder leer");
                return false;
            }
            return true;
        }

    }
}
