using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using selo_postal_service.Dados;
using System.Linq;
using selo_postal_service.Data.Domain.DTO;

namespace selo_postal_service.Core
{
    public class GeradorArquivo<TEntity> where TEntity : class
    {

        /// <summary>
        /// Cria um arquivo .tsv com o resultado da query
        /// </summary>
        public void CriarArquivo(IEnumerable<TEntity> list)
        {
            string gerarNomeArquivo = DateTime.Now.ToString("u").Replace(":", "");

            string novoArquivo = @"..\..\TSV\Pesquisa " + gerarNomeArquivo + ".tsv";

            HeaderEndereco header = new HeaderEndereco();  //Generic anulado pq não consegui generalizar aqui :/
            
            using (FileStream fluxoDeArquivo = new FileStream(novoArquivo, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {
                //writer.WriteLine($"quantidadePorPagina\tPaginaAtual\tQuantidadePaginas\tTotalRegistros");
                writer.WriteLine(header.ToString());
                writer.Flush();
                
                foreach (TEntity item in list)
                {
                    writer.WriteLine(item.ToString());
                    writer.Flush();

                }
            }
        }
    }
}