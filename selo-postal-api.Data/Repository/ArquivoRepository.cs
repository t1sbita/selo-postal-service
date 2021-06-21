using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Interfaces;

namespace selo_postal_api.Data.Repository
{
    public class ArquivoRepository : IArquivoRepository
    {

        /// <summary>
        /// Cria um arquivo .tsv com o resultado da query
        /// </summary>
        public byte[] CreateArchive(IEnumerable<TsvObjectItem> list)
        {
            
            
            HeaderEndereco header = new HeaderEndereco();
            using (var memoryStream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8))
                {
                    //writer.WriteLine($"quantidadePorPagina\tPaginaAtual\tQuantidadePaginas\tTotalRegistros");
                    writer.WriteLine(header.ToString());
                    writer.Flush();

                    foreach (TsvObjectItem item in list)
                    {
                        writer.WriteLine(item.ToString());
                        

                    }
                    writer.Flush();
                }
                
                byte[] arquivo = memoryStream.ToArray();
                return arquivo;
            }
            
        }
    }
}