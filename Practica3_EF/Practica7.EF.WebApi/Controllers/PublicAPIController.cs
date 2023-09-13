using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica7.EF.WebApi.Controllers
{
    public class PublicAPIController : Controller
    {
        // GET: PublicAPI
        public ActionResult Index()
        {
            return View();
        }
    }
}