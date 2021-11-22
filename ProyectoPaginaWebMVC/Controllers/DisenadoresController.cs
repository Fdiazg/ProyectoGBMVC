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
    public class DisenadoresController : Controller
    {
        private readonly IDisenadoresRepository _repositorio;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly string Carpeta = "img_disenadores";

        public DisenadoresController(IDisenadoresRepository repositorio, IAlmacenadorArchivos almacenadorArchivos)
        {
            _repositorio = repositorio;
            _almacenadorArchivos = almacenadorArchivos;
        }
        public async Task<IActionResult> Index()
        {
            var lista = await _repositorio.ObtenerTodos();
            return View(lista);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(DisenadorCreacionModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.Imagen !=null)
                {
                    var url = await _almacenadorArchivos.GuardarArchivo(model.Imagen, Carpeta);
                    model.ImagenUrl = url;
                }

                //Guardar en la BD
                await _repositorio.Guardar(model);
                return RedirectToAction("Index");

            }

            return View(model);
        }

        public async Task<IActionResult> Editar([FromRoute] int id)
        {
            //Buscar diseñador por Id
            var modelo = await _repositorio.BuscarPorId(id);
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(DisenadorEdicionModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Imagen != null)
                {
                    await _almacenadorArchivos.EliminarArchivo(model.ImagenUrl, Carpeta);
                    var nuevaUrl = await _almacenadorArchivos.GuardarArchivo(model.Imagen, Carpeta);
                    model.ImagenUrl = nuevaUrl;
                }
                //Guardar en la BD
                await _repositorio.Actualizar(model);
                return RedirectToAction("Index");

            }

            return View(model);
        }

        public async Task<IActionResult> Eliminar([FromRoute]int id)
        {
            var model = await _repositorio.BuscarPorId(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(DisenadorEdicionModel model)
        {
            var entidad = await _repositorio.BuscarPorId(model.Id);
            await _almacenadorArchivos.EliminarArchivo(entidad.ImagenUrl, Carpeta);
            //Eliminar
            await _repositorio.Eliminar(model.Id);
            return RedirectToAction("Index");
        }
    }
}
