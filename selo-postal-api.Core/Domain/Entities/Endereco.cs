using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selo_postal_api.Core.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string EnderecoCasa { get; set; }
        public string NumeroCasa { get; set; }
        public string CodigoPostal { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime ModificadoEm { get; set; }


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

    }
}
