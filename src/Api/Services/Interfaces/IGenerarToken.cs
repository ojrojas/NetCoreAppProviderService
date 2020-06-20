using Cinte.Api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cinte.Api.Services.Interfaces
{
    public interface IGeneradorToken
    {
       JsonResult GeneradorToken(LoginViewModel loginViewModel);
    }
}