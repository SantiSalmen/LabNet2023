using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.LINQ.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public List<Object> GetCustomers()
        {

            var query1 = from Customers in context.Customers
                         select Customers;

            List<Object> list = new List<Object>(query1);

            return list;
        }

        public List<Object> WaCustomers()
        {
            var query4 = context.Customers.Where(e => e.Region == "WA");

            List<Object> list = new List<Object>(query4);

            return list;
        }
    }
}
