namespace Cinte.Core.Infraestructure
{
    public interface IAppLogger<T>
    {
        void LogInformacion(string mensaje, params object[] args);
        void LogWarning(string mensaje, params object[] args);
    }
}