using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTPS
{
    public class PilaScarti
    {
        private List<Carta> carte;

        public PilaScarti()
        {
            carte = new List<Carta>();
        }

        public void AggiungiCarta(Carta carta)
        {
            carte.Add(carta);
        }

        public List<Carta> RipristinoCarte()
        {
            var temp = new List<Carta>(carte);
            carte.Clear();
            return temp;
        }

        public void Clear() => carte.Clear();
    }
}
