using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCurso.Models
{
    public class ClienteCLS
    {
        [Display(Name = "Id Cliente")]
        public int iddcliente { get; set; }

        [Display(Name = "Nombre Cliente")]
        [StringLength(100, ErrorMessage ="Longitud Maxima 100 Caracteres")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [StringLength(150, ErrorMessage = "Longitud Maxima 150 Caracteres")]
        [Required]
        public string appaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [StringLength(150, ErrorMessage = "Longitud Maxima 150 Caracteres")]
        [Required]
        public string apmaterno { get; set; }

        [Display(Name = "E-Mail")]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200 Caracteres")]
        [EmailAddress(ErrorMessage ="Ingrese un Mail valido")]
        [Required]
        public string email { get; set; }

        [Display(Name = "Direccion")]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200 Caracteres")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string direccion { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public int iddsexo { get; set; }

        [Display(Name = "Telefono")]
        [StringLength(10, ErrorMessage = "Longitud Maxima 10 Caracteres")]
        public string telefonofijo { get; set; }

        [Display(Name ="Celular")]
        [StringLength(10, ErrorMessage = "Longitud Maxima 10 Caracteres")]
        [Required]
        public string telefonocelular { get; set; }
        public int bhabilitado { get; set; }
        public int btieneusuario { get; set; }
    }
}