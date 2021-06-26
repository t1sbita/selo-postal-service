using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services.Interfaces;

namespace selo_postal_api.Core.Services
{
    public class QrCodeService : IQrCodeService
    {
        private readonly IQrCodeRepository _qrCodeRepository;

        public QrCodeService(IQrCodeRepository qrCodeRepository)
        {
            _qrCodeRepository = qrCodeRepository;
        }

        public byte[] GetQrCode(int id)
        {
            return _qrCodeRepository.GetQrCode(id);
        }
    }
}