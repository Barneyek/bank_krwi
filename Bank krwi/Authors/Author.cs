using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_krwi.Authors {
    class Author {
        public String Imie { get; private set; }
        public String Nazwisko { get; private set; }
        public String Grupa { get; private set; }

        public Author(String imie, String nazwisko, String grupa) {
            Imie = imie;
            Nazwisko = nazwisko;
            Grupa = grupa;
        }
    }
}
