using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Orojas.Infraestructure.Identity;

namespace Apitest.MockRepository.Stubs
{
    public static class UsuarioStub
    {
        public static Usuario usuario1 = new Usuario()
        {
            Id = "adshfkjasdhfjkads",
            TipoDocumento = "Cedula ciudadania",
            NumeroDocumento = "32423423",
            Nombre = "Dionisio",
            Apellido = "Detal",
            Email = "garcia@hotmail.com",
            Contrasena = "Abc456789#"

        };

        public static Usuario Usuario2 = new Usuario()
        {
            Id = "asdfasdfasdfasdfcxvxcv",
            TipoDocumento = "Cedula extranjeria",
            NumeroDocumento = "6549898",
            Nombre = "Patricio",
            Apellido = "Fondo de bikini",
            Email = "patricio@hotmail.com",
            Contrasena = "Abc456789#"

        };

        public static List<Usuario> listaUsuarios = new List<Usuario>()
        {
          new Usuario{
            Id = "adshfkjasdhfjkads",
            TipoDocumento = "Cedula ciudadania",
            NumeroDocumento = "32423423",
            Nombre = "Dionisio",
            Apellido = "Detal",
            Email = "garcia@hotmail.com",
            Contrasena = "Abc456789#"
          },
          new Usuario{
               Id = "asdfasdfasdfasdfcxvxcv",
            TipoDocumento = "Cedula extranjeria",
            NumeroDocumento = "6549898",
            Nombre = "Patricio",
            Apellido = "Fondo de bikini",
            Email = "patricio@hotmail.com",
            Contrasena = "Abc456789#"
          },

          new Usuario{
                 Id = "asdfasdfasdfasdfcxvxcv",
            TipoDocumento = "Cedula extranjeria",
            NumeroDocumento = "6549898",
            Nombre = "Patricio",
            Apellido = "Fondo de bikini",
            Email = "patricio@hotmail.com",
            Contrasena = "Abc456789#"

          }
        };

        public static JsonResult jsonresultado = new JsonResult(new { Data= Usuario2 } );
         public static JsonResult jsonresultadolista = new JsonResult(new { Data= listaUsuarios } );
    }
}