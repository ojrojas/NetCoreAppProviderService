using Moq;
using Apitest.MockRepository.Stubs;
using Orojas.Api.Repository.Interface;
using Orojas.Api.Models.ViewModels;

namespace NetCoreApiTokenTest.MockRepository
{
    public class ManageRepositoryMoq
    {
        public Mock<IManageRepository> _usuarioRepository;

        public ManageRepositoryMoq()
        {
            _usuarioRepository = new Mock<IManageRepository>();
            ConfiguracionEmpleadoRepositoryMoq();
        }

        private void ConfiguracionEmpleadoRepositoryMoq()
        {
            //ActualizarUsuarioApp
            _usuarioRepository.Setup((x) => x.ActualizarUsuarioApp(
                It.IsAny<UsuarioViewModel>())).ReturnsAsync(UsuarioStub.jsonresultado);
            //CrearUsuarioApp
            _usuarioRepository.Setup((x) => x.CrearUsuarioApp(
                It.IsAny<UsuarioViewModel>()
            )).ReturnsAsync(UsuarioStub.jsonresultado);
            //EliminarUsuarioApp
            _usuarioRepository.Setup((x) => x.EliminarUsuarioApp(
                It.IsAny<string>())).ReturnsAsync(UsuarioStub.jsonresultado);
            //ObtenerUsuarioAsync
            _usuarioRepository.Setup((x) => x.ObtenerUsuarioAsync(
                It.IsAny<string>())).ReturnsAsync(UsuarioStub.usuario1);
            //ObtenerUsuariosAsync
            _usuarioRepository.Setup((x) => x.ObtenerUsuariosAsync())
            .ReturnsAsync(UsuarioStub.listaUsuarios);
        }
    }


}