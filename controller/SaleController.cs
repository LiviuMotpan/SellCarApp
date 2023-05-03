using SellCarApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCarApp
{
    internal class SaleController
    {

        List<Sale> sales = new List<Sale>() { };

        public List<Sale> getAll()
        {
            return sales;
        }

        public bool SearchIdIfExist(string id)
        {
            bool res = true;
            foreach (Sale sale in sales)
            {
                if (sale.Id == id)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }


        public Sale getById(string id)
        {
            Sale sale1 = new Sale();
            foreach (Sale sale2 in sales)
            {
                if (sale2.Id == id)
                {
                    sale1 = sale2; break;
                }
            }
            return sale1;
        }

        public void create(Sale sale)
        {
            sales.Add(sale);
        }

        public void remove(string id)
        {
            foreach (Sale sale in sales.ToList())
            {
                if (sale.Id == id)
                {
                    sales.Remove(sale);
                }
            }


        }

        public void update(string id, Sale sale)
        {
            foreach (Sale sale1 in sales)
            {
                if (sale1.Id == id)
                {
                    if(sale.Id != "") sale1.Id = sale.Id;
                    if (sale.CarId != "") sale1.CarId = sale.CarId;
                    if (sale.StoreId != "") sale1.StoreId = sale.StoreId;
                    if (sale.CustomerId != "") sale1.CustomerId = sale.CustomerId;
                    if (sale.SalespersonId != "") sale1.SalespersonId = sale.SalespersonId;
                    if (sale.SaleDate != new DateTime(01/01/0001)) sale1.SaleDate = sale.SaleDate;
                    if (sale.SalePrice != -1) sale1.SalePrice = sale.SalePrice;
                }
            }

        }

    }
}
