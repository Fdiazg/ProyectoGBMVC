using ProyectoPaginaWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Repositorios
{
    public interface IEditorialesRepository
    {
        Task ActualizarEditorial(EditorialEdicionModel model);
        Task<EditorialEdicionModel> BuscarEditorialPorId(int id);
        Task EliminarEditorial(int id);
        Task GuardarEditorial(EditorialCreacionModel model);
        Task<List<EditorialModel>> ObtenerTodos();
    }
}
