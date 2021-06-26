
namespace selo_postal_api.Core.Services.Interfaces
{
    public interface IQrCodeService
    {
        byte[] GetQrCode(int id);
    }
}