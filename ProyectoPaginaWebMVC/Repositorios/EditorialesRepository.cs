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
    public class EditorialesRepository : IEditorialesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EditorialesRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EditorialModel>> ObtenerTodos()
        {
            var entities = await _context.Editoriales.ToListAsync();
            var models = _mapper.Map<List<EditorialModel>>(entities);
            return models;
        }

        public async Task GuardarEditorial(EditorialCreacionModel model)
        {
            var entities = _mapper.Map<Editorial>(model); //Se crea una categoria a partir de un modelo
            _context.Editoriales.Add(entities);
            await _context.SaveChangesAsync();

        }

        public async Task<EditorialEdicionModel> BuscarEditorialPorId(int id)
        {
            var entidad = await _context.Editoriales.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<EditorialEdicionModel>(entidad);
            return model;
        }
        public async Task ActualizarEditorial(EditorialEdicionModel model)
        {
            var entidad = await _context.Editoriales.FirstOrDefaultAsync(x => x.Id == model.Id);
            entidad.Nombre = model.Nombre;
            await _context.SaveChangesAsync();

        }
        public async Task EliminarEditorial(int id)
        {
            var entidad = await _context.Editoriales.FirstOrDefaultAsync(x => x.Id == id);
            _context.Editoriales.Remove(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
