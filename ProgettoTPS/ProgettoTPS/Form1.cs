namespace ProgettoTPS
{
    public partial class Form1 : Form
    {
        private Mazzo mazzo;
        private Pilascarti pilascarti;
        private Player[] players;
        private Table table;
        private int currentPlayerIndex;
        private Thread[] playerThreads;
        private bool gameRunning;

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
            // Initialize components
            mazzo = new Mazzo();
            pilascarti = new Pilascarti();
            table = new Table();
            players = new Player[4];
            playerThreads = new Thread[players.Length];

            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player($"Player {i + 1}");
            }

            StartNewRound();
        }

        private void StartNewRound()
        {
            mazzo.Shuffle();
            pilascarti.Clear();

            foreach (var player in players)
            {
                player.DrawInitialHand(mazzo);
            }

            table.SetInitialCard(mazzo.DrawCard());

            currentPlayerIndex = 0;
            gameRunning = true;

            for (int i = 0; i < players.Length; i++)
            {
                int playerIndex = i;
                playerThreads[i] = new Thread(() => PlayerTurn(playerIndex));
                playerThreads[i].Start();
            }
        }

        private void PlayerTurn(int playerIndex)
        {
            while (gameRunning)
            {
                if (currentPlayerIndex == playerIndex)
                {
                    var player = players[playerIndex];
                    var playableCard = player.ChooseCard(table.CurrentCard);

                    if (playableCard != null)
                    {
                        table.UpdateCard(playableCard);
                        pilascarti.AddCard(playableCard);
                        player.PlayCard(playableCard);
                    }
                    else
                    {
                        player.DrawCard(mazzo);
                    }

                    CheckMazzo();

                    currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
                }

                Thread.Sleep(100); // Prevent busy-wait
            }
        }

        private void CheckMazzo()
        {
            if (mazzo.IsEmpty())
            {
                mazzo.RefillFromPilascarti(pilascarti);
            }
        }
    }

    public class Card
    {
        public int Number { get; }
        public string Color { get; }

        public Card(int number, string color)
        {
            Number = number;
            Color = color;
        }

        public bool IsPlayable(Card other)
        {
            return Number == other.Number || Color == other.Color;
        }
    }

    public class Mazzo
    {
        private List<Card> cards;

        public Mazzo()
        {
            cards = new List<Card>();
            string[] colors = { "Red", "Blue", "Green", "Yellow" };

            foreach (var color in colors)
            {
                for (int i = 1; i <= 10; i++)
                {
                    cards.Add(new Card(i, color));
                }
            }
        }

        public void Shuffle()
        {
            var rnd = new Random();
            cards = cards.OrderBy(c => rnd.Next()).ToList();
        }

        public Card DrawCard()
        {
            if (cards.Count == 0) return null;

            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public bool IsEmpty() => cards.Count == 0;

        public void RefillFromPilascarti(Pilascarti pilascarti)
        {
            cards = pilascarti.ClearAndReturnCards();
            Shuffle();
        }
    }

    public class Pilascarti
    {
        private List<Card> cards;

        public Pilascarti()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public List<Card> ClearAndReturnCards()
        {
            var temp = new List<Card>(cards);
            cards.Clear();
            return temp;
        }

        public void Clear() => cards.Clear();
    }

    public class Player
    {
        public string Name { get; }
        private List<Card> hand;

        public Player(string name)
        {
            Name = name;
            hand = new List<Card>();
        }

        public void DrawInitialHand(Mazzo mazzo)
        {
            for (int i = 0; i < 7; i++)
            {
                DrawCard(mazzo);
            }
        }

        public void DrawCard(Mazzo mazzo)
        {
            var card = mazzo.DrawCard();
            if (card != null) hand.Add(card);
        }

        public Card ChooseCard(Card currentCard)
        {
            return hand.FirstOrDefault(c => c.IsPlayable(currentCard));
        }

        public void PlayCard(Card card)
        {
            hand.Remove(card);
        }
    }

    public class Table
    {
        public Card CurrentCard { get; private set; }

        public void SetInitialCard(Card card)
        {
            CurrentCard = card;
        }

        public void UpdateCard(Card card)
        {
            CurrentCard = card;
        }
    }
}

