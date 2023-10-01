namespace Poker.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Player_CalculateHandRank_HappyPath()
        {
            var player = new Player("John Smith", 0);

            player.Cards.Add(new Card(CardSuit.Club, CardRank.Three));
            player.Cards.Add(new Card(CardSuit.Diamond, CardRank.Five));
            player.Cards.Add(new Card(CardSuit.Diamond, CardRank.Jack));
            player.Cards.Add(new Card(CardSuit.Heart, CardRank.Jack));
            player.Cards.Add(new Card(CardSuit.Spade, CardRank.Two));

            player.CalculateHandRank();

            Assert.AreEqual(HandRank.Pair, player.HandRankResult.HandRank);
            Assert.AreEqual(CardRank.Five, player.HandRankResult.Kicker.Rank);
        }

        [TestMethod]
        public void Player_BetChips_HappyPath()
        {
            var player = new Player(Guid.NewGuid().ToString(), 10);

            player.BetChips(7);

            Assert.AreEqual(player.Chips, 3);
        }

        [TestMethod]
        public void Player_BetChips_AmountMustBePositive()
        {
            var player = new Player(Guid.NewGuid().ToString(), 10);

            Assert.ThrowsException<ArgumentException>(() => player.BetChips(-5));
        }

        [TestMethod]
        public void Player_BetChips_CannotBetHigherThanChipAmount()
        {
            var player = new Player(Guid.NewGuid().ToString(), 10);

            Assert.ThrowsException<InvalidOperationException>(() => player.BetChips(20));
        }

        [TestMethod]
        public void Player_AddChips_HappyPath()
        {
            var player = new Player(Guid.NewGuid().ToString(), 10);

            player.AddChips(5);

            Assert.AreEqual(player.Chips, 15d);
        }
    }
}
