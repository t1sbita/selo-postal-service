using System;
using System.Linq;

using selo_postal_service.Core;

namespace selo_postal_service.Application
{
    public class ValidarEntradas
    {
        internal static void Validar(string cidade, string estado, string codigoPostal, string paginaDesejada, string qtdPorPagina)
        {
            if (paginaDesejada.Equals("") || !paginaDesejada.All(char.IsDigit))
            {
                paginaDesejada = "1";
            }
            if (qtdPorPagina.Equals("") || !qtdPorPagina.All(char.IsDigit))
            {
                qtdPorPagina = "10";
            }
            
            System.Console.WriteLine($"\nIremos retornar a página: {paginaDesejada}, com {qtdPorPagina} itens por página \n");
            System.Console.WriteLine("\nAguarde, já iremos retornar sua solicitação...\n");
            //chamaMetodoPesquisa(cidade, estado, codigoPostal, paginaDesejada, qtdPorPagina);
        }
    }
}