using System.Collections.Generic;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;

namespace selo_postal_service.Core.Services.Interfaces
{
    public interface IEnderecoService
    {
        List<Endereco> GetByParameters(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest);
    }
}