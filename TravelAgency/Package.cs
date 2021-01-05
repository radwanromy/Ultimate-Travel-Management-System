using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    class Package
    {
        public string ID;
        public string location;
        public int totalNoOfMeals;
        public int pricePerPerson;
        public string hotelName;
        public string roomType;
        public string transport;

        public Package() { }

        public Package(string ID, string location, int totalNoOfMeals, int pricePerPerson, string hotelName, string roomType, string transport)
        {
            this.ID = ID;
            this.location = location;
            this.totalNoOfMeals = totalNoOfMeals;
            this.pricePerPerson = pricePerPerson;
            this.hotelName = hotelName;
            this.roomType = roomType;
            this.transport = transport;
        }




    }
}
