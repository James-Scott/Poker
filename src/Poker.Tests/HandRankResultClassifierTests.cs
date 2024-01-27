﻿namespace Poker.Tests
{
    using Poker.HandRankClassification;

    [TestClass]
    public class HandRankResultClassifierTests
    {
        [TestMethod]
        public void GetHandRank_HighCard_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Two),
                new Card(CardSuit.Diamond, CardRank.Three)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.HighCard, result.HandRank);
            Assert.AreEqual(CardRank.Three, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Pair_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Seven)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.Pair, result.HandRank);
            Assert.AreEqual(CardRank.Seven, result.KickerRank);
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
                new Card(CardSuit.Heart, CardRank.Eight)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.TwoPair, result.HandRank);
            Assert.AreEqual(CardRank.Eight, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_ThreeOfAKind_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Nine)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.ThreeOfAKind, result.HandRank);
            Assert.AreEqual(CardRank.Nine, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Straight_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Two),
                new Card(CardSuit.Club, CardRank.Four),
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Six),
                new Card(CardSuit.Diamond, CardRank.Seven),
                new Card(CardSuit.Heart, CardRank.Eight),
                new Card(CardSuit.Spade, CardRank.Ace)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.Straight, result.HandRank);
            Assert.AreEqual(CardRank.Eight, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Straight_AceIsLow()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Ace),
                new Card(CardSuit.Club, CardRank.Two),
                new Card(CardSuit.Club, CardRank.Three),
                new Card(CardSuit.Club, CardRank.Four),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Eight)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.Straight, result.HandRank);
            Assert.AreEqual(CardRank.Five, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Straight_DuplicatedValue()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Three),
                new Card(CardSuit.Club, CardRank.Four),
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Six),
                new Card(CardSuit.Heart, CardRank.Seven)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.Straight, result.HandRank);
            Assert.AreEqual(CardRank.Seven, result.KickerRank);
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
                new Card(CardSuit.Spade, CardRank.Ace),
                new Card(CardSuit.Heart, CardRank.King)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.Flush, result.HandRank);
            Assert.AreEqual(CardRank.Ace, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Flush_OverFiveSuitedCards()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Three),
                new Card(CardSuit.Spade, CardRank.Five),
                new Card(CardSuit.Spade, CardRank.Nine),
                new Card(CardSuit.Spade, CardRank.Jack),
                new Card(CardSuit.Spade, CardRank.Ace),
                new Card(CardSuit.Spade, CardRank.King)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.Flush, result.HandRank);
            Assert.AreEqual(CardRank.Ace, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_FullHouse_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Four),
                new Card(CardSuit.Diamond, CardRank.Four),
                new Card(CardSuit.Diamond, CardRank.King),
                new Card(CardSuit.Heart, CardRank.King),
                new Card(CardSuit.Spade, CardRank.King),
                new Card(CardSuit.Spade, CardRank.Ace)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.FullHouse, result.HandRank);
            Assert.AreEqual(CardRank.King, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_FourOfAKind_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Five),
                new Card(CardSuit.Spade, CardRank.Five),
                new Card(CardSuit.Spade, CardRank.Three)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.FourOfAKind, result.HandRank);
            Assert.AreEqual(CardRank.Three, result.KickerRank);
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

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.StraightFlush, result.HandRank);
            Assert.AreEqual(CardRank.Seven, result.KickerRank);
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
                new Card(CardSuit.Spade, CardRank.Ace),
                new Card(CardSuit.Club, CardRank.Ace)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(cards);

            Assert.AreEqual(HandRank.RoyalFlush, result.HandRank);
            Assert.AreEqual(CardRank.Ace, result.KickerRank);
        }
    }
}
