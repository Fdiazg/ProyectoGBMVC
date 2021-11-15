using Microsoft.AspNetCore.Mvc;
using ProyectoPaginaWebMVC.Models;
using ProyectoPaginaWebMVC.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Controllers
{
    public class CategoriasController: Controller
    {
        private readonly ICategoriasRepository _repository;

        public CategoriasController(ICategoriasRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var categorias = await _repository.ObtenerTodos();
            return View(categorias);
        }

        public IActionResult NuevaCategoria()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NuevaCategoria(CategoriaCreacionModel model)
        {
            if(ModelState.IsValid)
            {
                await _repository.GuardarCategoria(model);
                var lista = await _repository.ObtenerTodos();
                return View("index", lista);
            }
            return View("NuevaCategoria", model);
        }

        public  async Task<IActionResult> EditarCategoria([FromRoute] int id)
        {
            var categoria = await _repository.BuscarCategoriaPorId(id);
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> EditarCategoria(CategoriaEdicionModel model)
        {
            if(ModelState.IsValid)
            {
                await _repository.ActualizarCategoria(model);
                var lista = await _repository.ObtenerTodos();
                return View("Index", lista);
            }
            return View("EditarCategoria", model);
        }

        public  async Task<IActionResult> EliminarCategoria([FromRoute] int id)
        {
            var categoria = await _repository.BuscarCategoriaPorId(id);
            return View(categoria);
        }
        [HttpPost]
        public async Task<IActionResult> EliminarCategoria(CategoriaEdicionModel model)
        {
            await _repository.EliminarCategoria(model.Id);
            var lista = await _repository.ObtenerTodos();
            return View("Index",lista);
        }
    }
}
