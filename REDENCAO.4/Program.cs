using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REDENCAO._4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Jogo dos Nove Círculos do Inferno!");
            Console.Write("Digite o seu nome humano: ");
            string nomeHumano = Console.ReadLine();

            while (true)
            {
                try
                {
                    // Inicializa o jogo com o nome do humano
                    Jogo jogo = new Jogo(nomeHumano);

                    // Chama o método IniciarAsync de forma assíncrona
                    await jogo.IniciarAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Ocorreu um erro durante o jogo: {ex.Message}");
                }

                Console.WriteLine("\nDeseja jogar novamente? (s/n)");
                string resposta = Console.ReadLine();
                if (resposta?.ToLower() != "s")
                {
                    Console.WriteLine("Obrigado por jogar! Até a próxima jornada!");
                    break;
                }
            }
        }
    }
}