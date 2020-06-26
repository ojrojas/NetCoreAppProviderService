using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orojas.Api.Models.ViewModels;
using Orojas.Infraestructure.Identity;

namespace Orojas.Api.Repository.Interface
{
    /// <summary>
    /// IManageRepository interface que expone los metodos de ManageRepository
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>26/06/2020</date>
    /// <author>Oscar Julian Rojas</author>
    /// <date>26/06/2020</date>
    public interface IManageRepository 
    {
        /// <summary>
        /// ObtenerUsuariosAsync
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>26/06/2020</date> 
        Task<IReadOnlyList<Usuario>> ObtenerUsuariosAsync();

        /// <summary>
        /// ObtenerUsuariosAsync
        /// </summary>
        /// <returns>Usuario</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>26/06/2020</date> 
        Task<Usuario> ObtenerUsuarioAsync(string Id);

        /// <summary>
        /// CrearUsuarioApp
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>26/06/2020</date> 
        Task<JsonResult> CrearUsuarioApp(UsuarioViewModel usuario);

        /// <summary>
        /// EliminarUsuarioApp
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>26/06/2020</date> 
        Task<JsonResult> EliminarUsuarioApp(string Id);

        /// <summary>
        /// ActualizarUsuarioApp
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>26/06/2020</date> 
        Task<JsonResult> ActualizarUsuarioApp(UsuarioViewModel usuario);
    }
}