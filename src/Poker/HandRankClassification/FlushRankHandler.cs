namespace Poker.HandRankClassification
{
    public class FlushRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (IsFlush(cards))
            {
                return new HandResult(HandRank.Flush, this.GetKicker(cards));
            }

            return base.Handle(handCards, communityCards);
        }

        public Card GetKicker(List<Card> cards)
        {
            var flush = GetFlush(cards);
            return flush.OrderByDescending(x => x.Rank).First();
        }
    }
}
