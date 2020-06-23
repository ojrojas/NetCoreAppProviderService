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
using Microsoft.AspNetCore.Identity;
using Cinte.Infraestructure.Identity;

namespace App.Controllers
{
    public class ManageController : Controller
    {
        private readonly ILogger<ManageController> _logger;
        private readonly IConfiguration _config;
        private readonly ICacheProvider _cache;

        /// <summary>
        /// Interface que expone los servicios de SignInManager de netcore para el logueo
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private SignInManager<Usuario> _signInManager;

        public ManageController(
            ILogger<ManageController> logger,
            IConfiguration config,
            ICacheProvider cache,
             SignInManager<Usuario> signInManager)
        {
            _cache = cache;
            _logger = logger;
            _config = config;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
             var peticiones = FactoryProvider.CrearProvider(_config, _cache);
                var resultadoPeticion = await peticiones.PostConsultarTokenAsync(login);
         
            if (resultadoPeticion.Token_Auth != null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalido email y contraseña");
                return View();
            }
        }
    }
}
