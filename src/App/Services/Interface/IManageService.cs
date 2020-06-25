using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orojas.Api.Models.ViewModels;

namespace Orojas.App.Services.Interface
{
    public interface IManageService
    {
        Task<bool> Login(LoginViewModel login);
    }
}