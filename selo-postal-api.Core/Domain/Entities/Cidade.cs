using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selo_postal_api.Core.Domain.Entities
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Municipio { get; set; }
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
