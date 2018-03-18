using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTB_Manager.Types {
    public class ComboBoxItem {
        private string _Text;
        private int _Value;
        public ComboBoxItem() {

        }
        public ComboBoxItem(String text, int value) {
            this._Text = text;
            this._Value = value;
        }

        public string Text {
            get {
                return this._Text;
            }
            set {
                this._Text = value;
            }
        }
        public int Value {
            get {
                return this._Value;
            }
            set {
                this._Value = value;
            }
        }
    }
}
