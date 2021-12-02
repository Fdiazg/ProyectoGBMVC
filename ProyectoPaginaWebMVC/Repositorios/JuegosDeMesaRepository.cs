using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoPaginaWebMVC.Models;
using ProyectoPaginaWebMVC.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Repositorios
{
    public class JuegosDeMesaRepository : IJuegosDeMesaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDisenadoresRepository _disenadoresRepository;
        private readonly IMecanicasRepository _mecanicasRepository;
        private readonly ICategoriasRepository _categoriasRepository;
        private readonly IEditorialesRepository _editorialesRepository;

        public JuegosDeMesaRepository(ApplicationDbContext context, IMapper mapper, 
            IDisenadoresRepository disenadoresRepository,
            IMecanicasRepository mecanicasRepository,
            ICategoriasRepository categoriasRepository,
            IEditorialesRepository editorialesRepository)
        {
            _context = context;
            _mapper = mapper;
            _disenadoresRepository = disenadoresRepository;
            _mecanicasRepository = mecanicasRepository;
            _categoriasRepository = categoriasRepository;
            _editorialesRepository = editorialesRepository;
        }
        public async Task<JuegoDeMesaCreacionModel> NuevoJuegoCreacionModel()
        {
            var resultado = new JuegoDeMesaCreacionModel();
            var listaDisenadores = await _disenadoresRepository.ObtenerTodos();
            var listaMecanica = await _mecanicasRepository.ObtenerTodos();
            var listaCategoria = await _categoriasRepository.ObtenerTodos();
            var listaEditorial = await _editorialesRepository.ObtenerTodos();

            var selectListDisenadores = new SelectList(listaDisenadores, "Id", "Nombre");
            var selectListMecanicas = new SelectList(listaMecanica, "Id", "Nombre");
            var selectListCategorias = new SelectList(listaCategoria, "Id", "Nombre");
            var selectListEditoriales = new SelectList(listaEditorial, "Id", "Nombre");

            resultado.Disenadores = selectListDisenadores;
            resultado.Mecanicas = selectListMecanicas;
            resultado.Categorias = selectListCategorias;
            resultado.Editoriales = selectListEditoriales;


            return resultado;
        }
        public async Task Guardar(JuegoDeMesaCreacionModel model)
        {
            var entities = _mapper.Map<JuegoDeMesa>(model); //Se crea una categoria a partir de un modelo
            _context.JuegosDeMesa.Add(entities);
            await _context.SaveChangesAsync();

        }

        public async Task<List<JuegoDeMesaModel>> ObtenerTodo()
        {
            var entidades = await _context.JuegosDeMesa
                .Include(j=>j.Editorial)
                .Include(j=>j.JuegosDeMesaDisenadores)
                .ThenInclude(jd=>jd.Disenador)
                .Include(j=>j.JuegosDeMesaCategorias)
                .ThenInclude(jc=>jc.Categoria)
                .Include(j=>j.JuegosDeMesaMecanicas)
                .ThenInclude(jm=>jm.Mecanica)
                .ToListAsync();
            var resultado = _mapper.Map<List<JuegoDeMesaModel>>(entidades);
            return resultado;
        }
    }
}
