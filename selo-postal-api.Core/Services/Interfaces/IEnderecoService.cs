using System.Collections.Generic;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.Models;

namespace selo_postal_api.Core.Services.Interfaces
{
    public interface IEnderecoService
    {
        EnderecoModel Add(EnderecoModel endereco);
        List<EnderecoModel> GetByParameters(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest);
        EnderecoModel GetById(int id);
        EnderecoModel Update(int id, EnderecoModel endereco);
        void Remove(int id);
    }
}