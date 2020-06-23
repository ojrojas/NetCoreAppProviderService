using Cinte.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Cinte.Infraestructure.Identity
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoDocumento TipoIdentificacion { get; set; }
        public string NumeroDocumento { get; set; }
        public string Contrasena { get; set; }
    }
}