using selo_postal_service.Application.Controller.Interfaces;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;
using System;

namespace selo_postal_service.Application.Controller
{
    public class StartSystem
    {
        private readonly IEnderecoController _enderecoController;

        public StartSystem(IEnderecoController enderecoController)
        {
            _enderecoController = enderecoController;
        }

        public void Start(string cidade, string estado, string codigoPostal, int number, int limit)
        {
            SearchEnderecoQueryItem searchEnderecoQueryItem = new SearchEnderecoQueryItem(cidade, estado, codigoPostal);
            PageRequest pageRequest = PageRequest.Of(number, limit);

            _enderecoController.Search(searchEnderecoQueryItem, pageRequest);
        }

        

    }
}