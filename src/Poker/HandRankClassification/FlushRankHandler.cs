namespace Poker.HandRankClassification
{
    public class FlushRankHandler : BaseHandRankHandler, IWinningRankCalculator, IKickerRankCalculator
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (IsFlush(cards))
            {
                return new HandResult(HandRank.Flush, this.CalculateWinningRank(cards), this.CalculateKickerRank(cards));
            }

            return base.Handle(handCards, communityCards);
        }

        public CardRank CalculateWinningRank(List<Card> cards)
        {
            var flush = GetFlush(cards);
            return flush.OrderByDescending(x => x.Rank).First().Rank;
        }

        public CardRank CalculateKickerRank(List<Card> cards)
        {
            return this.CalculateWinningRank(cards);
        }
    }
}
