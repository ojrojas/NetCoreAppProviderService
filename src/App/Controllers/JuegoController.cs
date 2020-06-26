using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Models;
using Orojas.Infraestructure.RequestProvider;
using Microsoft.Extensions.Configuration;
using Api;
using Orojas.Core.Infraestructure;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
    /// <summary>
    /// JuegoController, controlador que exporne los endpoints de JugoControlle
    /// </summary>
    [Authorize]
    public class JuegoController : Controller
    {
        /// <summary>
        /// Interface Logger para informacion de api
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly ILogger<JuegoController> _logger;

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

        public JuegoController(ILogger<JuegoController> logger, IConfiguration config, ICacheProvider cache)
        {
            _cache = cache;
            _logger = logger;
            _config = config;
        }

        /// <summary>
        /// Index, expone la vista index de jugocontroller
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
