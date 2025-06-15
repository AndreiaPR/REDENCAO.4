using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REDENCAO._4
{
    public class Jogo
    {
        private Humano Humano { get; set; }
        private List<CirculoDoInferno> Circulos { get; set; }
        private List<CirculoDoInferno> CirculosSelecionados { get; set; }

        public Jogo(string nomeHumano)
        {
            Humano = new Humano(nomeHumano, 150, 25, 20, new List<string> { "Espada da Justiça", "Escudo da Fé" });
            Circulos = ConfigurarCirculos();
            CirculosSelecionados = new List<CirculoDoInferno>();
        }

        private List<CirculoDoInferno> ConfigurarCirculos()
        {
            return new List<CirculoDoInferno>
        {
            new CirculoDoInferno("Primeiro Círculo", "O Limbo", "Pagãos", "Não Batizados",
            "Ficam vagando para sempre na escuridão e em silêncio.", "Medusa", "Selo da Consagracao",
            new Anjo("Miguel", 100, 20, 15, new List<string> { "Espada Celestial", "Cura Divina" }, 10),
            new Demonio("Belial", 80, 18, 12, new List<string> { "Foice Maldita", "Garras Sombras" })),

            new CirculoDoInferno("Segundo Círculo", "Vale dos Ventos", "Adúlteros", "Luxúria",
            "São atormentados por um turbilhão eterno.", "Rei Minos de Creta", "Selo da Integridade",
            new Anjo("Gabriel", 120, 25, 18, new List<string> { "Arco da Verdade", "Luz Restauradora" }, 15),
            new Demonio("Asmodeus", 90, 22, 14, new List<string> { "Correntes Infernais", "Chamas do Pecado" })),

            new CirculoDoInferno("Terceiro Círculo", "Lago de Lama", "Gulosos", "Gula",
            "Castigados pela eternidade em um lago de lama gelada, sob chuva de granizo.", "Cérbero", "Selo da Sobriedade",
            new Anjo("Rafael", 110, 22, 16, new List<string> { "Lança Divina", "Benção do Céu" }, 12),
            new Demonio("Mammon", 85, 20, 13, new List<string> { "Chicote de Chamas", "Dança Sombria" })),

            new CirculoDoInferno("Quarto Círculo", "Colinas de Rocha", "Gananciosos", "Ganância",
            "Punidos rolando pedras pesadas por toda eternidade.", "Plutão", "Selo da Generosidade",
            new Anjo("Uriel", 130, 28, 20, new List<string> { "Escudo da Luz", "Proteção Divina" }, 20),
            new Demonio("Beelzebub", 100, 24, 16, new List<string> { "Machado Negro", "Aura de Terror" })),

            new CirculoDoInferno("Quinto Círculo", "Rio Estige", "Irados", "Ira",
            "Afogados em um rio de lama fervente, perpetuamente em combate.", "Flegias", "Selo da Serenidade",
            new Anjo("Sariel", 140, 30, 22, new List<string> { "Armadura Sagrada", "Luz Purificadora" }, 25),
            new Demonio("Abaddon", 110, 26, 18, new List<string> { "Espada Sangrenta", "Olhar da Perdição" })),

            new CirculoDoInferno("Sexto Círculo", "Cemitério de Fogo", "Hereges", "Heresia",
            "Eternidade em tumbas envoltas em chamas.", "Minotauro", "Selo da Clemência",
            new Anjo("Remiel", 150, 32, 24, new List<string> { "Cetro da Justiça", "Chama do Perdão" }, 30),
            new Demonio("Astaroth", 120, 28, 20, new List<string> { "Foice das Trevas", "Sombra Dilaceradora" })),

            new CirculoDoInferno("Sétimo Círculo", "Vale do Flegetonte", "Violentos", "Violência",
            "Mergulhados em um rio de sangue fervente.", "Centauros", "Selo da Serenidade",
            new Anjo("Metatron", 160, 35, 26, new List<string> { "Espada de Fogo", "Aura de Paz" }, 35),
            new Demonio("Lilith", 130, 30, 22, new List<string> { "Garras Sombrias", "Canto Hipnótico" })),

            new CirculoDoInferno("Oitavo Círculo", "O Malebolge", "Mentirosos", "Fraude",
            "Mutilados por demônios espadachins.", "Ciclope", "Selo da Confiança",
            new Anjo("Zadkiel", 170, 38, 28, new List<string> { "Flecha da Verdade", "Luz da Honestidade" }, 40),
            new Demonio("Leviathan", 140, 32, 24, new List<string> { "Tridente Profano", "Maré do Caos" })),

            new CirculoDoInferno("Nono Círculo", "Lago Cocite", "Traidores", "Traição",
            "Congelados no lago até o pescoço.", "Lúcifer", "Selo da Lealdade",
            new Anjo("Ariel", 200, 50, 40, new List<string> { "Espada da Redenção", "Escudo da Esperança" }, 50),
            new Demonio("Lúcifer", 180, 45, 35, new List<string> { "Cetro do Caos", "Aura de Desespero" }))
        };
        }

        public async Task IniciarAsync()
        {
            Console.WriteLine("\nEscolha os três pecados que o trouxeram ao inferno:");
            Console.WriteLine("1. Não Batizados");
            Console.WriteLine("2. Luxúria");
            Console.WriteLine("3. Gula");
            Console.WriteLine("4. Ganância");
            Console.WriteLine("5. Ira");
            Console.WriteLine("6. Heresia");
            Console.WriteLine("7. Violência");
            Console.WriteLine("8. Fraude");
            Console.WriteLine("9. Traição");

            var pecadosEscolhidos = new List<string>();

            while (pecadosEscolhidos.Count < 3)
            {
                Console.Write("\nDigite o número correspondente ao seu pecado: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1": pecadosEscolhidos.Add("Não Batizados"); break;
                    case "2": pecadosEscolhidos.Add("Luxúria"); break;
                    case "3": pecadosEscolhidos.Add("Gula"); break;
                    case "4": pecadosEscolhidos.Add("Ganância"); break;
                    case "5": pecadosEscolhidos.Add("Ira"); break;
                    case "6": pecadosEscolhidos.Add("Heresia"); break;
                    case "7": pecadosEscolhidos.Add("Violência"); break;
                    case "8": pecadosEscolhidos.Add("Fraude"); break;
                    case "9": pecadosEscolhidos.Add("Traição"); break;
                    default:
                        Console.WriteLine("Escolha inválida. Tente novamente.");
                        break;
                }
            }

            CirculosSelecionados = Circulos.Where(c => pecadosEscolhidos.Contains(c.Pecado)).ToList();

            int pontosHumano = 0;
            int pontosAnjo = 0;
            int pontosDemoniacos = 0;

            foreach (var circulo in CirculosSelecionados)
            {
                Console.WriteLine($"\n🌌 Entrando no {circulo.Nome} ({circulo.Pecado})...");
                Console.WriteLine($"Pecadores: {circulo.Pecadores}");
                Console.WriteLine($"Punição: {circulo.Punicao}");

                Batalha batalha = new Batalha();
                var resultado = await batalha.IniciarAsync(Humano, circulo.Anjo, circulo.Demonio);

                pontosHumano += resultado.PontuacaoHumano;
                pontosAnjo += resultado.PontuacaoAnjo;
                pontosDemoniacos += resultado.PontuacaoDemonio;

                Console.WriteLine("\n--- Resultado da Batalha ---");
                Console.WriteLine($"Círculo: {circulo.Nome}");
                Console.WriteLine($"Pecado: {circulo.Pecado}");
                Console.WriteLine($"Pontuação do Humano: {resultado.PontuacaoHumano}");
                Console.WriteLine($"Pontuação do Anjo: {resultado.PontuacaoAnjo}");
                Console.WriteLine($"Pontuação do Demônio: {resultado.PontuacaoDemonio}");

                if (resultado.HumanoVenceu)
                {
                    Console.WriteLine($"🎉 Vitória! Você redimiu o pecado de {circulo.Pecado} e conquistou o **{circulo.SeloRedencao}**.");
                }
                else
                {
                    Console.WriteLine($"❌ Derrota! O demônio {circulo.Demonio.Nome} venceu.");
                }
            }

            Console.WriteLine("\n--- Resultado Final ---");
            Console.WriteLine($"Pontuação do Humano: {pontosHumano}");
            Console.WriteLine($"Pontuação do Anjo: {pontosAnjo}");
            Console.WriteLine($"Pontuação dos Demônios: {pontosDemoniacos}");

            if (pontosHumano > pontosDemoniacos)
            {
                Console.WriteLine("\n🎉 Você foi redimido de seus pecados e poderá adentrar ao paraíso!");
            }
            else
            {
                Console.WriteLine("\n🔥 Lúcifer evoluiu para um dragão de três cabeças!");
                Console.WriteLine("💀 Lúcifer diz: 'Agora você perecerá para sempre no inferno!'");
            }
        }
    }
}