using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models.Entidades
{
    public class JuegoDeMesaDisenador
    {
        public int DisenadorId { get; set; }
        public int JuegoDeMesaId { get; set; }
        public Disenador Disenador { get; set; }
        public JuegoDeMesa JuegoDeMesa { get; set; }
    }
}
