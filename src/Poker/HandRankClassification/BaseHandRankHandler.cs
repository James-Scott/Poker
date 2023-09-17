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
            if (IsAceLowStraight(cards))
            {
                return true;
            }

            var ordered = cards.OrderBy(x => x.Rank).ToList();

            var straight = new List<Card>() { cards.First() };

            var expectedNextRank = (int)cards.First().Rank + 1;

            for (int i = 1; i < cards.Count; i++)
            {
                var current = ordered[i];

                if ((int)current.Rank == expectedNextRank)
                {
                    straight.Add(current);
                    expectedNextRank++;

                    if (straight.Count == 5)
                    {
                        return true;
                    }
                }
                else
                {
                    straight.Clear();
                    straight.Add(current);
                    expectedNextRank = (int)current.Rank + 1;
                }
            }

            return false;
        }

        protected static List<Card> GetStraight(List<Card> cards)
        {
            if (!IsStraight(cards))
            {
                throw new ArgumentException(nameof(cards));
            }

            if (IsAceLowStraight(cards))
            {
                return GetAceLowStraight(cards);
            }

            var ordered = cards.OrderBy(x => x.Rank).ToList();

            var straight = new List<Card>() { cards.First() };

            var expectedNextRank = (int)cards.First().Rank + 1;

            for (int i = 1; i < cards.Count; i++)
            {
                var current = ordered[i];

                if ((int)current.Rank == expectedNextRank)
                {
                    straight.Add(current);
                    expectedNextRank++;

                    if (straight.Count == 5)
                    {
                        break;
                    }
                }
                else
                {
                    straight.Clear();
                    straight.Add(current);
                    expectedNextRank = (int)current.Rank + 1;
                }
            }

            return straight;
        }

        protected static bool IsFlush(List<Card> cards)
        {
            return cards.GroupBy(x => x.Suit).Any(x => x.Count() == 5);
        }

        protected static List<Card> GetFlush(List<Card> cards)
        {
            if (!IsFlush(cards))
            {
                throw new ArgumentException(nameof(cards));
            }

            var ordered = cards.OrderBy(x => x.Rank).ToList();

            var flush = ordered.GroupBy(x => x.Suit).Where(x => x.Count() == 5);

            ordered.RemoveAll(x => x.Suit != flush.Select(x => x.Key).First());

            return ordered;
        }

        protected static bool IsStraightFlush(List<Card> cards)
        {
            return IsStraight(cards) && IsFlush(cards);
        }

        private static bool IsAceLowStraight(List<Card> cards)
        {
            var ordered = cards.OrderBy(x => x.Rank).ToList();

            return ordered.Where(x => x.Rank == CardRank.Ace
                || x.Rank == CardRank.Two
                || x.Rank == CardRank.Three
                || x.Rank == CardRank.Four
                || x.Rank == CardRank.Five).Count() == 5;
        }

        private static List<Card> GetAceLowStraight(List<Card> cards)
        {
            var ordered = cards.OrderBy(x => x.Rank).ToList();

            var straight = ordered.Where(x => x.Rank == CardRank.Ace
                || x.Rank == CardRank.Two
                || x.Rank == CardRank.Three
                || x.Rank == CardRank.Four
                || x.Rank == CardRank.Five).ToList();

            return new List<Card>()
            {
                straight[4],
                straight[0],
                straight[1],
                straight[2],
                straight[3]
            };
        }
    }
}
