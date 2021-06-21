using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selo_postal_api.Core.Domain.Entities
{
    [Table("etiqueta")]
    public class Etiqueta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("codigoQr")]
        public byte[] CodigoQr { get; set; }

        [Column("endereco")]
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
