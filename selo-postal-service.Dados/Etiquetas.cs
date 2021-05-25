using System;

namespace selo_postal_service.Dados
{
    public class Etiquetas
    {
        public string Nome { get; }
        public string Endereco { get; }
        public string NumeroCasa { get;  }
        public string CodigoPostal { get; }
        public string Bairro { get; }
        public string Cidade { get; }
        public string Estado { get; }

        public Etiquetas()
        {

        }
        public Etiquetas(string nome, string endereco, string numeroCasa, string codigoPostal, string bairro, string cidade, string estado)
        {
            this.Nome = nome;
            this.Endereco = endereco;
            this.NumeroCasa = numeroCasa;
            this.CodigoPostal = codigoPostal;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;

            
        }

    }
}
