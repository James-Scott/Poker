namespace Poker.HandRankClassification
{
    public class RoyalFlushRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (IsRoyalFlush(cards))
            {
                return new HandResult(HandRank.RoyalFlush, this.GetKicker(cards));
            }

            return base.Handle(handCards, communityCards);
        }

        public Card GetKicker(List<Card> cards)
        {
            var royalFlush = GetRoyalFlush(cards);
            return royalFlush.OrderByDescending(x => x.Rank).First();
        }
    }
}
