using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Apitest.MockRepository;
using Apitest.MockRepository.Stubs;
using Orojas.Api.Repository.Interface;
using Xunit;
using NetCoreApiTokenTest.MockRepository;
using Orojas.Api.Models.ViewModels;

namespace NetCoreApiTokenTest.MockService
{
    public class ManageServiceMoq
    {
        private static IManageRepository _manageRepository;
        public ManageServiceMoq()
        {
            Mock<IManageRepository> _manageRepository = new ManageRepositoryMoq()._usuarioRepository;
        }

        [Fact]
        public async System.Threading.Tasks.Task TestMethodActualizarUsuarioAsync()
        {
            var result = await _manageRepository.ActualizarUsuarioApp(new UsuarioViewModel
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

            result.Should().Be(default(int));
        }

      

        [Fact]
        public async System.Threading.Tasks.Task TestMethodCrearUsuarioAppAsync()
        {
            var result = await _manageRepository.CrearUsuarioApp(new UsuarioViewModel
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

            result.Should().NotBe(null);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestMethodEliminarUsuarioAppAsync()
        {
            var result = await _manageRepository.EliminarUsuarioApp("IDentificador");

            result.Should().NotBe(null);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestMethodObtenerEmpleadosAsync()
        {
            var result = await _manageRepository.ObtenerUsuariosAsync();

            result.Should().NotBeNull();
        }
    }
}