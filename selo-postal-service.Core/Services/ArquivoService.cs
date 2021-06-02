using System.Collections.Generic;

using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Interfaces;
using selo_postal_service.Core.Services.Interfaces;

namespace selo_postal_service.Core.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _enderecoRepository;

        public ArquivoService(IArquivoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void CreateArchive(IEnumerable<TsvObjectItem> list)
        {
            _enderecoRepository.CreateArchive(list);
        }
    }
}