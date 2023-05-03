using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCarApp
{
    internal class Saleperson
    {
        string id;
        string name;
        int age;
        int experience;
        double commissionPercentage;

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
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public double CommissionPercentage
        {
            get { return commissionPercentage; }
            set { commissionPercentage = value; }
        }

        public Saleperson() { }

        public Saleperson(string id, string name, int age, int experience, double commissionPercentage)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.experience = experience;
            this.commissionPercentage = commissionPercentage;
        }

        public string toString()
        {
            return $"{id},{name},{age},{experience},{commissionPercentage}";
        }
    }
}
