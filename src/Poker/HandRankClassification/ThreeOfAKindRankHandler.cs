namespace Poker.HandRankClassification
{
    public class ThreeOfAKindRankHandler : BaseHandRankHandler, IKicker
    {
        public override HandResult Handle(List<Card> cards)
        {
            if (cards.GroupBy(x => x.Rank).Any(x => x.Count() == 3))
            {
                return new HandResult(HandRank.ThreeOfAKind, this.GetKicker(cards));
            }

            return base.Handle(cards);
        }

        public Card GetKicker(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var tok = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 3).First();
            ordered.RemoveAll(x => x.Rank == tok.Key);
            return ordered.First();
        }
    }
}
