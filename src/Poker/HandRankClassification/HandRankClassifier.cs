namespace Poker.HandRankClassification
{
    public class HandRankClassifier
    {
        public HandRank GetHandRank(List<Card> cards)
        {
            var royalFlush = new RoyalFlushRankHandler();
            var straightFlush = new StraightFlushRankHandler();
            var fourOfAKind = new FourOfAKindRankHandler();
            var flush = new FlushRankHandler();
            var straight = new StraightRankHandler();
            var threeOfAKind = new ThreeOfAKindRankHandler();
            var twoPair = new TwoPairRankHandler();
            var pair = new PairRankHandler();

            royalFlush.SetNext(straightFlush)
                .SetNext(fourOfAKind)
                .SetNext(flush)
                .SetNext(straight)
                .SetNext(threeOfAKind)
                .SetNext(twoPair)
                .SetNext(pair);

            return royalFlush.Handle(cards);
        }
    }
}
