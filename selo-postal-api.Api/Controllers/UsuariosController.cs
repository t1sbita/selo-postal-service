using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using selo_postal_api.Api.Authorization;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Services.Interfaces;

namespace selo_postal_api.Api.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Adiciona um novo usuário
        /// </summary>
        /// <param name="model">Informacoes do usuario para serem atualizadas</param>
        /// <returns>Novo usuario</returns>
        /// <response code="200">Usuario criado com sucesso</response>
        /// <response code="400">Informacoes do usuario nao esta no padrao</response>
        /// <response code="401">"Token Invalido ou expirado!"</response>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AdicionarUsuario([FromBody] Usuario model)
        {
            if (_usuarioService.VerificaExistente(model))
            {

                Usuario usuario = _usuarioService.AdicionarUsuario(model);
                if (usuario == null)
                {
                    return BadRequest("Dados incorretos, verifique");
                }

                return Ok(usuario);
            }
            return BadRequest("Usuario já existe");

        }

        /// <summary>
        /// Realiza o login
        /// </summary>
        /// <param name="model">Informações do usuario que deseja logar</param>
        /// <returns>Token para autenticacao</returns>
        /// <response code="200">Token retornado com sucesso</response>
        /// <response code="400">Erro na validacao das informacoes</response>
        /// <response code="404">"Usuario ou senha incorretos"</response>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody] Usuario model)
        {

            var usuario = _usuarioService.Autenticar(model);

            if (usuario == null)
            {
                return NotFound(new { message = "Usuario ou senha inválidos" });
            }

            var token = TokenService.GerarToken(usuario);
            usuario.Password = "";
            return new
            {
                user = usuario.Login,
                token = token
            };
        }

        /// <summary>
        /// Altera um usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <param name="model">Informacoes do usuario que deverao ser alteradas</param>
        /// <returns>Usuario criado</returns>
        /// <response code="200">Usuario alterado com sucesso</response>
        /// <response code="400">Erro na validacao das informacoes</response>
        /// <response code="401">Token inválido ou expirado</response>
        /// <response code="404">Usuario nao encontrado</response>
        [Authorize]
        [HttpPatch("{id}")]
        public IActionResult Atualizar([FromRoute] int id, [FromBody] Usuario model)
        {
            string loginUsuario = _usuarioService.RetornaLogin(id);

            if (User.Identity.Name != loginUsuario)
            {
                return BadRequest("Usuário incorreto / não existe");
            }
            var user = _usuarioService.AtualizaSenha(id, model);
            return Ok(user);

        }

        /// <summary>
        /// Remove um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Usuario foi removido e nao se encontra na base de dados</response>
        /// <response code="401">"Token Invalido ou expirado!"</response>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _usuarioService.Remove(id);
            return NoContent();
        }


    }
}