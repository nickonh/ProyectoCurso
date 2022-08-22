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
        public ActionResult Agregar() 
        {
            ListarCombo();
            return View();
        }
        //-----Llenado de los ComboBox-----
        public void llenarTipoBus() 
        {
            List<SelectListItem> listaTipoBus;
            using (var db = new BDPasajeEntities())
            {
                listaTipoBus = (from item in db.TipoBus
                                where item.BHABILITADO == 1
                                select new SelectListItem
                                {
                                    Text = item.NOMBRE,
                                    Value = item.IIDTIPOBUS.ToString()
                                }).ToList();
            }
            listaTipoBus.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            ViewBag.TipoBus = listaTipoBus;
        }

        public void llenarMarcaBus()
        {
            List<SelectListItem> listaMarcaBus;
            using (var db = new BDPasajeEntities())
            {
                listaMarcaBus = (from item in db.Marca
                                where item.BHABILITADO == 1
                                select new SelectListItem
                                {
                                    Text = item.NOMBRE,
                                    Value = item.IIDMARCA.ToString()
                                }).ToList();
            }
            listaMarcaBus.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            ViewBag.MarcaBus = listaMarcaBus;
        }

        public void llenarModeloBus()
        {
            List<SelectListItem> listaModeloBus;
            using (var db = new BDPasajeEntities())
            {
                listaModeloBus = (from item in db.Modelo
                                 where item.BHABILITADO == 1
                                 select new SelectListItem
                                 {
                                     Text = item.NOMBRE,
                                     Value = item.IIDMODELO.ToString()
                                 }).ToList();
            }
            listaModeloBus.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            ViewBag.ModeloBus = listaModeloBus;
        }

        public void llenarSucursalBus()
        {
            List<SelectListItem> listaSucursalBus;
            using (var db = new BDPasajeEntities())
            {
                listaSucursalBus = (from item in db.Sucursal
                                  where item.BHABILITADO == 1
                                  select new SelectListItem
                                  {
                                      Text = item.NOMBRE,
                                      Value = item.IIDSUCURSAL.ToString()
                                  }).ToList();
            }
            listaSucursalBus.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            ViewBag.SucursalBus = listaSucursalBus;
        }

        public void ListarCombo() 
        {
            llenarTipoBus();
            llenarMarcaBus();
            llenarModeloBus();
            llenarSucursalBus();
        }
    }
}