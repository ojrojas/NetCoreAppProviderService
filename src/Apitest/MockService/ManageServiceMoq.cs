using FluentAssertions;
using Moq;
using Orojas.Api.Repository.Interface;
using Xunit;
using NetCoreApiTokenTest.MockRepository;
using Orojas.Api.Models.ViewModels;
using Orojas.Api.Controllers;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace NetCoreApiTokenTest.MockService
{
    public class ManageServiceMoq
    {
        private readonly ManageController manageController;
        public ManageServiceMoq()
        {
            Mock<IManageRepository> _manageRepository = new ManageRepositoryMoq()._usuarioRepository;
            var _logger = Mock.Of<ILogger<ManageController>>();
            manageController = new ManageController(_logger,_manageRepository.Object);
        }

        [Fact]
        public async Task TestMethodActualizarUsuarioAsync()
        {
            var result = await manageController.ActualizarUsuarioApp(new UsuarioViewModel
            {
                Id = "23ksklde",
                NumeroDocumento="82773838",
                Nombre ="fulano", 
                Apellido = "de tal detal",
                Email ="pepitoPeres@corre.com",
                Contrasena ="293993",
                TipoDocumento = "Cedula de ciudadania",
                Recuerdame = true
            });
            result.Should().NotBeNull();

        }

        [Fact]
        public async Task TestMethodCrearUsuarioAppAsync()
        {
            var result = await manageController.CrearUsuarioApp(new UsuarioViewModel
            {
                Id = "23ksklde",
                NumeroDocumento="82773838",
                Nombre ="fulano", 
                Apellido = "de tal detal",
                Email ="pepitoPeres@corre.com",
                Contrasena ="293993",
                TipoDocumento = "Cedula de ciudadania",
                Recuerdame = true

            });

           result.Should().NotBeNull();
        }

        [Fact]
        public async Task TestMethodEliminarUsuarioAppAsync()
        {
            var result = await manageController.EliminarUsuarioApp("IDentificador");

             result.Should().NotBeNull();
        }

        [Fact]
        public async Task TestMethodObtenerEmpleadosAsync()
        {
            var result = await manageController.ObtenerUsuariosAsync();

            result.Should().NotBeNull();
        }
    }
}