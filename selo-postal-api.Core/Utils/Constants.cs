namespace selo_postal_api.Core.Utils
{
    public static class Constants
    {
        public const string UrlQrCodePattern = "https://localhost:5001/api/enderecos/{0}/qrcode";
        public const string UrlPaginationPattern = "https://localhost:5001/api/enderecos?Cidade={0}&Estado={1}&CodigoPostal={2}&number={3}&limit={4}";
    }
}