using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCarApp
{
    public class Sale
    {
        string id;
        string carId;
        string storeId; 
        string customerId;
        string salespersonId;
        DateTime saleDate;
        double salePrice;

        public string CarId {
            get { return carId; }
            set { carId = value; }
        }
        public string Id {
            get { return id; }
            set { id = value; }
        }
        public string CustomerId {
            get { return customerId; }
            set { customerId = value; }
        }
        public string StoreId {
            get { return storeId; }
            set { storeId = value; }
        }
        public string SalespersonId {
            get { return salespersonId; }
            set { salespersonId = value; }
        }
        public DateTime SaleDate {
            get { return saleDate; }
            set { saleDate = value; }
        }
        public double SalePrice {
            get { return salePrice; }
            set { salePrice = value; }
        }

        public Sale() { }

        public Sale(string id,string carId,string customerId,string salespersonId,DateTime saleDate,double salePrice)
        {
            this.id = id;
            this.carId = carId;
            this.customerId = customerId;
            this.salespersonId = salespersonId;
            this.saleDate = saleDate;
            this.salePrice = salePrice;
        }

        public string toString()
        {
            return $"{id},{carId},{customerId},{salespersonId},{saleDate},{salePrice}";
        }

        /* public double CalculateCommission()
         {
             return SalePrice * (salespersonId / 100);
         }*/
    }
}
