using ProyectoCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoCurso.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            List<SucursalCLS> listaSucursal = null;
            using (var db = new BDPasajeEntities())
            {
                listaSucursal = (from sucursal in db.Sucursal
                                 where sucursal.BHABILITADO == 1
                                 select new SucursalCLS
                                 {
                                     iidsucursal = sucursal.IIDSUCURSAL,
                                     nombre = sucursal.NOMBRE,
                                     direccion = sucursal.DIRECCION,
                                     telefono = sucursal.TELEFONO,
                                     email = sucursal.EMAIL,
                                 }).ToList();

            }
            return View(listaSucursal);
        }

        //POST: Sucursal Vista
        public ActionResult Agregar()
        {
            return View();
        }

        //POST: Sucursal
        [HttpPost]
        public ActionResult Agregar(SucursalCLS oSucursalCLS) 
        {
            if (!ModelState.IsValid)
            {
                return View(oSucursalCLS);
            }
             using (var bd = new BDPasajeEntities())
             {
                Sucursal oSucursal = new Sucursal();
                oSucursal.NOMBRE = oSucursalCLS.nombre;
                oSucursal.DIRECCION = oSucursalCLS.direccion;
                oSucursal.TELEFONO = oSucursalCLS.telefono;
                oSucursal.EMAIL = oSucursalCLS.email;
                oSucursal.FECHAAPERTURA = oSucursalCLS.fechaapertura;
                oSucursal.BHABILITADO = 1;
                bd.Sucursal.Add(oSucursal);
                bd.SaveChanges();
             }

            return RedirectToAction("Index");
        }
    }
}