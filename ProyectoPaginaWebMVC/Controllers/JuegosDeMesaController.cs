using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoPaginaWebMVC.Helpers;
using ProyectoPaginaWebMVC.Models;
using ProyectoPaginaWebMVC.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Controllers
{
    public class JuegosDeMesaController : Controller
    {
        private readonly IJuegosDeMesaRepository _repository;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly string Carpeta = "img_portadas";

        public JuegosDeMesaController(IJuegosDeMesaRepository repository, IAlmacenadorArchivos almacenadorArchivos)
        {
            _repository = repository;
            _almacenadorArchivos = almacenadorArchivos;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _repository.ObtenerTodo();
            return View(model);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Nuevo()
        {
            var model = await _repository.NuevoJuegoCreacionModel();

            return View(model);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Nuevo(JuegoDeMesaCreacionModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Portada != null)
                {
                    //Guardar la imagen

                    var urlPoster = await _almacenadorArchivos.GuardarArchivo(model.Portada, Carpeta);
                    model.PortadaUrl = urlPoster;
                }
                //Guardar en la bd
                await _repository.Guardar(model);
                return RedirectToAction("Index");
            }
            return View(model); 
        }
    }
}
