using Cinte.Core.Entities;

namespace Cinte.Api.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public bool Recuerdame { get; set; }
        public string Nombre {get;set;}
        public string Apellido {get;set;}
         public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }

    }
}