namespace Poker.HandRankClassification
{
    public class HandResult
    {
        public HandResult(HandRank handRank, Card kicker)
        {
            this.HandRank = handRank;
            this.Kicker = kicker;
        }

        public HandRank HandRank { get; set; }

        public Card Kicker { get; set; }
    }
}
