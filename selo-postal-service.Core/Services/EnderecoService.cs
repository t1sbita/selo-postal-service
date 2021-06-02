using System.Collections.Generic;

using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Interfaces;

namespace selo_postal_service.Core.Services
{
    public class EnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public List<Endereco> GetByParameters(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest)
        {
            return _enderecoRepository.GetByParamets(searchEnderecoQueryItem, pageRequest);
            
        }
    }
}