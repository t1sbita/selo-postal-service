using System;

namespace selo_postal_service.Core.Domain.Entities
{
    public class Endereco
    {
        public string Nome { get; }
        public string EnderecoCasa { get; }
        public string NumeroCasa { get; }
        public string CodigoPostal { get; }
        public string Bairro { get; }
        public string Cidade { get; }
        public string Estado { get; }

        public Endereco()
        {

        }
        public Endereco(string nome, string enderecoCasa, string numeroCasa, string codigoPostal, string bairro, string cidade, string estado)
        {
            this.Nome = nome;
            this.EnderecoCasa = enderecoCasa;
            this.NumeroCasa = numeroCasa;
            this.CodigoPostal = codigoPostal;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;

        }


    }
}
