using System.Security.Cryptography;
using SenhaIdentidade.Senha.Exceptions;

namespace SenhaIdentidade.Senha
{
    public static class SenhaHash
    {
        public static string Hash(
            string senha,
            short tamanhoReal = 16,
            short tamanhoChave = 32,
            int iteracoes = 10000,
            char dividirChar = '.',
            string chavePrivada = "")
        {
            if (string.IsNullOrEmpty(senha))
                throw new ValidarSenhaException("Senha não pode ser nula ou vazia");

            senha += chavePrivada;

            using var algoritimo = new Rfc2898DeriveBytes(
                senha,
                tamanhoReal,
                iteracoes,
                HashAlgorithmName.SHA256);
            var key = Convert.ToBase64String(algoritimo.GetBytes(tamanhoChave));
            var salt = Convert.ToBase64String(algoritimo.Salt);

            return $"{iteracoes}{dividirChar}{salt}{dividirChar}{key}";
        }

        public static bool verify(
            string hash,
            string senha,
            short tamanhoReal = 32,
            int iteracoes = 10000,
            char dividirChar = '.',
            string chavePrivada = "")
        {
            senha += chavePrivada;

            var partes = hash.Split(dividirChar, 3);
            if (partes.Length != 3)
                return false;

                var hashInteracoes = Convert.ToInt32(partes[0]);
                var real = Convert.FromBase64String(partes[1]);
                var key = Convert.FromBase64String(partes[2]);

                if(hashInteracoes != iteracoes)
                    return false;

                    using var algoritimo = new Rfc2898DeriveBytes(
                        senha,
                        real,
                        iteracoes,
                        HashAlgorithmName.SHA256);
                        var senhaParaCheckar = algoritimo.GetBytes(tamanhoReal);

                        return senhaParaCheckar.SequenceEqual(key);
        }
    }
}

