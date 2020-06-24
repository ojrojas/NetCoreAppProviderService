using Orojas.Api.Models.ViewModels;
using Orojas.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Orojas.App.Tokens.Interfaces
{
    public interface IGeneradorToken
    {
       Token GeneradorToken(LoginViewModel loginViewModel);
    }
}