using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_krwi {
    class Donator {
        public String Imie { get; private set; }
        public String Nazwisko { get; private set; }
        public Int32 Wiek { get; private set; }
        public String GrupaKrw { get; private set; }
        public String Plec { get; private set; }
        public String Adres { get; private set; }
        public Int32 Telefon { get; private set; }
        public String IloscOddanejKrwi { get; set; }

        public Donator(String imie, String nazwisko, Int32 wiek, String grupaKrw, String plec, String adres, Int32 telefon, String iloscKrwii) {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Wiek = wiek;
            this.GrupaKrw = grupaKrw;
            this.Plec = plec;
            this.Adres = adres;
            this.Telefon = telefon;
            this.IloscOddanejKrwi = iloscKrwii;
        }
    }
}
