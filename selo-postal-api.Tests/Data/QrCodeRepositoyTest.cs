using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using selo_postal_api.Data.Repository;
using selo_postal_api.Data.Context;
using selo_postal_api.Core.Domain.Entities;

namespace selo_postal_api.Tests.Data
{
    [TestFixture]
    public class QrCodeRepositoyTest
    {
        private QrCodeRepository qrCodeRepository;
        private Mock<DbSet<Endereco>> mockEndereco;
        private Mock<DbSet<Cidade>> mockCidade;
        private Mock<PostgresContext> mockContext;

        [SetUp]
        public void Setup()
        {Cidade cidadeTeste = new Cidade()
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
                    new Endereco {Id = 1, Nome = "Usuario teste" , EnderecoCasa = "Endereco A", NumeroCasa="08", Bairro = "Bairro Teste",CodigoPostal = "AS323DSAS", Cidade = cidadeTeste , CidadeId = cidadeTeste.Id},
                    new Endereco {Id = 2, Nome = "Teste2" , EnderecoCasa = "Endereco B", NumeroCasa="14", Bairro = "Barro",CodigoPostal = "FRGF342D", Cidade =  dataCidade.Last(), CidadeId = 102},
                    new Endereco {Id = 3, Nome = "Testante Testado" , EnderecoCasa = "Endereco C", NumeroCasa="07", Bairro = "Bairro da Testante",CodigoPostal = "23FHGJ433", Cidade = dataCidade.First() , CidadeId = 100},
                    new Endereco {Id = 4, Nome = "Usuario Teste3", EnderecoCasa = "Endereco Teste3", NumeroCasa = "NumeroTeste3", Bairro = "Bairro Teste3", Cidade = cidadeTeste , CidadeId = cidadeTeste.Id}
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

            qrCodeRepository = new QrCodeRepository(mockContext.Object);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void RetornaUmaImagem(int id)
        {
            var resultado = qrCodeRepository.GetQrCode(id);

            Assert.IsInstanceOf<byte[]>(resultado);
        }

        [TestCase(10)]
        [TestCase(20)]
        public void RetornaUmaImagemNull(int id)
        {
            var resultado = qrCodeRepository.GetQrCode(id);

            Assert.IsNull(resultado);
        }

    }
}