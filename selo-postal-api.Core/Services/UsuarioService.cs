using selo_postal_api.Core.Authorization;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.Models;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services.Interfaces;

namespace selo_postal_api.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioToken Authenticate(UsuarioLogin loginModel)
        {
             var usuario = _usuarioRepository.Authenticate(loginModel.Login, loginModel.Password);

            if (usuario == null)
            {
                return null;
            }
            
            var token = TokenUtils.GerarToken(usuario);
            usuario.Password = "";
            return new UsuarioToken()
            {
                Login = usuario.Login,
                Token = token
            };

        }

        public string RetornaLogin(int id)
        {
            return _usuarioRepository.RetornaLogin(id);
        }

        public Usuario Update(int id, Usuario usuario)
        {
            return _usuarioRepository.Update(id, usuario);
        }

        public Usuario Add(Usuario usuario)
        {
            return _usuarioRepository.Add(usuario);
        }

        public bool VerificaExistente(Usuario model)
        {
            return _usuarioRepository.VerificaExistente(model);
        }

        public void Remove(int id)
        {
            _usuarioRepository.Remove(id);
        }
    }
}