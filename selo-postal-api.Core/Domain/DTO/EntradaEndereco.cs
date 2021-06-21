using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selo_postal_api.Core.Domain.DTO
{
    [Table("endereco")]
    public class EntradaEndereco
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string EnderecoCasa { get; set; }
        public string NumeroCasa { get; set; }
        public string CodigoPostal { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        

        public EntradaEndereco(string nome, string enderecoCasa, string numeroCasa, string codigoPostal, string bairro, string cidade)
        {
            this.Nome = nome;
            this.EnderecoCasa = enderecoCasa;
            this.NumeroCasa = numeroCasa;
            this.CodigoPostal = codigoPostal;
            this.Bairro = bairro;
            this.Cidade = cidade;
            

        }

        public EntradaEndereco()
        {

        }

        public override string ToString()
        {
            return $"{Nome}\t{EnderecoCasa}\t{NumeroCasa}\t{CodigoPostal}\t{Bairro}\t{Cidade}";
        }

    }
}
