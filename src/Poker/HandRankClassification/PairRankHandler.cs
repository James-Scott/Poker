namespace Poker.HandRankClassification
{
    public class PairRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> cards)
        {
            if (cards.GroupBy(x => x.Rank).Any(x => x.Count() == 2))
            {
                return new HandResult(HandRank.Pair, this.GetKicker(cards));
            }

            return base.Handle(cards);
        }

        public Card GetKicker(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var pair = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 2).First();
            ordered.RemoveAll(x => x.Rank == pair.Key);
            return ordered.First();
        }
    }
}
