using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_krwi.Tests {

    [TestFixture]
    class Testy {

        IDonatorValidation donatorValidation = new DonatorValidationImplentation();

        //Sprawdza czy walidator przejdzie, gdy wszystkie dane są poprawne
        [Test]
        public void DonatorShouldBeValid() {

            Donator donator = new Donator("Jan", "Kowalski", 23, "0Rh-", "M", "Olsztyn", 123456567,"4,5");
            donatorValidation.AddDonatorValidate(donator);
        }

        [Test]
        public void ShouldThrowExceptionWhenNameIsNull() {

            Donator donator = new Donator(null, "Kowalski", 23, "0Rh-", "M", "Olsztyn", 123456567,"3,5");
            Assert.That(() => donatorValidation.AddDonatorValidate(donator), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ShouldThrowExceptionWhenNameIsEmptyOrWhiteSpace() {

            Donator donator = new Donator("    ", "Kowalski", 23, "0Rh-", "M", "Olsztyn", 123456567,"2,5");
            Assert.That(() => donatorValidation.AddDonatorValidate(donator), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ShouldThrowExceptionWhenNameHasNumber() {

            Donator donator = new Donator("J4n", "Kowalski", 23, "0Rh-", "M", "Olsztyn", 123456567,"1");
            Assert.That(() => donatorValidation.AddDonatorValidate(donator), Throws.TypeOf<FormatException>());
        }

        [Test]
        public void ShouldThrowExceptionWhenSurnameIsNull() {

            Donator donator = new Donator("Jan", null, 23, "0Rh-", "M", "Olsztyn", 123456567,"1,5");
            Assert.That(() => donatorValidation.AddDonatorValidate(donator), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ShouldThrowExceptionWhenSurnameIsEmptyOrWhiteSpace() {

            Donator donator = new Donator("Jan", "   ", 23, "0Rh-", "M", "Olsztyn", 123456567,"1,5");
            Assert.That(() => donatorValidation.AddDonatorValidate(donator), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ShouldThrowExceptionWhenSurnameHasNumber() {

            Donator donator = new Donator("Jan", "Kow4lski", 23, "0Rh-", "M", "Olsztyn", 123456567,"1");
            Assert.That(() => donatorValidation.AddDonatorValidate(donator), Throws.TypeOf<FormatException>());
        }

        [Test]
        public void ShouldThrowExceptionWhenAgeIsToLow() { 

            Donator donator = new Donator("Jan", "Kowalski", 15, "0Rh-", "M", "Olsztyn", 123456567,"1");
            Assert.That(() => donatorValidation.AddDonatorValidate(donator), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ShouldThrowExceptionWhenAgeIsToHigh() {

            Donator donator = new Donator("Jan", "Kowalski", 90, "0Rh-", "M", "Olsztyn", 123456567,"1,5");
            Assert.That(() => donatorValidation.AddDonatorValidate(donator), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
