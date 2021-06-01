﻿using System;

using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Data.Repository;

namespace selo_postal_service.Application
{
    class Program
    {   
        
        static void Main(string[] args)
        {
            
          EnderecoRepository er = new EnderecoRepository();


            PageRequest pr = PageRequest.Of(2, 20);

            SearchEnderecoQueryItem pa = new SearchEnderecoQueryItem {
                Cidade = "Salvador",
                CodigoPostal = "CD548J2547"
            };

            var l =  er.GetByParamets(pa, pr);

            l.ForEach(e => Console.WriteLine(e.Nome));

        }
    }
}
