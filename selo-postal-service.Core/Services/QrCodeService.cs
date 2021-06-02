using System.Collections.Generic;

using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Interfaces;

namespace selo_postal_service.Core.Services
{
    public class QrCodeService
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
    }
}