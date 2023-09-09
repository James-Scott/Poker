namespace Poker.HandRankClassification
{
    public interface IHandRankHandler
    {
        IHandRankHandler SetNext(IHandRankHandler handler);

        HandRank Handle(List<Card> cards);
    }
}
