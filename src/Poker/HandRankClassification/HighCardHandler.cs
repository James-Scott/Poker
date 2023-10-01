namespace Poker.HandRankClassification
{
    public class HighCardHandler : BaseHandRankHandler
    {
        public override HandResult Handle(List<Card> cards)
        {
            var highCard = cards.OrderByDescending(x => x.Rank).First();

            return new HandResult(HandRank.HighCard, highCard);
        }
    }
}