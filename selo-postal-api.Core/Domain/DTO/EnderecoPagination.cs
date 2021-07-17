using System.Collections.Generic;

namespace selo_postal_api.Core.Domain.DTO
{
    public class EnderecoPagination
    {
        public int Total { get; set; }
        public int TotalPaginas { get; set; }
        public int QtdPorPagina { get; set; }
        public int NumeroPagina { get; set; }
        public IList<EnderecoModelResponse> Resultado { get; set; }
        public string Anterior { get; set; }
        public string Proximo { get; set; }
    }
}