using System;
using System.Collections.Generic;
using System.Linq;
using selo_postal_service.Dados;

namespace selo_postal_service.Core
{
    public class PesquisaLista
    {
        List<Etiquetas> resultadoPesquisa = new List<Etiquetas>();
        public List<Etiquetas> Pesquisar(string cidade, string estado, string codigoPostal, string paginaDesejada, string qtdPorPagina, List<Etiquetas> lista)
        {

            resultadoPesquisa = lista;
            
            if (!cidade.Equals(""))
            {
                resultadoPesquisa = resultadoPesquisa.Where(x => x.Cidade == cidade).ToList();
            }
            if (!estado.Equals(""))
            {
                resultadoPesquisa = resultadoPesquisa.Where(x => x.Estado == estado).ToList();
            }
            if (!codigoPostal.Equals(""))
            {
                resultadoPesquisa = resultadoPesquisa.Where(x => x.CodigoPostal == codigoPostal).ToList();
            }


            if (resultadoPesquisa.Count == 0)
            {
                throw new Exception("Não foram encontrados Membros");
                
            }

            return resultadoPesquisa;
            
        }
    }
}