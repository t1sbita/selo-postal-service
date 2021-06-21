using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selo_postal_api.Core.Domain.Entities
{
    [Table("endereco")]
    public class Endereco
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("enderecoCasa")]
        public string EnderecoCasa { get; set; }

        [Column("numeroCasa")]
        public string NumeroCasa { get; set; }

        [Column("codigoPostal")]
        public string CodigoPostal { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }
        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }

        [Column("criadoEm")]
        public DateTime CriadoEm { get; set; }

        [Column("modificadoEm")]
        public DateTime ModificadoEm { get; set; }
        public virtual Etiqueta Etiqueta { get; set; }
        public int EnderecoId { get; set; }

        public Endereco(string nome, string enderecoCasa, string numeroCasa, string codigoPostal, string bairro, Cidade cidade)
        {
            this.Nome = nome;
            this.EnderecoCasa = enderecoCasa;
            this.NumeroCasa = numeroCasa;
            this.CodigoPostal = codigoPostal;
            this.Bairro = bairro;
            this.CriadoEm = DateTime.Now;

            if (cidade != null)
            {
                this.Cidade = cidade;
            }
            
            
        }

        public Endereco()
        {
            
        }

        public override string ToString()
        {
            if (Cidade == null)
            {
                return $"{Nome}\t{EnderecoCasa}\t{NumeroCasa}\t{CodigoPostal}\t{Bairro}\tInexistente\tInexistente";
            }
            return $"{Nome}\t{EnderecoCasa}\t{NumeroCasa}\t{CodigoPostal}\t{Bairro}\t{Cidade.Municipio}\t{Cidade.Estado}";
        }

    }
}
