using ProyectoPaginaWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Repositorios
{
    public interface IMecanicasRepository
    {
        Task Actualizar(MecanicaEdicionModel model);
        Task<MecanicaEdicionModel> BuscarPorId(int id);
        Task Eliminar(int id);
        Task Guardar(MecanicaCreacionModel model);
        Task<List<MecanicaModel>> ObtenerTodos();
    }
}
