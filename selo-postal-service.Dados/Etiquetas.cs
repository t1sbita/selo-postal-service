using System;

namespace selo_postal_service.Dados
{
    public class Etiquetas
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CodigoPostal { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Etiquetas()
        {

        }
        public Etiquetas(string nome, string endereco, string codigoPostal, string bairro, string cidade, string estado)
        {
            this.Nome = nome;
            this.Endereco = endereco;
            this.CodigoPostal = codigoPostal;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;

            
        }

    }
}
