using System;
using System.Collections.Generic;
using System.Linq;

using selo_postal_service.Core.Exceptions;
using selo_postal_service.Core.Interfaces;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;


namespace selo_postal_service.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {

        public List<Endereco> GetByParamets(SearchEnderecoQueryItem enderecoQueryItem, PageRequest pr)
        {

            IQueryable<Endereco> resultadoPesquisaEndereco = ListaEnderecos.RetornaLista().AsQueryable();


            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.Estado))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.Estado == enderecoQueryItem.Estado);
            }

            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.Cidade))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.Cidade == enderecoQueryItem.Cidade);
            }

            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.CodigoPostal))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.CodigoPostal == enderecoQueryItem.CodigoPostal);
            }

            var page = Pagination<Endereco>.For(resultadoPesquisaEndereco, pr).ToList();


            if (page == null || page.Count() == 0)
            {
                throw new NotFoundException("Não existem endereços nesta página");
            }

            return page;

        }
    }
}