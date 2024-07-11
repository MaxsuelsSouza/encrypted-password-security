using SenhaIdentidade.Senha;
using SenhaIdentidade.Senha.Enums;

namespace SenhaIdentidade;

public static class Program
{
    public static void Main(string[] args)
    {
        SegurancaSenha resultado;
        string senhaUsuario;

        do
        {
            Console.Write("Digite sua senha: ");
            senhaUsuario = Console.ReadLine()!;
            resultado = CheckarSenha.CheckarSenhaForte(senhaUsuario);

            if(resultado <= SegurancaSenha.Fraca)
                Console.WriteLine("Senha Fraca, tente novamente!");
        }
        while(resultado <= SegurancaSenha.Fraca);


            SegurancaSenha resltado = CheckarSenha.CheckarSenhaForte(senhaUsuario);
        if(resltado == SegurancaSenha.Invalido)
            Console.WriteLine("Senha Invalida");
            
        if(resltado == SegurancaSenha.MuitoFraca)
            Console.WriteLine("Senha muito fraca");

        else if(resltado == SegurancaSenha.Fraca)
            Console.WriteLine("Senha fraca");

        else if(resltado == SegurancaSenha.Boa)
            Console.WriteLine("Senha boa");

        else if(resltado == SegurancaSenha.Forte)
            Console.WriteLine("Senha muito forte");


        senhaUsuario = GerarSenha.Gerador(16, true, true);

        string senhaCriptografada = SenhaHash.Hash(senhaUsuario);
        Console.WriteLine($"Senha criptografada: {senhaCriptografada}");
    }
}
