using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Controllers
{
    public class TemaController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Crear()
        {
            ViewBag.Message = "Pantalla de crear";
            return View();
        }

        [HttpPost] // esto sirve para que solo acepte peticiones http POST
        public ViewResult Crear(string nombre, string descripcion)
        {
            ViewBag.Message = "Pantalla de crear";
            return View();
        }
    }
}