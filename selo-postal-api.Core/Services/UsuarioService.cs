using selo_postal_api.Core.Domain.Entities;
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

        public Usuario Authenticate(Usuario usuario)
        {
            return _usuarioRepository.Authenticate(usuario.Login, usuario.Password);
        }

        public string RetornaLogin(int id)
        {
            return _usuarioRepository.RetornaLogin(id);
        }

        public Usuario Update(int id, Usuario usuario)
        {
            return _usuarioRepository.Update(id, usuario);
        }

        public Usuario Add(Usuario model)
        {
            return _usuarioRepository.Add(model);
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