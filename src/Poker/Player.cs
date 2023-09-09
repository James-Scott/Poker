using Poker.HandRankClassification;

namespace Poker
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.Cards = new List<Card>();
        }

        public string Name { get; }

        public List<Card> Cards { get; }

        public HandRank? HandRank { get; private set; }

        public void CalculateHandRank()
        {
            var classifier = new HandRankClassifier();

            this.HandRank = classifier.GetHandRank(this.Cards);
        }
    }
}
