using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoCurso.Models;

namespace ProyectoCurso.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente

        [HttpGet]
        public ActionResult Index()
        {
            List<ClienteCLS> listaCliente = null;
            using (var bd = new BDPasajeEntities()) 
            {
                listaCliente = (from cliente in bd.Cliente
                                where cliente.BHABILITADO==1
                                select new ClienteCLS 
                                {
                                    iddcliente= cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    appaterno = cliente.APPATERNO,
                                    apmaterno = cliente.APMATERNO,
                                    telefonofijo = cliente.TELEFONOFIJO
                                }).ToList();
            }
                
            return View(listaCliente);
        }

        //GET: De Sexo a Cliente
        List<SelectListItem> listasexo;
        private void llenarsexo() 
        {
            using (var db = new BDPasajeEntities()) 
            {
                listasexo = (from sexo in db.Sexo
                            where sexo.BHABILITADO == 1
                            select new SelectListItem 
                            {
                                Text=sexo.NOMBRE,
                                Value=sexo.IIDSEXO.ToString()
                            }).ToList();
                listasexo.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }
        public ActionResult Agregar()
        {
            llenarsexo();
            ViewBag.lista = listasexo;
            return View();
        }
    }
}