using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parcial.Models;

namespace Parcial.Controllers
{
    public class ConcesionariaController : Controller
    {
        // GET: Concesionaria
        public ActionResult Index()
        {
            ViewBag.showSuccessAlert = false;
            GestorBD gb = new GestorBD();
            var marcas = gb.Marcas();
            var model = new AutoMarcas();
            model.Marcas = marcas;
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Autos auto)
        {
            var modelo = new AutoMarcas();
            GestorBD gd = new GestorBD();
            if (!string.IsNullOrWhiteSpace(auto.Patente) &&
                 auto.Km > 0 && auto.PrecioReal >0)
            {
                ViewBag.showSuccessAlert = false;
                gd.InsertarAuto(auto);
                var valores = gd.Marcas();          
                modelo.Marcas = valores;
                return View(modelo);

            }
            else
            {        
                ViewBag.showSuccessAlert = true;
                var valores = gd.Marcas();
                modelo.Marcas = valores;
                return View(modelo);
            }
            
        }

        public ActionResult ListarOferta()
        {
            GestorBD gb = new GestorBD();
            var autos = gb.AutosOferta();
            return View(autos);
        }

        public ActionResult ListaMenosKM()
        {
            GestorBD gb = new GestorBD();
            var auto = gb.AutoMenosKM();
            return View(auto);
        }
    }
}

