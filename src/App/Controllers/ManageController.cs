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

namespace App.Controllers
{
    public class ManageController : Controller
    {
        private readonly ILogger<ManageController> _logger;
        private readonly IConfiguration _config;
        private readonly ICacheProvider _cache;

        public ManageController(
            ILogger<ManageController> logger,
            IConfiguration config,
            ICacheProvider cache)
        {
            _cache = cache;
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {

            var peticiones = FactoryProvider.CrearProvider(_config, _cache);
            var resultado = await peticiones.PostConsultarTokenAsync(login);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuarioAppAsync(UsuarioViewModel usuario)
        {
            string uripeticion = "http://localhost:5002/manage/CrearUsuarioApp";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            await peticiones.PostAsync<object>(usuario);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EliminarUsuario(UsuarioViewModel usuario)
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