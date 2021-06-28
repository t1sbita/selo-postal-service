using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;

using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Data.Context;
using selo_postal_api.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using selo_postal_api.Core.Exceptions;

namespace selo_postal_api.Tests.Data
{
    [TestFixture]
    public class UsuarioRepositoryTest
    {
        private Mock<DbSet<Usuario>> mockUsuario;
        private Mock<PostgresContext> mockContext;
        private UsuarioRepository usuarioRepository;
        private Usuario novoUsuario;
        private Usuario usuarioDiferenteDoLogado;
        private IQueryable<Usuario> dataUsuario;

        [SetUp]
        public void Setup()
        {
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
            dataUsuario = new List<Usuario>()
            {
                novoUsuario,
                new Usuario(){Id = 3, Login = "usuario3", Password = "senhateste", Role = "padrao"},
                new Usuario(){Id = 4, Login = "usuario4", Password = "senhateste", Role = "padrao"},

            }.AsQueryable();

            mockUsuario = new Mock<DbSet<Usuario>>();
            mockUsuario.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(dataUsuario.Provider);
            mockUsuario.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(dataUsuario.Expression);
            mockUsuario.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(dataUsuario.ElementType);
            mockUsuario.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(dataUsuario.GetEnumerator());

            mockContext = new Mock<PostgresContext>();

            mockContext.Setup(m => m.Usuario).Returns(mockUsuario.Object);

            usuarioRepository = new UsuarioRepository(mockContext.Object);
        }

        [Test]
        public void AdicionarNovoUsuario()
        {
            usuarioRepository.Add(novoUsuario);
            mockUsuario.Verify(e => e.Add(It.IsAny<Usuario>()), Times.Once);
            mockContext.Verify(e => e.SaveChanges(), Times.Once);
        }

        [Test]
        public void RetornaUsuarioAutenticacao()
        {
            var resultado = usuarioRepository.Authenticate(novoUsuario.Login, novoUsuario.Password);
            Assert.AreEqual(novoUsuario, resultado);
        }

        [Test]
        public void RetornaUsuarioNull()
        {
            var resultado = usuarioRepository.Authenticate(usuarioDiferenteDoLogado.Login, usuarioDiferenteDoLogado.Password);
            Assert.IsNull(resultado);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void DeveRetornarLogin(int id)
        {
            var resultado = usuarioRepository.RetornaLogin(id);

            Assert.AreEqual(dataUsuario.FirstOrDefault(x => x.Id == id).Login, resultado);
        }

        [TestCase(2)]
        [TestCase(6)]
        public void DeveRetornarLoginNull(int id)
        {
            var resultado = usuarioRepository.RetornaLogin(id);

            Assert.IsNull(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void VerificaSeExiste(int id)
        {
            var resultado = usuarioRepository.VerificaExistente(novoUsuario);

            Assert.IsTrue(resultado);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void AlteraUsuario(int id)
        {
            var resultado = usuarioRepository.Update(id, novoUsuario);

            Assert.IsInstanceOf<Usuario>(resultado);
        }

        [TestCase(10)]
        [TestCase(6)]
        public void AlteraUsuarioInexistente(int id)
        {
            var resultado = usuarioRepository.Update(id, novoUsuario);

            Assert.IsNull(resultado);
        }
        
        

        [TestCase(1)]
        [TestCase(3)]
        public void RemoveUsuario(int id)
        {
            usuarioRepository.Remove(id);
            mockUsuario.Verify(e => e.Remove(It.IsAny<Usuario>()), Times.Once);
            mockContext.Verify(e => e.SaveChanges(), Times.Once);
        }

        [TestCase(10)]
        [TestCase(5)]
        public void RemoveUsuarioInexistente(int id)
        {
            var exception = Assert.Throws<NotFoundException>(() => usuarioRepository.Remove(id));

            Assert.That(exception.Message, Is.EqualTo("Usuario não encontrado!"));
        }

    }
}
