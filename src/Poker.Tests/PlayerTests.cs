namespace Poker.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Player_CalculateHandRank_HappyPath()
        {
            var player = new Player("John Smith");

            player.Cards.Add(new Card(CardSuit.Club, CardRank.Three));
            player.Cards.Add(new Card(CardSuit.Diamond, CardRank.Five));
            player.Cards.Add(new Card(CardSuit.Diamond, CardRank.Jack));
            player.Cards.Add(new Card(CardSuit.Heart, CardRank.Jack));
            player.Cards.Add(new Card(CardSuit.Spade, CardRank.Two));

            player.CalculateHandRank();

            Assert.AreEqual(HandRank.Pair, player.HandRank);
        }
    }
}
