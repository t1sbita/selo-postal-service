namespace selo_postal_service.Core.Domain.DTO
{
    public struct SearchEnderecoQueryItem
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }

        public SearchEnderecoQueryItem(string cidade, string estado, string codigoPostal)
        {
            Cidade = cidade;
            Estado = estado;
            CodigoPostal = codigoPostal;
        }
    }
}