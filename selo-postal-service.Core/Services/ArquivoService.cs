using System.Collections.Generic;

using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Interfaces;
using selo_postal_service.Core.Services.Interfaces;

namespace selo_postal_service.Core.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;

        public ArquivoService(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }

        public string CreateArchive(IEnumerable<TsvObjectItem> list)
        {
            return _arquivoRepository.CreateArchive(list);
        }
    }
}