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
using Orojas.Api.Models.ViewModels;
using Orojas.Core.Infraestructure;
using App.Utils;
using Microsoft.AspNetCore.Identity;
using Orojas.Infraestructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Orojas.App.Tokens.Interfaces;
using System.Net.Http;
using System.Globalization;
using Orojas.App.Services.Interface;

namespace App.Controllers
{

    public class ManageController : Controller
    {
        private readonly ILogger<ManageController> _logger;
        private readonly IManageService _manageService;

        public ManageController(
            ILogger<ManageController> logger,
            IManageService manageService)
        {
            _logger = logger;
            _manageService = manageService;
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
