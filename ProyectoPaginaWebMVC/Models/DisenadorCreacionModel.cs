using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models
{
    public class DisenadorCreacionModel
    {

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [MaxLength(255,ErrorMessage ="El campo {0} debe tener como máximo {1} caracteres")]
        public string Nombre { get; set; }

        //[Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(1500, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        public string Biografia { get; set; }
        public string ImagenUrl { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        public string SitioWeb { get; set; }
        public IFormFile Imagen { get; set; }
    }
}
