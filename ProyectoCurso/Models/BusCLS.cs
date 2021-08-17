using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoCurso.Models
{
    public class BusCLS
    {
        [Display(Name ="Id Bus")]
        [Required]
        public int iidbus { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [Required]
        public int iidsucursal { get; set; }
        [Display(Name = "Tipo Bus")]
        [Required]
        public int iidtipobus { get; set; }
        [Display(Name = "Patente")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud Maxima 100 Caracteres")]
        public string placa { get; set; }
        [Display(Name = "Fecha Compra")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechacompra { get; set; }
        [Display(Name = "Nombre Modelo")]
        [Required]
        public int idmodelo { get; set; }
        [Display(Name = "Numero Filas")]
        [Required]
        public int numerofilas { get; set; }
        [Display(Name = "Numero Columna")]
        [Required]
        public int numerocolumnas { get; set; }
        public int bhabilitado { get; set; }
        [Display(Name = "Discripcion")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200 Caracteres")]
        public string descripcion { get; set; }
        [Display(Name = "Observacion")]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200 Caracteres")]
        public string observacion { get; set; }
        [Display(Name = "Nombre Marca")]
        [Required]
        
        public int iidmarca { get; set; }



        //Propiedades add

        [Display(Name = "Nombre Sucursal")]
        public string nombresucursal { get; set; }
        [Display(Name = "Tipo Bus")]
        public string nombretipobus { get; set; }
        [Display(Name = "Nombre Modelo")]
        public string nombremodelo { get; set; }

    }
}