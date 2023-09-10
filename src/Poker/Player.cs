using Poker.HandRankClassification;

namespace Poker
{
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

        public HandRank? HandRank { get; private set; }

        public void CalculateHandRank()
        {
            var classifier = new HandRankClassifier();

            if (this.Cards.Count < 5)
            {
                throw new ArgumentException(nameof(this.Cards));
            }

            this.HandRank = classifier.GetHandRank(this.Cards);
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
