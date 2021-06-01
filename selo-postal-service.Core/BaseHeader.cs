using System;
using System.Collections.Generic;
using selo_postal_service.Dados;
using selo_postal_service.Data.Domain.DTO;

namespace selo_postal_service.Core
{
    public class BaseHeader<TEntity> where TEntity : class
    {
        public List<HeaderItem> Items = new List<HeaderItem>();

        public BaseHeader()
        {
            
        }

        public override string ToString()
        {
            string stringSaida = String.Empty;

            foreach (var item in Items)
            {
                stringSaida = $"{stringSaida}{item.ItemName}\t";
            }
            return stringSaida;
        }

    }
}