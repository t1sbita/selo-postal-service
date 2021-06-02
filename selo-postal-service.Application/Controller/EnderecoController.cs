using System.Collections.Generic;

using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Services.Interfaces;
using selo_postal_service.Application.Controller.Interfaces;

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

        public void Search(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest)
        {
            List<Endereco> listResult = _enderecoService.GetByParameters(searchEnderecoQueryItem, pageRequest);
            _arquivoService.CreateArchive(_qrCoderService.GetQrCode(listResult));
        }
    }
}