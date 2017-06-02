using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_krwi
{
    class PlaceGet
    {
        public String Name { get; private set; }
        public String WorkDay { get; private set; }
        public String Adress { get; private set; }
        public String Telephone { get; private set; }

        public PlaceGet(String name, String workDay, String adress, String telephone) {
            this.Name = name;
            this.WorkDay = workDay;
            this.Adress = adress;
            this.Telephone = telephone;
        }
    }
}
