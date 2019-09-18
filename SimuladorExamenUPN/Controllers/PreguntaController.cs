using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Controllers
{
    public class PreguntaController : Controller
    {
        private SimuladorContext context;

        public PreguntaController()
        {
            context = new SimuladorContext();
        }

        [HttpGet]
        public ActionResult Index(string criterio)
        {
            var preguntas = context.Preguntas.AsQueryable();

            if (!string.IsNullOrEmpty(criterio))

                preguntas.Where(o => o.Descripcion.Contains(criterio));

            return View(preguntas.Include(o => o.Tema).ToList());
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Temas = context.Temas.ToList();
            return View(new Pregunta());
        }

        [HttpPost]
        public ActionResult Crear(Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Temas = context.Temas.ToList();
                return View(pregunta);
            }

            context.Preguntas.Add(pregunta);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            ViewBag.Temas = context.Temas.ToList();
            var pregunta = context.Preguntas.Find(id);
            return View(pregunta);
        }

        [HttpPost]
        public ActionResult Editar(Pregunta pregunta)
        {
            if (!ModelState.IsValid)
                return View(pregunta);

            context.Entry(pregunta).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var pregunta = context.Preguntas.Find(id);
            context.Preguntas.Remove(pregunta);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}