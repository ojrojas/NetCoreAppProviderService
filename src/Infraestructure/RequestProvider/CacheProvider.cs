using System;
using Cinte.Core.Entities;
using Cinte.Core.Infraestructure;
using Microsoft.Extensions.Caching.Memory;

namespace Cinte.Infraestructure.RequestProvider
{
    public class CacheProvider : ICacheProvider
    {
        /// <summary>
        /// Obejto cache referencia a la cache de aplicacion.
        /// </summary>
        IMemoryCache cache = new MemoryCache(new MemoryCacheOptions{ SizeLimit=1024});

        /// <summary>
        /// Setear el objeto token de cache
        /// </summary>
        /// <param name="token"></param>
        public void SetearTokenCache(Token token)
        {
            cache.Set("cacheToken", token);
        }

        /// <summary>
        /// Obtener el token de la memoria cache.
        /// </summary>
        /// <returns>Retorna objeto cache.</returns>
        public object ObtenerTokenCache()
        {
            return cache.Get("cacheToken");
        }
    }
}