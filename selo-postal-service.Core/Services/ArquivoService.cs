using System.Collections.Generic;

using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Interfaces;

namespace selo_postal_service.Core.Services
{
    public class ArquivoService
    {
        private readonly IArquivoRepository _enderecoRepository;

        public ArquivoService(IArquivoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void CriarArquivo(IEnumerable<Endereco> list)
        {
            _enderecoRepository.CriarArquivo(list);
        }
    }
}