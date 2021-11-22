using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Models
{
    public class DisenadorModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Biografia { get; set; }
        public string SitioWeb { get; set; }
    }
}
