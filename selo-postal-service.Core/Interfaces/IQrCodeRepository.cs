using System.Collections.Generic;

using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;

namespace selo_postal_service.Core.Interfaces
{
    public interface IQrCodeRepository
    {
        List<TsvObjectItem> GetQrCode(List<Endereco> list);
    }
}