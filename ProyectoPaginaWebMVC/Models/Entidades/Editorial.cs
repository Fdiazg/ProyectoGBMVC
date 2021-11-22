using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models.Entidades
{
    public class Editorial
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]

        public string Nombre { get; set; }
    }
}
