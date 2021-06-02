using System.Collections.Generic;

using selo_postal_service.Core.Domain.DTO;


namespace selo_postal_service.Core.Interfaces
{
    public interface IArquivoRepository
    {
        /// <summary>
        /// Cria um arquivo .tsv com o resultado da query
        /// </summary>
        void CreateArchive(IEnumerable<TsvObjectItem> list);
    }
}