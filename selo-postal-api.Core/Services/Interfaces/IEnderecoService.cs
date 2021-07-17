using System.Collections.Generic;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.Models;

namespace selo_postal_api.Core.Services.Interfaces
{
    public interface IEnderecoService
    {
        EnderecoModelResponse Add(EnderecoModel endereco);
        EnderecoPagination GetByParameters(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest);
        EnderecoModelResponse GetById(int id);
        EnderecoModelResponse Update(int id, EnderecoModel endereco);
        void Remove(int id);
    }
}