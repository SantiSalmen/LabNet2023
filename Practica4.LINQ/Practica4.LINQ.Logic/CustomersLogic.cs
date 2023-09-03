﻿using Practica4.LINQ.Data;
using Practica4.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.LINQ.Logic
{
    public class CustomersLogic : BaseLogic
    {

        protected readonly Customers dBcustomers;
        public CustomersLogic() 
        {
            dBcustomers = new Customers();
        }

        public List<Customers> GetCustomers()
        {

            var query1 = from Customers in context.Customers
                         select Customers;


            return query1.ToList();
        }

        public List<Customers> WaCustomers()
        {
            var query4 = context.Customers.Where(e => e.Region == "WA");

            return query4.ToList();
        }

        public List<Customers> CustomersName() 
        {
            var query6  = context.Customers.OrderBy(e => e.CustomerID).ToList();

           

           return query6;
        }

        public List<object> JoinOrders() 
        {
            var query7 = (from Customers in context.Customers
                         join Orders in context.Orders on Customers.CustomerID equals Orders.CustomerID
                         where Customers.Region == "WA" && Orders.OrderDate > new DateTime(1997,1,1)
                         select new {
                                        NombreCliente = Customers.ContactName,
                                        RegionDelCliente = Customers.Region,
                                        Ordenes = Orders.OrderID,
                                        FechaDeOrden = Orders.OrderDate
                                       }).Distinct();
                   

            return query7.ToList<object>();
        }

        public List<Customers> ThreeFirst() 
        {
            var query8 = (from Customers in context.Customers
                         where Customers.Region == "WA"
                         orderby Customers.CustomerID  
                         select Customers).Take(3).ToList();
                         
            return query8;
        }
    }
}
