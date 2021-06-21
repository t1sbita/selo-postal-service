using System.Collections.Generic;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;

namespace selo_postal_api.Core.Services.Interfaces
{
    public interface IEnderecoService
    {
        List<Endereco> GetByParameters(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest);
        Endereco AlterarCidade(int id, Cidade cidade);
        Endereco Add(Endereco endereco);
    }
}