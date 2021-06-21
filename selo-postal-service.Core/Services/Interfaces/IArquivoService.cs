using System.Collections.Generic;
using selo_postal_service.Core.Domain.DTO;

namespace selo_postal_service.Core.Services.Interfaces
{
    public interface IArquivoService
    {
        string CreateArchive(IEnumerable<TsvObjectItem> list);
    }
}