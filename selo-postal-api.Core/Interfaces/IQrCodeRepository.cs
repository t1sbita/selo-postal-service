using System.Collections.Generic;

using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;

namespace selo_postal_api.Core.Interfaces
{
    public interface IQrCodeRepository
    {
        List<TsvObjectItem> GetQrCode(List<Endereco> list);
        byte[] RecuperaQrCode(int id);
    }
}