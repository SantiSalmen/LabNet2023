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
                                    "6. Ejercicio 6\n" +
                                    "7. Ejercicio 7\n" +
                                    "8. Ejercicio 8\n" +    
                                    "9. Ejercicio 9\n" +
                                    "10 Ejercicio 10\n" +
                                    "11. Ejercicio 11\n" +
                                    "12. Ejercicio 12\n" +
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

                        Console.WriteLine("Clientes:\n");

                        foreach (Customers customers in customersLogic.GetCustomers())
                        {
                            Console.WriteLine($"[{customers.CustomerID}] - {customers.CompanyName} - {customers.ContactName}" +
                                              $"{customers.ContactTitle} - {customers.City} - {customers.Phone}");
                        }

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

                        break;

                    case 7:

                        break;

                    case 8:

                        break;

                    case 9:

                        break;

                    case 10:

                        break;

                    case 11:

                        break;

                    case 12:

                        break;

                    case 13:

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
