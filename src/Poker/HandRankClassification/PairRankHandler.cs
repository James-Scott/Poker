namespace Poker.HandRankClassification
{
    public class PairRankHandler : BaseHandRankHandler, IWinningRankCalculator, IKickerRankCalculator
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (cards.GroupBy(x => x.Rank).Any(x => x.Count() == 2))
            {
                return new HandResult(HandRank.Pair, this.CalculateWinningRank(cards), this.CalculateKickerRank(cards));
            }

            return base.Handle(handCards, communityCards);
        }

        public CardRank CalculateWinningRank(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var pair = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 2).First();
            return pair.First().Rank;
        }

        public CardRank CalculateKickerRank(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var pair = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 2).First();
            ordered.RemoveAll(x => x.Rank == pair.Key);
            return ordered.First().Rank;
        }
    }
}
