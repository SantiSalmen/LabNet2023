using Practica4.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.LINQ.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public List<Object> StocklessProducts()
        {

            var query2 = from Products in context.Products
                         where Products.UnitsInStock == 0
                         select Products;

            List<Object> list = new List<Object>(query2);

            return list;
        }

        public List<Object> MoreThan3() 
        {
            var query3 = context.Products.Where(e => e.UnitsInStock > 0 && e.UnitPrice > 3);

            List<Object> list = new List<Object>(query3);

            return list;
        }
    }
}
