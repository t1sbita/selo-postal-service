using System.Collections.Generic;

using selo_postal_service.Core.Domain.Entities;

namespace selo_postal_service.Core.Interfaces
{
    public interface IArquivoRepository
    {
        /// <summary>
        /// Cria um arquivo .tsv com o resultado da query
        /// </summary>
        void CriarArquivo(IEnumerable<Endereco> list);
    }
}