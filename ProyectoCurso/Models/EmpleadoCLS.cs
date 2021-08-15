using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoCurso.Models
{
    public class EmpleadoCLS
    {
        [Display(Name = "Id Empleado")]

        public int iddempleado { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud Maxima 100")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200")]
        public string appaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200")]
        public string apmaterno { get; set; }
        [Display(Name = "Fecha Contrato")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechacontrato { get; set; }
        [Display(Name = "Tipo Usuario")]
        [Required]
        public int iddtipousuario { get; set; }
        [Display(Name = "Tipo Contrato")]
        [Required]
        public int iddtipocontrato { get; set; }
        [Display(Name = "Sexo")]
        [Required]
        public int iddsexo { get; set; }
        public int bhabilitado { get; set; }

        //--------------------Propiedades Adicionales--------------------

        public string nombretipocontrato { get; set; }
        public string nombretipousuario { get; set; }
    }
}