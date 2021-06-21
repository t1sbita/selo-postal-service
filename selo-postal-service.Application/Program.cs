using System;

using Microsoft.Extensions.DependencyInjection;
using selo_postal_service.Application.Controller.Interface;
using selo_postal_service.Application.Controller;
using selo_postal_service.Core.Services.Interfaces;
using selo_postal_service.Core.Services;
using selo_postal_service.Core.Interfaces;
using selo_postal_service.Data.Repository;

namespace selo_postal_service.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IEnderecoController, EnderecoController>()
            .AddSingleton<IEnderecoService, EnderecoService>()
            .AddSingleton<IEnderecoRepository, EnderecoRepository>()
            .AddSingleton<IQrCodeService, QrCodeService>()
            .AddSingleton<IQrCodeRepository, QrCodeRepository>()
            .AddSingleton<IArquivoService, ArquivoService>()
            .AddSingleton<IArquivoRepository, ArquivoRepository>()
            .BuildServiceProvider();


            var search = serviceProvider.GetService<IEnderecoController>();

            string cidade = String.Empty;
            string estado = String.Empty;
            string codigoPostal = String.Empty;

            int? number = null;
            int? limit = null;


            search.Search(cidade, estado, codigoPostal, number, limit);
        }
    }
}
