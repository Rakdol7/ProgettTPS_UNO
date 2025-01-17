using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProgettoTPS
{
    public partial class Form1 : Form
    {
        private Mazzo mazzo;
        private PilaScarti pilascarti;
        private Giocatore[] giocatori;
        private Tavolo tavolo;
        private int indiceGiocatoreCorrente;
        private Thread[] giocatoreThreads;
        private bool giocoInCorso;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeGame()
        {
            mazzo = new Mazzo();
            pilascarti = new PilaScarti();
            tavolo = new Tavolo();
            giocatori = new Giocatore[2];
            giocatoreThreads = new Thread[giocatori.Length];

            for (int i = 0; i < giocatori.Length; i++)
            {
                giocatori[i] = new Giocatore($"Giocatore {i + 1}");
            }
        }

        //--------------------------------------------------------------------------------------------------------------

        private void Turno(int indiceGiocatore)
        {
            while (giocoInCorso)
            {
                if (indiceGiocatoreCorrente == indiceGiocatore)
                {
                    var giocatore = giocatori[indiceGiocatore];
                    var cartaGiocabile = giocatore.ScegliCarta(tavolo.CartaCorrente);

                    if (cartaGiocabile != null)
                    {
                        tavolo.AggiornaCarta(cartaGiocabile);
                        pilascarti.AggiungiCarta(cartaGiocabile);
                        giocatore.GiocaCarta(cartaGiocabile);
                    }
                    else
                    {
                        giocatore.Pesca(mazzo);
                    }

                    ControllaMazzo();

                    indiceGiocatoreCorrente = (indiceGiocatoreCorrente + 1) % giocatori.Length;
                }

                Thread.Sleep(100);
            }
        }

        private void ControllaMazzo()
        {
            if (mazzo.IsEmpty())
            {
                mazzo.RiempiDallaPilascarti(pilascarti);
            }
        }

        //--------------------------------------------------------------------------------------------------------------

        private void IniziaGioco_Click(object sender, EventArgs e)
        {
        }

        private void IniziaGioco_Click_1(object sender, EventArgs e)
        {
            IniziaGioco.Visible = false;
            ManoG1.Visible = true;
            ManoG2.Visible = true;
            GiocaG1.Visible = true;
            GiocaG2.Visible = true;
            PescaG1.Visible = true;
            PescaG2.Visible = true;
            FineG1.Visible = true;
            FineG2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            CartaTav.Visible = true;

            mazzo.Mescola();
            pilascarti.Clear();

            foreach (var giocatore in giocatori)
            {
                giocatore.PescaPrimaMano(mazzo);
            }

            tavolo.SetPrimaCarta(mazzo.Pesca());

            indiceGiocatoreCorrente = 0;
            giocoInCorso = true;

            for (int i = 0; i < giocatori.Length; i++)
            {
                int indiceGiocatore = i;
                giocatoreThreads[i] = new Thread(() => Turno(indiceGiocatore));
                giocatoreThreads[i].Start();
            }

            AggiornaPrimaMano();

        }
        private void AggiornaPrimaMano()
        {
            ManoG1.Items.Clear();
            foreach (var carta in giocatori[0].Mano.ToList())
            {
                ManoG1.Items.Add($"{carta.Colore} {carta.Numero}");
            }

            ManoG2.Items.Clear();
            foreach (var carta in giocatori[1].Mano.ToList())
            {
                ManoG2.Items.Add($"{carta.Colore} {carta.Numero}");
            }
            //label2.Text = Convert.ToString(giocatori[1].Mano.Count);
        }

        private void GiocaG1_Click(object sender, EventArgs e)
        {

        }

        private void PescaG1_Click(object sender, EventArgs e)
        {
            /*var nuovaCarta = mazzo.Pesca(); // Pesca una carta dal mazzo

            if (nuovaCarta != null) // Verifica che ci siano carte nel mazzo
            {
                giocatori[0].Mano.Add(nuovaCarta); // Aggiunge la carta pescata alla mano del giocatore

                // Aggiorna graficamente la mano del giocatore 1
                AggiornaManoGiocatore(0, ManoG1);
            }
            else
            {
                MessageBox.Show("Il mazzo è vuoto, non puoi pescare altre carte!", "Mazzo Vuoto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            label2.Text= Convert.ToString(giocatori[1].Mano.Count);*/

            Carta c = mazzo.Pesca();
            ManoG1.Items.Add($"{c.Colore} {c.Numero}");
            giocatori[0].PescaCarta(c);

        }

        private void GiocaG2_Click(object sender, EventArgs e)
        {

        }

        private void PescaG2_Click(object sender, EventArgs e)
        {
            /*var nuovaCarta = mazzo.Pesca(); // Pesca una carta dal mazzo

            if (nuovaCarta != null) // Verifica che ci siano carte nel mazzo
            {
                giocatori[1].Mano.Add(nuovaCarta); // Aggiunge la carta pescata alla mano del giocatore

                // Aggiorna graficamente la mano del giocatore 1
                AggiornaManoGiocatore(1, ManoG2);
            }
            else
            {
                MessageBox.Show("Il mazzo è vuoto, non puoi pescare altre carte!", "Mazzo Vuoto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            label2.Text = Convert.ToString(giocatori[1].Mano.Count);*/

            Carta c = mazzo.Pesca();
            ManoG2.Items.Add($"{c.Colore} {c.Numero}");
            giocatori[1].PescaCarta(c);
        }
        
        /*private void AggiornaManoGiocatore(int indexGiocatore, ListBox listBoxMano)
        {
            listBoxMano.Items.Clear(); // Svuota la ListBox
            foreach (var carta in giocatori[indexGiocatore].Mano)
            {
                listBoxMano.Items.Add($"{carta.Colore} {carta.Numero}"); // Aggiunge le carte alla ListBox
            }
        }*/

    }
}


