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

namespace selo_postal_api.Tests.Data
{
    [TestFixture]
    class EnderecoRepositoryTest
    {
        private Mock<DbSet<Endereco>> mockEndereco;
        private Mock<PostgresContext> mockContext;
        
        private EnderecoRepository enderecoRepository;

        private Endereco enderecoTeste3;
        private EnderecoModel enderecoModel;
        private SearchEnderecoQueryItem filtro;
        private PageRequest pr;

        [SetUp]
        public void Setup()
        {
            mockEndereco = new Mock<DbSet<Endereco>>();
            mockCidade = new Mock<DbSet<Cidade>>();

            mockContext = new Mock<PostgresContext>();

            mockContext.Setup(m => m.Endereco).Returns(mockEndereco.Object);

            enderecoRepository = new EnderecoRepository(mockContext.Object);

            Cidade cidadeTeste = new Cidade()
            {
                Municipio = "MunicipioTeste",
                Estado = "TE"
            };
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
                Cidade = 4386
            };

            filtro = new SearchEnderecoQueryItem()
            {
                Cidade = "MunicipioTeste"
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
            var resultado = enderecoRepository.GetByParameters(filtro, pr);

            Assert.IsEmpty(resultado);

        }

        [TestCase(1)]
        [TestCase(5)]
        public void DeveRetornarUmEndereco(int id)
        {
            var resultado = enderecoRepository.GetById(id);

            Assert.IsInstanceOf<Endereco>(resultado);
        }

        [Test]
        public void CriarNovoEndereco()
        {
            enderecoRepository.Add(enderecoModel);
            mockEndereco.Verify(e => e.Add(It.IsAny<Endereco>()), Times.Once);
            mockContext.Verify(e => e.SaveChanges(), Times.Once);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void AlterarEndereco(int id)
        {
            
            var resultado = enderecoRepository.Update(id, enderecoModel);

            Assert.IsInstanceOf<Endereco>(resultado);
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
            var endereco = enderecoRepository.GetById(id);

            var exception = Assert.Throws<NotFoundException>(() => enderecoRepository.Remove(id));

            Assert.That(exception.Message, Is.EqualTo("Endereço não encontrado!"));
        }

    }
}
