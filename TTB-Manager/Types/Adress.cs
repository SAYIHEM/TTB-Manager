using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTB_Manager {
    /// <summary>
    /// Holds Information about Street, Number, PLZ, City and Country.
    /// </summary>
    class Adress {
        public String street, number, plz, city, country;

        // Attributes    

        public bool Check() {
                if (street.Equals("") || number.Equals("") || plz.Equals("") || city.Equals("") || country.Equals("")) {
                    return false;

                } else {
                    return true;
                }
        }


        public Adress(String street, String number, String plz, String city, String country) {
            this.street = street;
            this.number = number;
            this.plz = plz;
            this.city = city;
            this.country = country;

        }
        public Adress() {

        }

        /// <summary>
        /// Split DatabaseFormat (Street_Number_PLZ_City_Country) into Strings
        /// </summary>
        public void setAdressFromDatabase(String adress_database) {

            string[] adress = adress_database.Split('|');

            this.street = adress[0];
            this.number = adress[1];
            this.plz = adress[2];
            this.city = adress[3];
            this.country = adress[4];

        }

        /// <summary>
        /// Returns Adress in DatabaseFormat: Street_Number_PLZ_City_Country
        /// </summary>
        /// <returns></returns>
        public String getAdressForDatabase() {

            return this.street + "|" + this.number + "|" + this.plz + "|" + this.city + "|" + this.country;
        }

    }
}
