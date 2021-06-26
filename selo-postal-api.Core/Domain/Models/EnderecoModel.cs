
using System;

namespace selo_postal_api.Core.Domain.Models
{
    public class EnderecoModel
    {
        public string Nome { get; set; }
        public string EnderecoCasa { get; set; }
        public string NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public string CodigoPostal { get; set; }
        public int Cidade { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime ModificadoEm { get; set; }

        public EnderecoModel()
        {
          
        }

    }


}
