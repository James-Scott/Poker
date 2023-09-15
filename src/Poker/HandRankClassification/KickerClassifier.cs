namespace Poker.HandRankClassification
{
    public class KickerClassifier
    {
        public Card GetKicker(HandRank rank, List<Card> cards)
        {
            if (cards.Count == 0)
            {
                throw new ArgumentException(nameof(cards));
            }

            // TODO: Move this into the hand classifiers and have it return a HandRankResult object with properties for Rank and Kicker?
            if (rank == HandRank.HighCard)
            {
                return cards.OrderBy(x => x.Rank).First();
            }
            else if (rank == HandRank.Pair)
            {
                var pair = cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).First();
                cards.RemoveAll(x => x.Rank == pair.Key);
                return cards.OrderByDescending(x => x.Rank).First(); // TODO just call RemoveAll and have the one return outside
            }
            else if (rank == HandRank.TwoPair)
            {
                var pairs = cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2);
                cards.RemoveAll(x => pairs.Select(x => x.Key).Contains(x.Rank));
                return cards.OrderByDescending(x => x.Rank).First();
            }
            else if (rank == HandRank.ThreeOfAKind)
            {
                var tok = cards.GroupBy(x => x.Rank).Where(x => x.Count() == 3).First();
                cards.RemoveAll(x => x.Rank == tok.Key);
                return cards.OrderByDescending(x => x.Rank).First();
            }

            return cards.OrderByDescending(x => x.Rank).First();
        }
    }
}