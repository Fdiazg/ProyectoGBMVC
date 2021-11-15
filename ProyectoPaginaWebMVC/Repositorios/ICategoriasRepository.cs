using ProyectoPaginaWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Repositorios
{
    public interface ICategoriasRepository
    {
        Task ActualizarCategoria(CategoriaEdicionModel model);
        Task<CategoriaEdicionModel> BuscarCategoriaPorId(int id);
        Task EliminarCategoria(int id);
        Task GuardarCategoria(CategoriaCreacionModel model);
        Task<List<CategoriaModel>> ObtenerTodos();
    }
}
