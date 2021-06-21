using System.Collections.Generic;
using System.IO;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services.Interfaces;

namespace selo_postal_api.Core.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;

        public ArquivoService(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }

        public byte[] CreateArchive(IEnumerable<TsvObjectItem> list)
        {
            return _arquivoRepository.CreateArchive(list);
        }
    }
}