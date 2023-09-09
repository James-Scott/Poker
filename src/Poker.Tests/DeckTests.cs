namespace Poker.Tests
{
    [TestClass]
    public class DeckTests
    {
        private const int TotalCardsInFullDeck = 52;

        [TestMethod]
        public void Deck_HappyPath()
        {
            var deck = new Deck();

            Assert.AreEqual(TotalCardsInFullDeck, deck.Cards.Count);
        }

        [TestMethod]
        public void Deck_Reset_HappyPath()
        {
            var deck = new Deck();

            deck.Reset();

            Assert.AreEqual(TotalCardsInFullDeck, deck.Cards.Count);
        }

        [TestMethod]
        public void Deck_Shuffle_HappyPath()
        {
            var deck = new Deck();

            var originalCards = deck.Cards.ToList();

            deck.Shuffle(5);

            var shuffledCards = deck.Cards.ToList();

            bool hasBeenShuffled = false;

            for (int i = 0; i < TotalCardsInFullDeck; i++)
            {
                var original = originalCards[i];
                var shuffled = shuffledCards[i];

                if (original.Suit != shuffled.Suit || original.Rank != shuffled.Rank)
                {
                    hasBeenShuffled = true;
                    break;
                }
            }

            Assert.IsTrue(hasBeenShuffled);
        }

        [DataRow(5, TotalCardsInFullDeck - 5)]
        [DataRow(11, TotalCardsInFullDeck - 11)]
        [DataRow(27, TotalCardsInFullDeck - 27)]
        [DataTestMethod]
        public void Deck_Deal_HappyPath(int cardsToDeal, int remainingCardsInDeck)
        {
            var deck = new Deck();

            var cards = deck.Deal(cardsToDeal);

            Assert.AreEqual(cardsToDeal, cards.Count);
            Assert.AreEqual(remainingCardsInDeck, deck.Cards.Count);
        }
    }
}