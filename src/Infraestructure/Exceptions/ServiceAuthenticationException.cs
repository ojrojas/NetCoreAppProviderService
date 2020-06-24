namespace Orojas.Infraestructure.Exceptions
{
    public class ServiceAuthenticationException : System.Exception
    {
        private string Contenido;
    public ServiceAuthenticationException(string contenido)
    {
        Contenido = contenido;
    }

    public ServiceAuthenticationException() { }
}

}