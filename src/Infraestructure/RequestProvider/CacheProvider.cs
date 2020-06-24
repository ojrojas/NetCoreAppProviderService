using System;
using Orojas.Core.Entities;
using Orojas.Core.Infraestructure;
using Microsoft.Extensions.Caching.Memory;

namespace Orojas.Infraestructure.RequestProvider
{
    public class CacheProvider : ICacheProvider
    {
        /// <summary>
        /// Obejto cache referencia a la cache de aplicacion.
        /// </summary>
        private readonly IMemoryCache _cache; 

        public CacheProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// Setear el objeto token de cache
        /// </summary>
        /// <param name="token"></param>
        public void SetearTokenCache(Token token)
        {
              var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Set cache entry size by extension method.
                .SetSize(1024)
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromMinutes(120));
            _cache.Set("cacheToken", token, cacheEntryOptions);
        }

        /// <summary>
        /// Obtener el token de la memoria cache.
        /// </summary>
        /// <returns>Retorna objeto cache.</returns>
        public object ObtenerTokenCache()
        {
            return _cache.Get("cacheToken");
        }
    }
}