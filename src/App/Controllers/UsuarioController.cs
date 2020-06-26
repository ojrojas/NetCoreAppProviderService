using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Models;
using Orojas.Api.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Orojas.App.Services.Interface;

namespace App.Controllers
{
    /// <summary>
    /// UsuarioController, expone los endpoint de usuariocontrolle
    /// </summary>
    /// <author>Oscar Julian Rojas Garces.</author>
    /// <date>26/06/2020</date>
    [Authorize]
    public class UsuarioController : Controller
    {
        /// <summary>
        /// Interface Logger para informacion de api
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly ILogger<UsuarioController> _logger;

        /// <summary>
        /// Interface IUsuarioService para exponer los metodos de UsuarioService
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly IUsuarioService _usuarioService;

        /// <summary>
        /// Contructor UsuarioController, para injectar las referencias de los servicios
        /// </summary>
        /// <param name="logger">Log de la aplicacion </param>
        /// <param name="usuarioService">UsuarioService expone las acciones para interacturar con la api</param>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        public UsuarioController(
            ILogger<UsuarioController> logger,
            IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _usuarioService.ObtenerUsuariosAsync());
        }

        /// <summary>
        /// Detalle
        /// </summary>
        /// <returns></returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>

        [HttpGet]
        public async Task<IActionResult> Detalle(string Id)
        {
            return View(await _usuarioService.ObtenerUsuarioAsync(Id));
        }

        /// <summary>
        /// Crear
        /// </summary>
        /// <returns></returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        /// <summary>
        /// Crear Post
        /// </summary>
        /// <returns></returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>

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

        /// <summary>
        /// Eliminar
        /// </summary>
        /// <returns></returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>

        [HttpGet]
        public async Task<IActionResult> EliminarAsync(string Id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioAsync(Id);
            return View(usuario);
        }

        /// <summary>
        /// Eliminar Post
        /// </summary>
        /// <returns></returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>

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

        /// <summary>
        /// Editar
        /// </summary>
        /// <returns></returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>

        [HttpGet]
        public async Task<IActionResult> Editar(string Id)
        {
            return View(await _usuarioService.ObtenerUsuarioAsync(Id));
        }

        /// <summary>
        /// Editar Póst
        /// </summary>
        /// <returns></returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>

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

        /// <summary>
        /// Cache de pagina
        /// </summary>
        /// <returns></returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
