using Practica3.EF.Entities;
using Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Practica3_EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool runApp = true;
            int optionMenu;
           
            while (runApp)
            {

                Console.WriteLine("\nHola, bienvenido al sistema de gestion de la base de datos Northwind, " +
                              "que desea realizar? \n1-Visualizar Tablas \n2-Editar Tablas\n3-Salir\n");

                optionMenu = SelectOption();

                switch (optionMenu)
                {
                    case 1:

                        ViewTable();

                        break;

                    case 2:


                        break;

                    case 3:
                        runApp = false;
                        break;
                    default:
                        Console.WriteLine("Por favor elija una opción valida.");
                        break;
                }

            }

            Console.WriteLine("Gracias por su tiempo.");

            Console.ReadKey();
        }

        private static void ViewTable()
        {
            bool keep = true;
            int viewOption = 0;

            while (keep)
            {
                Console.WriteLine("\nSeleccione una tabla para visualizar\n1-Customers\n2-Employees\n3-Volver al menu principal.");
                try
                {
                    viewOption = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {

                    Console.WriteLine($"\n{e.Message}");

                }


                switch (viewOption)
                {
                    case 1:
                        CustomersLogic customersLogic = new CustomersLogic();

                        foreach (Customers customer in customersLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.ContactName} - {customer.CompanyName}");
                        }
                        break;

                    case 2:
                        EmployeesLogic employeesLogic = new EmployeesLogic();

                        foreach (Employees employees in employeesLogic.GetAll())
                        {
                            Console.WriteLine($"{employees.LastName} {employees.FirstName} - {employees.BirthDate}");
                        }
                        break;

                    case 3:
                        keep = false;
                        break;
                    default:
                        Console.WriteLine("Por favor elija una opción valida.");
                        keep = true;
                        break;
                }



            }
        }


        private static int SelectOption() 
        {
            bool keep = true;
            int selectedOption = 0;

            while (keep)
            {
                
                try
                {
                    selectedOption = int.Parse(Console.ReadLine());
                    keep = false;

                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.Message);                  
             
                }
            }
            return selectedOption;
        }

       
    }
}
