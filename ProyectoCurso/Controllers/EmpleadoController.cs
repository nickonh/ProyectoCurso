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
    }
}