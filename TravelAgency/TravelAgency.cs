using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    class TravelAgency
    {
        public string name;
        public string userName;
        string password;
        public string email;
        //public bool verification;

        public TravelAgency() { }

        public TravelAgency(string name, string userName, string password, string email)
        {
            this.name = name;
            this.userName = userName;
            this.password = password;
            this.email = email;
        }

        public void CreatePackage()
        {
            Package p1 = new Package();

        }

        public void DeletePackage()
        {

        }

        public void UpdatePackage()
        {

        }

        public void ShowPackages()
        {

        }

    }

}
