namespace Poker.HandRankClassification
{
    public class FlushRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> cards)
        {
            if (IsFlush(cards))
            {
                return new HandResult(HandRank.Flush, this.GetKicker(cards));
            }

            return base.Handle(cards);
        }

        public Card GetKicker(List<Card> cards)
        {
            var flush = GetFlush(cards);
            return flush.OrderByDescending(x => x.Rank).First();
        }
    }
}
