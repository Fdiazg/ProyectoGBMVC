using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models.Entidades
{
    public class Disenador
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [MaxLength(1500)]
        public string Biografia { get; set; }
        public string ImagenUrl { get; set; }
        [MaxLength(255)]
        public string SitioWeb { get; set; }
        public List<JuegoDeMesaDisenador> JuegosDeMesaDisenadores { get; set; }

    }
}
