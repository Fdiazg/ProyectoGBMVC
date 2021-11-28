using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models
{
    public class MecanicaEdicionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(255, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        public string Nombre { get; set; }
    }
}
