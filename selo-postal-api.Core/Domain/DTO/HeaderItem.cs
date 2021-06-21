using System;

namespace selo_postal_api.Core.Domain.DTO
{
    public class HeaderItem
    {
        public int Order { get; set; }
        public string ItemName { get; set; }

        public HeaderItem(int order, string itemName)
        {
            this.Order = order;
            this.ItemName = itemName;

        }
    }
}