using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orojas.Api.Models.ViewModels;
using Orojas.Infraestructure.Identity;

namespace Orojas.Api.Repository.Interface
{
    public interface IManageRepository 
    {
        Task<IReadOnlyList<Usuario>> ObtenerUsuariosAsync();
        Task<Usuario> ObtenerUsuarioAsync(string Id);
        Task<JsonResult> CrearUsuarioApp(UsuarioViewModel usuario);
        Task<JsonResult> EliminarUsuarioApp(string Id);

        Task<JsonResult> ActualizarUsuarioApp(UsuarioViewModel usuario);


    }
}