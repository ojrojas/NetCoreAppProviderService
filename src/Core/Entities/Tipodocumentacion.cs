using Cinte.Core.Infraestructure;

namespace Cinte.Core.Entities
{
    public class TipoDocumento : BaseEntity, IAggregateRoot
    {
        public int codigo { get; set; }
        public string Nombre { get; set; }
    }
}