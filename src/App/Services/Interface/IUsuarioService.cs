using System.Collections.Generic;
using System.Threading.Tasks;
using Orojas.Api.Models.ViewModels;
using Orojas.Infraestructure.Identity;

namespace Orojas.App.Services.Interface
{
    /// <summary>
    /// Interface, que expone los servicios para el usuario
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>26/06/2020</date>
    public interface IUsuarioService
    {
        /// <summary>
        /// ObtenerUsuariosAsync
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>26/06/2020</date>
        Task<IReadOnlyList<Usuario>> ObtenerUsuariosAsync();

        /// <summary>
        /// ObtenerUsuarioAsync
        /// </summary>
        /// <returns>Usuario</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>26/06/2020</date>
        Task<Usuario> ObtenerUsuarioAsync(string Id);

        /// <summary>
        /// CrearUsuarioAsync
        /// </summary>
        /// <returns>JsonResult</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>26/06/2020</date>
        Task<object> CrearUsuarioAsync(UsuarioViewModel usuario);

        /// <summary>
        /// EditarUsuarioAsync
        /// </summary>
        /// <returns>JsonResult</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>26/06/2020</date>
        Task<object> EditarUsuarioAsync(UsuarioViewModel usuario);

        /// <summary>
        /// EliminarUsuarioAsync
        /// </summary>
        /// <returns>JsonResult</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>26/06/2020</date>
        Task<object> EliminarUsuarioAsync(string Id);
    }
}