namespace Poker
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck()
        {
            this.Cards = new List<Card>();
            this.Initialise();
        }

        public void Shuffle(int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                this.Cards = this.Cards.OrderBy(x => Guid.NewGuid()).ToList();
            }
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
                    this.Cards.Add(new Card(suit, rank));
                }
            }
        }
    }
}
