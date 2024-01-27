namespace Poker.HandRankClassification
{
    public class FourOfAKindRankHandler : BaseHandRankHandler, IWinningRankCalculator, IKickerRankCalculator
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (cards.GroupBy(x => x.Rank).Any(x => x.Count() == 4))
            {
                return new HandResult(HandRank.FourOfAKind, this.CalculateWinningRank(cards), this.CalculateKickerRank(cards));
            }

            return base.Handle(handCards, communityCards);
        }

        public CardRank CalculateWinningRank(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var fok = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 4).First();
            return fok.First().Rank;
        }

        public CardRank CalculateKickerRank(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var fok = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 4).First();
            ordered.RemoveAll(x => x.Rank == fok.Key);
            return ordered.First().Rank;
        }
    }
}
