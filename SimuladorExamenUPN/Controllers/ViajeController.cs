using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Controllers
{
    public class ViajeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new SimuladorContext();
            var id = Session["PersonaId"];
            db.Viajes.Where(o => o.Persona == id);

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var db = new SimuladorContext();

            ViewBag.Destinos = GetUbicaciones();
            ViewBag.Taxis = db.Taxis.ToList();
            return View(new Viaje());
        }

        [HttpPost]
        public ActionResult Create(Viaje viaje)
        {
            var db = new SimuladorContext();
            if (!ModelState.IsValid)
            {
                ViewBag.Destinos = GetUbicaciones();
                ViewBag.Taxis = db.Taxis.ToList();
                return View(viaje);
            }

            db.Viajes.Add(viaje);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public String GetRandomUbicacion()
        {
            var rnd = new Random();
            var ubicaciones = GetUbicaciones();
            int index = rnd.Next(ubicaciones.Count);
            return ubicaciones.ElementAt(index);
        }

        public String GetConductor(int taxiId)
        {
            var db = new SimuladorContext();
            var taxi = db.Taxis.Where(o => o.Id == taxiId).FirstOrDefault();
            if (taxi != null)
                return taxi.Conductor;
            return "";
        }


        private List<String> GetUbicaciones()
        {
            return new List<String> {
                "Ubicacion 1", "Ubicacion 2", "Ubicacion 3",
                "Ubicacion 4", "Ubicacion 5", "Ubicacion 6", "Ubicacion 7", "Ubicacion 8", "Ubicacion 9", "Ubicacion 10"
            };
        }
    }
}