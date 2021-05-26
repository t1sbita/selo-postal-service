using System;

namespace selo_postal_service.Application
{
    public class ImprimeNaTela
    {
        public static void ImprimirTela()
        {
            string cidade, estado, codigoPostal, paginaDesejada, qtdPorPagina;
            Console.Write("Escreva a cidade que você deseja pesquisar: ");
            cidade = Console.ReadLine();
            Console.Write("Escreva o estado que você deseja pesquisar: ");
            estado = Console.ReadLine();
            Console.Write("Escreva o código postal que você deseja pesquisar: ");
            codigoPostal = Console.ReadLine();

            System.Console.WriteLine($"\nIremos pesquisar usando os seguintes filtros:");
            System.Console.WriteLine($"Cidade: {cidade}");
            System.Console.WriteLine($"Estado: {estado}");
            System.Console.WriteLine($"Código Postal: {codigoPostal} \n ");

            Console.WriteLine("\n Agora, escolha a Paginação desejada\n");
            Console.WriteLine("Obs.: digitar valores inválidos ou deixar em branco irá setar os valores no padrão");
            Console.WriteLine("Padrão: Página 1 e 10 itens por página! \n");
            Console.Write("Qual a página desejada: ");
            paginaDesejada = Console.ReadLine();
            Console.Write("Quantos itens por página: ");
            qtdPorPagina = Console.ReadLine();

            ValidarEntradas.Validar(cidade, estado, codigoPostal, paginaDesejada, qtdPorPagina);
        }
    }
}