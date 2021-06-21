using System;
using System.Collections.Generic;

using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Services.Interfaces;
using selo_postal_service.Application.Controller.Interface;

namespace selo_postal_service.Application.Controller
{
    public class EnderecoController : IEnderecoController
    {
        
        private readonly IEnderecoService _enderecoService;
        private readonly IArquivoService _arquivoService;
        private readonly IQrCodeService _qrCoderService;

        public EnderecoController(IEnderecoService enderecoService, IArquivoService arquivoService, IQrCodeService qrCoderService)
        {
            _enderecoService = enderecoService;
            _arquivoService = arquivoService;
            _qrCoderService = qrCoderService;
        }

        public string Search(string cidade, string estado, string codigoPostal, Nullable<int> number, Nullable<int> limit)
        {
            SearchEnderecoQueryItem searchEnderecoQueryItem = new SearchEnderecoQueryItem(cidade, estado, codigoPostal);
            PageRequest pageRequest = PageRequest.Of(number, limit);

            List<Endereco> listResult = _enderecoService.GetByParameters(searchEnderecoQueryItem, pageRequest);
            return _arquivoService.CreateArchive(_qrCoderService.GetQrCode(listResult));
        }
    }
}