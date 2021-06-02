using System.Collections.Generic;

using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;

namespace selo_postal_service.Core.Interfaces
{
    public interface IEnderecoRepository
    {
        List<Endereco> GetByParamets(SearchEnderecoQueryItem enderecoQueryItem, PageRequest pr);
    }
}