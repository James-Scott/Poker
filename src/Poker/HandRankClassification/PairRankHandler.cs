namespace Poker.HandRankClassification
{
    public class PairRankHandler : BaseHandRankHandler
    {
        public override HandRank Handle(List<Card> cards)
        {
            if (cards.GroupBy(x => x.Rank).Any(x => x.Count() == 2))
            {
                return HandRank.Pair;
            }

            return base.Handle(cards);
        }
    }
}
