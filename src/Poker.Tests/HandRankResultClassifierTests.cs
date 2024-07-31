namespace Poker.Tests
{
    using Poker.HandRankClassification;

    [TestClass]
    public class HandRankResultClassifierTests
    {
        [TestMethod]
        public void GetHandRank_HighCard_HappyPath()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Two),
                new Card(CardSuit.Diamond, CardRank.Jack)
            };

            var commmunityCards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardRank.Three)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, commmunityCards);

            Assert.AreEqual(HandRank.HighCard, result.HandRank);
            Assert.AreEqual(CardRank.Jack, result.WinningRank);
            Assert.AreEqual(CardRank.Jack, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Pair_HappyPath()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Seven)
            };

            var commmunityCards = new List<Card>()
            {
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Ace)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, commmunityCards);

            Assert.AreEqual(HandRank.Pair, result.HandRank);
            Assert.AreEqual(CardRank.Five, result.WinningRank);
            Assert.AreEqual(CardRank.Ace, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_TwoPair_HappyPath()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Eight)
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Club, CardRank.King),
                new Card(CardSuit.Heart, CardRank.King),
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.TwoPair, result.HandRank);
            Assert.AreEqual(CardRank.King, result.WinningRank);
            Assert.AreEqual(CardRank.Eight, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_ThreeOfAKind_HappyPath()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five)
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Nine)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.ThreeOfAKind, result.HandRank);
            Assert.AreEqual(CardRank.Five, result.WinningRank);
            Assert.AreEqual(CardRank.Nine, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Straight_HappyPath()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Two),
                new Card(CardSuit.Club, CardRank.Four)
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Six),
                new Card(CardSuit.Diamond, CardRank.Seven),
                new Card(CardSuit.Heart, CardRank.Eight),
                new Card(CardSuit.Spade, CardRank.Ace)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.Straight, result.HandRank);
            Assert.AreEqual(CardRank.Eight, result.WinningRank);
            Assert.AreEqual(CardRank.Eight, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Straight_AceIsLow()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Ace),
                new Card(CardSuit.Club, CardRank.Two),
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Three),
                new Card(CardSuit.Club, CardRank.Four),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Eight)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.Straight, result.HandRank);
            Assert.AreEqual(CardRank.Five, result.WinningRank);
            Assert.AreEqual(CardRank.Five, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Straight_DuplicatedValue()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Three),
                new Card(CardSuit.Club, CardRank.Four)
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Six),
                new Card(CardSuit.Heart, CardRank.Seven)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.Straight, result.HandRank);
            Assert.AreEqual(CardRank.Seven, result.WinningRank);
            Assert.AreEqual(CardRank.Seven, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Straight_WhereItContinuesPastFiveCardsReturnsHighestFive()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Two),
                new Card(CardSuit.Club, CardRank.Three)
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Four),
                new Card(CardSuit.Diamond, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Six),
                new Card(CardSuit.Heart, CardRank.Seven),
                new Card(CardSuit.Spade, CardRank.Eight)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.Straight, result.HandRank);
            Assert.AreEqual(CardRank.Eight, result.WinningRank);
            Assert.AreEqual(CardRank.Eight, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Flush_HappyPath()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Three),
                new Card(CardSuit.Spade, CardRank.Five)
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Nine),
                new Card(CardSuit.Spade, CardRank.Jack),
                new Card(CardSuit.Spade, CardRank.Ace),
                new Card(CardSuit.Heart, CardRank.King)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.Flush, result.HandRank);
            Assert.AreEqual(CardRank.Ace, result.WinningRank);
            Assert.AreEqual(CardRank.Ace, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_Flush_OverFiveSuitedCards()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Three),
                new Card(CardSuit.Spade, CardRank.Five)
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Nine),
                new Card(CardSuit.Spade, CardRank.Jack),
                new Card(CardSuit.Spade, CardRank.Ace),
                new Card(CardSuit.Spade, CardRank.King)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.Flush, result.HandRank);
            Assert.AreEqual(CardRank.Ace, result.WinningRank);
            Assert.AreEqual(CardRank.Ace, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_FullHouse_HappyPath()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Four),
                new Card(CardSuit.Diamond, CardRank.Four)
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Diamond, CardRank.King),
                new Card(CardSuit.Heart, CardRank.King),
                new Card(CardSuit.Spade, CardRank.King),
                new Card(CardSuit.Spade, CardRank.Ace)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.FullHouse, result.HandRank);
            Assert.AreEqual(CardRank.King, result.WinningRank);
            Assert.AreEqual(CardRank.King, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_FourOfAKind_HappyPath()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Five),
                new Card(CardSuit.Diamond, CardRank.Five),
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardRank.Five),
                new Card(CardSuit.Spade, CardRank.Five),
                new Card(CardSuit.Spade, CardRank.Three)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.FourOfAKind, result.HandRank);
            Assert.AreEqual(CardRank.Five, result.WinningRank);
            Assert.AreEqual(CardRank.Three, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_StraightFlush_HappyPath()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardRank.Three),
                new Card(CardSuit.Heart, CardRank.Four)
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardRank.Five),
                new Card(CardSuit.Heart, CardRank.Six),
                new Card(CardSuit.Heart, CardRank.Seven)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.StraightFlush, result.HandRank);
            Assert.AreEqual(CardRank.Seven, result.WinningRank);
            Assert.AreEqual(CardRank.Seven, result.KickerRank);
        }

        [TestMethod]
        public void GetHandRank_RoyalFlush_HappyPath()
        {
            var handCards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Ten),
                new Card(CardSuit.Spade, CardRank.Jack),
            };

            var communityCards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Queen),
                new Card(CardSuit.Spade, CardRank.King),
                new Card(CardSuit.Spade, CardRank.Ace),
                new Card(CardSuit.Club, CardRank.Ace)
            };

            var classifier = new HandResultClassifier();

            var result = classifier.GetHandRankResult(handCards, communityCards);

            Assert.AreEqual(HandRank.RoyalFlush, result.HandRank);
            Assert.AreEqual(CardRank.Ace, result.WinningRank);
            Assert.AreEqual(CardRank.Ace, result.KickerRank);
        }
    }
}
