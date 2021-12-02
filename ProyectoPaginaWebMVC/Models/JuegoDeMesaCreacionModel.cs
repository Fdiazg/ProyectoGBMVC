using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models
{
    public class JuegoDeMesaCreacionModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(255,ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Año de lanzamiento")]

        public int? Anio { get; set; }
        [MaxLength(1500, ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; }
        public int? NumJugadoresMin { get; set; }
        public int? NumJugadoresMax { get; set; }
        public int? DuracionMin { get; set; }
        public int? DuracionMax { get; set; }
        public int? Edad { get; set; }

        [MaxLength(255)]
        public string Trailer { get; set; }
        public IFormFile Portada { get; set; }
        public string PortadaUrl { get; set; }

        public int? EditorialId { get; set; }
        public List<int> DisenadorId { get; set; }
        public List<int> MecanicaId { get; set; }
        public List<int> CategoriaId { get; set; }
        public SelectList Disenadores { get; set; }
        public SelectList Editoriales { get; set; }
        public SelectList Mecanicas { get; set; }
        public SelectList Categorias { get; set; }


    }
}
