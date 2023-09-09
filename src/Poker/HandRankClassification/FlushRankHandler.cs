namespace Poker.HandRankClassification
{
    public class FlushRankHandler : BaseHandRankHandler
    {
        public override HandRank Handle(List<Card> cards)
        {
            if (IsFlush(cards))
            {
                return HandRank.Flush;
            }

            return base.Handle(cards);
        }
    }
}
