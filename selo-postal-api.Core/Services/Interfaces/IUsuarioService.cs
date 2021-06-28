using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.Models;

namespace selo_postal_api.Core.Services.Interfaces
{
    public interface IUsuarioService
    {
        Usuario Add(Usuario model);
        public UsuarioToken Authenticate(UsuarioLogin usuario);
        string RetornaLogin(int id);
        Usuario Update(int id, Usuario usuario);
        bool VerificaExistente(Usuario model);
        void Remove(int id);
    }
}