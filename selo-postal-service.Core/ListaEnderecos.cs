using System;
using System.Collections.Generic;
using selo_postal_service.Dados;
using System.Linq;

namespace selo_postal_service.Core
{
    public class ListaEnderecos
    {
        List<Etiquetas> listaEnderecos = new List<Etiquetas>();

        public void PopularLista()
        {

            listaEnderecos.Add(new Etiquetas("Alex Gamas", "Rua Alceu Amoroso Lima", "120", "XC990N01233", "Caminho das Arvores", "Salvador", "Bahia"));
            listaEnderecos.Add(new Etiquetas("Elias Garcia", "Setor B - Caminho 10", "8", "CD548J2547", "Cajazeiras", "Salvador", "Bahia"));
            listaEnderecos.Add(new Etiquetas("Fulano de Tal", "Rua dos Bobos", "0", "RB125Z4785", "Utopia", "Aleatoricity", "Aleatorio"));
            listaEnderecos.Add(new Etiquetas("Oswald de Andrade", "Largo São Francisco", "19", "MA5VSPNO6M", "Brás", "São Paulo", "São Paulo"));
            listaEnderecos.Add(new Etiquetas("Tarsila do Amaral", "Rua do Museu", "15", "4URK44MZUO", "Abaporu", "Capivari", "São Paulo"));
            listaEnderecos.Add(new Etiquetas("Maju", "Rua Miados Noturnos", "4", "CD548J2547", "Cajazeiras", "Salvador", "Bahia"));
            listaEnderecos.Add(new Etiquetas("Alex Son", "Rua Alceu Amoroso Lima", "120", "XC990N01233", "Caminho das Arvores", "Salvador", "Bahia"));
            listaEnderecos.Add(new Etiquetas("Beltrano Entrando", "Beco sem Saída", "123", "RB125Z4785", "Utopia", "Aleatoricity", "Aleatorio"));
            listaEnderecos.Add(new Etiquetas("Molinesia Lira", "Rua Aquario Plantado", "72", "CD548J2547", "Cajazeiras", "Salvador", "Bahia"));
            listaEnderecos.Add(new Etiquetas("MC Funkeiro", "Rua Subida do Morro", "47", "P3JGRA5OAG", "Rocinha", "Rio de Janeiro", "Rio de Janeiro"));
            listaEnderecos.Add(new Etiquetas("Apolo Apolar", "Rua Caninos", "4", "XC990N01233", "Monster Bull", "Feira de Santana", "Bahia"));
            listaEnderecos.Add(new Etiquetas("Dalva Souza", "Rua Colorida", "475", "8EB4L1EUJE", "Bairro da Justiça", "Campinas", "São Paulo"));
            listaEnderecos.Add(new Etiquetas("Luiz Lula", "Rua do Tribunal", "13", "VSPZCP0STX", "Bairro da Cana", "Cinquanta e Um", "São Paulo"));
            listaEnderecos.Add(new Etiquetas("Gon Freecss", "Rua Sem Fim", "10", "M8LCMIHNIX", "Ilha da Baleia", "Hunter", "Hunter"));
            listaEnderecos.Add(new Etiquetas("Leonora", "Rua dos Corvos", "17", "O726G17J7O", "Bairro do Poente", "Londres", "Estado Real"));
            listaEnderecos.Add(new Etiquetas("Josilene Passos", "Rua Eliseu", "6", "X8LV4VTVUN", "Canela", "Feira de Santana", "Bahia"));
            listaEnderecos.Add(new Etiquetas("Bolsonaro", "Rua Da Cloroquina", "17", "M3ZF9LC4CE", "Palácio do Planalto", "Brasilia", "Distrito Federal"));
            listaEnderecos.Add(new Etiquetas("Bill Gates", "Rua Dono da Microsoft", "98", "XP95NT7810", "Microsoft", "Vale do Silício", "Outro Lugar"));
            listaEnderecos.Add(new Etiquetas("Daniel Nogueira", "Rua do Campo", "91", "XVWTN3NH9R", "Bairro do Casevinte", "Salvador", "Bahia"));
            listaEnderecos.Add(new Etiquetas("Olivia Ferreira", "Rua das Abaelhas", "54", "C8IWLON252", "Bairro do Mel", "Rio Doce", "Rio de Janeiro"));
            listaEnderecos.Add(new Etiquetas("Nome Qualquer", "Rua Embratel", "21", "RB125Z4785", "Setor das Antenas", "Aleatoricity", "Aleatorio"));

            //Duplica os itens da lista
            List<Etiquetas> listaRepetida = listaEnderecos;
            listaEnderecos.AddRange(listaRepetida.FindAll(x => x.Nome != null));

        }
        
        public List<Etiquetas> RetornaLista()
        {
            return listaEnderecos;

        }
    }
}
