using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

using selo_postal_api.Core.Domain.Models;
using System;

namespace selo_postal_api.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/enderecos")]
    public class EnderecosController : ControllerBase
    {

        private readonly IEnderecoService _enderecoService;
        private readonly IQrCodeService _qrCoderService;

        public EnderecosController(IEnderecoService enderecoService, IQrCodeService qrCoderService)
        {
            _enderecoService = enderecoService;
            _qrCoderService = qrCoderService;
        }

        /// <summary>
        /// Pesquisa paginada baseada em filtros
        /// </summary>
        /// <param name="filtro">Define o filtro de pesquisa</param>
        /// <param name="number">numero da página</param>
        /// <param name="limit">Itens por página</param>
        /// <returns>Retorna uma lista paginada com os resultados</returns>
        /// <response code="200">Lista retornada com sucesso</response>
        /// <response code="400">Filtro Invalido</response>
        /// <response code="401">"Token Invalido ou expirado!"</response>
        /// <response code="204">"Nao existem enderecos registrados para esta pesquisa"</response>
        [HttpGet]
        public IActionResult GetByParameters(
            [FromQuery] SearchEnderecoQueryItem filtro,
            [FromQuery] int number,
            [FromQuery] int limit)
        {
            PageRequest pr = PageRequest.Of(number, limit);
            List<EnderecoModel> listResult = _enderecoService.GetByParameters(filtro, pr);

            if (listResult == null || listResult.Count == 0 )
            {
                return NoContent();
            }

            return Ok(listResult);
        }
        /// <summary>
        /// Pesquisa paginada baseada em ID
        /// </summary>
        /// <param name="id">Define o id para pesquisa</param>
        /// <returns>Retorna um endereco</returns>
        /// <response code="200">Endereco retornado com sucesso</response>
        /// <response code="401">"Token Invalido ou expirado!"</response>
        /// <response code="404">"Nao existem enderecos registrados para este id"</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_enderecoService.GetById(id));
        }


        /// <summary>
        /// Retorna o QrCode para um determinado endereco
        /// </summary>
        /// <param name="id">Id do endereco</param>
        /// <returns>QrCode gerado</returns>
        /// <response code="200">QrCode gerado com sucesso</response>
        /// <response code="401">"Token Invalido ou expirado!"</response>
        /// <response code="404">"Id do Endereco Incorreto ou inexistente"</response>
        [HttpGet("{id}/qrcode")]
        public IActionResult GetQrCodes(int id)
        {
            byte[] img = _qrCoderService.GetQrCode(id);

            if (img.Length != 0)
            {
                return File(img, "image/png");
            }
            return NotFound();

        }

        /// <summary>
        /// Adiciona um novo endereco
        /// </summary>
        /// <param name="endereco">Endereco para ser cadastrado</param>
        /// <returns>Endereco cadastrado</returns>
        /// <response code="200">Endereco criado com sucesso</response>
        /// <response code="400">Endereco nao esta no padrao</response>
        /// <response code="401">"Token Invalido ou expirado!"</response>
        [HttpPost]
        public IActionResult Add(EnderecoModel endereco)
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

        /// <summary>
        /// Altera o endereço solicitado
        /// </summary>
        /// <param name="id">Id do endereco</param>
        /// <param name="endereco">Informações a serem alteradas</param>
        /// <returns>Endereço modificado</returns>
        /// <response code="200">Endereco alterado com sucesso</response>
        /// <response code="400">Erro na validacao das informacoes</response>
        /// <response code="401">Token inválido ou expirado</response>
        /// <response code="404">Endereco nao encontrado</response>
        [HttpPut("{id}")]
        public IActionResult Update(int id, EnderecoModel endereco)
        {
            if (ModelState.IsValid)
            {
                var enderecoModificado = _enderecoService.Update(id, endereco);
                return Ok(enderecoModificado);

            }
            else
            {
                return BadRequest();
            }
            
        }

        /// <summary>
        /// Remove um endereço
        /// </summary>
        /// <param name="id">Id do endereco a ser removido</param>
        /// <returns></returns>
        /// <response code="204">Endereco foi removido e nao se encontra na base de dados</response>
        /// <response code="401">"Token Invalido ou expirado!"</response>]
        /// <response code="404">Endereco nao encontrado</response>
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _enderecoService.Remove(id);

            return NoContent();
        }
    }
}