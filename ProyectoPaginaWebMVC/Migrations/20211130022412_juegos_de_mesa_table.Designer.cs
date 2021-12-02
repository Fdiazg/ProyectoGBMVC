﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoPaginaWebMVC;

namespace ProyectoPaginaWebMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211130022412_juegos_de_mesa_table")]
    partial class juegos_de_mesa_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.Disenador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biografia")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SitioWeb")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Disenadores");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.Editorial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<int>("DuracionMax")
                        .HasColumnType("int");

                    b.Property<int>("DuracionMin")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("EditorialId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("NumJugadoresMax")
                        .HasColumnType("int");

                    b.Property<int>("NumJugadoresMin")
                        .HasColumnType("int");

                    b.Property<string>("PortadaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("EditorialId");

                    b.ToTable("JuegosDeMesa");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesaCategoria", b =>
                {
                    b.Property<int>("JuegoDeMesaId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.HasKey("JuegoDeMesaId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("JuegosDeMesaCategorias");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesaDisenador", b =>
                {
                    b.Property<int>("JuegoDeMesaId")
                        .HasColumnType("int");

                    b.Property<int>("DisenadorId")
                        .HasColumnType("int");

                    b.HasKey("JuegoDeMesaId", "DisenadorId");

                    b.HasIndex("DisenadorId");

                    b.ToTable("JuegosDeMesaDisenadores");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesaMecanica", b =>
                {
                    b.Property<int>("JuegoDeMesaId")
                        .HasColumnType("int");

                    b.Property<int>("MecanicaId")
                        .HasColumnType("int");

                    b.HasKey("JuegoDeMesaId", "MecanicaId");

                    b.HasIndex("MecanicaId");

                    b.ToTable("JuegosDeMesaMecanicas");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.Mecanica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Mecanicas");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesa", b =>
                {
                    b.HasOne("ProyectoPaginaWebMVC.Models.Entidades.Editorial", "Editorial")
                        .WithMany("JuegosDeMesa")
                        .HasForeignKey("EditorialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editorial");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesaCategoria", b =>
                {
                    b.HasOne("ProyectoPaginaWebMVC.Models.Entidades.Categoria", "Categoria")
                        .WithMany("JuegosDeMesaCategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesa", "JuegoDeMesa")
                        .WithMany("JuegosDeMesaCategorias")
                        .HasForeignKey("JuegoDeMesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("JuegoDeMesa");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesaDisenador", b =>
                {
                    b.HasOne("ProyectoPaginaWebMVC.Models.Entidades.Disenador", "Disenador")
                        .WithMany("JuegosDeMesaDisenadores")
                        .HasForeignKey("DisenadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesa", "JuegoDeMesa")
                        .WithMany("JuegosDeMesaDisenadores")
                        .HasForeignKey("JuegoDeMesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disenador");

                    b.Navigation("JuegoDeMesa");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesaMecanica", b =>
                {
                    b.HasOne("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesa", "JuegoDeMesa")
                        .WithMany("JuegosDeMesaMecanicas")
                        .HasForeignKey("JuegoDeMesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoPaginaWebMVC.Models.Entidades.Mecanica", "Mecanica")
                        .WithMany("JuegosDeMesaMecanicas")
                        .HasForeignKey("MecanicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JuegoDeMesa");

                    b.Navigation("Mecanica");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.Categoria", b =>
                {
                    b.Navigation("JuegosDeMesaCategorias");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.Disenador", b =>
                {
                    b.Navigation("JuegosDeMesaDisenadores");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.Editorial", b =>
                {
                    b.Navigation("JuegosDeMesa");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.JuegoDeMesa", b =>
                {
                    b.Navigation("JuegosDeMesaCategorias");

                    b.Navigation("JuegosDeMesaDisenadores");

                    b.Navigation("JuegosDeMesaMecanicas");
                });

            modelBuilder.Entity("ProyectoPaginaWebMVC.Models.Entidades.Mecanica", b =>
                {
                    b.Navigation("JuegosDeMesaMecanicas");
                });
#pragma warning restore 612, 618
        }
    }
}