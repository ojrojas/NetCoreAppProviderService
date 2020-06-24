using System.Collections.Generic;
using System.Threading.Tasks;
using Orojas.Core.Entities;

namespace Orojas.Core.Infraestructure
{
    public interface IPeticionesService
    {
        Task<T> GetAsync<T>();
        Task<T> GetAsync<T>(Dictionary<string,string> parametros);
        Task<T> GetAsync<T>(Dictionary<string, string> parametros, Dictionary<string, string> headers);
        Task<T> PostAsync<T>(T objeto,Dictionary<string,string >headers);
         Task<T> PutAsync<T>(T objeto,Dictionary<string,string >headers);
          Task<T> DeleteAsync<T>(T objeto,Dictionary<string,string >headers);
        Task<Token> PostConsultarTokenAsync(object objeto);
    }
    
}