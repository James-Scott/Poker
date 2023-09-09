namespace Poker.HandRankClassification
{
    public class ThreeOfAKindRankHandler : BaseHandRankHandler
    {
        public override HandRank Handle(List<Card> cards)
        {
            if (cards.GroupBy(x => x.Rank).Any(x => x.Count() == 3))
            {
                return HandRank.ThreeOfAKind;
            }

            return base.Handle(cards);
        }
    }
}
