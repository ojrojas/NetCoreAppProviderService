using Microsoft.AspNetCore.Identity;

namespace Orojas.Infraestructure.Identity
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Contrasena { get; set; }
    }
}