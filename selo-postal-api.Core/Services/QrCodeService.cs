using System.Collections.Generic;

using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services.Interfaces;

namespace selo_postal_api.Core.Services
{
    public class QrCodeService : IQrCodeService
    {
        private readonly IQrCodeRepository _qrCodeRepository;

        public QrCodeService(IQrCodeRepository enderecoRepository)
        {
            _qrCodeRepository = enderecoRepository;
        }

        public List<TsvObjectItem> GetQrCode(List<Endereco> list)
        {
            return _qrCodeRepository.GetQrCode(list);
        }

        public byte[] RecuperaQrCode(int id)
        {
            return _qrCodeRepository.RecuperaQrCode(id);
        }
    }
}