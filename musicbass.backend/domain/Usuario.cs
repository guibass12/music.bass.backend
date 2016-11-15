using common.Validation;
using System;

namespace domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
        public int NivelId { get; set; }
        public virtual Nivel Nivel { get; set; }

        #region Methods
        public void SetarSenha(string senha, string confirmarSenha)
        {
            AssertionConcern.AssertArgumentNotNull(senha, "Senha Inválida");
            AssertionConcern.AssertArgumentNotNull(confirmarSenha, "Senha de confirmação inválida");
            AssertionConcern.AssertArgumentEquals(senha, confirmarSenha, "Senhas não coincidem");
            AssertionConcern.AssertArgumentLength(senha, 3, 12, "Senha inválida");

            this.Senha = PasswordAssertionConcern.Encrypt(senha);
        }
        public string ResetarSenha()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            this.Senha = PasswordAssertionConcern.Encrypt(password);

            return password;
        }
        public void MudarSenha(string nome)
        {
            this.Nome = nome;
        }
        public void Validar()
        {
            AssertionConcern.AssertArgumentLength(this.Nome, 3, 100, "Nome de Usuário Inválido");
          
            EmailAssertionConcern.AssertIsValid(this.Email);
            PasswordAssertionConcern.AssertIsValid(this.Senha);
        }
        public override string ToString()
        {
            return "Nome: " + this.Nome + "\nSenha: " + this.Senha;
        }
        #endregion
    }
}
