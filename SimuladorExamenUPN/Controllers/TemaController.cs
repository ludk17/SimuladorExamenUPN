using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Controllers
{
    public class TemaController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var context = new SimuladorContext();
            var temas = context.Temas.ToList();
            return View(temas);
        }

        [HttpGet]
        public ViewResult Crear()
        {
            ViewBag.Message = "Pantalla de crear";
            return View(new Tema());
        }

        [HttpPost] // esto sirve para que solo acepte peticiones http POST
        public ActionResult Crear(Tema tema)
        {
            var context = new SimuladorContext();

            //bool pasoValicacion = EsValido(tema);   
            //if (tema.Nombre == null || tema.Nombre == "")
            //    ModelState.AddModelError("Nombre", "Nombre es obligatorio");
            //if (tema.Descripcion == null || tema.Descripcion == "")
            //    ModelState.AddModelError("Descripcion", "Descripcion es obligatorio...");

            if (ModelState.IsValid == true)
            {
                context.Temas.Add(tema);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(tema);
            }
        }

        [HttpGet]
        public ViewResult Editar(int id)
        {
            var context = new SimuladorContext();
            
            Tema tema = context.Temas.Where(x => x.Id == id).First();
            
            return View(tema);
        }

        [HttpPost]
        public ViewResult Editar(Tema tema)
        {
            return View();
        }

        //private bool EsValido(Tema tema)
        //{
        //    var pasoValicacion = true;
        //    if (tema.Nombre == null || tema.Nombre == "")
        //    {
        //        ViewBag.NombreValicion = "Nombre es obligatorio";
        //        pasoValicacion = false;
        //    }

        //    if (tema.Descripcion == null || tema.Descripcion == "")
        //    {
        //        ViewBag.DescripcionValicion = "Descripción es obligatorio";
        //        pasoValicacion = false;
        //    }

        //    return pasoValicacion;
        //}
    }
}