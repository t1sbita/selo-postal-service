using NUnit.Framework;
using Moq;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services;

namespace selo_postal_api.Tests.Core
{
    [TestFixture]
    class QrCodeServiceTest
    {
        private Mock<IQrCodeRepository> mockQrCode;
        private QrCodeService qrCodeService;

        [SetUp]
        public void Setup()
        {
            mockQrCode = new Mock<IQrCodeRepository>();

            qrCodeService = new QrCodeService(mockQrCode.Object);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void PesquisarQrCode(int id)
        {
            byte[] imagem = new byte[1024];

            mockQrCode.Setup(e => e.GetQrCode(It.IsAny<int>())).Returns(imagem);

            var resultado = qrCodeService.GetQrCode(id);

            Assert.AreEqual(imagem, resultado);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void PesquisarQrCodeInexistente(int id)
        {
            byte[] imagem = null;

            mockQrCode.Setup(e => e.GetQrCode(It.IsAny<int>())).Returns(imagem);

            var resultado = qrCodeService.GetQrCode(id);

            Assert.IsNull(resultado);
        }

    }
}
