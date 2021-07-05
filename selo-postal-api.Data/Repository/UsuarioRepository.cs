using System.Linq;

using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Exceptions;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Data.Context;

namespace selo_postal_api.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly PostgresContext _context;

        public UsuarioRepository(PostgresContext context)
        {
            _context = context;
        }

        public Usuario Add(Usuario usuario)
        {
            var novoUsuario = new Usuario
            {
                Login = usuario.Login,
                Password = usuario.Password,
                Role = usuario.Role,
            };
            _context.Usuario.Add(novoUsuario);
            _context.SaveChanges();

            return novoUsuario;
        }

        public Usuario Authenticate(string login, string password)
        {
            var usuario = _context.Usuario.Where(x => x.Login == login).FirstOrDefault(x => x.Password == password);
            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }

        public string RetornaLogin(int id)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(x => x.Id == id);
            if (usuario != null)
            {
                return usuario.Login;
            }
            return null;
        }

        public Usuario Update(int id, Usuario usuario)
        {
            var usuarioNoBanco = _context.Usuario.FirstOrDefault(x => x.Id == id);
            if (usuarioNoBanco == null)
            {
                return null;
            }

            _context.Usuario.Attach(usuarioNoBanco);
            usuarioNoBanco.Password = usuario.Password;

            if (!string.IsNullOrEmpty(usuario.Role))
            {
                usuarioNoBanco.Role = usuario.Role;
            }

            _context.SaveChanges();

            return usuarioNoBanco;
        }

        public bool VerificaExistente(Usuario model) => (_context.Usuario.FirstOrDefault(x => x.Login == model.Login) != null);

        public void Remove(int id)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(e => e.Id == id);

            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
            }
            else
            {
                throw new NotFoundException("Usuario não encontrado!");
            }
        }
    }
}