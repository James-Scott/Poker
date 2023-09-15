namespace Poker.Tests
{
    using Poker.HandRankClassification;

    [TestClass]
    public class KickerClassifierTests
    {
        [TestMethod]
        public void GetKicker_Pair_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Three),
                new Card(CardSuit.Club, CardRank.Six),
                new Card(CardSuit.Diamond, CardRank.Six),
                new Card(CardSuit.Diamond, CardRank.Jack),
                new Card(CardSuit.Spade, CardRank.King)
            };

            var classifier = new KickerClassifier();

            Assert.AreEqual(CardRank.King, classifier.GetKicker(HandRank.Pair, cards).Rank);
        }

        [TestMethod]
        public void GetKicker_TwoPair_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Three),
                new Card(CardSuit.Spade, CardRank.Three),
                new Card(CardSuit.Club, CardRank.Six),
                new Card(CardSuit.Diamond, CardRank.Six),
                new Card(CardSuit.Diamond, CardRank.Jack),
            };

            var classifier = new KickerClassifier();

            Assert.AreEqual(CardRank.Jack, classifier.GetKicker(HandRank.Pair, cards).Rank);
        }

        [TestMethod]
        public void GetKicker_ThreeOfAKind_HappyPath()
        {
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardRank.Three),
                new Card(CardSuit.Club, CardRank.Six),
                new Card(CardSuit.Diamond, CardRank.Six),
                new Card(CardSuit.Spade, CardRank.Six),
                new Card(CardSuit.Spade, CardRank.King)
            };

            var classifier = new KickerClassifier();

            Assert.AreEqual(CardRank.King, classifier.GetKicker(HandRank.ThreeOfAKind, cards).Rank);
        }
    }
}
