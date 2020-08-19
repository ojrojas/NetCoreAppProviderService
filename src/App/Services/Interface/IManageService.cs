using System.Threading.Tasks;
using Orojas.Api.Models.ViewModels;

namespace Orojas.App.Services.Interface
{
    /// <summary>
    /// IManageService, Interface que expoene los metodos de ManageService
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>26/06/2020</date>
    public interface IManageService
    {
        /// <summary>
        /// Login metodo que notifica si hubo o no logueo en la aplicacion
        /// </summary>
        /// <param name="login">Modelo de vista ingreso de dstos</param>
        /// <returns>Booleano que notifica si o no</returns>
        Task<bool> Login(LoginViewModel login);
    }
}