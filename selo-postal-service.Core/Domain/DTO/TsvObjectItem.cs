namespace selo_postal_service.Core.Domain.DTO
{
    public class TsvObjectItem
    {
        public string Nome { get; }
        public string EnderecoCasa { get; }
        public string NumeroCasa { get; }
        public string CodigoPostal { get; }
        public string Bairro { get; }
        public string Cidade { get; }
        public string Estado { get; }
        public string QrCodeRef { get; set; }

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
    }
}