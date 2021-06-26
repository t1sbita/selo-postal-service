using NUnit.Framework;
using Moq;
using System.Collections.Generic;

using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services;
using selo_postal_api.Core.Domain.Models;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Exceptions;

namespace selo_postal_api.Tests.Core
{
    [TestFixture]
    class EnderecoServiceTest
    {
        private Mock<IEnderecoRepository> mockEndereco;

        private EnderecoService enderecoService;

        private SearchEnderecoQueryItem filtro;
        private PageRequest pr;

        private Cidade salvador;
        private Endereco endereco;
        private EnderecoModel enderecoModel;
        private List<EnderecoModel> listaEnderecoModel;
        private List<Endereco> listaEndereco;
        private List<Endereco> listaEnderecoVazia;
        private EnderecoModel enderecoModelModificado;
        private Endereco enderecoModificado;

        [SetUp]
        public void Setup()
        {
            mockEndereco = new Mock<IEnderecoRepository>();

            enderecoService = new EnderecoService(mockEndereco.Object);

            salvador = new Cidade()
            {
                Id = 4386,
                Municipio = "Salvador",
                Estado = "BA"
            };

            endereco = new Endereco()
            {
                Nome = "Alex Gamas",
                EnderecoCasa = "Rua Alceu Amoroso Lima",
                NumeroCasa = "120",
                CodigoPostal = "XC990N01233",
                Bairro = "Caminho das Arvores",
                Cidade = salvador,
                CriadoEm = System.DateTime.Now
            };
            listaEndereco = new List<Endereco>();
            listaEndereco.Add(endereco);

            enderecoModel = new EnderecoModel()
            {
                Nome = "Alex Gamas",
                EnderecoCasa = "Rua Alceu Amoroso Lima",
                NumeroCasa = "120",
                CodigoPostal = "XC990N01233",
                Bairro = "Caminho das Arvores",
                Cidade = 4386
            };

            listaEnderecoModel = new List<EnderecoModel>();
            listaEnderecoModel.Add(enderecoModel);

            enderecoModelModificado = new EnderecoModel()
            {
                Nome = "Nome Alterado",
                EnderecoCasa = "Rua Modificado de Modifica",
                NumeroCasa = "10",
                CodigoPostal = "N0123XC9903",
                Bairro = "Bairro da Mudança",
                Cidade = 2365
            };

            enderecoModificado = new Endereco()
            {
                Nome = "Nome Alterado",
                EnderecoCasa = "Rua Modificado de Modifica",
                NumeroCasa = "10",
                CodigoPostal = "N0123XC9903",
                Bairro = "Bairro da Mudança",
                Cidade = salvador
            };

            listaEnderecoVazia = new List<Endereco>();

            filtro = new SearchEnderecoQueryItem()
            {
                Cidade = "Salvador"
            };

            pr = PageRequest.Of(1, 10);

        }

        [Test]
        public void DeveRetornarInformacoesValidas()
        {
            mockEndereco.Setup(e => e.GetByParameters(It.IsAny<SearchEnderecoQueryItem>(), It.IsAny<PageRequest>())).Returns(listaEndereco);

            var resultado = enderecoService.GetByParameters(filtro, pr);

            Assert.IsInstanceOf<IList<EnderecoModel>>(resultado);

        }

        [Test]
        public void DeveRetornarVazio()
        {
            mockEndereco.Setup(e => e.GetByParameters(It.IsAny<SearchEnderecoQueryItem>(), It.IsAny<PageRequest>())).Returns(listaEnderecoVazia);

            var resultado = enderecoService.GetByParameters(filtro, pr);

            Assert.IsEmpty(resultado);

        }

        [TestCase(1)]
        [TestCase(5)]
        public void DeveRetornarUmEndereco(int id)
        {
            mockEndereco.Setup(e => e.GetById(It.IsAny<int>())).Returns(endereco);

            var resultado = enderecoService.GetById(id);

            Assert.IsInstanceOf<EnderecoModel>(resultado);
        }

        [Test]
        public void CriarNovoEndereco()
        {
            mockEndereco.Setup(e => e.Add(It.IsAny<EnderecoModel>())).Returns(endereco);

            var resultado = enderecoService.Add(enderecoModel);

            Assert.IsInstanceOf<EnderecoModel>(enderecoModel);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void AlterarEndereco(int id)
        {
            mockEndereco.Setup(e => e.Update(It.IsAny<int>(), It.IsAny<EnderecoModel>())).Returns(enderecoModificado);

            var resultado = enderecoService.Update(id, enderecoModelModificado);

            Assert.IsInstanceOf<EnderecoModel>(resultado);
        }

        [TestCase(50, "Endereço não encontrado!")]
        public void RemoveUsuarioIncorreto(int id, string message){
            mockEndereco.Setup(u => u.Remove(It.IsAny<int>())).Throws(new NotFoundException("Endereço não encontrado!"));
            var exception = Assert.Throws<NotFoundException>(() => enderecoService.Remove(id));

            Assert.That(exception.Message, Is.EqualTo(message));
        }
        
    }
}
