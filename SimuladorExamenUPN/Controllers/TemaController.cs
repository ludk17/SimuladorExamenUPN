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
    public class TemaController : Controller
    {
        public SimuladorContext context;
        public TemaController()
        {
           context = new SimuladorContext();
        }
        [HttpGet]
        public ViewResult Index(string criterio)
        {
         
            var temas = context.Temas.Include(a=>a.Categorias.Select(o=>o.Categoria)).AsQueryable();

            if (!string.IsNullOrEmpty(criterio))
                temas = temas.Where(o => o.Nombre.Contains(criterio));

            ViewBag.Criterio = criterio;
            return View(temas.ToList());
        }

        [HttpGet]
        public ViewResult Crear()
        {
            ViewBag.Categorias = context.Categorias.ToList();
            ViewBag.Message = "Pantalla de crear";
            return View(new Tema());
        }

        [HttpPost] // esto sirve para que solo acepte peticiones http POST
        public ActionResult Crear(Tema tema,List<int> Ids)
        {

            ViewBag.Categorias = context.Categorias.ToList();
            //bool pasoValicacion = EsValido(tema);   
            //if (tema.Nombre == null || tema.Nombre == "")
            //    ModelState.AddModelError("Nombre", "Nombre es obligatorio");
            //if (tema.Descripcion == null || tema.Descripcion == "")
            //    ModelState.AddModelError("Descripcion", "Descripcion es obligatorio...");

            if (ModelState.IsValid == true)
            {
               
                context.Temas.Add(tema);
                context.SaveChanges();
               

                foreach (var categoriaid in Ids)
                {
                   var temaCategoria = new TemaCategoria() { CategoriaId = categoriaid, TemaId = tema.Id };
                    context.TemaCategorias.Add(temaCategoria);
                    context.SaveChanges();
                }
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
            
            Tema tema = context.Temas.Where(x => x.Id == id).First();
            
                      
            return View(tema);
        }

        [HttpPost]
        public ActionResult Editar(Tema tema)
        {
            
            //Tema temaDB = context.Temas.Where(x => x.Id == tema.Id).First();
            //temaDB.Nombre = tema.Nombre;
            //temaDB.Descripcion = tema.Descripcion;
            //context.SaveChanges();
            if (ModelState.IsValid == true)
            {
                context.Entry(tema).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tema);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
           
            Tema tema = context.Temas.Where(x => x.Id == id).First();
            context.Temas.Remove(tema);
            context.SaveChanges();

            return RedirectToAction("Index");
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