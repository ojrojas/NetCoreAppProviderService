using System.Collections.Generic;
using System.Threading.Tasks;
using Orojas.Core.Entities;

namespace Orojas.Core.Infraestructure
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        Task<T> ObtenerByIdAsync(int id);
        Task<IReadOnlyList<T>> ListarTodosAsync();
        Task<T> AnadirAsync(T entity);
        Task ActualizarAsync(T entity);
        Task EliminarAsync(T entity);
        Task<int> ContarAsync();
    }
}