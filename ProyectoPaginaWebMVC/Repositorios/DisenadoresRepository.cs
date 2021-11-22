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
    public class DisenadoresRepository : IDisenadoresRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DisenadoresRepository(ApplicationDbContext context, IMapper  mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<DisenadorModel>> ObtenerTodos()
        {
            var entities = await _context.Disenadores.ToListAsync();
            var models = _mapper.Map<List<DisenadorModel>>(entities);
            return models;
        }

        public async Task Guardar(DisenadorCreacionModel model)
        {
            var entities = _mapper.Map<Disenador>(model); //Se crea una categoria a partir de un modelo
            _context.Disenadores.Add(entities);
            await _context.SaveChangesAsync();

        }

        public async Task<DisenadorEdicionModel> BuscarPorId(int id)
        {
            var entidad = await _context.Disenadores.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<DisenadorEdicionModel>(entidad);
            return model;
        }

        public async Task Actualizar(DisenadorEdicionModel model)
        {
            var entidad = await _context.Disenadores.FirstOrDefaultAsync(x => x.Id == model.Id);
            entidad.Nombre = model.Nombre;
            entidad.FechaNacimiento = Convert.ToDateTime(model.FechaNacimiento);
            entidad.Biografia = model.Biografia;
            entidad.SitioWeb = model.SitioWeb;
            entidad.ImagenUrl = model.ImagenUrl;
            await _context.SaveChangesAsync();

        }

        public async Task Eliminar(int id)
        {
            var entidad = await _context.Disenadores.FirstOrDefaultAsync(x => x.Id == id);
            _context.Disenadores.Remove(entidad);
            await _context.SaveChangesAsync();
        }

    }
}
