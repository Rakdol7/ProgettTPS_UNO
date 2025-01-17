using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ProgettoTPS
{
    public class Giocatore
    {
        public string Nome { get; }
        private List<Carta> mano;
        public List<Carta> Mano => mano;

        public Giocatore(string nome)
        {
            Nome = nome;
            mano = new List<Carta>();
        }

        public void PescaPrimaMano(Mazzo mazzo)
        {
            for (int i = 0; i < 7; i++)
            {
                Pesca(mazzo);
            }
        }

        public void Pesca(Mazzo mazzo)
        {
            var carta = mazzo.Pesca(); // Pesca una carta dal mazzo
            if (carta != null)
            {
                Mano.Add(carta); // Aggiunge la carta alla mano
            }
        }

        public void PescaCarta(Carta carta)
        {
            if (carta != null)
            {
                Mano.Add(carta); // Aggiunge la carta alla mano
            }
        }
        
        public Carta ScegliCarta(Carta cartaCorrente)
        {
            return mano.FirstOrDefault(c => c.IsGiocabile(cartaCorrente));
        }

        public void GiocaCarta(Carta carta)
        {
            mano.Remove(carta);
        }
    }
}
