using Cinte.Core.Infraestructure;

namespace Cinte.Core.Entities
{
    public class Token
    {
        public string Token_Auth { get; set; }
        public int Expire_In { get; set; }
        public string NickName { get; set; }

    }
}