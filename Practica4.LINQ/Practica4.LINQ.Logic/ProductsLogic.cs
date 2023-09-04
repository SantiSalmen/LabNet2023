using Practica4.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Practica4.LINQ.Entities;

namespace Practica4.LINQ.Logic
{
    public class ProductsLogic : BaseLogic
    {

        protected readonly Products dBproducts;
        public ProductsLogic()
        {
            dBproducts = new Products();
        }
        public List<Products> StocklessProducts()
        {

            var query2 = from Products in context.Products
                         where Products.UnitsInStock == 0
                         select Products;


            return query2.ToList();
        }

        public List<Products> MoreThan3() 
        {
            var query3 = context.Products.Where(e => e.UnitsInStock > 0 && e.UnitPrice > 3);


            return query3.ToList();
        }

        public Products SpecificId()
        {
       
                var query5 = (from Products in context.Products
                         where Products.ProductID == 789
                         select Products).FirstOrDefault();

                return query5;

     
        }
        public List<Products> NameProducts() 
        {
            var query9 = context.Products.OrderBy(e => e.ProductName).ToList();

            return query9;
        }

        public List<Products> StockOrder()
        {
            var query10 = context.Products.OrderByDescending(e => e.UnitsInStock).ToList();

            return query10;
        }

        public List<object> CategoryProducts()
        {
            var query11 = from Products in context.Products
                          join Categories in context.Categories on Products.CategoryID equals Categories.CategoryID
                          orderby Categories.CategoryID
                          select new
                          {
                              Categoria = Categories.CategoryName,
                              Productos = Products.ProductName,
                          };



            return query11.ToList<object>();
        }

        public Products FirstProduct()
        {
            var query12 = context.Products.First();

            return query12;
        }
    }
}
