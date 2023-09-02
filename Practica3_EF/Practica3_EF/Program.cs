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

                        EditMenu();
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

        private static void EditMenu()
        {
            bool keep = true;
            int viewOption = 0;

            while (keep)
            {
                Console.WriteLine("\nQue tabal quiere modificar? \n1-Customers\n2-Employees\n3-Volver al menu principal.");
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

                        CustomerEditor();

                        break;

                    case 2:

                        EmployeesEditor();
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

        private static void EmployeesEditor()
        {

            bool keep = true;
            int viewOption = 0;

            while (keep)
            {


                Console.WriteLine("Perfecto, usted ha seleccioonado la tabla Employees. ¿Como le gustaría modificarla? \n1-Añadir un elemento\n2-Modificar un elemento\n3-Eliminar un elemento\n4-Volver\n");


                try
                {
                    viewOption = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {

                    Console.WriteLine($"\n{e.Message}");

                }
                EmployeesLogic employeesLogic = new EmployeesLogic();

                switch (viewOption)
                {

                    case 1:

                        Console.WriteLine("Ingrese las caracteristicas de su nuevo Empleado");


                        string lastName = VerifyValue("Apellido", 20);
                        string firstName = VerifyValue("Nombre", 10);
                        string homePhone = VerifyValue("Telefono", 24);

                    

                        employeesLogic.Add(new Employees
                        {

                            LastName = lastName,

                            FirstName = firstName,

                            HomePhone = homePhone,

                        });



                        foreach (Employees employees in employeesLogic.GetAll())
                        {
                            Console.WriteLine($"{employees.EmployeeID} - {employees.LastName} {employees.FirstName} - Telefono: {employees.HomePhone}");
                        }

                        break;

                    case 2:

                        bool cont = true;

                        foreach (Employees employees in employeesLogic.GetAll())
                        {
                            Console.WriteLine($"{employees.EmployeeID} - {employees.LastName} {employees.FirstName} - Telefono: {employees.HomePhone}");
                        }

                        int employeeUpdate;

                        while (cont)
                        {
                            Console.WriteLine("\nIngrese el Id del Empleado a modificar");
                            employeeUpdate = int.Parse(Console.ReadLine());

                            foreach (Employees employees in employeesLogic.GetAll())
                            {
                                if (employeeUpdate == employees.EmployeeID)
                                {
                                    cont = false;


                                }

                            }


                        }

                        Console.WriteLine("\nIngrese los datos que desea modificar");

                        string mewlastName = VerifyValue("Apellido", 20);
                        string newFirstName = VerifyValue("Nombre", 10);
                        string newHomePhone = VerifyValue("Telefono", 24);

                        employeesLogic.Update(new Employees
                        {
                            LastName = mewlastName,

                            FirstName = newFirstName,

                            HomePhone = newHomePhone,

                        });

                        foreach (Employees employees in employeesLogic.GetAll())
                        {
                            Console.WriteLine($"{employees.EmployeeID} - {employees.LastName} {employees.FirstName} - Telefono: {employees.HomePhone}");
                        }

                        break;

                    case 3:
                        bool cont1 = true;

                        foreach (Employees employees in employeesLogic.GetAll())
                        {
                            Console.WriteLine($"{employees.EmployeeID} - {employees.LastName} {employees.FirstName} - Telefono: {employees.HomePhone}");
                        }


                        int employeeDelete;

                        Employees employees1 = new Employees();

                        while (cont1)
                        {
                            Console.WriteLine("\nIngrese el Id del Empleado a modificar");
                            employeeDelete = int.Parse(Console.ReadLine());

                            foreach (Employees employees in employeesLogic.GetAll())
                            {
                                if (employeeDelete == employees.EmployeeID)
                                {
                                    cont1 = false;
                                    employees1 = employees;

                                }

                            }


                        }

                        employeesLogic.Delete(employees1);

                        

                        foreach (Employees employees in employeesLogic.GetAll())
                        {
                            Console.WriteLine($"{employees.EmployeeID} - {employees.LastName} {employees.FirstName} - Telefono: {employees.HomePhone}");
                        }

                        Console.WriteLine("\nSe ha eliminado el Empleado");
                        break;

                    case 4:
                        keep = false;
                        break;

                    default:
                        Console.WriteLine("Por favor elija una opción valida.");
                        break;
                }
            }
           
        }

        private static void CustomerEditor()
        {
            bool keep = true;
            int viewOption = 0;


            CustomersLogic customersLogic = new CustomersLogic(); 

            while (keep)
            {
                Console.WriteLine("Perfecto, usted ha seleccioonado la tabla Clientes. ¿Como le gustaría modificarla? \n1-Añadir un elemento\n2-Modificar un elemento\n3-Eliminar un elemento\n4-Volver\n");
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

                        Console.WriteLine("Ingrese las caracteristicas de su nuevo Cliente");

                       
                        string id = VerifyValue("Id", 5);
                        string contactName= VerifyValue("Nombre de contacto", 40);
                        string companyName = VerifyValue("Nombre de compañia", 40);
                        string city = VerifyValue("Ciudad", 40);
                        string country = VerifyValue("País", 40);
                        string phone = VerifyValue("Telefono", 40);

                       

                        customersLogic.Add(new Customers
                        {
                            CustomerID= id,

                            ContactName = contactName,

                            CompanyName = companyName,

                            City = city,

                            Country= country,

                            Phone= phone,
                        });

                        foreach (Customers customer in customersLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.CompanyName}  - {customer.City}  - {customer.Country} - {customer.Phone}");
                        }
                        break;


                    case 2:
                        bool cont = true;

                        foreach (Customers customer in customersLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.CompanyName}  - {customer.City}  - {customer.Country} - {customer.Phone}");
                        }

                        string clientUpdate = "";
                        while (cont)
                        {
                            Console.WriteLine("\nIngrese el Id del Cliente a modificar");
                            clientUpdate = Console.ReadLine();

                            foreach (Customers customers in customersLogic.GetAll())
                            {
                                if (clientUpdate.ToLower() == customers.CustomerID.ToLower())
                                {
                                    cont = false;
                                    
                                }
                             
                            }

                            
                        }

                        Console.WriteLine("\nIngrese los datos que desea modificar");

                        string newContact = VerifyValue("Nombre de contacto", 40);
                        string newName = VerifyValue("Nombre de compañia", 40);
                        string newCity = VerifyValue("Ciudad", 40);
                        string newCountry = VerifyValue("País", 40);
                        string newPhone = VerifyValue("Telefono", 40);

                        customersLogic.Update(new Customers
                        {
                            CustomerID = clientUpdate,

                            ContactName = newContact,

                            CompanyName = newName,

                            City = newCity,

                            Country = newCountry,

                            Phone = newPhone,
                        }) ;

                        foreach (Customers customer in customersLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.CompanyName}  - {customer.City}  - {customer.Country} - {customer.Phone}");
                        }

                        break;

                    case 3:
                        bool cont1 = true;

                        foreach (Customers customer in customersLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.CompanyName}  - {customer.City}  - {customer.Country} - {customer.Phone}");
                        }

                        string clientDelete = "";

                        Customers customers1= new Customers(); 

                        while (cont1)
                        {
                            Console.WriteLine("\nIngrese el Id del Cliente a modificar");
                            clientDelete = Console.ReadLine();

                            foreach (Customers customers in customersLogic.GetAll())
                            {
                                if (clientDelete.ToLower() == customers.CustomerID.ToLower())
                                {
                                    cont1 = false;
                                    customers1 = customers;

                                }

                            }


                        }

                        customersLogic.Delete(customers1);

                        foreach (Customers customer in customersLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.CompanyName}  - {customer.City}  - {customer.Country} - {customer.Phone}");
                        }

                        Console.WriteLine("\nSe ha eliminado el Empleado");

                        break;

                    case 4:
                        keep = false;
                        break;

                    default:

                        Console.WriteLine("Por favor elija una opción valida.");
                        break;
                }
            }
        }

        private static string VerifyValue(string caracteristic,int character) 
        {
            bool keep = true;

            string parameter = "";
            while (keep)
            {
                Console.WriteLine($"El campo {caracteristic} permmite {character} caracteres");

                parameter = Console.ReadLine();

                if (parameter.Length < character && parameter != "")
                {
                    return parameter;
                }

                Console.WriteLine("Parametro no valido");
            }

            return parameter;

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
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.CompanyName}  - {customer.City}  - {customer.Country} - {customer.Phone}");
                        }
                        break;

                    case 2:
                        EmployeesLogic employeesLogic = new EmployeesLogic();

                        foreach (Employees employees in employeesLogic.GetAll())
                        {
                            Console.WriteLine($"{employees.EmployeeID} - {employees.LastName} {employees.FirstName} - Telefono: {employees.HomePhone}");
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
