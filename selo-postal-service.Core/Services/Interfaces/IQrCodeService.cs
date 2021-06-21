using System.Collections.Generic;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;

namespace selo_postal_service.Core.Services.Interfaces
{
    public interface IQrCodeService
    {
        List<TsvObjectItem> GetQrCode(List<Endereco> list);
    }
}