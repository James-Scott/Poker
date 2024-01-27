namespace Poker.HandRankClassification
{
    public class StraightRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (IsStraight(cards))
            {
                return new HandResult(HandRank.Straight, this.GetKicker(cards));
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
