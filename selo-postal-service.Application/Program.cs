using System;

using selo_postal_service.Core;

namespace selo_postal_service.Application
{
    class Program
    {   
        
        static void Main(string[] args)
        {
            
            char repetirPesquisa = 's';

            Console.WriteLine("*****************************************");
            Console.WriteLine("\t\tBEM VINDO!");
            Console.WriteLine("***************************************** \n");
            Console.WriteLine("\tSistema Gerador de Etiquetas \n");

            while (repetirPesquisa != 'n')
            {
                ImprimeNaTela.ImprimirTela();
                
                //retornaMetodoPesquisa();
                System.Console.WriteLine("\nSua Pesquisa retornou a página p de um total de x páginas, com y itens por página, totalizando z itens");

                Console.WriteLine("\n Deseja Fazer outra pesquisa? [S/N]");
                repetirPesquisa = char.Parse(Console.ReadLine().ToLowerInvariant());
            }

        }
    }
}
