using CSVWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVWebApplication.Data
{
    public class CustomerService : ICustomerService
    {

            private List<Customer> customerList;

            public CustomerService()
            {
                customerList = new List<Customer>();
            }

            public List<Customer> GetCustomers()
            {
                return customerList;
            }

            public Customer AddCustomer(Customer productItem)
            {
                customerList.Add(productItem);
                return productItem;
            }

            public Customer UpdateCustomer(string id, Customer productItem)
            {
                for (var index = customerList.Count - 1; index >= 0; index--)
                {
                    if (customerList[index].CUST_CODE == id)
                    {
                        customerList[index] = productItem;
                    }
                }
                return productItem;
            }

            public string DeleteCustomer(string id)
            {
                for (var index = customerList.Count - 1; index >= 0; index--)
                {
                    if (customerList[index].CUST_CODE == id)
                    {
                        customerList.RemoveAt(index);
                    }
                }

                return id;
            }
    }
}
