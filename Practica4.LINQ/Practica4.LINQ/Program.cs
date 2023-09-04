using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica4.LINQ.Entities;
using Practica4.LINQ.Logic;

namespace Practica4.LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomersLogic customersLogic = new CustomersLogic();
            ProductsLogic productsLogic = new ProductsLogic();
            bool keep = true;
            while (keep)
            {
                int exercise = 14;

                Console.WriteLine("\n1. Lista de Clientes\n" +
                                    "2. Lista de Productos sin stock\n" +
                                    "3. Lista de Productos en stock +$3\n" +
                                    "4. Lista de clientes de Wa\n" +
                                    "5. Ejercicio 5\n" +
                                    "6. Nombres de los Clientes en mayuscula y minuscula" +
                                    "7. Lista de Clientes de Wa y productos de 1997 para arriba\n" +
                                    "8. Lista de los tres primeros Clientes de Wa\n" +
                                    "9. Lista de Productos ordenados por nombre\n" +
                                    "10. Lista de Productos ordenados por stock, de mayor a menor\n" +
                                    "11. Lista de Categorias y sus productos\n" +
                                    "12. Primer Producto de la lista\n" +
                                    "13. Ejercicio 13\n" +
                                    "0. Salir");
                try
                {
                    exercise = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.Message);
                }    


                switch (exercise)
                {
                    case 1:


                        customersLogic.GetAllCustomers().ForEach(x => Console.WriteLine($"[ID]{x.CustomerID} - [NOMBRE]{x.ContactName}"));
                        string id = "";
                        bool comprobarId = true;

                        while (comprobarId)
                        {
                            Console.WriteLine("Seleccione cliente por su Id:\n");
                            id = Console.ReadLine();
                            foreach (Customers customers in customersLogic.GetAllCustomers())
                            {
                                if (id.ToLower() == customers.CustomerID.ToLower())
                                {
                                    comprobarId = false;
                                }
                            }
                        }

                        Customers customer = customersLogic.GetCustomer(id);

                        Console.WriteLine($"[ID]{customer.CustomerID} - [NOMBRE]{customer.ContactName}");
                        

                        break;

                    case 2:

                        Console.WriteLine("Productos sin stock:\n");

                        foreach (Products products in productsLogic.StocklessProducts())
                        {
                            Console.WriteLine($"{products.ProductName}");
                        }

                        break;

                    case 3:

                        Console.WriteLine("Productos en stock que duelen mas de $3 por unidad:\n");

                        foreach (Products products in productsLogic.MoreThan3())
                        {
                            Console.WriteLine($"[NOMBRE]: {products.ProductName}"+$" [PRECIO]: {products.UnitPrice} [STOCK]: {products.UnitsInStock}");
                        }

                        break;

                    case 4:

                        Console.WriteLine("Clientes de Wa:\n");

                        foreach (Customers customers in customersLogic.WaCustomers())
                        {
                            Console.WriteLine($"[ID]{customers.CustomerID} - Nombre: {customers.ContactName} - Reguion: {customers.Region}");
                        }
                        break;

                    case 5:

                        break;

                    case 6:

                        Console.WriteLine("Nombre de los Clientes:\n");

                        foreach (Customers customers in customersLogic.CustomersName())
                        {
                            Console.WriteLine($"[ID]{customers.CustomerID} - NombreMinus: {customers.ContactName.ToLower()} - NombreMayus: {customers.ContactName.ToUpper()}");
                        }

                        break;

                    case 7:
                        
                        Console.WriteLine("Clientes de Wa y Regiones :\n");

                        foreach (object customers in customersLogic.JoinOrders())
                        {
                            Console.WriteLine(customers);
                        }

                        break;

                    case 8:
                        
                        Console.WriteLine("Tres primeros clientes de Wa:\n");

                        foreach (Customers customers in customersLogic.ThreeFirst())
                        {
                            Console.WriteLine($"[ID]{customers.CustomerID} - Nombre: {customers.ContactName} - Reguion: {customers.Region}");
                        }

                        break;

                    case 9:

                        Console.WriteLine("Productos ordenados por nombre:\n");

                        foreach (Products products in productsLogic.NameProducts())
                        {
                            Console.WriteLine($"[ID]{products.ProductID} - [Nombre]{products.ProductName}");
                        }

                        break;

                    case 10:

                        Console.WriteLine("Productos ordenados por stock:\n");

                        foreach (Products products in productsLogic.StockOrder())
                        {
                            Console.WriteLine($"[ID]{products.ProductID} - [Stock]{products.UnitsInStock} - [Nombre]{products.ProductName}");
                        }

                        break;

                    case 11:

                        Console.WriteLine("Categorias de los productos:\n");

                        foreach (object products in productsLogic.CategoryProducts())
                        {
                            Console.WriteLine(products);
                        }

                        break;

                    case 12:

                        Console.WriteLine("Primer producto:\n");

                        Products productRef = productsLogic.FirstProduct();


                            Console.WriteLine($"[ID]{productRef.ProductID} - [Nombre] {productRef.ProductName}");
                       
                        break;

                    case 13:

                        Console.WriteLine("Clientes con sus ordenes asociads:\n");

                    

                        foreach (var customers in customersLogic.CantOrders())
                        {
                            Console.WriteLine(customers);
                        }

                        break;

                    case 0:
                        keep = false;
                        break;

                    default:
                        Console.WriteLine("\nPor favor, ingrese una opcion valida");
                        break;
                }
            }

            Console.ReadKey();

        }
    
    }
}
