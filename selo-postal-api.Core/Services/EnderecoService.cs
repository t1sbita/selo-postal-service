using System;
using System.Collections.Generic;
using System.Linq;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.Models;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services.Interfaces;
using selo_postal_api.Core.Utils;

namespace selo_postal_api.Core.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public EnderecoModelResponse Add(EnderecoModel endereco)
        {
            // Endereco enderecoBanco = _enderecoRepository.Add(endereco);

            return null; // (EnderecoModelResponse)enderecoBanco;
        }

        public EnderecoPagination GetByParameters(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest)
        {
            List<EnderecoModelResponse> listaModel = new List<EnderecoModelResponse>();
            IEnumerable<Endereco> listaEnderecos = _enderecoRepository.GetAll();

                if (!String.IsNullOrWhiteSpace(searchEnderecoQueryItem.Estado))
            {
                listaEnderecos = listaEnderecos.Where(x => x.Cidade.Estado == searchEnderecoQueryItem.Estado);
            }

            if (!String.IsNullOrWhiteSpace(searchEnderecoQueryItem.Cidade))
            {
                listaEnderecos = listaEnderecos.Where(x => x.Cidade.Municipio == searchEnderecoQueryItem.Cidade);
            }

            if (!String.IsNullOrWhiteSpace(searchEnderecoQueryItem.CodigoPostal))
            {
                listaEnderecos = listaEnderecos.Where(x => x.CodigoPostal == searchEnderecoQueryItem.CodigoPostal);
            }
            
            foreach (Endereco endereco in listaEnderecos)
            {
                listaModel.Add((EnderecoModelResponse)endereco);
            }

            var page = Pagination<EnderecoModelResponse>.For(listaModel.AsQueryable(), pageRequest).ToList();

            int totalPaginas = (int)Math.Ceiling(listaModel.Count / (double)pageRequest.Limit);
            return new EnderecoPagination
            {
                Total = listaModel.Count,
                TotalPaginas = totalPaginas,
                QtdPorPagina = pageRequest.Limit,
                NumeroPagina = pageRequest.Number,
                Resultado = page,
                Anterior = pageRequest.Number > 1
                    ? String.Format(
                        Constants.UrlPaginationPattern,
                        searchEnderecoQueryItem.Cidade,
                        searchEnderecoQueryItem.Estado,
                        searchEnderecoQueryItem.CodigoPostal,
                        pageRequest.Number -1,
                        pageRequest.Limit
                        )
                    : "",
                Proximo = pageRequest.Number < totalPaginas
                    ? String.Format(
                        Constants.UrlPaginationPattern,
                        searchEnderecoQueryItem.Cidade,
                        searchEnderecoQueryItem.Estado,
                        searchEnderecoQueryItem.CodigoPostal,
                        pageRequest.Number +1,
                        pageRequest.Limit
                        )
                    : ""
            };
        }

        public EnderecoModelResponse GetById(int id)
        {
           return (EnderecoModelResponse)_enderecoRepository.GetById(id);
        }

        public EnderecoModelResponse Update(int id, EnderecoModel endereco)
        {
            return null; //(EnderecoModelResponse)_enderecoRepository.Update(endereco);

        }

        public void Remove(int id)
        {
            _enderecoRepository.Remove(id);
        }

    }
}