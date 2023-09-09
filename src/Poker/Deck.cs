namespace Poker
{
    public class Deck
    {
        public Deck()
        {
            this.Cards = new Queue<Card>();
            this.Initialise();
        }

        public Queue<Card> Cards { get; private set; }

        public void Shuffle(int times = 1)
        {
            var cards = this.Cards.ToList();

            for (int i = 0; i < times; i++)
            {
                cards = cards.OrderBy(x => Guid.NewGuid()).ToList();
            }

            this.Cards = new Queue<Card>(cards);
        }

        public List<Card> Deal(int numberOfCards)
        {
            var cards = new List<Card>();

            for (int i = 0; i < numberOfCards; i++)
            {
                cards.Add(this.Cards.Dequeue());
            }

            return cards;
        }

        public void Reset()
        {
            this.Cards.Clear();
            this.Initialise();
        }

        private void Initialise()
        {
            foreach (var suit in Enum.GetValues<CardSuit>())
            {
                foreach (var rank in Enum.GetValues<CardRank>())
                {
                    this.Cards.Enqueue(new Card(suit, rank));
                }
            }
        }
    }
}
