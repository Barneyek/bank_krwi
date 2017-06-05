using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_krwi.Authors {
    class Author {
        public String FirstName { get; private set; }
        public String Surname { get; private set; }
        public String BloodGr { get; private set; }

        public Author(String firstName, String surname, String bloodGr) {
            FirstName = firstName;
            Surname = surname;
            BloodGr = bloodGr;
        }
    }
}
