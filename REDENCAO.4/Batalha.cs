using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace REDENCAO._4
{
    public class Batalha
    {
        private Random rng = new Random();
        private SoundPlayer somBatalha;
        private SoundPlayer somVitoriaHumano;
        private SoundPlayer somVitoriaLucifer;

        public Batalha()
        {
            try
            {
                somBatalha = new SoundPlayer("C:\\Users\\Andréia Patricia\\source\\repos\\REDENCAO.4\\REDENCAO.4\\Som\\som-Violin-Metal.wav");
                somVitoriaHumano = new SoundPlayer("C:\\Users\\Andréia Patricia\\source\\repos\\REDENCAO.4\\REDENCAO.4\\Som\\som-Revelation-Jesus.wav");
                somVitoriaLucifer = new SoundPlayer("C:\\Users\\Andréia Patricia\\source\\repos\\REDENCAO.4\\REDENCAO.4\\Som\\som-inferno.wav");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar sons: {ex.Message}");
            }
        }

        public async Task<(int PontuacaoHumano, int PontuacaoAnjo, int PontuacaoDemonio, bool HumanoVenceu)> IniciarAsync(Humano humano, Anjo anjo, Demonio demonio)
        {
            Console.WriteLine($"⚔️ A batalha começa entre {humano.Nome} (com a ajuda de {anjo.Nome}) e {demonio.Nome}! ⚔️");

            int pontuacaoHumano = 0;
            int pontuacaoAnjo = 0;
            int pontuacaoDemonio = 0;

            try
            {
                somBatalha?.PlayLooping(); // Toca o som de batalha em loop
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao reproduzir o som de batalha: {ex.Message}");
            }

            while (humano.Vida > 0 && demonio.Vida > 0)
            {
                Console.WriteLine("\n--- Turno de Combate ---");
                ExibirStatus(humano, anjo, demonio);

                // Turno do Humano
                if (humano.Vida > 0)
                {
                    pontuacaoHumano += RealizarAcao(humano, demonio);
                }

                // Turno do Anjo
                if (anjo.Vida > 0 && demonio.Vida > 0)
                {
                    if (humano.Vida > 0 && humano.Vida <= 30) // Limita a cura para valores críticos
                    {
                        anjo.Curar(humano);
                    }
                    else
                    {
                        pontuacaoAnjo += RealizarAcao(anjo, demonio);
                    }
                }

                // Turno do Demônio
                if (demonio.Vida > 0)
                {
                    // Estratégia: Atacar o alvo mais vulnerável
                    Personagem alvo;
                    if (!(humano.Vida <= 0 || humano.Vida >= anjo.Vida && anjo.Vida > 0))
                    {
                        alvo = humano;
                    }
                    else
                    {
                        alvo = anjo;
                    }

                    pontuacaoDemonio += RealizarAcao(demonio, alvo);
                }

                await Task.Delay(1000); // Simula o tempo entre os turnos
            }

            try
            {
                somBatalha?.Stop(); // Para o som da batalha
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao parar o som de batalha: {ex.Message}");
            }

            // Resultado da batalha
            bool humanoVenceu = humano.Vida > 0;
            try
            {
                if (humanoVenceu)
                {
                    somVitoriaHumano?.Play(); // Som de vitória do Humano
                    Console.WriteLine($"\n🎉 Vitória! {humano.Nome} e {anjo.Nome} derrotaram {demonio.Nome}! 🎉");
                }
                else
                {
                    somVitoriaLucifer?.Play(); // Som de vitória de Lúcifer
                    Console.WriteLine($"\n❌ Derrota! {demonio.Nome} venceu a batalha e dominou o círculo! ❌");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao reproduzir o som de vitória: {ex.Message}");
            }

            return (pontuacaoHumano, pontuacaoAnjo, pontuacaoDemonio, humanoVenceu);
        }

        private int RealizarAcao(Personagem atacante, Personagem alvo)
        {
            string acao = EscolherAcao();
            switch (acao)
            {
                case "Atacar":
                    return Atacar(atacante, alvo);
                case "Defender":
                    Defender(atacante);
                    return 0; // Defesa não acumula pontuação
                default:
                    return 0; // Caso não haja ação válida
            }
        }

        private string EscolherAcao()
        {
            string[] acoes = { "Atacar", "Defender" };
            return acoes[rng.Next(acoes.Length)];
        }

        private int Atacar(Personagem atacante, Personagem alvo)
        {
            string arma = atacante.Habilidades[rng.Next(atacante.Habilidades.Count)];
            int dano = Math.Max(1, atacante.Ataque - alvo.Defesa + rng.Next(-3, 4)); // Dano com variação aleatória
            alvo.Vida -= dano;
            Console.WriteLine($"{atacante.Nome} atacou {alvo.Nome} com {arma}, causando {dano} de dano!");
            return dano; // Retorna o dano causado
        }

        private void Defender(Personagem defensor)
        {
            int bonusDefesa = rng.Next(5, 11); // Defesa aleatória entre 5 e 10
            defensor.Defesa += bonusDefesa;
            Console.WriteLine($"{defensor.Nome} usou sua habilidade defensiva, aumentando a defesa em {bonusDefesa}!");
        }

        private void ExibirStatus(Humano humano, Anjo anjo, Demonio demonio)
        {
            Console.WriteLine($"{humano.Nome}: Vida = {humano.Vida}, Defesa = {humano.Defesa}");
            Console.WriteLine($"{anjo.Nome}: Vida = {anjo.Vida}, Defesa = {anjo.Defesa}");
            Console.WriteLine($"{demonio.Nome}: Vida = {demonio.Vida}, Defesa = {demonio.Defesa}");
        }
    }
}