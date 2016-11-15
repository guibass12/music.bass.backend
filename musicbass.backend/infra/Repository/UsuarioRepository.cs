using domain;
using infra.DataContext;
using System;
using System.Data.Entity;
using System.Linq;

namespace infra.Repository
{
    public class UsuarioRepository:IDisposable
    {
        musicbassDataContext _context = new musicbassDataContext();

        public Usuario Obter(string email)
        {
            return _context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public void Criar(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
