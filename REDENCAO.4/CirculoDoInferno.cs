using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REDENCAO._4
{
    public class CirculoDoInferno
    {
        public string NumCirculo { get; set; }
        public string Nome { get; set; }
        public string Pecadores { get; set; }
        public string Pecado { get; set; }
        public string Punicao { get; set; }
        public string Vigia { get; set; }
        public string SeloRedencao { get; set; }
        public Anjo Anjo { get; set; }
        public Demonio Demonio { get; set; }

        public CirculoDoInferno(
            string numCirculo,
            string nome,
            string pecadores,
            string pecado,
            string punicao,
            string vigia,
            string seloRedencao,
            Anjo anjo,
            Demonio demonio)
        {
            this.NumCirculo = numCirculo;
            this.Nome = nome;
            this.Pecadores = pecadores;
            this.Pecado = pecado;
            this.Punicao = punicao;
            this.Vigia = vigia;
            this.SeloRedencao = seloRedencao;
            this.Anjo = anjo;
            this.Demonio = demonio;
        }
    }
}