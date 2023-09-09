namespace Poker
{
    public struct Card
    {
        public Card(CardSuit suit, CardRank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public readonly CardSuit Suit { get; }

        public readonly CardRank Rank { get; }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}s";
        }
    }
}
