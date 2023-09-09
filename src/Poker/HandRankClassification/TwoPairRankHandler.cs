namespace Poker.HandRankClassification
{
    public class TwoPairRankHandler : BaseHandRankHandler
    {
        public override HandRank Handle(List<Card> cards)
        {
            if (cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2)
            {
                return HandRank.TwoPair;
            }

            return base.Handle(cards);
        }
    }
}
