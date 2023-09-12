using Practica3.EF.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Practica3.EF.Logic
{
    public class EmployeesLogic : BaseLogic, ILogic<Employees>
    {
        public void Add(Employees newEmployees)
        {
            context.Employees.Add(newEmployees);

            context.SaveChanges();
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


        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Update(Employees employees)
        {
            var employeesUpdate = context.Employees.Find(employees.EmployeeID);

            employeesUpdate.LastName = employees.LastName;
            employeesUpdate.FirstName = employees.FirstName;
            employeesUpdate.HomePhone = employees.HomePhone;

            context.SaveChanges();
        }
    }
}
