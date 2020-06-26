namespace Orojas.Api.Models.ViewModels
{
    /// <summary>
    /// UsuarioViewModel modelo de vista para Usuario
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</author>
    /// <date>26/06/2020</date>
    public class UsuarioViewModel
    {
        /// <summary>
        /// Id 
        /// </summary>
        /// <value>Id Modelo</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public string Id { get; set; }

        /// <summary>
        /// Email 
        /// </summary>
        /// <value>Email Modelo</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public string Email { get; set; }

        /// <summary>
        /// Contrasena 
        /// </summary>
        /// <value>Contrasena Modelo</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public string Contrasena { get; set; }

        /// <summary>
        /// Recuerdame 
        /// </summary>
        /// <value>Recuerdame Modelo</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public bool Recuerdame { get; set; }

        /// <summary>
        /// Nombre 
        /// </summary>
        /// <value>Nombre Modelo</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public string Nombre {get;set;}

        /// <summary>
        /// Apellido 
        /// </summary>
        /// <value>Apellido Modelo</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public string Apellido {get;set;}

        /// <summary>
        /// TipoDocumento 
        /// </summary>
        /// <value>TipoDocumento Modelo</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public string TipoDocumento { get; set; }

        /// <summary>
        /// NumeroDocumento 
        /// </summary>
        /// <value>NumeroDocumento Modelo</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public string NumeroDocumento { get; set; }

    }
}