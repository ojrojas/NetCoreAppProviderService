using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Orojas.Api.Models.ViewModels;
using Orojas.Api.Repository.Interface;
using Orojas.Infraestructure.Identity;

namespace Orojas.Api.Repository
{

    public class ManageRepository : IManageRepository
    {
        /// <summary>
        /// Interface que expone los servicios de logger para el controlador
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private readonly ILogger<ManageRepository> _logger;

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

        public ManageRepository(IConfiguration config,
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
            AppIdentityDbContext context)
        {
            _config = config;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        public async Task<JsonResult> ActualizarUsuarioApp(UsuarioViewModel usuario)
        {
            var userEdit = new Usuario { 
                UserName = usuario.Email, 
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                TipoDocumento = usuario.TipoDocumento,
                NumeroDocumento = usuario.NumeroDocumento, 
                Contrasena = usuario.Contrasena };
                var user = await _userManager.FindByNameAsync(usuario.Email);
            var resultadoEliminar = _userManager.DeleteAsync(user);
            var result = await _userManager.CreateAsync(userEdit);
            if (result.Succeeded)
            {
                return new JsonResult(new
                {
                    success = string.Format(
                   CultureInfo.CurrentCulture,
                   "usuario actualizado con exito")
                });
            }

            return new JsonResult(new
            {
                error = string.Format(
                  CultureInfo.CurrentCulture,
                  "No se pudo eliminar el usuario.")
            });
        }

        public async Task<JsonResult> CrearUsuarioApp(UsuarioViewModel usuario)
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
                return new JsonResult(new
                {
                    success = string.Format(
                   CultureInfo.CurrentCulture,
                   "usuario creado con exito")
                });
            }

            return new JsonResult(new
            {
                error = string.Format(
                  CultureInfo.CurrentCulture,
                  "No se pudo crear el usuario.")
            });
        }

        public async Task<JsonResult> EliminarUsuarioApp(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new JsonResult(new
                {
                    success = string.Format(
                   CultureInfo.CurrentCulture,
                   "usuario eliminado con exito")
                });
            }

            return new JsonResult(new
            {
                error = string.Format(
                  CultureInfo.CurrentCulture,
                  "No se pudo eliminar el usuario.")
            });
        }

        public async Task<Usuario> ObtenerUsuarioAsync(string Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<IReadOnlyList<Usuario>> ObtenerUsuariosAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}