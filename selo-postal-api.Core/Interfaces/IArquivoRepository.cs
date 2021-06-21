using System.Collections.Generic;
using System.IO;
using selo_postal_api.Core.Domain.DTO;


namespace selo_postal_api.Core.Interfaces
{
    public interface IArquivoRepository
    {
        /// <summary>
        /// Cria um arquivo .tsv com o resultado da query
        /// </summary>
        public byte[] CreateArchive(IEnumerable<TsvObjectItem> list);
    }
}