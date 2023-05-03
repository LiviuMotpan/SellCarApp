using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SellCarApp
{
    internal class CarController
    {

        List<Car> cars = new List<Car>() { };

        public List<Car> getAll()
        {
            return cars;
        }

        public Car getById(string id)
        {
            Car carr = new Car();
            foreach (Car carx in cars)
            {
                if (carx.Id == id)
                {
                    carr = carx; break;
                }
            }
            return carr;
        }

        public bool SearchIdIfExist(string id)
        {
            bool res = true;
            foreach(Car car in cars)
            {
                if (car.Id == id)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        public void create(Car car)
        {
            cars.Add(car);
        }

        public void remove(string id)
        {
                foreach (Car carx in cars.ToList())
                {
                    if (carx.Id == id)
                    {
                        cars.Remove(carx);
                    }
                }
            
            
        }

        public void update(string id,Car car)
        {
            foreach(Car carx in cars)
            {
                if(carx.Id == id)
                {
                    if(car.Id != "") carx.Id = car.Id;
                    if (car.Producer != "") carx.Producer = car.Producer;
                    if (car.Model != "") carx.Model = car.Model;
                    if (car.Year != -1) carx.Year = car.Year;
                    if (car.Mileage != -1) carx.Mileage = car.Mileage;
                    if (car.Price != -1) carx.Price = car.Price;
                }
            }
        }

    }
}
