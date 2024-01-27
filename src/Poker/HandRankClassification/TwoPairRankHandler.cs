namespace Poker.HandRankClassification
{
    public class TwoPairRankHandler : BaseHandRankHandler, IWinningRankCalculator, IKickerRankCalculator
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2)
            {
                return new HandResult(HandRank.TwoPair, this.CalculateWinningRank(cards), this.CalculateKickerRank(cards));
            }

            return base.Handle(handCards, communityCards);
        }

        public CardRank CalculateWinningRank(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var highestPair = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 2).First();
            return highestPair.First().Rank;
        }

        public CardRank CalculateKickerRank(List<Card> cards)
        {
            var ordered = cards.OrderByDescending(x => x.Rank).ToList();
            var pairs = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 2);
            ordered.RemoveAll(x => pairs.Select(x => x.Key).Contains(x.Rank));
            return ordered.OrderByDescending(x => x.Rank).First().Rank;
        }
    }
}
