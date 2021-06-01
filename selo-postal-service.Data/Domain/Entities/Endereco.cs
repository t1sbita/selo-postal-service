using System;

namespace selo_postal_service.Dados
{
    public class Endereco
    {
        public string Name { get; }
        public string Address { get; }
        public string NumberHouse { get;  }
        public string ZipCode { get; }
        public string District { get; }
        public string City { get; }
        public string State { get; }

        public Endereco()
        {

        }
        public Endereco(string name, string address, string numberHouse, string ZipCode, string district, string city, string state)
        {
            this.Name = name;
            this.Address = address;
            this.NumberHouse = numberHouse;
            this.ZipCode = ZipCode ;
            this.District = district;
            this.City = city;
            this.State = state;

            
        }

    }
}
