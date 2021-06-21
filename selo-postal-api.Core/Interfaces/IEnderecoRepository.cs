using System.Collections.Generic;

using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;

namespace selo_postal_api.Core.Interfaces
{
    public interface IEnderecoRepository
    {
        List<Endereco> GetByParamets(SearchEnderecoQueryItem enderecoQueryItem, PageRequest pr);
        Endereco AlterarCidade(int id, Cidade cidade);
        Endereco Add(Endereco endereco);
    }
}