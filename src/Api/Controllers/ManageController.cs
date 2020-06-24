using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Orojas.Api.Models.ViewModels;
using Orojas.Infraestructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Orojas.Api.Controllers
{
    /// <summary>
    /// CuentasManager servicio que expone los endpoint del manager
    /// para el login y creacion de usuarios
    /// </summary>
    /// <author>Oscar Julian Rojas.</author>
    /// <date>09/06/2020</date>
    [ApiController]
    [Route("[controller]")]
    public class ManageController : ControllerBase
    {
        /// <summary>
        /// Interface que expone los servicios de logger para el controlador
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private readonly ILogger<ManageController> _logger;

        /// <summary>
        /// Interface que expone la configuracion de appsettings.json
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private readonly IConfiguration _config;

        /// <summary>
        /// Interface que expone los servicios de SignInManager de netcore para el logueo
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private SignInManager<Usuario> _signInManager;

        /// <summary>
        /// Interface que expone los servicios de UserManager 
        /// para la creacion de usuarios tipo Identity
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private UserManager<Usuario> _userManager;

      

        private readonly AppIdentityDbContext _context;

        /// <summary>
        /// Construcctor de Controlador que inyecta las interfaces a los servicios
        /// constituidos para el este controlador
        /// </summary>
        /// <param name="logger">Interface que informa la aplicacion</param>
        /// <param name="config">Interface que expone la configuracion de la aplicacion</param>
        /// <param name="generadorToken">Interface que expone los servicios de token</param>
        /// <param name="signInManager">Interface que expone el signinmanager</param>
        /// <param name="userManager">Interface que expone el usermanager</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public ManageController(
            ILogger<ManageController> logger,
            IConfiguration config,
         
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
            AppIdentityDbContext context)
        {
            _logger = logger;
            _config = config;
            _signInManager = signInManager;
          
            _userManager = userManager;
            _context = context;
        }

        /// <summary>
        /// ObtenerUsuarios
        /// </summary>
        /// <param name="usuario">Modelo de vista para eliminar usuarios</param>
        /// <returns>IdentityResult que notifica la eliminacion de
        /// los usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [ActionName("ObtenerUsuarios")]
        public IActionResult ObtenerUsuarios()
        {
            return Ok(_context.Users);
        }

         /// <summary>
        /// ObtenerUsuarios
        /// </summary>
        /// <param name="usuario">Modelo de vista para eliminar usuarios</param>
        /// <returns>IdentityResult que notifica la eliminacion de
        /// los usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        [ActionName("ObtenerUsuarios")]
        public async Task<IActionResult> ObtenerUsuarios(string Id)
        {
            return Ok(await _context.Users.FindAsync(Id));
        }

        /// <summary>
        /// CrearUsuarioApp
        /// </summary>
        /// <param name="usuario">Modelo de vista entrada para 
        /// la creacion de usuarios al sistema</param>
        /// <returns>IdentityResult que notifica si creo o no el usuario</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [ActionName("CrearUsuarioApp")]
        public async Task<IActionResult> CrearUsuarioApp(UsuarioViewModel usuario)
        {
            var user = new Usuario { 
                UserName = usuario.Email, 
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                TipoDocumento = usuario.TipoDocumento,
                NumeroDocumento = usuario.NumeroDocumento, 
                Contrasena = usuario.Contrasena };
            var result = await _userManager.CreateAsync(user, usuario.Contrasena);
            if (result.Succeeded)
            {
                return Ok(new JsonResult(new
                {
                    success = string.Format(
                   CultureInfo.CurrentCulture,
                   "usuario creado con exito")
                }));
            }

            return BadRequest(new JsonResult(new
            {
                error = string.Format(
                  CultureInfo.CurrentCulture,
                  "No se pudo crear el usuario.")
            }));
        }

        /// <summary>
        /// EliminarUsuario
        /// </summary>
        /// <param name="usuario">Modelo de vista para eliminar usuarios</param>
        /// <returns>IdentityResult que notifica la eliminacion de
        /// los usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        [ActionName("EliminarUsuarioApp")]
        public async Task<IActionResult> EliminarUsuarioApp(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok(new JsonResult(new
                {
                    success = string.Format(
                   CultureInfo.CurrentCulture,
                   "usuario eliminado con exito")
                }));
            }

            return BadRequest(new JsonResult(new
            {
                error = string.Format(
                  CultureInfo.CurrentCulture,
                  "No se pudo eliminar el usuario.")
            }));
        }

         /// <summary>
        /// EliminarUsuario
        /// </summary>
        /// <param name="usuario">Modelo de vista para eliminar usuarios</param>
        /// <returns>IdentityResult que notifica la eliminacion de
        /// los usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [ActionName("ActualizarUsuarioApp")]
        public async Task<IActionResult> ActualizarUsuarioApp(UsuarioViewModel usuario)
        {
           var user = new Usuario { 
                UserName = usuario.Email, 
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                TipoDocumento = usuario.TipoDocumento,
                NumeroDocumento = usuario.NumeroDocumento, 
                Contrasena = usuario.Contrasena };
            var resultadoEliminar = _userManager.DeleteAsync(user);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(new JsonResult(new
                {
                    success = string.Format(
                   CultureInfo.CurrentCulture,
                   "usuario actualizado con exito")
                }));
            }

            return BadRequest(new JsonResult(new
            {
                error = string.Format(
                  CultureInfo.CurrentCulture,
                  "No se pudo eliminar el usuario.")
            }));
        }
    }
}