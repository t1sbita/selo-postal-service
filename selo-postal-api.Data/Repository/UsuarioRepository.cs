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

        public Usuario Add(Usuario model)
        {
            var usuario = new Usuario
            {
                Login = model.Login,
                Password = model.Password,
                Role = model.Role,
            };
            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return usuario;
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

        public Usuario Update(int id, Usuario model)
        {
            var usuario = _context.Usuario.FirstOrDefault(x => x.Id == id);
            if (usuario == null)
            {
                return null;
            }

            _context.Usuario.Attach(usuario);
            usuario.Password = model.Password;
            _context.SaveChanges();
            return usuario;

        }

        public bool VerificaExistente(Usuario usuario) => (_context.Usuario.FirstOrDefault(x => x.Login == usuario.Login) != null);

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
                throw new NotFoundException("Endereço não encontrado!");
            }
        }
    }
}