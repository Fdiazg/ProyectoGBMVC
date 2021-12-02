using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models.Entidades
{
    public class JuegoDeMesa
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }
        public int Anio { get; set; }
        [MaxLength(1500)]
        public string Descripcion { get; set; }
        public int NumJugadoresMin { get; set; }
        public int NumJugadoresMax { get; set; }

        public int DuracionMin { get; set; }
        public int DuracionMax { get; set; }

        public int Edad { get; set; }
        [MaxLength(255)]
        public string Trailer { get; set; }
        public string PortadaUrl { get; set; }
        public int EditorialId { get; set; }
        public Editorial Editorial { get; set; }
        public List<JuegoDeMesaMecanica> JuegosDeMesaMecanicas { get; set; }
        public List<JuegoDeMesaCategoria> JuegosDeMesaCategorias { get; set; }
        public List<JuegoDeMesaDisenador> JuegosDeMesaDisenadores { get; set; }


    }
}
