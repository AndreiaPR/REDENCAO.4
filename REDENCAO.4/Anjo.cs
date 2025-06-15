using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REDENCAO._4
{
    public class Anjo : Personagem
    {
        public int PoderCura { get; private set; } // Poder de cura do Anjo
        public int Pontuacao { get; internal set; }

        public Anjo(string nome, int vida, int ataque, int defesa, List<string> habilidades, int poderCura)
            : base(nome, vida, ataque, defesa, habilidades)
        {
            this.PoderCura = poderCura;
        }

        // Método para curar o Humano
        public void Curar(Humano humano)
        {
            int vidaCurada = this.PoderCura;
            humano.Vida += vidaCurada;
            Console.WriteLine($"{Nome} curou {humano.Nome} em {vidaCurada} pontos de vida!");
        }

        // Método para atacar (sobrescrevendo o método base)
        public override void Atacar(Personagem alvo)
        {
            base.Atacar(alvo); // Chama o ataque padrão
        }
    }
}