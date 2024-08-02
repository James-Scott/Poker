namespace Poker
{
    public class Engine
    {
        public Engine()
        {
            this.Deck = new Deck();
            this.Flop = new List<Card>(3);
            this.Turn = new List<Card>(1);
            this.River = new List<Card>(1);
            this.Players = new List<Player>();
            this.WinningPlayers = new List<Player>();
        }

        public Deck Deck { get; }

        public List<Card> Flop { get; private set; }

        public List<Card> Turn { get; private set; }

        public List<Card> River { get; private set; }

        public List<Player> Players { get; }

        public List<Player> WinningPlayers { get; private set; }

        public int Pot { get; private set; }

        public void Reset()
        {
            foreach (var player in this.Players)
            {
                player.HandCards.Clear();
                player.CommunityCards.Clear();
            }

            this.Deck.Reset();
            this.Flop.Clear();
            this.Turn.Clear();
            this.River.Clear();
            this.Pot = 0;
            this.WinningPlayers.Clear();
        }

        public void Run()
        {
            if (this.Players.Count == 0)
            {
                throw new InvalidOperationException("Cannot play a hand without any players");
            }

            this.Deck.Shuffle(5);

            this.DealHands();

            this.DealFlop();

            this.DealTurn();

            this.DealRiver();

            this.CalculateWinner();
        }

        public void Bet(Player player, int amount)
        {
            player.BetChips(amount);

            this.Pot += amount;
        }

        private void DealHands()
        {
            foreach (var player in this.Players)
            {
                var handCards = this.Deck.Deal(2);

                player.HandCards.AddRange(handCards);
            }
        }

        private void DealFlop()
        {
            this.Flop = this.Deck.Deal(3);

            foreach (var player in this.Players)
            {
                player.CommunityCards.AddRange(this.Flop);
            }
        }

        private void DealTurn()
        {
            this.Turn = this.Deck.Deal(1);

            foreach (var player in this.Players)
            {
                player.CommunityCards.AddRange(this.Turn);
            }
        }

        private void DealRiver()
        {
            this.River = this.Deck.Deal(1);

            foreach (var player in this.Players)
            {
                player.CommunityCards.AddRange(this.River);
            }
        }

        private void CalculateWinner()
        {
            foreach (var player in this.Players)
            {
                player.CalculateHandRank();
            }

            this.WinningPlayers = this.Players.OrderByDescending(x => x.HandRankResult).GroupBy(x => x.HandRankResult.ToString()).First().ToList();

            foreach (var winningPlayer in this.WinningPlayers)
            {
                winningPlayer.AddChips(this.Pot / this.WinningPlayers.Count);
            }
        }
    }
}
