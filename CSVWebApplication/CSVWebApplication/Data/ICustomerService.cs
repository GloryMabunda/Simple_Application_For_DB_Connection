using CSVWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVWebApplication.Data
{
    public interface ICustomerService
    {
        public List<Customer> GetCustomers();

        public Customer AddCustomer(Customer productItem);

        public Customer UpdateCustomer(string id, Customer productItem);

        public string DeleteCustomer(string id);
    }
}
