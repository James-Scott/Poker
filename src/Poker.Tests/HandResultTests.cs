using Poker.HandRankClassification;

namespace Poker.Tests
{
    [TestClass]
    public class HandResultTests
    {
        [TestMethod]
        public void HandResult_CompareTo_HigherHandRank()
        {
            var lowHand = new HandResult(HandRank.Pair, CardRank.Two, CardRank.Two);
            var highHand = new HandResult(HandRank.ThreeOfAKind, CardRank.Two, CardRank.Two);

            var result = lowHand.CompareTo(highHand);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_SameHandRank_HigherWinningRank()
        {
            var lowHand = new HandResult(HandRank.Pair, CardRank.Queen, CardRank.Two);
            var highHand = new HandResult(HandRank.Pair, CardRank.King, CardRank.Two);

            var result = lowHand.CompareTo(highHand);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_SameHandRank_SameWinningRank_HigherKickerRank()
        {
            var lowHand = new HandResult(HandRank.Pair, CardRank.King, CardRank.Two);
            var highHand = new HandResult(HandRank.Pair, CardRank.King, CardRank.Ace);

            var result = lowHand.CompareTo(highHand);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_Equal()
        {
            var lowHand = new HandResult(HandRank.Pair, CardRank.Ten, CardRank.Four);
            var highHand = new HandResult(HandRank.Pair, CardRank.Ten, CardRank.Four);

            var result = lowHand.CompareTo(highHand);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_LowerHandRank()
        {
            var lowHand = new HandResult(HandRank.Pair, CardRank.Two, CardRank.Two);
            var highHand = new HandResult(HandRank.ThreeOfAKind, CardRank.Two, CardRank.Two);

            var result = highHand.CompareTo(lowHand);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_SameHandRank_LowerWinningRank()
        {
            var lowHand = new HandResult(HandRank.Pair, CardRank.Queen, CardRank.Two);
            var highHand = new HandResult(HandRank.Pair, CardRank.King, CardRank.Two);

            var result = highHand.CompareTo(lowHand);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_SameHandRank_SameWinningRank_LowerKickerRank()
        {
            var lowHand = new HandResult(HandRank.Pair, CardRank.King, CardRank.Two);
            var highHand = new HandResult(HandRank.Pair, CardRank.King, CardRank.Ace);

            var result = highHand.CompareTo(lowHand);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_Null()
        {
            var hand = new HandResult(HandRank.Pair, CardRank.Two, CardRank.Two);

            var result = hand.CompareTo(null);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void HandResult_CompareTo_Object()
        {
            var hand = new HandResult(HandRank.Pair, CardRank.Two, CardRank.Two);

            var result = hand.CompareTo(new object());

            Assert.AreEqual(1, result);
        }
    }
}
