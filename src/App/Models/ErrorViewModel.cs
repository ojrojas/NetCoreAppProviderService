using System;

namespace App.Models
{
    /// <summary>
    /// Modelo de errors para aplicacion App
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Peticion
        /// </summary>
        /// <value>una cadena con el id de peticion</value>
        public string RequestId { get; set; }

        /// <summary>
        /// metodo que expoene el Id de la peticion
        /// </summary>
        /// <returns>Guid de peticion</returns>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
