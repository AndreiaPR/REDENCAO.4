using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REDENCAO._4
{
    public class Inimigo : Personagem
    {
        public Inimigo(string nome, int vida, int ataque, int defesa, List<string> habilidades)
            : base(nome, vida, ataque, defesa, habilidades)
        {
        }
    }
}