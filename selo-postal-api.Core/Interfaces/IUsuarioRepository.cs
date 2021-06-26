using selo_postal_api.Core.Domain.Entities;

namespace selo_postal_api.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Add(Usuario model);
        public Usuario Authenticate(string login, string password);
        string RetornaLogin(int id);
        Usuario Update(int id, Usuario usuario);
        bool VerificaExistente(Usuario model);
        void Remove(int id);
    }
}