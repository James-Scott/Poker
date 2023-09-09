namespace Poker.HandRankClassification
{
    public class RoyalFlushRankHandler : BaseHandRankHandler
    {
        public override HandRank Handle(List<Card> cards)
        {
            if (IsStraightFlush(cards) && cards.Any(x => x.Rank == CardRank.Ace))
            {
                return HandRank.RoyalFlush;
            }

            return base.Handle(cards);
        }
    }
}
