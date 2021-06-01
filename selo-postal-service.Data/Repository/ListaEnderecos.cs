using System.Collections.Generic;
using selo_postal_service.Core.Domain.Entities;


namespace selo_postal_service.Data.Repository
{
    public class ListaEnderecos
    {
        private static List<Endereco> Enderecos = null;

        private static void PopularLista()
        {

            List<Endereco> InternalEnderecosList = new List<Endereco>() {
                new Endereco("Alex Gamas", "Rua Alceu Amoroso Lima", "120", "XC990N01233", "Caminho das Arvores", "Salvador", "Bahia"),
                new Endereco("Elias Garcia", "Setor B - Caminho 10", "8", "CD548J2547", "Cajazeiras", "Salvador", "Bahia"),
                new Endereco("Fulano de Tal", "Rua dos Bobos", "0", "RB125Z4785", "Utopia", "Aleatoricity", "Aleatorio"),
                new Endereco("Oswald de Andrade", "Largo São Francisco", "19", "MA5VSPNO6M", "Brás", "São Paulo", "São Paulo"),
                new Endereco("Tarsila do Amaral", "Rua do Museu", "15", "4URK44MZUO", "Abaporu", "Capivari", "São Paulo"),
                new Endereco("Maju", "Rua Miados Noturnos", "4", "CD548J2547", "Cajazeiras", "Salvador", "Bahia"),
                new Endereco("Alex Son", "Rua Alceu Amoroso Lima", "120", "XC990N01233", "Caminho das Arvores", "Salvador", "Bahia"),
                new Endereco("Beltrano Entrando", "Beco sem Saída", "123", "RB125Z4785", "Utopia", "Aleatoricity", "Aleatorio"),
                new Endereco("Molinesia Lira", "Rua Aquario Plantado", "72", "CD548J2547", "Cajazeiras", "Salvador", "Bahia"),
                new Endereco("MC Funkeiro", "Rua Subida do Morro", "47", "P3JGRA5OAG", "Rocinha", "Rio de Janeiro", "Rio de Janeiro"),
                new Endereco("Apolo Apolar", "Rua Caninos", "4", "XC990N01233", "Monster Bull", "Feira de Santana", "Bahia"),
                new Endereco("Dalva Souza", "Rua Colorida", "475", "8EB4L1EUJE", "Bairro da Justiça", "Campinas", "São Paulo"),
                new Endereco("Luiz Lula", "Rua do Tribunal", "13", "VSPZCP0STX", "Bairro da Cana", "Cinquanta e Um", "São Paulo"),
                new Endereco("Gon Freecss", "Rua Sem Fim", "10", "M8LCMIHNIX", "Ilha da Baleia", "Hunter", "Hunter"),
                new Endereco("Leonora", "Rua dos Corvos", "17", "O726G17J7O", "Bairro do Poente", "Londres", "Estado Real"),
                new Endereco("Josilene Passos", "Rua Eliseu", "6", "X8LV4VTVUN", "Canela", "Feira de Santana", "Bahia"),
                new Endereco("Bolsonaro", "Rua Da Cloroquina", "17", "M3ZF9LC4CE", "Palácio do Planalto", "Brasilia", "Distrito Federal"),
                new Endereco("Bill Gates", "Rua Dono da Microsoft", "98", "XP95NT7810", "Microsoft", "Vale do Silício", "Outro Lugar"),
                new Endereco("Daniel Nogueira", "Rua do Campo", "91", "XVWTN3NH9R", "Bairro do Casevinte", "Salvador", "Bahia"),
                new Endereco("Olivia Ferreira", "Rua das Abaelhas", "54", "C8IWLON252", "Bairro do Mel", "Rio Doce", "Rio de Janeiro"),
                new Endereco("Nome Qualquer", "Rua Embratel", "21", "RB125Z4785", "Setor das Antenas", "Aleatoricity", "Aleatorio"),
            };
            //Duplica os itens da lista
            Enderecos.AddRange(InternalEnderecosList);
            Enderecos.AddRange(InternalEnderecosList);
            Enderecos.AddRange(InternalEnderecosList);
            Enderecos.AddRange(InternalEnderecosList);

        }

        public static List<Endereco> RetornaLista()
        {
            if (Enderecos == null) 
            {
                Enderecos = new List<Endereco>();
            }

            if(Enderecos.Count == 0)
            {
                PopularLista();
            }

            return Enderecos;
        }

    }
}
