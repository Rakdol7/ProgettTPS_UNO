using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTPS
{
    public class Tavolo
    {
        public Carta CartaCorrente { get; private set; }

        public void SetPrimaCarta(Carta carta)
        {
            CartaCorrente = carta;
        }

        public void AggiornaCarta(Carta carta)
        {
            CartaCorrente = carta;
        }
    }
}
