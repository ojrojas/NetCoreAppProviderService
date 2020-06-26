namespace Orojas.Api.Models.ViewModels
{
    /// <summary>
    /// LoginViewmodel vista de modelo para el logueo
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>24/06/2020</date>
    public class LoginViewModel
    {
        /// <summary>
        /// Eamil
        /// </summary>
        /// <value>Correo Electronico</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public string Email { get; set; }

        /// <summary>
        /// Contrasena 
        /// </summary>
        /// <value>Correo Electronico</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public string Contrasena { get; set; }

       /// <summary>
        /// Recuerdame 
        /// </summary>
        /// <value>Booleano recuerdame</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/06/2020</date>
        public bool Recuerdame { get; set; }
    }
}