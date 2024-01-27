namespace Poker.HandRankClassification
{
    [Obsolete($"Refactor using new {nameof(IWinningRankCalculator)} and {nameof(IKickerRankCalculator)}")]
    public interface IKicker
    {
        public Card GetKicker(List<Card> cards);
    }
}
