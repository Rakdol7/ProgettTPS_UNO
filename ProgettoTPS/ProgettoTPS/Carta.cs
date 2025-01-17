using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTPS
{
    public class Carta
    {
        public int Numero { get; }
        public string Colore { get; }

        public Carta(int numero, string colore)
        {
            Numero = numero;
            Colore = colore;
        }

        public bool IsGiocabile(Carta other)
        {
            return Numero == other.Numero || Colore == other.Colore;
        }
    }
}

