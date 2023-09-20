using Practica3.EF.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Practica3.EF.Logic
{
    public class EmployeesLogic : BaseLogic, ILogic<Employees>
    {
        public void Add(Employees newEmployees)
        {
            try
            {

                if (newEmployees.FirstName != null && newEmployees.LastName != null)
                {

                    context.Employees.Add(newEmployees);

                    context.SaveChanges();

                }
                else
                {
                    throw new NullReferenceException("Los campos nombre y apellido son obligatorios.");
                }

            }
            catch (NullReferenceException)
            {

                throw new NullReferenceException("El empleado se pudo agregar");
            }
            catch (Exception)
            {

                throw new Exception("El empleado se pudo agregar");
            }

        }

        public void Delete(Employees deleteEmployee)
        {

            Employees employeeDelete = context.Employees.Find(deleteEmployee.EmployeeID);
            if (employeeDelete != null)
            {

                List<Territories> territoriesList = new List<Territories>(deleteEmployee.Territories);

                foreach (var territories in territoriesList)
                {
                    context.Territories.Remove(territories);

                }

                List<Orders> orderList = new List<Orders>(deleteEmployee.Orders);

                foreach (var orders in orderList)
                {
                    List<Order_Details> detailsList = new List<Order_Details>(orders.Order_Details);
                    foreach (var dOrders in detailsList)
                    {
                        context.Order_Details.Remove(dOrders);
                    }
                    context.Orders.Remove(orders);

                }

                context.Employees.Remove(employeeDelete);

                context.SaveChanges();

            }
            else
            {
                throw new NullReferenceException("No existe el Empleado que desea eliminar");
            }


        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employees GetById(int id)
        {
            try
            {
                var employee = context.Employees.Where(e => e.EmployeeID == id).FirstOrDefault();
                return employee;

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("No se encontró el ID deseado");
            }
            catch (Exception)
            {

                throw;
            }



        }


        public void Update(Employees employees)
        {
            try
            {
                var employeesUpdate = context.Employees.Find(employees.EmployeeID);
                if (employees.LastName == null || employees.FirstName == null)
                    throw new NullReferenceException("Los campos nombre y apellido son obligatorios.");

                employeesUpdate.LastName = employees.LastName;
                employeesUpdate.FirstName = employees.FirstName;
                employeesUpdate.HomePhone = employees.HomePhone;

                context.SaveChanges();

            }
            catch (InvalidOperationException)
            {

                throw new InvalidOperationException("No se pudo realizar la operacion.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}