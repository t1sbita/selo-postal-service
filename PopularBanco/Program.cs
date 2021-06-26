using Microsoft.EntityFrameworkCore;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Data.Context;
using System;
using System.Linq;

namespace PopularBanco
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Carregando informações no Banco:");

            var optionsBuilder = new DbContextOptionsBuilder<PostgresContext>();
            optionsBuilder
                .UseNpgsql("Server=localhost;Port=5432;Database=Particular;User Id=postgres;Password=elias1993;");

            using (PostgresContext ctx = new PostgresContext(optionsBuilder.Options))
            {
                if (!ctx.Cidade.Any())
                {
                    ctx.Cidade.AddRange(PopularBanco.PopularCidade());
                    ctx.SaveChanges();
                }
                
                if (!ctx.Endereco.Any())
                {
                    foreach (var item in PopularBanco.PopularEndereco())
                    {
                        Endereco endereco = new Endereco(
                            nome: item.Nome,
                            enderecoCasa: item.EnderecoCasa,
                            numeroCasa: item.NumeroCasa,
                            codigoPostal: item.CodigoPostal,
                            bairro: item.Bairro,
                            cidade: ctx.Cidade.Where(i => i.Id == item.Cidade).FirstOrDefault()
                            );

                        ctx.Endereco.Add(endereco);
                    }
                    ctx.SaveChanges();
                }

            }



        }
    }
}
