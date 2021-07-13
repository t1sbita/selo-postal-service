using NUnit.Framework;
using Moq;

using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services;
using selo_postal_api.Core.Exceptions;
using selo_postal_api.Core.Domain.Models;

namespace selo_postal_api.Tests.Core
{
    [TestFixture]
    class UsuariosServiceTest
    {
        private Mock<IUsuarioRepository> mockUsuario;

        private UsuarioService usuarioService;

        private Usuario novoUsuario;
        private Usuario usuarioDiferenteDoLogado;
        private UsuarioLogin novoUsuarioEntradaModel;

        [SetUp]
        public void Setup()
        {

            mockUsuario = new Mock<IUsuarioRepository>();

            usuarioService = new UsuarioService(mockUsuario.Object);

            novoUsuario = new Usuario()
            {
                Id = 1,
                Login = "usuario",
                Password = "senhateste",
                Role = "teste"
            };
            usuarioDiferenteDoLogado = new Usuario()
            {
                Id = 2,
                Login = "usuarioDiferente",
                Password = "senhateste",
                Role = "testeDiferente"
            };

            novoUsuarioEntradaModel = new UsuarioLogin()
            {
                Login = "usuario",
                Password = "senhateste",
                
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

            var resultado = usuarioService.Authenticate(novoUsuarioEntradaModel);

            Assert.IsInstanceOf<UsuarioToken>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void AlterarUsuario(int id)
        {
            mockUsuario.Setup(u => u.Update(It.IsAny<int>(), It.IsAny<Usuario>())).Returns(novoUsuario);

            var resultado = usuarioService.Update(id, novoUsuario);

            Assert.IsInstanceOf<Usuario>(resultado);
        }
        
        [TestCase(1)]
        [TestCase(5)]
        public void DeveRetornarLogin(int id)
        {
            mockUsuario.Setup(u => u.RetornaLogin(It.IsAny<int>())).Returns(novoUsuario.Login);

            var resultado = usuarioService.RetornaLogin(id);

            Assert.AreEqual(novoUsuario.Login, resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void VerificaSeExiste(int id)
        {
            mockUsuario.Setup(u => u.VerificaExistente(It.IsAny<Usuario>())).Returns(true);

            var resultado = usuarioService.VerificaExistente(novoUsuario);

            Assert.IsTrue(resultado);
        }

        [TestCase(50, "Usuário não encontrado!")]
        public void RemoveUsuarioIncorreto(int id, string message){
            mockUsuario.Setup(u => u.Remove(It.IsAny<int>())).Throws(new NotFoundException("Usuário não encontrado!"));
            var exception = Assert.Throws<NotFoundException>(() => usuarioService.Remove(id));

            Assert.That(exception.Message, Is.EqualTo(message));
        }

    }
}
