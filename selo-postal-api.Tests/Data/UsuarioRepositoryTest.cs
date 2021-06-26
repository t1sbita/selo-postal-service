using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;

using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Data.Context;
using selo_postal_api.Data.Repository;
using System.Collections.Generic;
using System.Linq;

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
            var dataUsuario = new List<Usuario>()
            {
                new Usuario(){Id = 1, Login = "usuario1", Password = "senhateste", Role = "teste"},
                novoUsuario,
                usuarioDiferenteDoLogado

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
    }
}
