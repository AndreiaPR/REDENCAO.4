using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REDENCAO._4
{
    public class Demonio : Personagem
    {
        public Demonio(string nome, int vida, int ataque, int defesa, List<string> habilidades)
            : base(nome, vida, ataque, defesa, habilidades)
        {
            this.Nome = nome;
            this.Vida = vida;
            this.Ataque = ataque;
            this.Defesa = defesa;
            this.Habilidades = habilidades;
        }
    }
}