namespace Poker.HandRankClassification
{
    public class HighCardHandler : BaseHandRankHandler
    {
        public override HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            var highCard = handCards.OrderByDescending(x => x.Rank).First();

            return new HandResult(HandRank.HighCard, highCard.Rank, highCard.Rank);
        }
    }
}