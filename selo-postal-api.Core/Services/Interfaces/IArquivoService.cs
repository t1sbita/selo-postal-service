using System.Collections.Generic;
using System.IO;
using selo_postal_api.Core.Domain.DTO;

namespace selo_postal_api.Core.Services.Interfaces
{
    public interface IArquivoService
    {
        public byte[] CreateArchive(IEnumerable<TsvObjectItem> list);
    }
}