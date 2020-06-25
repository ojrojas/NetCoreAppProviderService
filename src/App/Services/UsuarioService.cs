using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orojas.Api.Models.ViewModels;
using Orojas.App.Services.Interface;
using Orojas.Infraestructure.Identity;

namespace Orojas.App.Services
{
    public class UsuarioService : IUsuarioService
    {
        public Task<object> CrearUsuarioAsync(UsuarioViewModel usuario)
        {
            throw new System.NotImplementedException();
        }

        public Task<object> EditarUsuarioAsync(UsuarioViewModel usuario)
        {
            throw new System.NotImplementedException();
        }

        public Task<object> EliminarUsuarioAsync(UsuarioViewModel usuario)
        {
            throw new System.NotImplementedException();
        }

        public Task<Usuario> ObtenerUsuarioAsync(string Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Usuario>> ObtenerUsuariosAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}