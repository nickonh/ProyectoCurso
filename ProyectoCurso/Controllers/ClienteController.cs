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
        //--------------------Peticiones o GET's---------------
        //--------------------GET: Cliente---------------------

        /*ESTA FUNCION RECIBE DE LA CLASE CLIENTECLS, EL CONTENIDO DE ESTE EN LA BD, DONDE CADA CLIENTE ESTE HABILITADO == 1, CUYOS PARAMETROS SOLICITADOS SON IDDCLIENTE
         * NOMBRE, APPATERNO, APMATERNO, TELEFONOFIJO, ESTOS PARAMETROS SERAN GUARDADOS EN LA LISTA listaCliente*/
        [HttpGet]
        public ActionResult Index()
        {
            List<ClienteCLS> listaCliente = null;
            using (var bd = new BDPasajeEntities())
            {
                listaCliente = (from cliente in bd.Cliente
                                where cliente.BHABILITADO == 1
                                select new ClienteCLS
                                {
                                    iddcliente = cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    appaterno = cliente.APPATERNO,
                                    apmaterno = cliente.APMATERNO,
                                    telefonofijo = cliente.TELEFONOFIJO,
                                    telefonocelular = cliente.TELEFONOCELULAR
                                }).ToList();
            }

            return View(listaCliente);
        }

        public ActionResult Editar(int id) 
        {
            ClienteCLS oClienteCLS = new ClienteCLS();
            using (var bd = new BDPasajeEntities()) 
            {
                llenarSexo();
                ViewBag.lista = listaSexo;

                Cliente oCliente = bd.Cliente.Where(p => p.IIDCLIENTE.Equals(id)).First();
                oClienteCLS.iddcliente = oCliente.IIDCLIENTE;
                oClienteCLS.nombre = oCliente.NOMBRE;
                oClienteCLS.appaterno = oCliente.APPATERNO;
                oClienteCLS.apmaterno = oCliente.APMATERNO;
                oClienteCLS.iddsexo = (int) oCliente.IIDSEXO;
                oClienteCLS.direccion = oCliente.DIRECCION;
                oClienteCLS.telefonofijo = oCliente.TELEFONOFIJO;
                oClienteCLS.telefonocelular = oCliente.TELEFONOCELULAR;
                oClienteCLS.email = oCliente.EMAIL;
            }
                return View(oClienteCLS);
        }

        //---------------------GET: De Sexo a Cliente---------------------
        //---------------------FUNCIONES DEL GET---------------------

        /*ESTA FUNCION LLENA UNA listasexo CUYO CONTENIDO ESTA EN LA BD, CONSTRUYE UNA PEQUENIA Tabla PARA SELECCINAR EL SEXO*/
        List<SelectListItem> listaSexo;
        private void llenarSexo()
        {
            using (var db = new BDPasajeEntities())
            {
                listaSexo = (from sexo in db.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.IIDSEXO.ToString()
                             }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }
        public ActionResult Agregar()
        {
            llenarSexo();
            ViewBag.lista = listaSexo;

            return View();
        }
        //--------------------POST---------------
        //

        //AGREGANDO INFORMACION LEIDO DE UN COMBOBOX
        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS) 
        {
            //Validacion; EL COMBOBOX DEBE SER LLENADDO SINO SE CAE
            if (!ModelState.IsValid) 
            {
                llenarSexo();
                ViewBag.lista = listaSexo;
                return View(oClienteCLS);
            }

            using (var bd= new BDPasajeEntities()) 
            {
                Cliente oCliente = new Cliente();
                oCliente.NOMBRE = oClienteCLS.nombre;
                oCliente.APPATERNO = oClienteCLS.appaterno;
                oCliente.APMATERNO = oClienteCLS.apmaterno;
                oCliente.EMAIL = oClienteCLS.email;
                oCliente.DIRECCION = oClienteCLS.direccion;
                oCliente.IIDSEXO = oClienteCLS.iddsexo;
                oCliente.TELEFONOFIJO = oClienteCLS.telefonofijo;
                oCliente.TELEFONOCELULAR = oClienteCLS.telefonocelular;
                oCliente.BHABILITADO = 1;
                //INSERCION
                bd.Cliente.Add(oCliente);
                bd.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}