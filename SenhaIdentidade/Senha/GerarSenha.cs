namespace SenhaIdentidade.Senha
{
    public static class GerarSenha
    {
        private const string Valido = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private const string Especial = "!@#$%&*()_+-=[]{};:,.<>?";

        public static string Gerador(
            short tamanho = 16,
            bool incluirCaracteresEspeciais = true,
            bool maiuscula = false)
        {
            var caracteres = incluirCaracteresEspeciais ? (Valido + Especial) : Valido;
            var inicioAleatorio = maiuscula ? 26 : 0;
            var index = 0;
            var resultado = new char[tamanho];
            var random = new Random();

            while (index < tamanho)
                resultado[index++] = caracteres[random.Next(inicioAleatorio, caracteres.Length)];

            return new string(resultado);
        }
    }
}