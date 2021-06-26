namespace selo_postal_api.Core.Domain.DTO
{
    public class SearchEnderecoQueryItem
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }

        public SearchEnderecoQueryItem()
        {

        }
        
    }
}