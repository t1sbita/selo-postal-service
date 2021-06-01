using selo_postal_service.Core.Domain.DTO;


namespace selo_postal_service.Core.Domain.Entities
{
    public class HeaderEndereco: BaseHeader<Endereco>
    {
        public HeaderEndereco()
        {
            Items.Add(new HeaderItem(0, "Nome"));
            Items.Add(new HeaderItem(1, "Endereço"));
            Items.Add(new HeaderItem(2, "Numero"));
            Items.Add(new HeaderItem(3, "Código Postal"));
            Items.Add(new HeaderItem(4, "Bairro"));
            Items.Add(new HeaderItem(5, "Cidade"));
            Items.Add(new HeaderItem(6, "Estado"));
            Items.Add(new HeaderItem(7, "QRCodeRef"));
        }

        

    }
}