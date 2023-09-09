using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica3.EF.Entities;
using Practica3.EF.Logic;
using Practica3.EF.MVC.Models;

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

        public ActionResult Insert() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeesView employeesViews) 
        {
            try
            {
                //TODO: No permitir que ingrese un valor nulo. Id autoincremental.
                Employees employeesEntity = new Employees { FirstName = employeesViews.firstName, LastName = employeesViews.lastName };
                logic.Add(employeesEntity);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return RedirectToAction ("Index","Error");
            }
        }
        //TODO: Arreglar compatibilidad con customer y el id.
        public ActionResult Delete(Employees id) 
        {
            logic.Delete(id);
            return RedirectToAction("index");
        }
    }
}