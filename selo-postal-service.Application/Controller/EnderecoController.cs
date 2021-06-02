
using selo_postal_service.Core.Services;
using selo_postal_service.Core.Domain.Entities;

namespace selo_postal_service.Application.Controller
{
    public class EnderecoController
    {
        
        private readonly EnderecoService _enderecoService;
        private readonly ArquivoService _arquivoService;
        private readonly QrCoderService _qrCoderService;

        public EnderecoController(EnderecoService enderecoService, ArquivoService arquivoService, QrCoderService qrCoderService)
        {
            _enderecoService = enderecoService;
            _arquivoService = arquivoService;
            _qrCoderService = qrCoderService;
        }

        public static void  Search(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest)
        {
            List<Endereco> listResult = _enderecoService.GetByParameters(searchEnderecoQueryItem, pageRequest);
            _arquivoService.CriarArquivo(_qrCoderService.GetQrCode());
        }
    }
}