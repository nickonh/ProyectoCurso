using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoCurso.Models;

namespace ProyectoCurso.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        public ActionResult Index()
        {
            List<BusCLS> listaBus = null;
            using (var bd= new BDPasajeEntities()) 
            {
                listaBus = (from bus in bd.Bus
                            join sucursal in bd.Sucursal
                            on bus.IIDSUCURSAL equals sucursal.IIDSUCURSAL
                            join tipoBus in bd.TipoBus
                            on bus.IIDTIPOBUS equals tipoBus.IIDTIPOBUS
                            join tipoModelo in bd.Modelo
                            on bus.IIDMODELO equals tipoModelo.IIDMODELO
                            where bus.BHABILITADO == 1
                            select new BusCLS
                            {
                                iidbus = bus.IIDBUS,
                                placa = bus.PLACA,
                                nombremodelo = tipoModelo.NOMBRE,
                                nombretipobus = tipoBus.NOMBRE,
                                nombresucursal = sucursal.NOMBRE,

                            }).ToList();


            }
                return View(listaBus);
        }
    }
}