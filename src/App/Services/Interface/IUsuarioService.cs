using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orojas.Api.Models.ViewModels;
using Orojas.Infraestructure.Identity;

namespace Orojas.App.Services.Interface
{
    public interface IUsuarioService
    {
        Task<IReadOnlyList<Usuario>> ObtenerUsuariosAsync();
         Task<Usuario> ObtenerUsuarioAsync(string Id);
         Task<object> CrearUsuarioAsync(UsuarioViewModel usuario);
         Task<object> EditarUsuarioAsync(UsuarioViewModel usuario);
         Task<object> EliminarUsuarioAsync(UsuarioViewModel usuario);
    }
}