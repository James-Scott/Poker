namespace Poker.HandRankClassification
{
    public class TwoPairRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> cards)
        {
            if (cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2)
            {
                return new HandResult(HandRank.TwoPair, this.GetKicker(cards));
            }

            return base.Handle(cards);
        }

        public Card GetKicker(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var pairs = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 2);
            ordered.RemoveAll(x => pairs.Select(x => x.Key).Contains(x.Rank));
            return ordered.OrderByDescending(x => x.Rank).First();
        }
    }
}
