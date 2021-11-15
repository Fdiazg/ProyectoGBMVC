using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoPaginaWebMVC.Models;
using ProyectoPaginaWebMVC.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Repositorios
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriasRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CategoriaModel>> ObtenerTodos()
        {
            var entities = await _context.Categorias.ToListAsync();
            var models = _mapper.Map<List<CategoriaModel>>(entities);
            return models;
        }

        public async Task GuardarCategoria(CategoriaCreacionModel model)
        {
            var entities = _mapper.Map<Categoria>(model); //Se crea una categoria a partir de un modelo
            _context.Categorias.Add(entities);
            await _context.SaveChangesAsync();

        }

        public async Task<CategoriaEdicionModel> BuscarCategoriaPorId(int id)
        {
            var entidad = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<CategoriaEdicionModel>(entidad);
            return model;
        }

        public async Task ActualizarCategoria (CategoriaEdicionModel model)
        {
            var entidad = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == model.Id);
            entidad.Nombre = model.Nombre;
            await _context.SaveChangesAsync();

        }
        public async Task EliminarCategoria(int id)
        {
            var entidad = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            _context.Categorias.Remove(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
