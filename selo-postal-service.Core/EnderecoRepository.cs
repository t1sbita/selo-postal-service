using System;
using System.Collections.Generic;
using System.Linq;
using selo_postal_service.Dados;
using selo_postal_service.Dados.DTO;

namespace selo_postal_service.Core
{
    public class EnderecoRepository
    {
        ListaEnderecos listaEnderecos = new ListaEnderecos();
        List<Endereco> resultadoPesquisaEndereco = new List<Endereco>();
        public IEnumerable<Endereco> GetByParamets(SearchEnderecoQueryItem enderecoQueryItem)
        {

            resultadoPesquisaEndereco = listaEnderecos.Lista();

            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.Cidade))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.Cidade == enderecoQueryItem.Cidade).ToList();
            }
            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.Estado))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.Estado == enderecoQueryItem.Estado).ToList();
            }
            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.CodigoPostal))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.CodigoPostal == enderecoQueryItem.CodigoPostal).ToList();
            }


            if (resultadoPesquisaEndereco.Count == 0 || resultadoPesquisaEndereco == null)
            {
                throw new NotFoundException("Não foram encontrados Membros");
                
            }

            return resultadoPesquisaEndereco;
            
        }
    }
}