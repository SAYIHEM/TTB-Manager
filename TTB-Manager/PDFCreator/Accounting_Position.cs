using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTB_Manager.PDFCreator {
    enum Unit { Std}
    class Accounting_Position {
        public double amount = 0;
        public Unit unit;
        public String description = "";
        public double price;
        public double tax = 0;
        public Accounting_Position() {

        }
    }
}
