using Practica3.EF.Entities;
using Practica3.EF.Logic;
using Practica7.EF.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Practica7.EF.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {
        EmployeesLogic logic = new EmployeesLogic();
        // GET: HelpPage/

        public IHttpActionResult Get()
        {
            try
            {

                var employees = this.logic.GetAll();
                List<EmployeesView> employeesViews = employees.Select(e => new EmployeesView
                {
                    id = e.EmployeeID,
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    homePhone = e.HomePhone,
                }).ToList();
                return Ok(employeesViews);

            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                Employees employees = this.logic.GetById(id);
                EmployeesView employeesView = new EmployeesView()
                {
                    id = employees.EmployeeID,
                    firstName = employees.FirstName,
                    lastName = employees.LastName,
                    homePhone = employees.HomePhone,
                };

                return Ok(employeesView);
            }
            catch (NullReferenceException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public IHttpActionResult Post([FromBody] EmployeesView employeesView)
        {
            try
            {
                Employees employee = new Employees()
                {
                    FirstName = employeesView.firstName,
                    LastName = employeesView.lastName,
                    HomePhone = employeesView.homePhone
                };
                this.logic.Add(employee);
                return Content(HttpStatusCode.Created, employee);
            }
            catch (NullReferenceException ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody] EmployeesView employee)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                Employees employeesEntity = new Employees { EmployeeID = employee.id, FirstName = employee.firstName, LastName = employee.lastName, HomePhone = employee.homePhone };
                logic.Update(employeesEntity);

                return Ok(employeesEntity);

            }
            catch (NullReferenceException e)
            {

                return Content(HttpStatusCode.NotFound, e.Message);
            }

        }


        public IHttpActionResult Delete(int id)
        {
            try
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
                return Ok();

            }
            catch (NullReferenceException e)
            {

                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }


    }
}