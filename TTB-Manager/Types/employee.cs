using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace TTB_Manager {
    class Employee {
        public String lastname, firstname, mail;
        public int gender;
        public int id = -1;
        internal enum State { FRE, HLD, ILL, WKS }
        public State state = State.FRE;

        public long birthdate;

        public Adress adress = new Adress();

        public Employee() {

        }
        public bool check() {
            if (firstname.Equals("") || lastname.Equals("") || birthdate.Equals("") || !adress.Check()) {
                System.Windows.MessageBox.Show("Fehler: Einige Felder sind leer!");
                return false;
            }
            else {
                return true;
            }
        }
        public Label stateLabel() {
            Label l = new Label();
            String tool_text = "";
            switch (state) {
                case State.FRE:
                    l.BackColor = Color.Green;
                    l.ForeColor = Color.White;
                    tool_text = "Verfügbar";
                    break;
                case State.HLD:
                    l.BackColor = Color.Yellow;
                    l.ForeColor = Color.Black;
                    tool_text = "Im Urlaub";
                    break;
                case State.WKS:
                    l.BackColor = Color.Blue;
                    l.ForeColor = Color.White;
                    tool_text = "Arbeitet";
                    break;
                case State.ILL:
                    l.BackColor = Color.Red;
                    l.ForeColor = Color.White;
                    tool_text = "Krank";
                    break;
            }

            l.Text = state + "";
            l.TextAlign = ContentAlignment.MiddleCenter;
            
            l.Height = 12;
            l.Width = 35;

            //Generate ToolTip
            ToolTip state_tooltip = new ToolTip();
            state_tooltip.ShowAlways = true;
            state_tooltip.SetToolTip(l, tool_text);

            return l;
        }
    }
}
