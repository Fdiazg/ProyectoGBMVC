using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models.Entidades
{
    public class JuegoDeMesaCategoria
    {
        public int JuegoDeMesaId { get; set; }
        public int CategoriaId { get; set; }
        public JuegoDeMesa JuegoDeMesa { get; set; }
        public Categoria Categoria { get; set; }
    }
}
