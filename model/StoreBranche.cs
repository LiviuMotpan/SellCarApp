using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCarApp.model
{
    internal class StoreBranche
    {
        string id;
        string name;
        string address;

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

        public StoreBranche() { }

        public StoreBranche(string id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        public string toString()
        {
            return $"{id},{name},{address}";
        }
    }
}
