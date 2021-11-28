using Microsoft.AspNetCore.Mvc;
using ProyectoPaginaWebMVC.Models;
using ProyectoPaginaWebMVC.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Controllers
{
    public class MecanicasController : Controller
    {
        private readonly IMecanicasRepository _repository;

        public MecanicasController(IMecanicasRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var mecanicas = await _repository.ObtenerTodos();
            return View(mecanicas);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(MecanicaCreacionModel model)
        {
            if (ModelState.IsValid)
            {
                await _repository.Guardar(model);
                var lista = await _repository.ObtenerTodos();
                return View("index", lista);
            }

            return View("Nuevo", model);
        }

        public async Task<IActionResult> Editar([FromRoute] int id)
        {
            var mecanica = await _repository.BuscarPorId(id);
            return View(mecanica);
        }
        [HttpPost]
        public async Task<IActionResult> Editar (MecanicaEdicionModel model)
        {
            if (ModelState.IsValid)
            {
                await _repository.Actualizar(model);
                var lista = await _repository.ObtenerTodos();
                return View("Index", lista);
            }

            return View("Editar", model);
        }

        public async Task<IActionResult> Eliminar ([FromRoute] int id)
        {
            var mecanica = await _repository.BuscarPorId(id);
            return View(mecanica);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar (MecanicaEdicionModel model)
        {
            await _repository.Eliminar(model.Id);
            var lista = await _repository.ObtenerTodos();
            return View("Index", lista);
        }
    }
}
