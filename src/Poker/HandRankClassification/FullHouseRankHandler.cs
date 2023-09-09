namespace Poker.HandRankClassification
{
    public class FullHouseRankHandler : BaseHandRankHandler
    {
        public override HandRank Handle(List<Card> cards)
        {
            if (cards.GroupBy(x => x.Rank).Any(x => x.Count() == 2 && x.Count() == 3))
            {
                return HandRank.FullHouse;
            }

            return base.Handle(cards);
        }
    }
}
