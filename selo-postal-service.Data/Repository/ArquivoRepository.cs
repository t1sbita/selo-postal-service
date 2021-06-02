using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Interfaces;

namespace selo_postal_service.Data.Repository
{
    public class ArquivoRepository : IArquivoRepository
    {

        /// <summary>
        /// Cria um arquivo .tsv com o resultado da query
        /// </summary>
        public void CreateArchive(IEnumerable<TsvObjectItem> list)
        {
            string gerarNomeArquivo = DateTime.Now.ToString("u").Replace(":", "");

            string novoArquivo = @"..\..\TSV\Pesquisa " + gerarNomeArquivo + ".tsv";

            HeaderEndereco header = new HeaderEndereco();  
            using (FileStream fluxoDeArquivo = new FileStream(novoArquivo, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {
                //writer.WriteLine($"quantidadePorPagina\tPaginaAtual\tQuantidadePaginas\tTotalRegistros");
                writer.WriteLine(header.ToString());
                writer.Flush();
                
                foreach (TsvObjectItem item in list)
                {
                    writer.WriteLine(item.ToString());
                    writer.Flush();

                }
            }
        }
    }
}