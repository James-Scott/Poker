namespace Poker
{
    public struct Card
    {
        private readonly CardSuit suit;
        private readonly CardRank rank;

        public Card(CardSuit suit, CardRank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public override string ToString()
        {
            return $"{this.rank} of {this.suit}s";
        }
    }
}
