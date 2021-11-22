using ProyectoPaginaWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Repositorios
{
    public interface IDisenadoresRepository
    {
        Task Actualizar(DisenadorEdicionModel model);
        Task<DisenadorEdicionModel> BuscarPorId(int id);
        Task Eliminar(int id);
        Task Guardar(DisenadorCreacionModel model);
        Task<List<DisenadorModel>> ObtenerTodos();
    }
}
