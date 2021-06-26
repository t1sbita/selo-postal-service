using selo_postal_api.Core.Domain.Entities;

namespace selo_postal_api.Core.Services.Interfaces
{
    public interface IUsuarioService
    {
        Usuario Add(Usuario model);
        public Usuario Authenticate(Usuario usuario);
        string RetornaLogin(int id);
        Usuario Update(int id, Usuario usuario);
        bool VerificaExistente(Usuario model);
        void Remove(int id);
    }
}