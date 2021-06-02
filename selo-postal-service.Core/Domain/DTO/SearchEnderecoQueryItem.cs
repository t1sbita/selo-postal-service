namespace selo_postal_service.Core.Domain.DTO
{
    public class SearchEnderecoQueryItem
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }

        public SearchEnderecoQueryItem()
        {
            
        }
        public SearchEnderecoQueryItem(string cidade, string estado, string codigoPostal)
        {
            Cidade = cidade;
            Estado = estado;
            CodigoPostal = codigoPostal;
        }
    }
}