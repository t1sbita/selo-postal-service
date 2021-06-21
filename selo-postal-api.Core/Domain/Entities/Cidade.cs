using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selo_postal_api.Core.Domain.Entities
{
    [Table("cidade")]
    public class Cidade
    {
        [Key]
        
        [Column("id")]
        public int Id { get; set; }
        [Column("municipio")]
        public string Municipio { get; set; }
        [Column("estado")]
        public string Estado { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

        public Cidade()
        {

        }

        public Cidade(string municipio, string estado)
        {
            Municipio = municipio;
            Estado = estado;
        }
    }
}
