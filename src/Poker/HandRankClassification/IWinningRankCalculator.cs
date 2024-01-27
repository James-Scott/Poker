namespace Poker.HandRankClassification
{
    public interface IWinningRankCalculator
    {
        public CardRank CalculateWinningRank(List<Card> cards);
    }
}
