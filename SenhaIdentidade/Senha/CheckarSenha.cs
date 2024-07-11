using System.Text.RegularExpressions;
using SenhaIdentidade.Senha.Enums;

namespace SenhaIdentidade.Senha
{
    public static class CheckarSenha
    {
        private const string TemNumeroExpressao = @"[0-9]+";
        private const string TemCaracteresMaisculosExpressao = @"[A-Z]+";
        private const string TemCaracteresMinusculosExpressao = @".{12,}";
        private const string NaoTemCaracteresEspeciaisExpressao = @"^[a-zA-Z0-9 ]*$";

        public static SegurancaSenha CheckarSenhaForte(string senhaTextoSimples)
        {
            short pontos = 0;

            if (Regex.Match(senhaTextoSimples, TemNumeroExpressao).Success)
                pontos++;

            if (Regex.Match(senhaTextoSimples, TemCaracteresMaisculosExpressao).Success)
                pontos++;

            if (Regex.Match(senhaTextoSimples, TemCaracteresMinusculosExpressao).Success)
                pontos++;

            if (!Regex.Match(senhaTextoSimples, NaoTemCaracteresEspeciaisExpressao).Success)
                pontos++;

                return (SegurancaSenha)pontos;
        }
    }
}