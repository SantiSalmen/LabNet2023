using Practica3.EF.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Practica3.EF.Logic
{
    public class CustomersLogic : BaseLogic, ILogic<Customers>
    {

        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Add(Customers newCustomers) 
        {
            context.Customers.Add(newCustomers);

            context.SaveChanges();
        }

        public void Delete(Customers deleteCustomer)
        {

            var customerDelete = context.Customers.Find(deleteCustomer.CustomerID);


            List<Orders> orderList= new List<Orders>(deleteCustomer.Orders);
        
            foreach (var orders in orderList)
            {
                List<Order_Details> detailsList = new List<Order_Details>(orders.Order_Details);
                foreach (var dOrders in detailsList)
                {
                    context.Order_Details.Remove(dOrders);
                }
                context.Orders.Remove(orders);
                    
            }

            context.Customers.Remove(customerDelete);

            context.SaveChanges();

        }

        public void Update(Customers customer)
        {
            var customerUpdate = context.Customers.Find(customer.CustomerID);

            customerUpdate.CompanyName= customer.CompanyName;
            customerUpdate.ContactName= customer.ContactName;           
            customerUpdate.City= customer.City;
            customerUpdate.Country= customer.Country;
            customerUpdate.Phone= customer.Phone;

            context.SaveChanges();
        }

    }
}
