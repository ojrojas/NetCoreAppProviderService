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
using Orojas.App.Services.Interface;

namespace App.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            ILogger<UsuarioController> logger,
            IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _usuarioService.ObtenerUsuariosAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(string Id)
        {
            return View(await _usuarioService.ObtenerUsuarioAsync(Id));
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
                await _usuarioService.CrearUsuarioAsync(usuario);
                return View();
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> EliminarAsync(string Id)
        {
          var usuario = await _usuarioService.ObtenerUsuarioAsync(Id);
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.EliminarUsuarioAsync(usuario.Id);
                return View();
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(string Id)
        {
            return View(await _usuarioService.ObtenerUsuarioAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
               await _usuarioService.EditarUsuarioAsync(usuario);
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
