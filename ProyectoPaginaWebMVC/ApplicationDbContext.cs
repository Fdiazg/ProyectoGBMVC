using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoPaginaWebMVC.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JuegoDeMesaCategoria>()
                .HasKey(jc => new { jc.JuegoDeMesaId, jc.CategoriaId });
            modelBuilder.Entity<JuegoDeMesaMecanica>()
                .HasKey(jm => new { jm.JuegoDeMesaId, jm.MecanicaId });
            modelBuilder.Entity<JuegoDeMesaDisenador>()
                .HasKey(jd => new { jd.JuegoDeMesaId, jd.DisenadorId });
        }

        public DbSet<Categoria> Categorias { get; set; } //La entidad va en singular y la tabla en plural
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Disenador> Disenadores { get; set; }
        public DbSet<Mecanica> Mecanicas { get; set; }
        public DbSet<JuegoDeMesa> JuegosDeMesa { get; set; }
        public DbSet <JuegoDeMesaDisenador> JuegosDeMesaDisenadores { get; set; }
        public DbSet <JuegoDeMesaCategoria> JuegosDeMesaCategorias { get; set; }
        public DbSet <JuegoDeMesaMecanica> JuegosDeMesaMecanicas { get; set; }
    }
}
