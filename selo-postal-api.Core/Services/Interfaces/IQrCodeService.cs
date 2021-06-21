using System.Collections.Generic;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;

namespace selo_postal_api.Core.Services.Interfaces
{
    public interface IQrCodeService
    {
        List<TsvObjectItem> GetQrCode(List<Endereco> list);
        byte[] RecuperaQrCode(int id);
    }
}