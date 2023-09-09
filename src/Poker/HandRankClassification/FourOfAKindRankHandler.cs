namespace Poker.HandRankClassification
{
    public class FourOfAKindRankHandler : BaseHandRankHandler
    {
        public override HandRank Handle(List<Card> cards)
        {
            if (cards.GroupBy(x => x.Rank).Any(x => x.Count() == 4))
            {
                return HandRank.FourOfAKind;
            }

            return base.Handle(cards);
        }
    }
}
