using SellCarApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCarApp.controller
{
    internal class CustomerController
    {

        List<Customer> customers = new List<Customer>() { };

        public List<Customer> getAll()
        {
            return customers;
        }

        public bool SearchIdIfExist(string id)
        {
            bool res = true;
            foreach (Customer customer in customers)
            {
                if (customer.Id == id)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        public Customer getById(string id)
        {
            Customer customer1 = new Customer();
            foreach (Customer customer2 in customers)
            {
                if (customer2.Id == id)
                {
                    customer1 = customer2; break;
                }
            }
            return customer1;
        }

        public void create(Customer customer)
        {
            customers.Add(customer);
        }

        public void remove(string id)
        {
            foreach (Customer customer in customers.ToList())
            {
                if (customer.Id == id)
                {
                    customers.Remove(customer);
                }
            }


        }

        public void update(string id, Customer customer)
        {
            foreach (Customer customer1 in customers)
            {
                if (customer1.Id == id)
                {

                    if(customer.Id != "") customer1.Id = customer.Id;
                    if (customer.Address != "") customer1.Address = customer.Address;
                    if (customer.Name != "") customer1.Name = customer.Name;
                    if (customer.PhoneNumber != "") customer1.PhoneNumber = customer.PhoneNumber;
                }
            }

        }
    }
}
