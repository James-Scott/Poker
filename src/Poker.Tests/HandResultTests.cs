using Poker.HandRankClassification;

namespace Poker.Tests
{
    [TestClass]
    public class HandResultTests
    {
        [TestMethod]
        public void HandResult_CompareTo_HigherRank()
        {
            var lowHand = new HandResult(HandRank.Pair, new Card(CardSuit.Club, CardRank.Two));
            var highHand = new HandResult(HandRank.ThreeOfAKind, new Card(CardSuit.Club, CardRank.Two));

            var result = lowHand.CompareTo(highHand);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_SameRank_HigherKicker()
        {
            var lowHand = new HandResult(HandRank.Pair, new Card(CardSuit.Club, CardRank.Two));
            var highHand = new HandResult(HandRank.Pair, new Card(CardSuit.Club, CardRank.Ace));

            var result = lowHand.CompareTo(highHand);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_Equal()
        {
            var lowHand = new HandResult(HandRank.Pair, new Card(CardSuit.Club, CardRank.Ten));
            var highHand = new HandResult(HandRank.Pair, new Card(CardSuit.Club, CardRank.Ten));

            var result = lowHand.CompareTo(highHand);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_LowerRank()
        {
            var lowHand = new HandResult(HandRank.Pair, new Card(CardSuit.Club, CardRank.Two));
            var highHand = new HandResult(HandRank.ThreeOfAKind, new Card(CardSuit.Club, CardRank.Two));

            var result = highHand.CompareTo(lowHand);

            Assert.AreEqual(1, result);
        }
    }
}
