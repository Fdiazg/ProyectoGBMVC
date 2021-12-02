using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models
{
    public class JuegoDeMesaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Anio { get; set; }
        public string Descripcion { get; set; }
        public int NumJugadoresMin { get; set; }
        public int NumJugadoresMax { get; set; }
        public int DuracionMin { get; set; }
        public int DuracionMax { get; set; }

        public int Edad { get; set; }
        public string Trailer { get; set; }
        public string PortadaUrl { get; set; }
        public string EditorialNombre { get; set; }
        public string MecanicaNombre { get; set; }
        public string DisenadorNombre { get; set; }
        public string CategoriaNombre { get; set; }
        public List<DisenadorListaModel> Disenadores { get; set; }
        public List<string> Categorias { get; set; }
        public List<string> Mecanicas { get; set; }
    }
}
