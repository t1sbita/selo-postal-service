using System;
using System.Collections.Generic;
using selo_postal_service.Core;

namespace selo_postal_service.Application
{
    class Program
    {   
        
        static void Main(string[] args)
        {
            
          EnderecoRepository er = new EnderecoRepository();


            PageRequest pr = PageRequest.Of(2, 20);

            Dados.DTO.SearchEnderecoQueryItem pa = new Dados.DTO.SearchEnderecoQueryItem {
                Cidade = "Salvador",
                CodigoPostal = "CD548J2547"
            };

            var l =  er.GetByParamets(pa, pr);

            l.ForEach(e => Console.WriteLine(e.Nome));

        }
    }
}
