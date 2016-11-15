using common.Validation;
using domain;
using infra.Repository;
using System;

namespace service
{
    public class UsuarioService : IDisposable
    {
        UsuarioRepository _userRepo = new UsuarioRepository();

        public Usuario Autenticar(string email, string senha)
        {
            var user = this.Obter(email);
            if (user.Senha != PasswordAssertionConcern.Encrypt(senha))
            {
                throw new Exception("Senha inválida");
            }

            return user;
        }

        public Usuario Obter(string email)
        {
            Usuario user = _userRepo.Obter(email);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            return user;
        }

        public void Criar(Usuario usuario)
        {
            var hasUser = _userRepo.Obter(usuario.Email);
            if (hasUser != null)
                throw new Exception("Email já cadastrado");

            usuario.Validar();
            usuario.SetarSenha(usuario.Senha, usuario.ConfirmarSenha);
            _userRepo.Criar(usuario);
        }

        public void Dispose()
        {
            _userRepo.Dispose();
        }
    }
}
