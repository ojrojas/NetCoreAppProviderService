using Orojas.Core.Infraestructure;

namespace Orojas.Core.Entities
{
    public class TipoDocumento : BaseEntity
    {
        public int codigo { get; set; }
        public string Nombre { get; set; }
    }
}