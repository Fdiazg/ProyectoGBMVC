using AutoMapper;
using ProyectoPaginaWebMVC.Models;
using ProyectoPaginaWebMVC.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Helpers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Categoria, CategoriaModel>();
            CreateMap<CategoriaCreacionModel, Categoria>();
            CreateMap<Categoria, CategoriaEdicionModel>();
            CreateMap<Editorial, EditorialModel>();
            CreateMap<EditorialCreacionModel, Editorial>();
            CreateMap<Editorial, EditorialEdicionModel>();
            CreateMap<Disenador, DisenadorModel>();
            CreateMap<DisenadorCreacionModel, Disenador>();
            CreateMap<Disenador, DisenadorEdicionModel>();
            CreateMap<Disenador, DisenadorListaModel>();
            CreateMap<Mecanica, MecanicaModel>();
            CreateMap<MecanicaCreacionModel, Mecanica>();
            CreateMap<Mecanica, MecanicaEdicionModel>();
            CreateMap<JuegoDeMesaCreacionModel, JuegoDeMesa>()
                .ForMember(juego => juego.JuegosDeMesaDisenadores, opciones => opciones.MapFrom(MapJuegoDeMesaDisenador))
                .ForMember(juego => juego.JuegosDeMesaCategorias, opciones => opciones.MapFrom(MapJuegoDeMesaCategoria))
                .ForMember(juego => juego.JuegosDeMesaMecanicas, opciones => opciones.MapFrom(MapJuegoDeMesaMecanica))
                ;
            CreateMap<JuegoDeMesa, JuegoDeMesaModel>()
                .ForMember(juegoDeMesaModel => juegoDeMesaModel.DisenadorNombre, opciones => opciones.MapFrom(juego=>juego.JuegosDeMesaDisenadores.FirstOrDefault().Disenador.Nombre))
                .ForMember(juegoDeMesaModel => juegoDeMesaModel.CategoriaNombre, opciones => opciones.MapFrom(juego => juego.JuegosDeMesaCategorias.FirstOrDefault().Categoria.Nombre))
                .ForMember(juegoDeMesaModel => juegoDeMesaModel.MecanicaNombre, opciones => opciones.MapFrom(juego => juego.JuegosDeMesaMecanicas.FirstOrDefault().Mecanica.Nombre))
                .ForMember(juegoDeMesaModel => juegoDeMesaModel.Disenadores, opciones => opciones.MapFrom(juego => juego.JuegosDeMesaDisenadores.Select(x=> x.Disenador)))
                .ForMember(juegoDeMesaModel => juegoDeMesaModel.Categorias, opciones => opciones.MapFrom(juego => juego.JuegosDeMesaCategorias.Select(x => x.Categoria.Nombre)))
                .ForMember(juegoDeMesaModel => juegoDeMesaModel.Mecanicas, opciones => opciones.MapFrom(juego => juego.JuegosDeMesaMecanicas.Select(x => x.Mecanica.Nombre)))

                ;
        }

        private List<JuegoDeMesaDisenador> MapJuegoDeMesaDisenador(JuegoDeMesaCreacionModel juegoDeMesaCreacionModel, JuegoDeMesa juego )
        {
            var resultado = new List<JuegoDeMesaDisenador>();
            if(juegoDeMesaCreacionModel.DisenadorId == null)
            {
                return resultado;
            }

            foreach (var id in juegoDeMesaCreacionModel.DisenadorId)
            {
                resultado.Add(new JuegoDeMesaDisenador { DisenadorId = id});

            }
            return resultado;
        }
        private List<JuegoDeMesaCategoria> MapJuegoDeMesaCategoria(JuegoDeMesaCreacionModel juegoDeMesaCreacionModel, JuegoDeMesa juego)
        {
            var resultado = new List<JuegoDeMesaCategoria>();
            if (juegoDeMesaCreacionModel.CategoriaId == null)
            {
                return resultado;
            }

            foreach (var id in juegoDeMesaCreacionModel.CategoriaId)
            {
                resultado.Add(new JuegoDeMesaCategoria { CategoriaId = id });
            }

            return resultado;
        }

        private List<JuegoDeMesaMecanica> MapJuegoDeMesaMecanica(JuegoDeMesaCreacionModel juegoDeMesaCreacionModel, JuegoDeMesa juego)
        {
            var resultado = new List<JuegoDeMesaMecanica>();
            if (juegoDeMesaCreacionModel.MecanicaId == null)
            {
                return resultado;
            }

            foreach (var id in juegoDeMesaCreacionModel.MecanicaId)
            {
                resultado.Add(new JuegoDeMesaMecanica { MecanicaId = id });
            }
            return resultado;
        }
    }
}
