using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;

namespace selo_postal_service.Application.Controller.Interfaces
{
    public interface IEnderecoController
    {
        void Search(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest);
    }
}