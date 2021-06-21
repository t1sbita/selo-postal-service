using System;
using System.Collections.Generic;

using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using selo_postal_api.Data.Repository;

namespace selo_postal_api.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecosController : ControllerBase
    {

        private readonly IEnderecoService _enderecoService;
        private readonly IArquivoService _arquivoService;
        private readonly IQrCodeService _qrCoderService;

        public EnderecosController(IEnderecoService enderecoService, IArquivoService arquivoService, IQrCodeService qrCoderService)
        {
            _enderecoService = enderecoService;
            _arquivoService = arquivoService;
            _qrCoderService = qrCoderService;
        }

        [HttpGet]
        public IActionResult Search(
            [FromQuery] SearchEnderecoQueryItem filtro,
            [FromQuery] PageRequest pageRequest)
        {
            PageRequest pr = PageRequest.Of(pageRequest.Number, pageRequest.Limit);
            List<Endereco> listResult = _enderecoService.GetByParameters(filtro, pr);
            var arquivo = _arquivoService.CreateArchive(_qrCoderService.GetQrCode(listResult));

            string gerarNomeArquivo = DateTime.Now.ToString("u").Replace(":", "");

            return File(arquivo, "text/tsv", $"{gerarNomeArquivo}.tsv");

        }
        [HttpGet("{id}/qrcode")]
        public IActionResult QrCodes(int id)
        {
            byte[] img = _qrCoderService.RecuperaQrCode(id);
            return File(img, "image/png");
        }

        [HttpPost]
        public IActionResult Add(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                return Ok(_enderecoService.Add(endereco));

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}/cidade")]
        public IActionResult AlterarCidade(int id, Cidade cidade)
        {
            var enderecoModificado =_enderecoService.AlterarCidade(id, cidade);
            return Ok(enderecoModificado);
        }
    }
}