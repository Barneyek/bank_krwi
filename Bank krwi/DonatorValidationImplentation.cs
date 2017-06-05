using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Text.RegularExpressions;

namespace Bank_krwi {
    class DonatorValidationImplentation : IDonatorValidation {

        public void AddDonatorValidate(Donator donator) {
            if(String.IsNullOrWhiteSpace(donator.FirstName)) {
                throw new ArgumentNullException("Imie jest wymagane");
            }
            if(donator.FirstName.Any(char.IsDigit)) { // sprawdza, czy string zawiera jakąś cyfrę
                throw new FormatException("Imie nie może być cyfrą");
            }

            if(String.IsNullOrWhiteSpace(donator.Surname)) {
                throw new ArgumentNullException("Nazwisko jest wymagane");
            }
            if(donator.Surname.Any(char.IsDigit)) {
                throw new FormatException("Nazwisko nie może być cyfrą");
            }

            if(donator.Age < 18 || donator.Age > 65) {
                throw new ArgumentOutOfRangeException("Wiek musi zawierać się w przedziale 18-65");
            }

            List<String> dostepneGrupyKrwi = new List<String> {
                "0Rh-",
                "0Rh+",
                "ARh-",
                "ARh+",
                "BRh-",
                "BRh+",
                "ABRh-",
                "ABRh+"
            };

            if(!CheckIfStringIsInArray(donator.BloodGr, dostepneGrupyKrwi)) {
                throw new Exception("Nie wybrano grupy krwi");
            }

            if(String.IsNullOrWhiteSpace(donator.AmountOfBlood)) {
                donator.AmountOfBlood = "0";
            }
        }

        private bool CheckIfStringIsInArray(String stringToTest, List<String> stringsList) {
            foreach(String value in stringsList) {
                if(value == stringToTest) {
                    return true;
                }
            }

            return false;
        }
    }
}
