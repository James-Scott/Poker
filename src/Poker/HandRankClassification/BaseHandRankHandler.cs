namespace Poker.HandRankClassification
{
    public class BaseHandRankHandler : IHandRankHandler
    {
        private IHandRankHandler next;

        public IHandRankHandler SetNext(IHandRankHandler handler)
        {
            this.next = handler;

            return handler;
        }

        public virtual HandRank Handle(List<Card> cards)
        {
            if (this.next != null)
            {
                return this.next.Handle(cards);
            }
            else
            {
                return HandRank.HighCard;
            }
        }

        protected static bool IsStraight(List<Card> cards)
        {
            var ordered = cards.OrderBy(x => x.Rank).Select(x => x.Rank).ToList();

            var ranks = Enum.GetValues<CardRank>().ToList();

            var matchingRanks = ranks.GetRange(ranks.IndexOf(ordered.First()), 5);

            return Enumerable.SequenceEqual(ordered, matchingRanks);
        }

        protected static bool IsFlush(List<Card> cards)
        {
            return cards.GroupBy(x => x.Suit).Count() == 1;
        }

        protected static bool IsStraightFlush(List<Card> cards)
        {
            return IsStraight(cards) && IsFlush(cards);
        }
    }
}
