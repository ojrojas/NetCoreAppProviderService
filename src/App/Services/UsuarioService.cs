using System.Collections.Generic;
using System.Threading.Tasks;
using App.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Orojas.Api.Models.ViewModels;
using Orojas.App.Services.Interface;
using Orojas.Core.Infraestructure;
using Orojas.Infraestructure.Identity;

namespace Orojas.App.Services
{
    /// <summary>
    /// Servicio, implementa los servicios para el usuario
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>26/06/2020</date>
    public class UsuarioService : IUsuarioService
    {
        /// <summary>
        /// Interface Logger para informacion de api
        /// </summary>
        /// <author>Oscar Julian Rojas Garces.</author>
        /// <date>26/06/2020</date>
        private readonly ILogger<UsuarioService> _logger;

        /// <summary>
        /// Interface Confiugaration para informacion de api
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
        /// Constructor para injectar las dependencias de UsuarioService
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="config"></param>
        /// <param name="cache"></param>
        public UsuarioService(
            ILogger<UsuarioService> logger,
            IConfiguration config,
            ICacheProvider cache)
        {
            _cache = cache;
            _logger = logger;
            _config = config;
        }

        /// <summary>
        /// CrearUsuarioAsync
        /// </summary>
        /// <returns>JsonResult</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>26/06/2020</date>
        public async Task<object> CrearUsuarioAsync(UsuarioViewModel usuario)
        {
            string uripeticion = "http://localhost:5002/manage";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            return await peticiones.PostAsync<object>(usuario);
        }

        /// <summary>
        /// EditarUsuarioAsync
        /// </summary>
        /// <returns>JsonResult</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>26/06/2020</date>

        public async Task<object> EditarUsuarioAsync(UsuarioViewModel usuario)
        {
            string uripeticion = "http://localhost:5002/manage";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            return await peticiones.PutAsync<object>(usuario);
        }

        /// <summary>
        /// EliminarUsuarioAsync
        /// </summary>
        /// <returns>JsonResult</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>26/06/2020</date>
        public async Task<object> EliminarUsuarioAsync(string Id)
        {
            string uripeticion = $"http://localhost:5002/manage/{Id}";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            var usuario = await peticiones.GetAsync<Usuario>();
            return await peticiones.DeleteAsync<Usuario>(usuario);
        }

        /// <summary>
        /// ObtenerUsuarioAsync
        /// </summary>
        /// <returns>Usuario</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>26/06/2020</date>
        public async Task<Usuario> ObtenerUsuarioAsync(string Id)
        {
            string uripeticion = $"http://localhost:5002/manage/{Id}";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            return await peticiones.GetAsync<Usuario>();
        }

        /// <summary>
        /// ObtenerUsuarioAsync
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>26/06/2020</date>
        public async Task<IReadOnlyList<Usuario>> ObtenerUsuariosAsync()
        {
            string uripeticion = "http://localhost:5002/manage";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            return await peticiones.GetAsync<IReadOnlyList<Usuario>>();
        }
    }
}