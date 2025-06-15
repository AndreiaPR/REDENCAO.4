using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REDENCAO._4
{
    public abstract class Personagem
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public List<string> Habilidades { get; set; }

        public Personagem(string nome, int vida, int ataque, int defesa, List<string> habilidades)
        {
            this.Nome = nome;
            this.Vida = vida;
            this.Ataque = ataque;
            this.Defesa = defesa;
            this.Habilidades = habilidades;
        }

        public virtual void Atacar(Personagem alvo)
        {
            int dano = Math.Max(1, Ataque - alvo.Defesa);
            alvo.Vida -= dano;
            Console.WriteLine($"{Nome} atacou {alvo.Nome} causando {dano} de dano!");
        }
    }
}