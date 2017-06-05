using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_krwi {
    class Donator {
        public String FirstName { get; private set; }
        public String Surname { get; private set; }
        public Int32 Age { get; private set; }
        public String BloodGr { get; private set; }
        public String Sex { get; private set; }
        public String Address { get; private set; }
        public Int32 PhoneNumber { get; private set; }
        public String AmountOfBlood { get; set; }

        public Donator(String firstName, String surname, Int32 age, String bloodGr, String sex, String address, Int32 phoneNumber, String amountOfBlood) {
            this.FirstName = firstName;
            this.Surname = surname;
            this.Age = age;
            this.BloodGr = bloodGr;
            this.Sex = sex;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.AmountOfBlood = amountOfBlood;
        }
    }
}
