namespace Poker.HandRankClassification
{
    public class FourOfAKindRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> cards)
        {
            if (cards.GroupBy(x => x.Rank).Any(x => x.Count() == 4))
            {
                return new HandResult(HandRank.FourOfAKind, this.GetKicker(cards));
            }

            return base.Handle(cards);
        }

        public Card GetKicker(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var fok = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 4).First();
            ordered.RemoveAll(x => x.Rank == fok.Key);
            return ordered.First();
        }
    }
}
