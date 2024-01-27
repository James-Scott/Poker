namespace Poker.HandRankClassification
{
    public class StraightFlushRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (IsStraightFlush(cards))
            {
                return new HandResult(HandRank.StraightFlush, this.GetKicker(cards));
            }

            return base.Handle(handCards, communityCards);
        }

        public Card GetKicker(List<Card> cards)
        {
            var straight = GetStraight(cards);
            return straight.Last();
        }
    }
}
