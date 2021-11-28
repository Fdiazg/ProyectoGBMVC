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
    public class MecanicasRepository : IMecanicasRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MecanicasRepository (ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MecanicaModel>> ObtenerTodos()
        {
            var entities = await _context.Mecanicas.ToListAsync();
            var models = _mapper.Map<List<MecanicaModel>>(entities);
            return models;
        }

        public async Task Guardar(MecanicaCreacionModel model)
        {
            var entities = _mapper.Map<Mecanica>(model);
            _context.Mecanicas.Add(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<MecanicaEdicionModel> BuscarPorId (int id)
        {
            var entidad = await _context.Mecanicas.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<MecanicaEdicionModel>(entidad);
            return model;
        }

        public async Task Actualizar (MecanicaEdicionModel model)
        {
            var entidad = await _context.Mecanicas.FirstOrDefaultAsync(x => x.Id == model.Id);
            entidad.Nombre = model.Nombre;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar (int id)
        {
            var entidad = await _context.Mecanicas.FirstOrDefaultAsync(x => x.Id == id);
            _context.Mecanicas.Remove(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
