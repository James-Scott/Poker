namespace Poker.HandRankClassification
{
    public class RoyalFlushRankHandler : BaseHandRankHandler
    {
        public override HandRank Handle(List<Card> cards)
        {
            if (IsRoyalFlush(cards))
            {
                return HandRank.RoyalFlush;
            }

            return base.Handle(cards);
        }
    }
}
