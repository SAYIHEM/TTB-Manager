using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTB_Manager.PDFCreator {
    class WorkProof {
        public enum Days {Mo,Di,Mi,Do,Fr,Sa,So }
        public Days day;
        public String date;
        public List<String> firstnames = new List<string>();
        public List<String> lastnames = new List<string>();
        public String starttime;
        public String enddtime;
        public double break_time;
        public double duration;
        public String name;
         
        public WorkProof() {

        }
    }
}
