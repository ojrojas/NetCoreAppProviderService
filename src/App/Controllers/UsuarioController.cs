using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Models;
using Cinte.Infraestructure.RequestProvider;
using Microsoft.Extensions.Configuration;
using Api;
using Cinte.Api.Models.ViewModels;
using Cinte.Core.Infraestructure;
using App.Utils;
using Microsoft.AspNetCore.Authorization;
using Cinte.Infraestructure.Identity;

namespace App.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
            var login = new LoginViewModel{ Email="algo", Contrasena="algo", Recuerdame=true};
            var algo =await peticiones.PostConsultarTokenAsync(login);
            var usuarios = await peticiones.GetAsync<List<Usuario>>();
            return View(usuarios);
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(string id)
        {
              string uripeticion = "http://localhost:5002/usuario/CrearUsuarioApp";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            var usuarios = await peticiones.GetAsync<object>();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
     
        [HttpPost]
        public async Task<IActionResult> Crear(UsuarioViewModel usuario)
        {
            string uripeticion = "http://localhost:5002/manage";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            var algo = await peticiones.PostAsync<object>(usuario);
            return View();
        }

        [HttpGet]
        public IActionResult Eliminar()
        {
         return View();
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(UsuarioViewModel usuario)
        {
            string uripeticion = "http://localhost:5002/manage/EliminarUsuario";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            await peticiones.PostAsync<object>(usuario);
            return View();
        }

        [HttpGet]
        public IActionResult Actulizar()
        {
         return View();
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(UsuarioViewModel usuario)
        {
            string uripeticion = "http://localhost:5002/manage/EliminarUsuario";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            await peticiones.PostAsync<object>(usuario);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
