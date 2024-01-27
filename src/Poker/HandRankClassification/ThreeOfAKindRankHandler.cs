namespace Poker.HandRankClassification
{
    public class ThreeOfAKindRankHandler : BaseHandRankHandler, IWinningRankCalculator, IKickerRankCalculator
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (cards.GroupBy(x => x.Rank).Any(x => x.Count() == 3))
            {
                return new HandResult(HandRank.ThreeOfAKind, this.CalculateWinningRank(cards), this.CalculateKickerRank(cards));
            }

            return base.Handle(handCards, communityCards);
        }

        public CardRank CalculateWinningRank(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var tok = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 3).First();
            return tok.First().Rank;
        }

        public CardRank CalculateKickerRank(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var tok = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 3).First();
            ordered.RemoveAll(x => x.Rank == tok.Key);
            return ordered.First().Rank;
        }
    }
}
