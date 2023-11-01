namespace Poker.HandRankClassification
{
    public class HandResult : IComparable<HandResult>, IComparable
    {
        public HandResult(HandRank handRank, Card kicker)
        {
            this.HandRank = handRank;
            this.Kicker = kicker;
        }

        public HandRank HandRank { get; set; }

        public Card Kicker { get; set; }

        public int CompareTo(HandResult? other)
        {
            if (other == null)
            {
                return 1;
            }

            if (this.HandRank > other.HandRank)
            {
                return 1;
            }

            if (this.HandRank == other.HandRank && this.Kicker.Rank > other.Kicker.Rank)
            {
                return 1;
            }

            if (this.HandRank == other.HandRank && this.Kicker.Rank == other.Kicker.Rank)
            {
                return 0;
            }

            return -1;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var otherHandResult = obj as HandResult;

            if (otherHandResult == null)
            {
                return 1;
            }

            return this.CompareTo(otherHandResult);
        }
    }
}
