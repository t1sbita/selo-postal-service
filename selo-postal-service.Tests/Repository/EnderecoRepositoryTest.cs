using NUnit.Framework;
using System;

using selo_postal_service.Data.Repository;
using selo_postal_service.Core.Exceptions;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;

namespace selo_postal_service.Tests.Repository
{
    [TestFixture]
    class EnderecoRepositoryTest
    {
        EnderecoRepository enderecoRepository;
        SearchEnderecoQueryItem searchEnderecoQueryItem;
        PageRequest pageRequest;

        [SetUp]
        public void SetUp()
        {
            enderecoRepository = new EnderecoRepository();
            searchEnderecoQueryItem = new SearchEnderecoQueryItem(null, null, null);
            pageRequest = PageRequest.First();
        }

        [TestCase]
        public void TestaLancamentoException()
        {
            var teste = searchEnderecoQueryItem;
            var pagina = pageRequest;
            Assert.Throws<NotFoundException>(
                () => enderecoRepository.GetByParamets(searchEnderecoQueryItem, pageRequest)
                );
        }

    }
}
