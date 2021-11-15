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
        }
    }
}
