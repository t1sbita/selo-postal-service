using System.Collections.Generic;

using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.Models;

namespace selo_postal_api.Core.Interfaces
{
    public interface IEnderecoRepository
    {
        List<Endereco> GetByParameters(SearchEnderecoQueryItem enderecoQueryItem, PageRequest pr);
        Endereco Update(int id, EnderecoModel endereco);
        Endereco Add(EnderecoModel endereco);
        void Remove(int id);
        Endereco GetById(int id);
    }
}