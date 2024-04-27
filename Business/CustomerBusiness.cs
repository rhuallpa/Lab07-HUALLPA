using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerBusiness
    {
        public List<Customer> GetCustomerByName(string name)
        {
            List<Customer> customers = new List<Customer>();
            CustomerData data = new CustomerData();
            customers = data.GetCustomer();
            var resul = customers.Where(x => x.name.Contains(name)).ToList();
            return resul;
        }
    }
}
