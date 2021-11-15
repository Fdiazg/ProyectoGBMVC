using Microsoft.AspNetCore.Mvc;
using ProyectoPaginaWebMVC.Models;
using ProyectoPaginaWebMVC.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Controllers
{
    public class EditorialesController : Controller
    {
 
        private readonly IEditorialesRepository _repository;

        public EditorialesController(IEditorialesRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var editoriales = await _repository.ObtenerTodos();
            return View(editoriales);
        }

        public IActionResult NuevaEditorial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NuevaEditorial(EditorialCreacionModel model)
        {
            if (ModelState.IsValid)
            {
                await _repository.GuardarEditorial(model);
                var lista = await _repository.ObtenerTodos();
                return View("index", lista);
            }
            return View("NuevaEditorial", model);
        }

        public async Task<IActionResult> EditarEditorial([FromRoute] int id)
        {
            var editorial = await _repository.BuscarEditorialPorId(id);
            return View(editorial);
        }

        [HttpPost]
        public async Task<IActionResult> EditarEditorial(EditorialEdicionModel model)
        {
            if (ModelState.IsValid)
            {
                await _repository.ActualizarEditorial(model);
                var lista = await _repository.ObtenerTodos();
                return View("Index", lista);
            }
            return View("EditarEditorial", model);
        }

        public async Task<IActionResult> EliminarEditorial([FromRoute] int id)
        {
            var editorial = await _repository.BuscarEditorialPorId(id);
            return View(editorial);
        }
        [HttpPost]
        public async Task<IActionResult> EliminarEditorial(EditorialEdicionModel model)
        {
            await _repository.EliminarEditorial(model.Id);
            var lista = await _repository.ObtenerTodos();
            return View("Index", lista);
        }
    }
}

