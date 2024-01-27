namespace Poker.HandRankClassification
{
    public class StraightRankHandler : BaseHandRankHandler, IWinningRankCalculator, IKickerRankCalculator
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var cards = handCards.Concat(communityCards).ToList();

            if (IsStraight(cards))
            {
                return new HandResult(HandRank.Straight, this.CalculateWinningRank(cards), this.CalculateKickerRank(cards));
            }

            return base.Handle(handCards, communityCards);
        }

        public CardRank CalculateWinningRank(List<Card> cards)
        {
            var straight = GetStraight(cards);
            return straight.Last().Rank;
        }

        public CardRank CalculateKickerRank(List<Card> cards)
        {
            return this.CalculateWinningRank(cards);
        }
    }
}
