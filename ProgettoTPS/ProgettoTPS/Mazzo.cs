using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTPS
{
    public class Mazzo
    {
        private List<Carta> carte;

        public Mazzo()
        {
            carte = new List<Carta>();
            string[] colori = { "Rosso", "Blu", "Verde", "Giallo" };

            foreach (var colore in colori)
            {
                for (int i = 1; i <= 10; i++)
                {
                    carte.Add(new Carta(i, colore));
                }
            }
        }

        public void Mescola()
        {
            var rnd = new Random();
            carte = carte.OrderBy(c => rnd.Next()).ToList();
        }

        public Carta Pesca()
        {
            if (carte.Count == 0) return null;

            var carta = carte[0];
            carte.RemoveAt(0);
            return carta;
        }

        public bool IsEmpty() => carte.Count == 0;

        public void RiempiDallaPilascarti(PilaScarti pilascarti)
        {
            carte = pilascarti.RipristinoCarte();
            Mescola();
        }
    }
}