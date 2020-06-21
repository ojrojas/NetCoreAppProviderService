using Cinte.Core.Entities;

namespace Cinte.Core.Infraestructure
{
    public interface ICacheProvider
    {
         void SetearTokenCache(Token token);
        object ObtenerTokenCache();
    }
}