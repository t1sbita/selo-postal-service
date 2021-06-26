using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PopularBanco.FileProssessing;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
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

                    Cidade cidade = new Cidade(municipio: lr.Municipio, estado: lr.UF);

                    lista.Add(cidade);
                }

                return lista;
            }
        }

        public static List<EntradaEndereco> PopularEntradaEndereco()
        {
            List<EntradaEndereco> lista = new List<EntradaEndereco>() {
                new EntradaEndereco("Alex Gamas", "Rua Alceu Amoroso Lima", "120", "XC990N01233", "Caminho das Arvores", "Salvador"),
                new EntradaEndereco("Elias Garcia", "Setor B - Caminho 10", "8", "CD548J2547", "Cajazeiras", "Salvador"),
                new EntradaEndereco("Fulano de Tal", "Rua dos Bobos", "0", "RB125Z4785", "Utopia", "Porto Alegre"),
                new EntradaEndereco("Oswald de Andrade", "Largo São Francisco", "19", "MA5VSPNO6M", "Brás", "São Paulo" ),
                new EntradaEndereco("Tarsila do Amaral", "Rua do Museu", "15", "4URK44MZUO", "Abaporu", "Capivari" ),
                new EntradaEndereco("Maju", "Rua Miados Noturnos", "4", "CD548J2547", "Cajazeiras", "Salvador"),
                new EntradaEndereco("Alex Son", "Rua Alceu Amoroso Lima", "120", "XC990N01233", "Caminho das Arvores", "Salvador"),
                new EntradaEndereco("Beltrano Entrando", "Beco sem Saída", "123", "RB125Z4785", "Utopia", "Porto Alegre"),
                new EntradaEndereco("Molinesia Lira", "Rua Aquario Plantado", "72", "CD548J2547", "Cajazeiras", "Salvador"),
                new EntradaEndereco("MC Funkeiro", "Rua Subida do Morro", "47", "P3JGRA5OAG", "Rocinha", "Rio de Janeiro"),
                new EntradaEndereco("Apolo Apolar", "Rua Caninos", "4", "XC990N01233", "Monster Bull", "Feira de Santana"),
                new EntradaEndereco("Dalva Souza", "Rua Colorida", "475", "8EB4L1EUJE", "Bairro da Justiça", "Campinas"),
                new EntradaEndereco("Luiz Lula", "Rua do Tribunal", "13", "VSPZCP0STX", "Bairro da Cana", "Macapá"),
                new EntradaEndereco("Gon Freecss", "Rua Sem Fim", "10", "M8LCMIHNIX", "Ilha da Baleia", "Belo Horizonte"),
                new EntradaEndereco("Leonora", "Rua dos Corvos", "17", "O726G17J7O", "Bairro do Poente", "Londrina"),
                new EntradaEndereco("Josilene Passos", "Rua Eliseu", "6", "X8LV4VTVUN", "Canela", "Feira de Santana"),
                new EntradaEndereco("Bolsonaro", "Rua Da Cloroquina", "17", "M3ZF9LC4CE", "Palácio do Planalto", "Brasília"),
                new EntradaEndereco("Bill Gates", "Rua Dono da Microsoft", "98", "XP95NT7810", "Microsoft", "Vitória da COnquista"),
                new EntradaEndereco("Daniel Nogueira", "Rua do Campo", "91", "XVWTN3NH9R", "Bairro do Casevinte", "Salvador"),
                new EntradaEndereco("Olivia Ferreira", "Rua das Abaelhas", "54", "C8IWLON252", "Bairro do Mel", "Rio Doce"),
                new EntradaEndereco("Nome Qualquer", "Rua Embratel", "21", "RB125Z4785", "Setor das Antenas", "Campo Grande"),
            };

            return lista;
        }

    }
}
