using System;
using System.Collections.Generic;
using System.Linq;
using selo_postal_service.Core.Exceptions;
using selo_postal_service.Dados;
using selo_postal_service.Dados.DTO;

namespace selo_postal_service.Core
{
    public class EnderecoRepository
    {

        public List<Etiquetas> GetByParamets(SearchEnderecoQueryItem enderecoQueryItem, PageRequest pr)
        {
            IQueryable<Etiquetas> resultadoPesquisaEndereco = ListaEnderecos.RetornaLista().AsQueryable();

            // resultadoPesquisaEndereco.All()

            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.Cidade))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.Cidade == enderecoQueryItem.Cidade);
            }

            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.Estado))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.Estado == enderecoQueryItem.Estado);
            }

            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.CodigoPostal))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.CodigoPostal == enderecoQueryItem.CodigoPostal);
            }

            var page = Pagination<Etiquetas>.For(resultadoPesquisaEndereco, pr).ToList();


            if (page == null || page.Count() == 0)
            {
                throw new NotFoundException("Não foram encontrados Membros");
            }

            return page;

        }
    }
}