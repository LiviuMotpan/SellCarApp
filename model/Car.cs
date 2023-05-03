using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCarApp
{
    public class Car
    {
        string id;
        string producer;
        string model;
        int year;
        int mileage;
        double price;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Producer
        {

            get { return producer; }
            set { producer = value; }
        }

        public string Model
        {

            get { return model; }
            set { model = value; }
        }

        public int Year
        {

            get { return year; }
            set { year = value; }
        }

        public int Mileage
        {

            get { return mileage; }
            set { mileage = value; }
        }

        public double Price
        {

            get { return price; }
            set { price = value; }
        }

        public Car() { }

        public Car(string id, string producer, string model, int year, int mileage, double price)
        {
            this.id = id;
            this.producer = producer;
            this.model = model;
            this.year = year;
            this.mileage = mileage;
            this.price = price;
        }

        public string toString()
        {
            return $"{id},{producer},{model},{year},{mileage},{price}";
        }

    }
}
