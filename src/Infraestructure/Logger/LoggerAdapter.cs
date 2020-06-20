using Cinte.Core.Infraestructure;
using Microsoft.Extensions.Logging;

namespace Cinte.Infraestructure.Logger
{
     public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogInformacion(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }
    }
}