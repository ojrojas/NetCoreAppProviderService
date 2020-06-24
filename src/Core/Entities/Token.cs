using Orojas.Core.Infraestructure;

namespace Orojas.Core.Entities
{
    public class Token
    {
        public string Token_Auth { get; set; }
        public double Expire_In { get; set; }
        public string NickName { get; set; }

    }
}