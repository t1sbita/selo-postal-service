using System;
using System.Collections.Generic;
using selo_postal_service.Application.Controller;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Services;
using selo_postal_service.Core.Services.Interfaces;
using selo_postal_service.Data.Repository;

namespace selo_postal_service.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            EnderecoController enderecoController = new EnderecoController(new EnderecoService(new EnderecoRepository()), new ArquivoService(new ArquivoRepository()), new QrCodeService(new QrCodeRepository()));

            enderecoController.Search("Salvador", "Bahia", null, 1, null);
        }
    }
}
