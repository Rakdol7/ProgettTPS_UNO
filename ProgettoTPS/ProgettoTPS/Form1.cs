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

        /*private void CreatePlayerHandsUI()
        {
            // Posizione iniziale per i bottoni delle mani
            int startX = 20; // Margine sinistro
            int startY = 50; // Margine superiore
            int buttonWidth = 60;
            int buttonHeight = 40;
            int spacing = 10; // Spazio tra i bottoni

            for (int i = 0; i < giocatori.Length; i++)
            {
                var player = giocatori[i];
                int currentY = startY + (buttonHeight + spacing) * i; // Riga per ogni giocatore

                for (int j = 0; j < player.Mano.Count; j++)
                {
                    var card = player.Mano[j];
                    Button cardButton = new Button
                    {
                        Width = buttonWidth,
                        Height = buttonHeight,
                        Text = card.Numero.ToString(),
                        BackColor = GetColorFromString(card.Colore),
                        Location = new Point(startX + (buttonWidth + spacing) * j, currentY),
                        Name = $"Player{i}_Card{j}" // Nome univoco per ogni bottone
                    };

                    // Aggiunta del bottone alla Form
                    Controls.Add(cardButton);
                }
            }
        }

        private Color GetColorFromString(string colorName)
        {
            return colorName switch
            {
                "Rosso" => Color.Red,
                "Blu" => Color.Blue,
                "Verde" => Color.Green,
                "Giallo" => Color.Yellow,
                _ => Color.Gray, // Default in caso di errore
            };
        }*/

        //--------------------------------------------------------------------------------------------------------

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

            //CreatePlayerHandsUI();
        }
    }
}


