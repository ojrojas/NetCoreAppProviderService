using System;
using Orojas.Core.Infraestructure;
using Orojas.Infraestructure.RequestProvider;
using Microsoft.Extensions.Configuration;

namespace App.Utils
{
    public static class FactoryProvider
    {
        public static PeticionesService CrearProvider(IConfiguration _config, ICacheProvider cache, string uriPeticion = null)
        {
            if (uriPeticion == null)
                return new PeticionesService(
                     new Uri(_config["UrisApp:UriToken"]), cache);

            else
                return new PeticionesService(
                     new Uri(_config["UrisApp:UriToken"]), cache, new Uri(uriPeticion));
        }
    }
}
