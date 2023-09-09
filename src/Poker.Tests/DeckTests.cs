namespace Poker.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Deck_HappyPath()
        {
            var deck = new Deck();

            Assert.AreEqual(52, deck.Cards.Count);
        }
    }
}