using System.Collections.Generic;

using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.Models;

namespace selo_postal_api.Core.Interfaces
{
    public interface IEnderecoRepository
    {
        IEnumerable<Endereco> GetAll();
        Endereco Update(Endereco endereco);
        Endereco Add(Endereco endereco);
        void Remove(int id);
        Endereco GetById(int id);
    }
}