namespace Poker.HandRankClassification
{
    public class StraightRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> cards)
        {
            if (IsStraight(cards))
            {
                return new HandResult(HandRank.Straight, this.GetKicker(cards));
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
