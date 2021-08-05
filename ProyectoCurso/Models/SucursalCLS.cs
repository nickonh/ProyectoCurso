using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ProyectoCurso.Models
{
    public class SucursalCLS
    {
        [Display(Name = "Id Sucursal")]
        public int iidsucursal { get; set; }

        [Display(Name = "Nombre Sucursal")]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Direccion")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [Required]
        public string direccion { get; set; }

        [Display(Name = "Telefono")]
        [StringLength(10, ErrorMessage = "Longitud maxima 10")]
        [Required]
        public string telefono { get; set; }

        [Display(Name = "E-Mail")]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        [EmailAddress(ErrorMessage ="Ingrese un email valido")]
        [Required]
        public string email { get; set; }

        [Required]
        [Display(Name = "Fecha Apertura")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaapertura { get; set; }
        public int bhabilitado { get; set; }

    }
}