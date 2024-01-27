namespace Poker.HandRankClassification
{
    public class FullHouseRankHandler : BaseHandRankHandler, IWinningRankCalculator, IKickerRankCalculator
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            var ordered = cards.OrderByDescending(x => x.Rank).ToList();

            if (ordered.GroupBy(x => x.Rank).Any(x => x.Count() == 3))
            {
                var tok = ordered.GroupBy(x => x.Rank).Where(x => x.Count() == 3).First();
                ordered.RemoveAll(x => x.Rank == tok.Key);

                if (ordered.GroupBy(x => x.Rank).Any(x => x.Count() == 2))
                {
                    var tokCards = tok.Select(x => new Card(x.Suit, x.Rank)).ToList();
                    return new HandResult(HandRank.FullHouse, this.CalculateWinningRank(tokCards), this.CalculateKickerRank(tokCards));
                }
            }

            return base.Handle(handCards, communityCards);
        }

        public CardRank CalculateWinningRank(List<Card> cards)
        {
            return cards.First().Rank;
        }

        public CardRank CalculateKickerRank(List<Card> cards)
        {
            return this.CalculateWinningRank(cards);
        }
    }
}
