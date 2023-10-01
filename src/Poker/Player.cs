namespace Poker
{
    using Poker.HandRankClassification;

    public class Player
    {
        public Player(string name, int chips)
        {
            this.Name = name;
            this.Chips = chips;
            this.Cards = new List<Card>();
        }

        public string Name { get; }

        public int Chips { get; private set; }

        public List<Card> Cards { get; }

        public HandResult HandRankResult { get; private set; }

        public void CalculateHandRank()
        {
            var classifier = new HandResultClassifier();

            if (this.Cards.Count < 5)
            {
                throw new ArgumentException(nameof(this.Cards));
            }

            this.HandRankResult = classifier.GetHandRankResult(this.Cards);
        }

        public void BetChips(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            if (this.Chips - amount < 0)
            {
                throw new InvalidOperationException("Not enough chips");
            }

            this.Chips -= amount;
        }

        public void AddChips(int amount)
        {
            this.Chips += amount;
        }
    }
}
