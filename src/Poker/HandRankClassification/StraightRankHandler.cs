namespace Poker.HandRankClassification
{
    public class StraightRankHandler : BaseHandRankHandler
    {
        public override HandRank Handle(List<Card> cards)
        {
            if (IsStraight(cards))
            {
                return HandRank.Straight;
            }

            return base.Handle(cards);
        }
    }
}
