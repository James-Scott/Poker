namespace Poker.HandRankClassification
{
    public class StraightFlushRankHandler : BaseHandRankHandler
    {
        public override HandRank Handle(List<Card> cards)
        {
            if (IsStraightFlush(cards))
            {
                return HandRank.StraightFlush;
            }

            return base.Handle(cards);
        }
    }
}
