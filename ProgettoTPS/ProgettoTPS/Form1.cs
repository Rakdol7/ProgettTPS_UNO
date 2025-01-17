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
        private void Turno(int indiceGiocatore)
        {
            while (giocoInCorso)
            {
                if (indiceGiocatoreCorrente == indiceGiocatore)
                {
                    Invoke(new Action(() =>
                    {
                        AggiornaInterfacciaGiocatore(indiceGiocatore);
                        label2.Text = $"GIOCATORE {indiceGiocatore + 1}";
                    }));

                    while (indiceGiocatoreCorrente == indiceGiocatore)
                    {
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        private void ControllaMazzo()
        {
            if (mazzo.IsEmpty())
            {
                mazzo.RiempiDallaPilascarti(pilascarti);
            }
        }

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
                giocatoreThreads[i].IsBackground = true;
                giocatoreThreads[i].Start();
            }

            AggiornaPrimaMano();
            ModCarta(tavolo.CartaCorrente);

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
        }

        private void GiocaG1_Click(object sender, EventArgs e)
        {
            int indice = ManoG1.SelectedIndex;

            if (giocatori[0].Mano[indice].Colore == tavolo.CartaCorrente.Colore || giocatori[0].Mano[indice].Numero == tavolo.CartaCorrente.Numero)
            {
                ModCarta(giocatori[0].Mano[indice]);
                tavolo.AggiornaCarta(giocatori[0].Mano[indice]);
                pilascarti.AggiungiCarta(giocatori[0].Mano[indice]);
                giocatori[0].GiocaCarta(indice);
                ManoG1.Items.Remove(ManoG1.SelectedItem);
                indiceGiocatoreCorrente = 1;
            }
            else
            {
                MessageBox.Show("LA CARTA NON E' GIOCABILE");
            }
            if (giocatori[0].Mano.Count == 0)
            {
                giocoInCorso = false;
                MessageBox.Show("IL GIOCATORE 1 HA VINTO");
            }
        }

        private void PescaG1_Click(object sender, EventArgs e)
        {
            Carta c = mazzo.Pesca();
            ManoG1.Items.Add($"{c.Colore} {c.Numero}");
            giocatori[0].PescaCarta(c);
            ControllaMazzo();
            PescaG1.Visible = false;
        }

        private void GiocaG2_Click(object sender, EventArgs e)
        {
            int indice = ManoG2.SelectedIndex;

            if (giocatori[1].Mano[indice].Colore == tavolo.CartaCorrente.Colore || giocatori[1].Mano[indice].Numero == tavolo.CartaCorrente.Numero)
            {
                ModCarta(giocatori[1].Mano[indice]);
                tavolo.AggiornaCarta(giocatori[1].Mano[indice]);
                pilascarti.AggiungiCarta(giocatori[1].Mano[indice]);
                giocatori[1].GiocaCarta(indice);
                ManoG2.Items.Remove(ManoG2.SelectedItem);
                indiceGiocatoreCorrente = 0;
            }
            else
            {
                MessageBox.Show("LA CARTA NON E' GIOCABILE");
            }
            if (giocatori[1].Mano.Count == 0)
            {
                giocoInCorso = false;
                MessageBox.Show("IL GIOCATORE 2 HA VINTO");
            }
        }

        private void PescaG2_Click(object sender, EventArgs e)
        {
            Carta c = mazzo.Pesca();
            ManoG2.Items.Add($"{c.Colore} {c.Numero}");
            giocatori[1].PescaCarta(c);
            ControllaMazzo();
            PescaG2.Visible = false;
        }

        private void ModCarta(Carta c)
        {
            CartaTav.Text = Convert.ToString(c.Numero);
            if (c.Colore == "Rosso")
            {
                CartaTav.BackColor = Color.Red;
            }
            else if (c.Colore == "Giallo")
            {
                CartaTav.BackColor = Color.Yellow;
            }
            else if (c.Colore == "Blu")
            {
                CartaTav.BackColor = Color.Blue;

            }
            else if (c.Colore == "Verde")
            {
                CartaTav.BackColor = Color.Green;

            }
        }

        private void FineG1_Click(object sender, EventArgs e)
        {
            if (indiceGiocatoreCorrente == 0)
            {
                indiceGiocatoreCorrente = 1;
            }
        }

        private void FineG2_Click(object sender, EventArgs e)
        {
            if (indiceGiocatoreCorrente == 1)
            {
                indiceGiocatoreCorrente = 0;
            }
        }
        private void AggiornaInterfacciaGiocatore(int indiceGiocatore)
        {
            ManoG1.Visible = indiceGiocatore == 0;
            GiocaG1.Visible = indiceGiocatore == 0;
            PescaG1.Visible = indiceGiocatore == 0;
            FineG1.Visible = indiceGiocatore == 0;

            ManoG2.Visible = indiceGiocatore == 1;
            GiocaG2.Visible = indiceGiocatore == 1;
            PescaG2.Visible = indiceGiocatore == 1;
            FineG2.Visible = indiceGiocatore == 1;
        }
    }
}

