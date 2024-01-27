namespace Poker.HandRankClassification
{
    public class HandResultClassifier
    {
        public HandResult GetHandRankResult(List<Card> handCards, List<Card> communityCards)
        {
            if (handCards.Count == 0)
            {
                throw new ArgumentException(nameof(handCards));
            }

            // TODO: Reinstate once all tests are reworked
            //if (communityCards.Count == 0)
            //{
            //    throw new ArgumentException(nameof(communityCards));
            //}

            var royalFlush = new RoyalFlushRankHandler();
            var straightFlush = new StraightFlushRankHandler();
            var fourOfAKind = new FourOfAKindRankHandler();
            var fullHouse = new FullHouseRankHandler();
            var flush = new FlushRankHandler();
            var straight = new StraightRankHandler();
            var threeOfAKind = new ThreeOfAKindRankHandler();
            var twoPair = new TwoPairRankHandler();
            var pair = new PairRankHandler();
            var highCard = new HighCardHandler();

            royalFlush.SetNext(straightFlush)
                .SetNext(fourOfAKind)
                .SetNext(fullHouse)
                .SetNext(flush)
                .SetNext(straight)
                .SetNext(threeOfAKind)
                .SetNext(twoPair)
                .SetNext(pair)
                .SetNext(highCard);

            return royalFlush.Handle(handCards, communityCards);
        }
    }
}
