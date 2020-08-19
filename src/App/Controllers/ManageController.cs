using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orojas.Api.Models.ViewModels;
using Orojas.App.Services.Interface;

namespace App.Controllers
{
    /// <summary>
    /// Controlador que expone el servicios de Logueo de la aplicacion
    /// </summary>
    public class ManageController : Controller
    {
         /// <summary>
        /// Interface Logger para informacion de api
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly ILogger<ManageController> _logger;

         /// <summary>
        /// Interface IManageService para exponer los metodos de ManageService
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly IManageService _manageService;

        public ManageController(
            ILogger<ManageController> logger,
            IManageService manageService)
        {
            _logger = logger;
            _manageService = manageService;
        }

        /// <summary>
        /// Login, expone la vista login de managecontroller
        /// </summary>
        /// <returns>Action</returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login, expone peticion login post
        /// </summary>
        /// <returns>Action</returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var resultado = await _manageService.Login(login);

            if (resultado)
                return RedirectToAction(nameof(HomeController.Index), "Home");
            else
            {
                ModelState.AddModelError("", "Email o password invalidos");
                return View(login);
            }
        }
    }
}
