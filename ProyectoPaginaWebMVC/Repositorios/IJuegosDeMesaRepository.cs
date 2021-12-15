using ProyectoPaginaWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Repositorios
{
    public interface IJuegosDeMesaRepository
    {
        Task Actualizar(JuegoDeMesaEdicionModel model);
        Task<JuegoDeMesaEdicionModel> BuscarPorId(int id);
        Task Eliminar(int id);
        Task Guardar(JuegoDeMesaCreacionModel model);
        Task<JuegoDeMesaCreacionModel> NuevoJuegoCreacionModel();
        Task<List<JuegoDeMesaModel>> ObtenerTodo();
    }
}
