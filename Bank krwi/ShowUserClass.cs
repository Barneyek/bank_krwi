using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_krwi
{
    class ShowUserClass
    {
        private int id;
        public string imie { get; private set; }
        public string nazwisko { get; private set; }
        public string dataUrodzenia { get; private set; }
        public string grupaKrwii { get; private set; }
        public string plec { get; private set; }
        public string adres { get; private set; }
        public string numerTelefonu { get; private set; }

        public ShowUserClass(string imie, string nazwisko, string dataUrodzenia, string grupaKrwii, string plec, string adres, string numerTelefonu) {

            this.imie = imie;
            this.nazwisko = nazwisko;
            this.dataUrodzenia = dataUrodzenia;
            this.grupaKrwii = grupaKrwii;
            this.plec = plec;
            this.adres = adres;
            this.numerTelefonu = numerTelefonu;
        }

        public string wezImie()
        {
            return this.imie;
        }

        public string wezNazwisko()
        {
            return this.nazwisko;
        }

        public string wezDataUrodzenia()
        {
            return this.dataUrodzenia;
        }

        public string wezGrupaKrwii()
        {
            return this.grupaKrwii;
        }

        public string wezPlec()
        {
            return this.plec;
        }

        public string wezAdres()
        {
            return this.adres;
        }

        public string wezNumerTelefonu()
        {
            return this.numerTelefonu;
        }

    }
}
