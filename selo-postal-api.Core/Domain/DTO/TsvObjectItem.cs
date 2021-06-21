namespace selo_postal_api.Core.Domain.DTO
{
    public class TsvObjectItem
    {
        public string Nome { get; set; }
        public string EnderecoCasa { get; set; }
        public string NumeroCasa { get; set; }
        public string CodigoPostal { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string QrCodeRef { get; set; }

        public TsvObjectItem()
        {

        }
        public TsvObjectItem(string nome, string enderecoCasa, string numeroCasa, string codigoPostal, string bairro, string cidade, string estado, string qrCodeRef)
        {
            this.Nome = nome;
            this.EnderecoCasa = enderecoCasa;
            this.NumeroCasa = numeroCasa;
            this.CodigoPostal = codigoPostal;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
            this.QrCodeRef = qrCodeRef;

        }

        public override string ToString()
        {
            return $"{Nome}\t{EnderecoCasa}\t{NumeroCasa}\t{CodigoPostal}\t{Bairro}\t{Cidade}\t{Estado}\t{QrCodeRef}";
        }
        public static TsvObjectItem Build()
        {
            return new TsvObjectItem();
        }
        public TsvObjectItem WithName(string name)
        {
            this.Nome = name;
            return this;
        }
        public TsvObjectItem WithEndereco(string endereco)
        {
            this.EnderecoCasa = endereco;
            return this;
        }
        public TsvObjectItem WithNumero(string numero)
        {
            this.NumeroCasa = numero;
            return this;
        }
    }
}