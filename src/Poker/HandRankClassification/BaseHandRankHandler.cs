namespace Poker.HandRankClassification
{
    public class BaseHandRankHandler : IHandRankHandler
    {
        private const int TotalCardRanks = 13;

        private IHandRankHandler next;

        public IHandRankHandler SetNext(IHandRankHandler handler)
        {
            this.next = handler;

            return handler;
        }

        public virtual HandResult Handle(List<Card> handCards, List<Card> communityCards)
        {
            if (this.next != null)
            {
                return this.next.Handle(handCards, communityCards);
            }
            else
            {
                throw new InvalidOperationException("Cannot determine a valid hand rank for this set of cards");
            }
        }

        protected static bool IsStraight(List<Card> cards)
        {
            var ordered = cards.OrderBy(x => x.Rank).ThenBy(x => x.Suit).GroupBy(x => x.Rank).Select(x => x.First()).ToList();

            if (ordered.Last().Rank == CardRank.Ace)
            {
                ordered.Insert(0, ordered.Last());
            }

            var straight = new List<Card>() { ordered.First() };

            var expectedNextRank = ((int)ordered.First().Rank + 1) % TotalCardRanks;

            for (int i = 1; i < ordered.Count; i++)
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

            var ordered = cards.OrderBy(x => x.Rank).ThenBy(x => x.Suit).GroupBy(x => x.Rank).Select(x => x.First()).ToList();

            if (ordered.Last().Rank == CardRank.Ace)
            {
                ordered.Insert(0, ordered.Last());
            }

            var straight = new List<Card>() { ordered.First() };

            var straights = new List<List<Card>>(); // This approach could probably be optimised later

            var expectedNextRank = ((int)ordered.First().Rank + 1) % TotalCardRanks;

            for (int i = 1; i < ordered.Count; i++)
            {
                var current = ordered[i];

                if ((int)current.Rank == expectedNextRank)
                {
                    straight.Add(current);
                    expectedNextRank++;

                    if (straight.Count >= 5)
                    {
                        straights.Add(straight.Skip(straight.Count - 5).Take(5).ToList());
                    }
                }
                else
                {
                    straight.Clear();
                    straight.Add(current);
                    expectedNextRank = (int)current.Rank + 1;
                }
            }

            return straights.Last();
        }

        protected static bool IsFlush(List<Card> cards)
        {
            return cards.GroupBy(x => x.Suit).Any(x => x.Count() >= 5);
        }

        protected static List<Card> GetFlush(List<Card> cards)
        {
            if (!IsFlush(cards))
            {
                throw new ArgumentException(nameof(cards));
            }

            var ordered = cards.OrderBy(x => x.Rank).ToList();

            var flush = ordered.GroupBy(x => x.Suit).Where(x => x.Count() >= 5);

            ordered.RemoveAll(x => x.Suit != flush.Select(x => x.Key).First());

            return ordered;
        }

        protected static bool IsStraightFlush(List<Card> cards)
        {
            return IsStraight(cards) && IsFlush(cards);
        }

        protected static bool IsRoyalFlush(List<Card> cards)
        {
            if (!IsStraightFlush(cards))
            {
                return false;
            }

            var ranks = new List<CardRank>()
            {
                CardRank.Ten,
                CardRank.Jack,
                CardRank.Queen,
                CardRank.King,
                CardRank.Ace
            };

            foreach (var suit in Enum.GetValues<CardSuit>())
            {
                var suitRanks = cards.Where(x => x.Suit == suit).Select(x => x.Rank);

                if (ranks.All(x => suitRanks.Contains(x)))
                {
                    return true;
                }
            }

            return false;
        }

        protected static List<Card> GetRoyalFlush(List<Card> cards)
        {
            if (!IsRoyalFlush(cards))
            {
                throw new ArgumentException(nameof(cards));
            }

            var ranks = new List<CardRank>()
            {
                CardRank.Ten,
                CardRank.Jack,
                CardRank.Queen,
                CardRank.King,
                CardRank.Ace
            };

            CardSuit royalFlushSuit = CardSuit.Club;

            foreach (var suit in Enum.GetValues<CardSuit>())
            {
                var suitRanks = cards.Where(x => x.Suit == suit).Select(x => x.Rank);

                if (ranks.All(x => suitRanks.Contains(x)))
                {
                    royalFlushSuit = suit;
                }
            }

            return cards.Where(x => x.Suit == royalFlushSuit && ranks.Contains(x.Rank)).OrderBy(x => x.Rank).ToList();
        }
    }
}
