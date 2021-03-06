using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoCurso.Models;

namespace ProyectoCurso.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> listaEmpleado = null;
            using (var bd = new BDPasajeEntities()) 
            {
                listaEmpleado= (from empleado in bd.Empleado
                               join tipousuario in bd.TipoUsuario
                               on empleado.IIDTIPOUSUARIO equals tipousuario.IIDTIPOUSUARIO
                               join tipocontrato in bd.TipoUsuario
                               on empleado.IIDTIPOCONTRATO equals tipocontrato.IIDTIPOUSUARIO
                               where empleado.BHABILITADO == 1
                               //Formamos la lista a mostrar.
                               select new EmpleadoCLS
                               {
                                   iddempleado = empleado.IIDEMPLEADO,
                                   nombre = empleado.NOMBRE,
                                   appaterno = empleado.APPATERNO,
                                   apmaterno = empleado.APMATERNO,
                                   nombretipousuario= tipousuario.NOMBRE,
                                   nombretipocontrato= tipocontrato.NOMBRE
                               }).ToList();
            }
                return View(listaEmpleado);
        }

        public void llenarSexo()
        {
            //Agregar
            List<SelectListItem> listaEmSexo;
            using (var db=new BDPasajeEntities()) 
            {
                listaEmSexo = (from sexo in db.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.IIDSEXO.ToString()
                             }).ToList();
            }
            listaEmSexo.Insert(0, new SelectListItem { Text = "--Seleccione--", Value ="" });
            ViewBag.LSexo = listaEmSexo;
        }

        public void llenarTipoContrato()
        {
            //Agregar
            List<SelectListItem> listaTipoContrato;
            using (var db = new BDPasajeEntities())
            {
                listaTipoContrato = (from tipoContrato in db.TipoContrato
                                     where tipoContrato.BHABILITADO == 1
                                     select new SelectListItem
                                     {
                                         Text = tipoContrato.NOMBRE,
                                         Value = tipoContrato.IIDTIPOCONTRATO.ToString()
                                     }).ToList();
            }
            listaTipoContrato.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            ViewBag.TContrato = listaTipoContrato;
        }

        public void llenarTipoUsuario()
        {
            //Agregar
            List<SelectListItem> listaTipoUsuario;
            using (var db = new BDPasajeEntities())
            {
                listaTipoUsuario = (from tipoUsuario in db.TipoUsuario
                                     where tipoUsuario.BHABILITADO == 1
                                     select new SelectListItem
                                     {
                                         Text = tipoUsuario.NOMBRE,
                                         Value = tipoUsuario.IIDTIPOUSUARIO.ToString()
                                     }).ToList();
            }
            listaTipoUsuario.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            ViewBag.TUsuario = listaTipoUsuario;
        }

        public void ListarCombos() 
        {
            llenarSexo();
            llenarTipoContrato();
            llenarTipoUsuario();

        }
        public ActionResult Agregar() 
        {
            ListarCombos();
            return View();
        }
    }
}