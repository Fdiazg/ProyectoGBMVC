using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models
{
    public class UsuarioCreacionModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string Email { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Password { get; set; }
    }
}
