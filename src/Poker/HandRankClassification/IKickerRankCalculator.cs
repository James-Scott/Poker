namespace Poker.HandRankClassification
{
    public interface IKickerRankCalculator
    {
        public CardRank CalculateKickerRank(List<Card> cards);
    }
}
