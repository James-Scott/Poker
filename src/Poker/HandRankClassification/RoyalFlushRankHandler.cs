namespace Poker.HandRankClassification
{
    public class RoyalFlushRankHandler : BaseHandRankHandler, IWinningRankCalculator, IKickerRankCalculator
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (IsRoyalFlush(cards))
            {
                return new HandResult(HandRank.RoyalFlush, this.CalculateWinningRank(cards), this.CalculateKickerRank(cards));
            }

            return base.Handle(handCards, communityCards);
        }

        public CardRank CalculateWinningRank(List<Card> cards)
        {
            var royalFlush = GetRoyalFlush(cards);
            return royalFlush.OrderByDescending(x => x.Rank).First().Rank;
        }

        public CardRank CalculateKickerRank(List<Card> cards)
        {
            return this.CalculateWinningRank(cards);
        }
    }
}
