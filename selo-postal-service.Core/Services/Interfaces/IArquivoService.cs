using System.Collections.Generic;
using selo_postal_service.Core.Domain.DTO;

namespace selo_postal_service.Core.Services.Interfaces
{
    public interface IArquivoService
    {
        void CreateArchive(IEnumerable<TsvObjectItem> list);
    }
}