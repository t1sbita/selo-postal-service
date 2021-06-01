using System;
using System.Collections.Generic;
using selo_postal_service.Dados;
using selo_postal_service.Data.Domain.DTO;

namespace selo_postal_service.Core
{
    public class HeaderEndereco: BaseHeader<Etiquetas>
    {
        //public List<HeaderItem> Items = new List<HeaderItem>();

        public HeaderEndereco()
        {
            Items.Add(new HeaderItem(0, "Nome"));
            Items.Add(new HeaderItem(0, "Endereço"));
            Items.Add(new HeaderItem(0, "Numero"));
            Items.Add(new HeaderItem(0, "Código Postal"));
            Items.Add(new HeaderItem(0, "Bairro"));
            Items.Add(new HeaderItem(0, "Cidade"));
            Items.Add(new HeaderItem(0, "Estado"));
            Items.Add(new HeaderItem(0, "QRCodeRef"));
        }

        

    }
}