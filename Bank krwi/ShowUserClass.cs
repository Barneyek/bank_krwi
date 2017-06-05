using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_krwi
{
    class ShowUserClass
    {
        private int Id;
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string Date { get; private set; }
        public string BloodGr { get; private set; }
        public string Sex { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }

        public ShowUserClass(string firstName, string surname, string date, string bloodGr, string sex, string address, string phoneNumber) {

            this.FirstName = firstName;
            this.Surname = surname;
            this.Date = date;
            this.BloodGr = bloodGr;
            this.Sex = sex;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public string TakeFirstName()
        {
            return this.FirstName;
        }

        public string TakeSurname()
        {
            return this.Surname;
        }

        public string TakeDate()
        {
            return this.Date;
        }

        public string TakeBloodGr()
        {
            return this.BloodGr;
        }

        public string TakeSex()
        {
            return this.Sex;
        }

        public string TakeAddress()
        {
            return this.Address;
        }

        public string TakePhoneNumber()
        {
            return this.PhoneNumber;
        }

    }
}
