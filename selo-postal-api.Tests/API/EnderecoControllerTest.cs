using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using selo_postal_api.Core.Services.Interfaces;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.Models;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Api.Controllers;
using System;

namespace selo_postal_api.Tests.API
{
    [TestFixture]
    class EnderecoControllerTest 
    {
        public SearchEnderecoQueryItem filtro;
        public PageRequest pr;
        
        public Mock<IEnderecoService> mockEndereco;
        public Mock<IQrCodeService> mockQrCode;

        public EnderecosController enderecosController;

        public Cidade salvador;
        public Endereco endereco;
        public EnderecoModel enderecoModel;
        public EnderecoModel enderecoModelModificado;

        public List<EnderecoModel> listaEndereco;
        public List<EnderecoModel> listaEnderecoVazia;

        [SetUp]
        public void Setup()
        {
            mockEndereco = new Mock<IEnderecoService>();
            mockQrCode = new Mock<IQrCodeService>();

            enderecosController = new EnderecosController(mockEndereco.Object, mockQrCode.Object);

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

            enderecoModel = new EnderecoModel()
            {
                Nome = "Alex Gamas",
                EnderecoCasa = "Rua Alceu Amoroso Lima",
                NumeroCasa = "120",
                CodigoPostal = "XC990N01233",
                Bairro = "Caminho das Arvores",
                Cidade = 4386
            };

            enderecoModelModificado = new EnderecoModel()
            {
                Nome = "Nome Alterado",
                EnderecoCasa = "Rua Modificado de Modifica",
                NumeroCasa = "10",
                CodigoPostal = "N0123XC9903",
                Bairro = "Bairro da Mudança",
                Cidade = 2365
            };

            listaEndereco = new List<EnderecoModel>();
            listaEndereco.Add(enderecoModel);

            listaEnderecoVazia = new List<EnderecoModel>();

            filtro = new SearchEnderecoQueryItem()
            {
                Cidade = "Salvador"
            };

            pr = PageRequest.Of(1, 10);

        }


        [TestCase(1, 5)]
        public void DeveRetornarInformacoesValidas(int number, int limit)
        {
            mockEndereco.Setup(e => e.GetByParameters(It.IsAny<SearchEnderecoQueryItem>(), It.IsAny<PageRequest>())).Returns(listaEndereco);
            
            var resultado = enderecosController.GetByParameters(filtro, number, limit);

            Assert.IsInstanceOf<OkObjectResult>(resultado);

        }

        [TestCase(1, 5)]
        public void DeveRetornarNotFound(int number, int limit)
        {
            mockEndereco.Setup(e => e.GetByParameters(It.IsAny<SearchEnderecoQueryItem>(), It.IsAny<PageRequest>())).Returns(listaEnderecoVazia);
            
            var resultado = enderecosController.GetByParameters(filtro, number, limit);

            Assert.IsInstanceOf<NoContentResult>(resultado);

        }

        [TestCase(1)]
        [TestCase(5)]
        public void DeveRetornarUmEndereco(int id)
        {
            mockEndereco.Setup(e => e.GetById(It.IsAny<int>())).Returns(enderecoModel);

            var resultado = enderecosController.GetById(id);

            Assert.IsInstanceOf<OkObjectResult>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void DeveRetornarNotFountById(int id)
        {
            mockEndereco.Setup(e => e.GetById(It.IsAny<int>())).Returns<EnderecoModel>(null);

            var resultado = enderecosController.GetById(id);

            Assert.IsInstanceOf<OkObjectResult>(resultado);
        }

        [Test]
        public void CriarNovoEndereco()
        {
            mockEndereco.Setup(e => e.Add(It.IsAny<EnderecoModel>())).Returns(enderecoModel);

            var resultado = enderecosController.Add(enderecoModel);

            Assert.IsInstanceOf<EnderecoModel>(enderecoModel);
        }

        [Test]
        public void CriarNovoEnderecoIncorreto()
        {
            enderecosController.ModelState.AddModelError("test", "test");

            var resultado = enderecosController.Add(enderecoModel);
            
            Assert.IsInstanceOf<BadRequestResult>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void AlterarEndereco(int id)
        {
            mockEndereco.Setup(e => e.Update(It.IsAny<int>(), It.IsAny<EnderecoModel>())).Returns(enderecoModelModificado);

            var resultado = enderecosController.Update(id, enderecoModelModificado);

            Assert.IsInstanceOf<OkObjectResult>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void UpdateIncorreto(int id)
        {
            enderecosController.ModelState.AddModelError("test", "test");

            var resultado = enderecosController.Update(id, enderecoModelModificado);

            Assert.IsInstanceOf<BadRequestResult>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void RemoverEndereco(int id)
        {
            mockEndereco.Setup(e => e.Remove(It.IsAny<int>()));

            var resultado = enderecosController.Remove(id);

            Assert.IsInstanceOf<NoContentResult>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void PesquisarQrCode(int id)
        {
            byte[] imagem = new byte[1024];
            
            mockQrCode.Setup(e => e.GetQrCode(It.IsAny<int>())).Returns(imagem);

            var resultado = enderecosController.GetQrCodes(id);

            Assert.IsInstanceOf<FileResult>(resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void PesquisarQrCodeInexistente(int id)
        {
            byte[] imagem = Array.Empty<byte>();

            mockQrCode.Setup(e => e.GetQrCode(It.IsAny<int>())).Returns(imagem);

            var resultado = enderecosController.GetQrCodes(id);

            Assert.IsInstanceOf<NotFoundResult>(resultado);
        }

    }
}
