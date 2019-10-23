using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ViewResult Page1() {
            return View();
        }

        public ViewResult Page2()
        {
            return View();
        }

        public ViewResult Ciudades(int pais)
        {
            var ciudades = GetCiudades(pais);
            return View(ciudades);
        }

        private List<String> GetCiudades(int pais)
        {
            //return db.Ciudades.Where(o => o.PaisId == pais).ToList()
            switch(pais)
            {
                case 1:
                    return new List<string> { "Lima", "Cajamarca", "La Libertad" };
                case 2:
                    return new List<string> { "Bueno Aires", "Mendoza", "Rosario" };
                default:
                    return new List<string>();
            }
        }
    }
}