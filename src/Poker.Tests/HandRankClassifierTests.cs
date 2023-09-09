using Poker.HandRankClassification;

namespace Poker.Tests
{
    [TestClass]
    public class HandRankClassifierTests
    {
        [TestMethod]
        public void GetHandRank_HighCard_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Two),
                new Card(CardSuit.Diamond, CardRank.Three)
            };

            var classifier = new HandRankClassifier();

            var rank = classifier.GetHandRank(cards);

            Assert.AreEqual(HandRank.HighCard, rank);
        }

        [TestMethod]
        public void GetHandRank_Pair_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five)
            };

            var classifier = new HandRankClassifier();

            var rank = classifier.GetHandRank(cards);

            Assert.AreEqual(HandRank.Pair, rank);
        }

        [TestMethod]
        public void GetHandRank_TwoPair_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Club, CardRank.King),
                new Card(CardSuit.Heart, CardRank.King),
            };

            var classifier = new HandRankClassifier();

            var rank = classifier.GetHandRank(cards);

            Assert.AreEqual(HandRank.TwoPair, rank);
        }

        [TestMethod]
        public void GetHandRank_ThreeOfAKind_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Five)
            };

            var classifier = new HandRankClassifier();

            var rank = classifier.GetHandRank(cards);

            Assert.AreEqual(HandRank.ThreeOfAKind, rank);
        }

        [TestMethod]
        public void GetHandRank_Straight_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Three),
                new Card(CardSuit.Club, CardRank.Four),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Six),
                new Card(CardSuit.Heart, CardRank.Seven)
            };

            var classifier = new HandRankClassifier();

            var rank = classifier.GetHandRank(cards);

            Assert.AreEqual(HandRank.Straight, rank);
        }

        [TestMethod]
        public void GetHandRank_Flush_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Three),
                new Card(CardSuit.Spade, CardRank.Five),
                new Card(CardSuit.Spade, CardRank.Nine),
                new Card(CardSuit.Spade, CardRank.Jack),
                new Card(CardSuit.Spade, CardRank.Ace)
            };

            var classifier = new HandRankClassifier();

            var rank = classifier.GetHandRank(cards);

            Assert.AreEqual(HandRank.Flush, rank);
        }

        [TestMethod]
        public void GetHandRank_FourOfAKind_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Five),
                new Card(CardSuit.Spade, CardRank.Five)
            };

            var classifier = new HandRankClassifier();

            var rank = classifier.GetHandRank(cards);

            Assert.AreEqual(HandRank.FourOfAKind, rank);
        }

        [TestMethod]
        public void GetHandRank_StraightFlush_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardRank.Three),
                new Card(CardSuit.Heart, CardRank.Four),
                new Card(CardSuit.Heart, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Six),
                new Card(CardSuit.Heart, CardRank.Seven)
            };

            var classifier = new HandRankClassifier();

            var rank = classifier.GetHandRank(cards);

            Assert.AreEqual(HandRank.StraightFlush, rank);
        }

        [TestMethod]
        public void GetHandRank_RoyalFlush_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Ten),
                new Card(CardSuit.Spade, CardRank.Jack),
                new Card(CardSuit.Spade, CardRank.Queen),
                new Card(CardSuit.Spade, CardRank.King),
                new Card(CardSuit.Spade, CardRank.Ace)
            };

            var classifier = new HandRankClassifier();

            var rank = classifier.GetHandRank(cards);

            Assert.AreEqual(HandRank.RoyalFlush, rank);
        }
    }
}
