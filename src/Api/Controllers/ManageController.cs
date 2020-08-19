using System.Threading.Tasks;
using Orojas.Api.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orojas.Api.Repository.Interface;

namespace Orojas.Api.Controllers
{
    /// <summary>
    /// ManageController controlador que expone los endpoint del manager
    /// para el login y creacion de usuarios
    /// </summary>
    /// <author>Oscar Julian Rojas.</author>
    /// <date>24/06/2020</date>
    [ApiController]
    [Route("[controller]")]
    public class ManageController : ControllerBase
    {
        /// <summary>
        /// Interface que expone los servicios de logger para el controlador
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
         /// <date>24/06/2020</date>
        private readonly ILogger<ManageController> _logger;

        /// <summary>
        /// Interface que expone los metodos del respoitory manageRepository para el controlador
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
         /// <date>24/06/2020</date>
        private readonly IManageRepository _manageRepository;

        /// <summary>
        /// Constructor de Controlador que inyecta las interfaces a los servicios
        /// constituidos para este controlador
        /// </summary>
        /// <param name="logger">Interface que informa la aplicacion</param>
        /// <param name="manageRepository">Instancia del repository manageRepository</param>
        /// <author>Oscar Julian Rojas</author>
         /// <date>24/06/2020</date>
        public ManageController(
            ILogger<ManageController> logger,
            IManageRepository manageRepository)
            {
            _logger = logger;
            _manageRepository = manageRepository;
        }

        /// <summary>
        /// ObtenerUsuarios
        /// </summary>
        /// <param name="usuario">Modelo de vista para eliminar usuarios</param>
        /// <returns>IdentityResult que notifica la eliminacion de
        /// los usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
         /// <date>24/06/2020</date>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [ActionName("ObtenerUsuarios")]
        public async Task<IActionResult> ObtenerUsuariosAsync()
        {
            return Ok(await _manageRepository.ObtenerUsuariosAsync());
        }

         /// <summary>
        /// ObtenerUsuarios
        /// </summary>
        /// <param name="usuario">Modelo de vista para eliminar usuarios</param>
        /// <returns>IdentityResult que notifica la eliminacion de
        /// los usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
         /// <date>24/06/2020</date>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        [ActionName("ObtenerUsuario")]
        public async Task<IActionResult> ObtenerUsuario(string Id)
        {
            return Ok(await _manageRepository.ObtenerUsuarioAsync(Id));
        }

        /// <summary>
        /// CrearUsuarioApp
        /// </summary>
        /// <param name="usuario">Modelo de vista entrada para 
        /// la creacion de usuarios al sistema</param>
        /// <returns>IdentityResult que notifica si creo o no el usuario</returns>
        /// <author>Oscar Julian Rojas</author>
         /// <date>24/06/2020</date>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [ActionName("CrearUsuarioApp")]
        public async Task<IActionResult> CrearUsuarioApp(UsuarioViewModel usuario)
        {
           return await _manageRepository.CrearUsuarioApp(usuario);
        }

        /// <summary>
        /// EliminarUsuario
        /// </summary>
        /// <param name="usuario">Modelo de vista para eliminar usuarios</param>
        /// <returns>IdentityResult que notifica la eliminacion de
        /// los usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
         /// <date>24/06/2020</date>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        [ActionName("EliminarUsuarioApp")]
        public async Task<IActionResult> EliminarUsuarioApp(string Id)
        {
           return await _manageRepository.EliminarUsuarioApp(Id);
        }

         /// <summary>
        /// EliminarUsuario
        /// </summary>
        /// <param name="usuario">Modelo de vista para eliminar usuarios</param>
        /// <returns>IdentityResult que notifica la eliminacion de
        /// los usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
         /// <date>24/06/2020</date>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [ActionName("ActualizarUsuarioApp")]
        public async Task<IActionResult> ActualizarUsuarioApp(UsuarioViewModel usuario)
        {
          return await _manageRepository.ActualizarUsuarioApp(usuario);
        }
    }
}