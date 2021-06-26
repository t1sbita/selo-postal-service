using NUnit.Framework;
using Moq;

using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services;

namespace selo_postal_api.Tests.Core
{
    [TestFixture]
    class UsuariosServiceTest
    {
        private Mock<IUsuarioRepository> mockUsuario;

        private UsuarioService usuarioService;

        private Usuario novoUsuario;
        private Usuario usuarioDiferenteDoLogado;


        [SetUp]
        public void Setup()
        {

            mockUsuario = new Mock<IUsuarioRepository>();

            usuarioService = new UsuarioService(mockUsuario.Object);

            novoUsuario = new Usuario()
            {
                Login = "usuario",
                Password = "senhateste",
                Role = "teste"
            };
            usuarioDiferenteDoLogado = new Usuario()
            {
                Login = "usuarioDiferente",
                Password = "senhateste",
                Role = "testeDiferente"
            };


        }

        [Test]
        public void AdicionarNovoUsuario()
        {
            mockUsuario.Setup(u => u.Add(It.IsAny<Usuario>())).Returns(novoUsuario);

            var resultado = usuarioService.Add(novoUsuario);

            Assert.IsInstanceOf<Usuario>(resultado);
        }

        [Test]
        public void RetornaTokenAutenticacao()
        {
            mockUsuario.Setup(u => u.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(novoUsuario);

            var resultado = usuarioService.Authenticate(novoUsuario);

            Assert.IsInstanceOf<Usuario>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void AlterarUsuario(int id)
        {
            mockUsuario.Setup(u => u.Update(It.IsAny<int>(), It.IsAny<Usuario>())).Returns(novoUsuario);

            var resultado = usuarioService.Update(id, novoUsuario);

            Assert.IsInstanceOf<Usuario>(resultado);
        }

    }
}
