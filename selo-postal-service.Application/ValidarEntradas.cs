using System;
using System.Linq;

using selo_postal_service.Core;

namespace selo_postal_service.Application
{
    public class ValidarEntradas
    {
        internal static void Validar(string cidade, string estado, string codigoPostal, int paginaDesejada, int qtdPorPagina)
        {
            if(paginaDesejada == 0)
            {
                paginaDesejada = 1;
            }
            if(qtdPorPagina == 0)
            {
                qtdPorPagina = 10;
            }
            
            System.Console.WriteLine($"\nIremos retornar a página: {paginaDesejada}, com {qtdPorPagina} itens por página \n");
            System.Console.WriteLine("\nAguarde, já iremos retornar sua solicitação...\n");
            //chamaMetodoPesquisa(cidade, estado, codigoPostal, paginaDesejada, qtdPorPagina);
        }
    }
}