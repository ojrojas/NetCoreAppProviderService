using Orojas.Api.Models.ViewModels;
using Orojas.Core.Entities;

namespace Orojas.App.Tokens.Interfaces
{
    public interface IGeneradorToken
    {
       Token GeneradorToken(LoginViewModel loginViewModel);
    }
}