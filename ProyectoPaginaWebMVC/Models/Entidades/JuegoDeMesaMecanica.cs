using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models.Entidades
{
    public class JuegoDeMesaMecanica
    {
        public int JuegoDeMesaId { get; set; }
        public int MecanicaId { get; set; }
        public JuegoDeMesa JuegoDeMesa { get; set; }
        public Mecanica Mecanica { get; set; }
    }
}
