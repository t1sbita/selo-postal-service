using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selo_postal_api.Core.Domain.Entities
{
    public class Etiqueta
    {
        public int Id { get; set; }
        public byte[] CodigoQr { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        
        public Etiqueta()
        {

        }

        public Etiqueta(byte[] codigoQr, Endereco endereco)
        {
            CodigoQr = codigoQr;
            Endereco = endereco;
        }
    }

}
