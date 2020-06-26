using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Models;
using Microsoft.Extensions.Configuration;
using Orojas.Core.Infraestructure;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
    /// <summary>
    /// HomeController, contralador que expone los endpoints del home
    /// </summary>
    /// <author>Oscar Julian Rojas Garces.</author>
    /// <date>26/06/2020</date>
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Interface Logger para informacion de api
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Interface IConfiguration para configuracion de la aplicacion 
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly IConfiguration _config;

        /// <summary>
        /// Interface IProviderCache para setear la cache de los tokens
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly ICacheProvider _cache;

        /// <summary>
        /// Constructor del controlador para injectar las opciones y configuraciones
        /// </summary>
        /// <param name="logger">Interface Logger</param>
        /// <param name="config">Interface Configuration</param>
        /// <param name="cache">IProviderCache Cache</param>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        public HomeController(ILogger<HomeController> logger, IConfiguration config, ICacheProvider cache)
        {
            _cache = cache;
            _logger = logger;
            _config = config;
        }

        /// <summary>
        /// Index, expone la vista index de homecontroller
        /// </summary>
        /// <returns>Action</returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Cache de informe de errors en la pagina
        /// </summary>
        /// <returns>Action</returns>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
