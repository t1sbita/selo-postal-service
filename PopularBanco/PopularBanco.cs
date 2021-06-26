using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PopularBanco.FileProssessing;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.Models;
using selo_postal_api.Data.Context;

namespace PopularBanco
{
    public class PopularBanco
    {
        public static List<Cidade> PopularCidade()
        {
           
            using (StreamReader sr = new StreamReader("Lista_Municípios_com_IBGE_Brasil_Versao_CSV.csv"))
            {
                string line;
                List<Cidade> lista = new List<Cidade>();

                while ((line = sr.ReadLine()) != null)
                {
                    LeitorArquivo lr = new LeitorArquivo(line);

                    Cidade cidade = new Cidade(){Municipio = lr.Municipio, Estado = lr.UF};
                    
                    lista.Add(cidade);
                }

                return lista;
            }
        }

        public static List<EnderecoModel> PopularEndereco()
        {
            List<EnderecoModel> lista = new List<EnderecoModel>() {
                new EnderecoModel(){Nome = "Alex Gamas", EnderecoCasa = "Rua Alceu Amoroso Lima", NumeroCasa = "120", CodigoPostal = "XC990N01233", Bairro = "Caminho das Arvores", Cidade = 4386},
                new EnderecoModel(){Nome = "Elias Garcia", EnderecoCasa = "Setor B - Caminho 10", NumeroCasa = "8", CodigoPostal = "CD548J2547", Bairro = "Cajazeiras", Cidade = 4386},
                new EnderecoModel(){Nome = "Fulano de Tal", EnderecoCasa = "Rua dos Bobos", NumeroCasa = "0", CodigoPostal = "RB125Z4785", Bairro = "Utopia", Cidade = 1576},
                new EnderecoModel(){Nome = "Oswald de Andrade", EnderecoCasa = "Largo São Francisco", NumeroCasa = "19", CodigoPostal = "MA5VSPNO6M", Bairro = "Brás", Cidade = 521},
                new EnderecoModel(){Nome = "Tarsila do Amaral", EnderecoCasa = "Rua do Museu", NumeroCasa = "15", CodigoPostal = "4URK44MZUO", Bairro = "Abaporu", Cidade = 1072 },
                new EnderecoModel(){Nome = "Maju", EnderecoCasa = "Rua Miados Noturnos", NumeroCasa = "4", CodigoPostal = "CD548J2547", Bairro = "Cajazeiras", Cidade = 4386},
                new EnderecoModel(){Nome = "Alex Son", EnderecoCasa = "Rua Alceu Amoroso Lima", NumeroCasa = "120", CodigoPostal = "XC990N01233", Bairro = "Caminho das Arvores", Cidade = 4386},
                new EnderecoModel(){Nome = "Beltrano Entrando", EnderecoCasa = "Beco sem Saída", NumeroCasa = "123", CodigoPostal = "RB125Z4785", Bairro = "Utopia", Cidade = 1576},
                new EnderecoModel(){Nome = "Molinesia Lira", EnderecoCasa = "Rua Aquario Plantado", NumeroCasa = "72", CodigoPostal = "CD548J2547", Bairro = "Cajazeiras", Cidade = 4386},
                new EnderecoModel(){Nome = "MC Funkeiro", EnderecoCasa = "Rua Subida do Morro", NumeroCasa = "47", CodigoPostal = "P3JGRA5OAG", Bairro = "Rocinha", Cidade = 1380},
                new EnderecoModel(){Nome = "Apolo Apolar", EnderecoCasa = "Rua Caninos", NumeroCasa = "4", CodigoPostal = "XC990N01233", Bairro = "Monster Bull", Cidade = 1587},
                new EnderecoModel(){Nome = "Dalva Souza", EnderecoCasa = "Rua Colorida", NumeroCasa = "475", CodigoPostal = "8EB4L1EUJE", Bairro = "Bairro da Justiça", Cidade = 521},
                new EnderecoModel(){Nome = "Luiz Lula", EnderecoCasa = "Rua do Tribunal", NumeroCasa = "13", CodigoPostal = "VSPZCP0STX", Bairro = "Bairro da Cana", Cidade = 2547},
                new EnderecoModel(){Nome = "Gon Freecss", EnderecoCasa = "Rua Sem Fim", NumeroCasa = "10", CodigoPostal = "M8LCMIHNIX", Bairro = "Ilha da Baleia", Cidade = 741},
                new EnderecoModel(){Nome = "Leonora", EnderecoCasa = "Rua dos Corvos", NumeroCasa = "17", CodigoPostal = "O726G17J7O", Bairro = "Bairro do Poente", Cidade = 1587},
                new EnderecoModel(){Nome = "Josilene Passos", EnderecoCasa = "Rua Eliseu", NumeroCasa = "6", CodigoPostal = "X8LV4VTVUN", Bairro = "Canela", Cidade = 4386},
                new EnderecoModel(){Nome = "Bolsonaro", EnderecoCasa = "Rua Da Cloroquina", NumeroCasa = "17", CodigoPostal = "M3ZF9LC4CE", Bairro = "Palácio do Planalto", Cidade = 5570},
                new EnderecoModel(){Nome = "Bill Gates", EnderecoCasa = "Rua Dono da Microsoft", NumeroCasa = "98", CodigoPostal = "XP95NT7810", Bairro = "Microsoft", Cidade = 4458},
                new EnderecoModel(){Nome = "Daniel Nogueira", EnderecoCasa = "Rua do Campo", NumeroCasa = "91", CodigoPostal = "XVWTN3NH9R", Bairro = "Bairro do Casevinte", Cidade = 4386},
                new EnderecoModel(){Nome = "Olivia Ferreira", EnderecoCasa = "Rua das Abaelhas", NumeroCasa = "54", CodigoPostal = "C8IWLON252", Bairro = "Bairro do Mel", Cidade = 1009},
                new EnderecoModel(){Nome = "Nome Qualquer", EnderecoCasa = "Rua Embratel", NumeroCasa = "21", CodigoPostal = "RB125Z4785", Bairro = "Setor das Antenas", Cidade = 745},
            };

            return lista;
        }

    }
}
