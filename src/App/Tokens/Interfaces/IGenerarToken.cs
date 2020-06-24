using Cinte.Api.Models.ViewModels;
using Cinte.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cinte.App.Tokens.Interfaces
{
    public interface IGeneradorToken
    {
       Token GeneradorToken(LoginViewModel loginViewModel);
    }
}