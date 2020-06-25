using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Models;
using Microsoft.Extensions.Configuration;
using Orojas.Api.Models.ViewModels;
using Orojas.Core.Infraestructure;
using App.Utils;
using Microsoft.AspNetCore.Authorization;
using Orojas.Infraestructure.Identity;

namespace App.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IConfiguration _config;
        private readonly ICacheProvider _cache;

        public UsuarioController(
            ILogger<UsuarioController> logger,
            IConfiguration config,
            ICacheProvider cache)
        {
            _cache = cache;
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string uripeticion = "http://localhost:5002/manage";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            var usuarios = await peticiones.GetAsync<IReadOnlyList<Usuario>>();
            return View(usuarios);
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(string Id)
        {
            string uripeticion = $"http://localhost:5002/manage/{Id}";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            var usuario = await peticiones.GetAsync<Usuario>();
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                string uripeticion = "http://localhost:5002/manage";
                var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
                var algo = await peticiones.PostAsync<object>(usuario);
                return View();
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> EliminarAsync(string Id)
        {
            string uripeticion = $"http://localhost:5002/manage/{Id}";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            var usuario = await peticiones.GetAsync<Usuario>();
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                string uripeticion = $"http://localhost:5002/manage/{usuario.Id}";
                var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
                await peticiones.DeleteAsync<object>(usuario);
                return View();
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(string Id)
        {
            string uripeticion = $"http://localhost:5002/manage/{Id}";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            var usuario = await peticiones.GetAsync<Usuario>();
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                string uripeticion = "http://localhost:5002/manage";
                var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
                await peticiones.PutAsync<object>(usuario);
                return View();
            }
            return View(usuario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
