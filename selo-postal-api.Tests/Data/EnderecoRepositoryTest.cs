using NUnit.Framework;
using Moq;
using System;

using selo_postal_api.Data.Context;
using selo_postal_api.Data.Repository;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Exceptions;
using selo_postal_api.Core.Domain.DTO;
using System.Collections.Generic;
using selo_postal_api.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace selo_postal_api.Tests.Data
{
    [TestFixture]
    class EnderecoRepositoryTest
    {
        private Mock<DbSet<Endereco>> mockEndereco;
        private Mock<DbSet<Cidade>> mockCidade;
        private Mock<PostgresContext> mockContext;

        private EnderecoRepository enderecoRepository;

        private Endereco enderecoTeste3;
        private EnderecoModel enderecoModel;
        private EnderecoModel enderecoModelIncorreto;
        private SearchEnderecoQueryItem filtro;
        private SearchEnderecoQueryItem filtroInvalido;
        private PageRequest pr;

        [SetUp]
        public void Setup()
        {
            Cidade cidadeTeste = new Cidade()
            {
                Municipio = "MunicipioTeste",
                Estado = "TE"
            };

            var dataCidade = new List<Cidade>
                {
                    new Cidade {Id = 100, Municipio = "Cidade A", Estado="BA" },
                    new Cidade {Id = 101, Municipio = "Cidade B", Estado="RJ" },
                    new Cidade {Id = 102, Municipio = "Cidade C", Estado="BA" },
                }.AsQueryable();

            var dataEndereco = new List<Endereco>
                {
                    new Endereco {Id = 1, Nome = "Usuario teste" , EnderecoCasa = "Endereco A", NumeroCasa="08", Bairro = "Bairro Teste",CodigoPostal = "AS323DSAS", Cidade = cidadeTeste },
                    new Endereco {Id = 2, Nome = "Teste2" , EnderecoCasa = "Endereco B", NumeroCasa="14", Bairro = "Barro",CodigoPostal = "FRGF342D", Cidade =  dataCidade.Last()},
                    new Endereco {Id = 3, Nome = "Testante Testado" , EnderecoCasa = "Endereco C", NumeroCasa="07", Bairro = "Bairro da Testante",CodigoPostal = "23FHGJ433", Cidade = dataCidade.First() },
                    new Endereco {Id = 4, Nome = "Usuario Teste3", EnderecoCasa = "Endereco Teste3", NumeroCasa = "NumeroTeste3", Bairro = "Bairro Teste3", Cidade = cidadeTeste }
                }.AsQueryable();
            mockCidade = new Mock<DbSet<Cidade>>();
            mockCidade.As<IQueryable<Cidade>>().Setup(m => m.Provider).Returns(dataCidade.Provider);
            mockCidade.As<IQueryable<Cidade>>().Setup(m => m.Expression).Returns(dataCidade.Expression);
            mockCidade.As<IQueryable<Cidade>>().Setup(m => m.ElementType).Returns(dataCidade.ElementType);
            mockCidade.As<IQueryable<Cidade>>().Setup(m => m.GetEnumerator()).Returns(dataCidade.GetEnumerator());

            mockEndereco = new Mock<DbSet<Endereco>>();
            mockEndereco = new Mock<DbSet<Endereco>>();
            mockEndereco.As<IQueryable<Endereco>>().Setup(m => m.Provider).Returns(dataEndereco.Provider);
            mockEndereco.As<IQueryable<Endereco>>().Setup(m => m.Expression).Returns(dataEndereco.Expression);
            mockEndereco.As<IQueryable<Endereco>>().Setup(m => m.ElementType).Returns(dataEndereco.ElementType);
            mockEndereco.As<IQueryable<Endereco>>().Setup(m => m.GetEnumerator()).Returns(dataEndereco.GetEnumerator());

            mockContext = new Mock<PostgresContext>();

            mockContext.Setup(m => m.Endereco).Returns(mockEndereco.Object);
            mockContext.Setup(m => m.Cidade).Returns(mockCidade.Object);

            enderecoRepository = new EnderecoRepository(mockContext.Object);


            Cidade cidadeTeste2 = new Cidade()
            {
                Municipio = "MunicipioTeste2",
                Estado = "TS"
            };

            Endereco enderecoTeste1 = new Endereco()
            {
                Nome = "Usuario Teste",
                EnderecoCasa = "Endereco Teste",
                NumeroCasa = "NumeroTeste",
                Bairro = "Bairro Teste",
                Cidade = cidadeTeste,
                CriadoEm = DateTime.Now
            };
            Endereco enderecoTeste2 = new Endereco()
            {
                Nome = "Usuario Teste2",
                EnderecoCasa = "Endereco Teste2",
                NumeroCasa = "NumeroTeste2",
                Bairro = "Bairro Teste2",
                Cidade = cidadeTeste2,
                CriadoEm = DateTime.Now
            };
            enderecoTeste3 = new Endereco()
            {
                Nome = "Usuario Teste3",
                EnderecoCasa = "Endereco Teste3",
                NumeroCasa = "NumeroTeste3",
                Bairro = "Bairro Teste3",
                Cidade = cidadeTeste,
                CriadoEm = DateTime.Now
            };
            enderecoModel = new EnderecoModel()
            {
                Nome = "Alex Gamas",
                EnderecoCasa = "Rua Alceu Amoroso Lima",
                NumeroCasa = "120",
                CodigoPostal = "XC990N01233",
                Bairro = "Caminho das Arvores",
                Cidade = 101
            };

            enderecoModelIncorreto = new EnderecoModel()
            {
                Nome = "Alex Gamas",
                EnderecoCasa = "Rua Alceu Amoroso Lima",
                NumeroCasa = "120",
                CodigoPostal = "XC990N01233",
                Bairro = "Caminho das Arvores",
                Cidade = 4386
            };

            filtro = new SearchEnderecoQueryItem()
            {
                Cidade = "MunicipioTeste"
            };

            filtroInvalido = new SearchEnderecoQueryItem()
            {
                Cidade = "Invalidado"
            };

            pr = PageRequest.Of(1, 10);

        }

        [Test]
        public void DeveRetornarInformacoesValidas()
        {
            var resultado = enderecoRepository.GetByParameters(filtro, pr);

            Assert.IsInstanceOf<List<Endereco>>(resultado);

        }

        [Test]
        public void DeveRetornarVazio()
        {
            var resultado = enderecoRepository.GetByParameters(filtroInvalido, pr);

            Assert.IsEmpty(resultado);

        }

        [TestCase(1)]
        [TestCase(3)]
        public void DeveRetornarUmEndereco(int id)
        {
            var resultado = enderecoRepository.GetById(id);
            Assert.IsInstanceOf<Endereco>(resultado);
        }

        [TestCase(5)]
        [TestCase(13)]
        public void DeveRetornarNotFound(int id)
        {
            var resultado = Assert.Throws<NotFoundException>(() => enderecoRepository.GetById(id));

            Assert.IsInstanceOf<NotFoundException>(resultado);
        }

        [Test]
        public void CriarNovoEndereco()
        {
            enderecoRepository.Add(enderecoModel);
            mockEndereco.Verify(e => e.Add(It.IsAny<Endereco>()), Times.Once);
            mockContext.Verify(e => e.SaveChanges(), Times.Once);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void AlterarEndereco(int id)
        {

            var resultado = enderecoRepository.Update(id, enderecoModel);

            Assert.IsInstanceOf<Endereco>(resultado);
        }

        [TestCase(1, "Cidade não encontrada")]
        [TestCase(5, "Id de endereço não encontrado")]
        public void AlterarEnderecoIncorreto(int id, string message)
        {
            var exception = Assert.Throws<NotFoundException>(() => enderecoRepository.Update(id, enderecoModelIncorreto));

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void RemoveEndereco(int id)
        {
            enderecoRepository.Remove(id);
            mockEndereco.Verify(e => e.Remove(It.IsAny<Endereco>()), Times.Once);
            mockContext.Verify(e => e.SaveChanges(), Times.Once);
        }

        [TestCase(10)]
        [TestCase(5)]
        public void RemoveEnderecoInexistente(int id)
        {
            var exception = Assert.Throws<NotFoundException>(() => enderecoRepository.Remove(id));

            Assert.That(exception.Message, Is.EqualTo("Id de endereço não encontrado"));
        }

    }
}
