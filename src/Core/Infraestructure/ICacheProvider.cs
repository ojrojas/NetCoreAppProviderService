using Orojas.Core.Entities;

namespace Orojas.Core.Infraestructure
{
    public interface ICacheProvider
    {
         void SetearTokenCache(Token token);
        object ObtenerTokenCache();
    }
}