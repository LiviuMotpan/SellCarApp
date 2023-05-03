using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCarApp
{
    internal class Customer
    {

        string id;
        string name;
        string address;
        string phoneNumber;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public Customer() { }

        public Customer(string id, string name, string adr, string phoneNumber)
        {
            this.id = id;
            this.name = name;
            address = adr;
            this.phoneNumber = phoneNumber;
        }

        public string toString()
        {
            return $"{id},{name},{address},{phoneNumber}";
        }
    }
}
