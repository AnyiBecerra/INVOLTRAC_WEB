using SISTEMADEINGRESO.Models;
using SISTEMADEINGRESO.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISTEMADEINGRESO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Personas> ListPersonas = CRUD.ListaPersonas();
            return View(ListPersonas);
        }
    }
}