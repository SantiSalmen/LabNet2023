using Practica3.EF.Entities;
using Practica3.EF.Logic;
using Practica3.EF.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica3.EF.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesLogic logic = new EmployeesLogic();

        // GET: Employees
        public ActionResult Index()
        {
            List<Employees> employees = logic.GetAll();
            List <EmployeesView> employeesViews = employees.Select(e => new EmployeesView
            {
                id = e.EmployeeID,
                firstName = e.FirstName,
                lastName = e.LastName,
            }).ToList();
            return View(employeesViews);
        }


        public ActionResult Delete(int id)
        {
            Employees employee = new Employees();

            foreach (Employees eList in logic.GetAll())
            {
                if (id == eList.EmployeeID)
                {
                    employee = eList;

                }

            }
            logic.Delete(employee);
            return RedirectToAction("index");
        }

        public ActionResult UpdateInsert() 
        {
            return View(); 
        }
      
        [HttpPost]
        public ActionResult UpdateInsert(EmployeesView employee)
        {

            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            
            if(employee.id == 0)
            {
                Employees employeesEntity = new Employees { FirstName = employee.firstName, LastName = employee.lastName };
                logic.Add(employeesEntity);
                return RedirectToAction("Index");
            }
            else
            {
                Employees employeesEntity = new Employees { EmployeeID = employee.id, FirstName = employee.firstName, LastName = employee.lastName };
                logic.Update(employeesEntity);
                return RedirectToAction("Index");

            }

        }

    }
}