namespace Poker.HandRankClassification
{
    public class StraightFlushRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> cards)
        {
            if (IsStraightFlush(cards))
            {
                return new HandResult(HandRank.StraightFlush, this.GetKicker(cards));
            }

            return base.Handle(cards);
        }

        public Card GetKicker(List<Card> cards)
        {
            var straight = GetStraight(cards);
            return straight.Last();
        }
    }
}
