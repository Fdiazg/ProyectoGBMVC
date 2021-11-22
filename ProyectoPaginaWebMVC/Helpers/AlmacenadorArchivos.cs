using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPaginaWebMVC.Helpers
{
    public class AlmacenadorArchivos : IAlmacenadorArchivos
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AlmacenadorArchivos(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GuardarArchivo (IFormFile archivo, string carpeta)
        {
            using var fileStream = archivo.OpenReadStream();
            byte[] contenido = new byte[archivo.Length];
            fileStream.Read(contenido, 0, (int)archivo.Length);

            string extension = Path.GetExtension(archivo.FileName);

            var filename = $"{Guid.NewGuid()}{extension}"; //Guarda GUID.jpg

            string folder = Path.Combine(_env.WebRootPath, carpeta);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string rutaGuardado = Path.Combine(folder, filename);
            await File.WriteAllBytesAsync(rutaGuardado, contenido);
            var urlActual = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var urlParaBd = Path.Combine(urlActual, carpeta, filename);

            return urlParaBd;

        }

        public Task EliminarArchivo(string url, string nombreCarpeta)
        {
            var nombreArchivo = Path.GetFileName(url);
            string directorioArchivo = Path.Combine(_env.WebRootPath, nombreCarpeta, nombreArchivo);
            if (File.Exists(directorioArchivo))
            {
                File.Delete(directorioArchivo);
            }
            return Task.FromResult(0);
        }

    }
}
