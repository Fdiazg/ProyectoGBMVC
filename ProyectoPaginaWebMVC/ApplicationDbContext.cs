using Microsoft.EntityFrameworkCore;
using ProyectoPaginaWebMVC.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; } //La entidad va en singular y la tabla en plural
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Disenador> Disenadores { get; set; }
    }
}
