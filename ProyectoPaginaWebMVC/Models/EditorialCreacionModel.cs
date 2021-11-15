using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models
{
    public class EditorialCreacionModel
    {
        [Required(ErrorMessage ="El campo nombre es requerido")]
        public string Nombre { get; set; }
    }
}
