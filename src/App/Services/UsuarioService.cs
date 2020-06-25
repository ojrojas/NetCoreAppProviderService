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
    public class UsuarioService : IUsuarioService
    {
        private readonly ILogger<UsuarioService> _logger;
        private readonly IConfiguration _config;
        private readonly ICacheProvider _cache;

        public UsuarioService(
            ILogger<UsuarioService> logger,
            IConfiguration config,
            ICacheProvider cache)
        {
            _cache = cache;
            _logger = logger;
            _config = config;
        }

        public async Task<object> CrearUsuarioAsync(UsuarioViewModel usuario)
        {
            string uripeticion = "http://localhost:5002/manage";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            return await peticiones.PostAsync<object>(usuario);
        }

        public async Task<object> EditarUsuarioAsync(UsuarioViewModel usuario)
        {
            string uripeticion = "http://localhost:5002/manage";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            return await peticiones.PutAsync<object>(usuario);
        }

        public async Task<object> EliminarUsuarioAsync(string Id)
        {
            string uripeticion = $"http://localhost:5002/manage/{Id}";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            var usuario = await peticiones.GetAsync<Usuario>();
            return await peticiones.DeleteAsync<Usuario>(usuario);
        }

        public async Task<Usuario> ObtenerUsuarioAsync(string Id)
        {
            string uripeticion = $"http://localhost:5002/manage/{Id}";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            return await peticiones.GetAsync<Usuario>();
        }

        public async Task<IReadOnlyList<Usuario>> ObtenerUsuariosAsync()
        {
            string uripeticion = "http://localhost:5002/manage";
            var peticiones = FactoryProvider.CrearProvider(_config, _cache, uripeticion);
            return await peticiones.GetAsync<IReadOnlyList<Usuario>>();
        }
    }
}