using SellCarApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCarApp.controller
{
    internal class StoreBrancheController
    {

        List<StoreBranche> storeBranches = new List<StoreBranche>() { };

        public List<StoreBranche> getAll()
        {
            return storeBranches;
        }

        public bool SearchIdIfExist(string id)
        {
            bool res = true;
            foreach (StoreBranche storeBranche in storeBranches)
            {
                if (storeBranche.Id == id)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        public StoreBranche getById(string id)
        {
            StoreBranche storeBranche1 = new StoreBranche();
            foreach (StoreBranche storeBranche2 in storeBranches)
            {
                if (storeBranche2.Id == id)
                {
                    storeBranche1 = storeBranche2; break;
                }
            }
            return storeBranche1;
        }

        public void create(StoreBranche storeBranche)
        {
            storeBranches.Add(storeBranche);
        }

        public void remove(string id)
        {
            foreach (StoreBranche storeBranche in storeBranches.ToList())
            {
                if (storeBranche.Id == id)
                {
                    storeBranches.Remove(storeBranche);
                }
            }


        }

        public void update(string id, StoreBranche storeBranche)
        {
            foreach (StoreBranche storeBranche1 in storeBranches)
            {
                if (storeBranche1.Id == id)
                {
                    if(storeBranche.Id != "") storeBranche1.Id = storeBranche.Id;
                    if (storeBranche.Name != "") storeBranche1.Name = storeBranche.Name;
                    if (storeBranche.Address != "") storeBranche1.Address = storeBranche.Address;
                }
            }

        }

    }
}
