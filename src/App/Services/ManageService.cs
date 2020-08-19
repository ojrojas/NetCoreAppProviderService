using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Orojas.Api.Models.ViewModels;
using Orojas.App.Services.Interface;
using Orojas.App.Tokens.Interfaces;
using Orojas.Core.Infraestructure;
using Orojas.Infraestructure.Identity;

namespace Orojas.App.Services
{
    /// <summary>
    /// ManageService, implementacion que expoene los metodos de ManageService
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>26/06/2020</date>
    public class ManageService : IManageService
    {
        /// <summary>
        /// Interface IConfiguration para informacion de api
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly IConfiguration _config;

        /// <summary>
        /// Interface Cache para informacion de api
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly ICacheProvider _cache;

        /// <summary>
        /// Interface Logger para informacion de api
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly ILogger<ManageService> _logger;

        /// <summary>
        /// Interface que expone los servicios de 
        /// creacion de token para autenticar  alos usuarios
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private readonly IGeneradorToken _generadorToken;

        /// <summary>
        /// Interface que expone los servicios de SignInManager de netcore para el logueo
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private SignInManager<Usuario> _signInManager;

        public ManageService(
            ILogger<ManageService> logger,
            IConfiguration config,
            ICacheProvider cache,
            IGeneradorToken generadorToken,
            SignInManager<Usuario> signInManager)
        {
            _cache = cache;
            _logger = logger;
            _config = config;
            _signInManager = signInManager;
            _generadorToken = generadorToken;
        }

         /// <summary>
        /// Login metodo que notifica si hubo o no logueo en la aplicacion
        /// </summary>
        /// <param name="login">Modelo de vista ingreso de dstos</param>
        /// <returns>Booleano que notifica si o no</returns>
        public async Task<bool> Login(LoginViewModel login)
        {
            _logger.LogInformation("Petición de logueo");
            HttpResponseMessage _responseMessage = new HttpResponseMessage();
            Microsoft.AspNetCore.Identity.SignInResult resultado =
            await _signInManager.PasswordSignInAsync(
                login.Email,
                login.Contrasena,
                login.Recuerdame, lockoutOnFailure: true);

            if (resultado.Succeeded)
            {
                var token = _generadorToken.GeneradorToken(login);
                if (token.Token_Auth != null)
                    _cache.SetearTokenCache(token);
                _logger.LogInformation("logueo exitoso");
                return true;
            }
            else
            {
                _logger.LogError("Error en el logueo");
                return false;
            }
        }
    }
}