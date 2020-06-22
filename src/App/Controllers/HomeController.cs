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
using Cinte.Core.Infraestructure;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly ICacheProvider _cache;

        public HomeController(ILogger<HomeController> logger, IConfiguration config , ICacheProvider cache)
        {
            _cache = cache;
            _logger = logger;
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            string uripeticion =_config["UrisApp:UriApi"] + "WeatherForecast";
            PeticionesService peticiones = new PeticionesService(
               new Uri(_config["UrisApp:UriToken"]), 
               _cache,
               new Uri(uripeticion) 
            ); 

           var resultado = await peticiones.GetAsync<List<WeatherForecast>>();
            return View(resultado);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
