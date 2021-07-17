using System;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Utils;

namespace selo_postal_api.Core.Domain.DTO
{
    public class EnderecoModelResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string EnderecoCasa { get; set; }
        public string NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public string CodigoPostal { get; set; }
        public int Cidade { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime ModificadoEm { get; set; }
        public string QrCode { get; set; }

        public EnderecoModelResponse()
        {

        }

        public static explicit operator EnderecoModelResponse(Endereco endereco)
        {
            return new EnderecoModelResponse()
            {
                Id = endereco.Id,
                Nome = endereco.Nome,
                EnderecoCasa = endereco.EnderecoCasa,
                NumeroCasa = endereco.NumeroCasa,
                Bairro = endereco.Bairro,
                CodigoPostal = endereco.CodigoPostal,
                Cidade = endereco.CidadeId,
                CriadoEm = endereco.CriadoEm,
                ModificadoEm = endereco.ModificadoEm,
                QrCode = string.Format(Constants.UrlQrCodePattern, endereco.Id)

            };
        }

    }


}

