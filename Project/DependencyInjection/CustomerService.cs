using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorECommerce.DependencyInjection
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> customers;
        public string UId { get; set; }

        public CustomerService()
        {
            UId = Guid.NewGuid().ToString();

            customers = new List<Customer>()
            {
                new Customer{Id = 1, Name = "Ali"},
                new Customer{Id = 2, Name = "Veli"},
                new Customer{Id = 3, Name = "Neco"},
            };
        }

        public Customer GetCustomerById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
