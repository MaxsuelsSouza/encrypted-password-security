namespace SenhaIdentidade.Senha.Exceptions
{
    public class ValidarSenhaException : Exception
    {
        public ValidarSenhaException(string mensagem = "Senha Invalidar") : base(mensagem) { }
    }
}