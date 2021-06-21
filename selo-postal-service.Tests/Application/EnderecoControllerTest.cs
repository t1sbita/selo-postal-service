using NUnit.Framework;
using System;

using selo_postal_service.Application.Controller;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Services;
using selo_postal_service.Data.Repository;
using System.IO;
namespace selo_postal_service.Tests.Application
{
    [TestFixture]
    public class EnderecoControllerTest
    {

        EnderecoController enderecoController = new EnderecoController(new EnderecoService(new EnderecoRepository()), new ArquivoService(new ArquivoRepository()), new QrCodeService(new QrCodeRepository()));
        
        [SetUp]
        public void SetUp()
        {
            SearchEnderecoQueryItem search = new SearchEnderecoQueryItem(null, "Bahia", null);


        }

        [TestCase("Salvador", "Bahia", null, 1, 5, @"..\..\..\TsvTests\TsvTestCidadeEstado.tsv")]
        [TestCase(null, null, "CD548J2547", null, 11, @"..\..\..\TsvTests\TsvTestCodigo.tsv")]
        public void TestaSeTSVEstaCorreto(string cidade, string estado, string codigoPostal, Nullable<int> number, Nullable<int> limit, string expected)
        {
            string result = enderecoController.Search(cidade, estado, codigoPostal, number, limit);
            FileAssert.AreEqual(result, expected);
            File.Delete(result);
            Directory.Delete(@"..\..\..\QRCode", true);
            Directory.Delete(@"..\..\..\TSV", true);

        }

    }
}