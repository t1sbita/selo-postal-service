using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Http;

using selo_postal_api.Core.Services.Interfaces;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Api.Controllers;
using selo_postal_api.Core.Domain.Models;

namespace selo_postal_api.Tests.API
{
    [TestFixture]
    class UsuariosControllerTest
    {
        private Mock<IUsuarioService> mockUsuario;
        
        private UsuariosController usuariosController;

        private Usuario novoUsuario;
        private UsuarioLogin novoUsuarioEntradaModel;
        private UsuarioToken novoUsuarioSaidaModel;
        private Usuario usuarioDiferenteDoLogado;
        
        private ControllerContext contextUser;
        
        [SetUp]
        public void Setup()
        {

            mockUsuario = new Mock<IUsuarioService>();

            usuariosController = new UsuariosController(mockUsuario.Object);

            novoUsuario = new Usuario()
            {
                Login = "usuario",
                Password = "senhateste",
                Role = "teste"
            };

            novoUsuarioEntradaModel = new UsuarioLogin()
            {
                Login = "usuario",
                Password = "senhateste",
                
            };

            novoUsuarioSaidaModel = new UsuarioToken()
            {
                Login = "usuario",
                Token = "tokenGenerico",
                
            };

            usuarioDiferenteDoLogado = new Usuario()
            {
                Login = "usuarioDiferente",
                Password = "senhateste",
                Role = "testeDiferente"
            };
            
            var claimsUser = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, novoUsuario.Login.ToString()),
                    new Claim(ClaimTypes.Role, novoUsuario.Role.ToString())
               });
            
            contextUser = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(claimsUser)
                }
            };

        }

        [Test]
        public void AdicionarNovoUsuario()
        {
            mockUsuario.Setup(u => u.Add(It.IsAny<Usuario>())).Returns(novoUsuario);

            var resultado = usuariosController.Add(novoUsuario);

            Assert.IsInstanceOf<OkObjectResult>(resultado);
        }

        [Test]
        public void AdicionarNovoUsuarioJaExistente()
        {
            mockUsuario.Setup(u => u.VerificaExistente(It.IsAny<Usuario>())).Returns(true);

            var resultado = usuariosController.Add(novoUsuario);

            Assert.IsInstanceOf<BadRequestObjectResult>(resultado);
        }

        [Test]
        public void CriarNovoUsuarioIncorreto()
        {
            usuariosController.ModelState.AddModelError("test", "test");

            var resultado = usuariosController.Add(novoUsuario);

            Assert.IsInstanceOf<BadRequestObjectResult>(resultado);
        }
        [Test]
        public void RetornaTokenAutenticacao()
        {
            mockUsuario.Setup(u => u.Authenticate(It.IsAny<UsuarioLogin>())).Returns(novoUsuarioSaidaModel);

            var resultado = usuariosController.Authenticate(novoUsuarioEntradaModel);

            Assert.IsInstanceOf<OkObjectResult>(resultado);
        }

        [Test]
        public void TentaAutenticarUsuarioIncorreto()
        {
            mockUsuario.Setup(u => u.Authenticate(It.IsAny<UsuarioLogin>())).Returns<UsuarioToken>(null);

            var resultado = usuariosController.Authenticate(novoUsuarioEntradaModel);

            Assert.IsInstanceOf<UnauthorizedResult>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void AlterarUsuario(int id)
        {
            mockUsuario.Setup(u => u.RetornaLogin(It.IsAny<int>())).Returns(novoUsuario.Login);

            usuariosController.ControllerContext = contextUser;
            
            var resultado = usuariosController.Update(id, novoUsuario);

            Assert.IsInstanceOf<OkObjectResult>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void UpdateIncorreto(int id)
        {
            mockUsuario.Setup(e => e.RetornaLogin(It.IsAny<int>())).Returns(usuarioDiferenteDoLogado.Login);

            usuariosController.ControllerContext = contextUser;

            var resultado = usuariosController.Update(id, novoUsuario);

            Assert.IsInstanceOf<BadRequestObjectResult>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void RemoverUsuario(int id)
        {
            mockUsuario.Setup(e => e.Remove(It.IsAny<int>()));

            var resultado = usuariosController.Remove(id);

            Assert.IsInstanceOf<NoContentResult>(resultado);
        }
    }
}
