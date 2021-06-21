using System.Collections.Generic;

using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services.Interfaces;

namespace selo_postal_api.Core.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public Endereco Add(Endereco endereco)
        {
            return _enderecoRepository.Add(endereco);
        }

        public Endereco AlterarCidade(int id, Cidade cidade)
        {
            return _enderecoRepository.AlterarCidade(id, cidade);
        }

        public List<Endereco> GetByParameters(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest)
        {
            return _enderecoRepository.GetByParamets(searchEnderecoQueryItem, pageRequest);
            
        }
    }
}