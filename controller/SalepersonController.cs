using SellCarApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCarApp.controller
{
    internal class SalepersonController
    {

        List<Saleperson> salespersons = new List<Saleperson>() { };

        public List<Saleperson> getAll()
        {
            return salespersons;
        }

        public bool SearchIdIfExist(string id)
        {
            bool res = true;
            foreach (Saleperson salesperson in salespersons)
            {
                if (salesperson.Id == id)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }



        public Saleperson getById(string id)
        {
            Saleperson salesperson1 = new Saleperson();
            foreach (Saleperson salesperson2 in salespersons)
            {
                if (salesperson2.Id == id)
                {
                    salesperson1 = salesperson2; break;
                }
            }
            return salesperson1;
        }

        public void create(Saleperson salesperson)
        {
            salespersons.Add(salesperson);
        }

        public void remove(string id)
        {
            foreach (Saleperson salesperson in salespersons.ToList())
            {
                if (salesperson.Id == id)
                {
                    salespersons.Remove(salesperson);
                }
            }


        }

        public void update(string id, Saleperson salesperson)
        {
            foreach (Saleperson salesperson1 in salespersons)
            {
                if (salesperson1.Id == id)
                {
                    if(salesperson.Id != "") salesperson1.Id = salesperson.Id;
                    if (salesperson.Name != "")  salesperson1.Name = salesperson.Name;
                    if (salesperson.Experience != -1) salesperson1.Experience = salesperson.Experience;
                    if (salesperson.Age != -1)  salesperson1.Age = salesperson.Age;
                    if (salesperson.CommissionPercentage != -1)  salesperson1.CommissionPercentage = salesperson.CommissionPercentage;
                }
            }

        }

    }
}
