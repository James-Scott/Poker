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
            this.BlindPlayers = new List<Player>();
            this.Pot = 0;
            this.CurrentState = GameState.Start;
        }

        public Deck Deck { get; }

        public List<Card> Flop { get; private set; }

        public List<Card> Turn { get; private set; }

        public List<Card> River { get; private set; }

        public List<Player> Players { get; }

        public List<Player> WinningPlayers { get; private set; }

        public List<Player> BlindPlayers { get; private set; }

        public int Pot { get; private set; }

        public int LittleBlind { get; private set; }

        public int BigBlind { get; private set; }

        public GameState CurrentState { get; private set; }

        public void ResetHand()
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
            this.CurrentState = GameState.Start;
        }

        public void RunHand()
        {
            if (this.Players.Count < 2)
            {
                throw new InvalidOperationException("Cannot play a hand without at least 2 players");
            }

            this.Deck.Shuffle(5);

            this.PreHandSetup();

            this.DealHands();

            this.DealFlop();

            this.DealTurn();

            this.DealRiver();

            this.CalculateWinner();

            this.PostRoundCleanup();
        }

        public void Bet(Player player, int amount)
        {
            player.BetChips(amount);

            this.Pot += amount;
        }

        public void SetBlinds(int littleBlind, int bigBlind)
        {
            if (littleBlind <= 0)
            {
                throw new ArgumentException(nameof(littleBlind));
            }

            if (bigBlind <= 0)
            {
                throw new ArgumentException(nameof(bigBlind));
            }

            this.LittleBlind = littleBlind;
            this.BigBlind = bigBlind;
        }

        private void PreHandSetup()
        {
            this.CurrentState = GameState.PreHand;

            Player littleBlindPlayer;
            Player bigBlindPlayer;

            if (!this.BlindPlayers.Any())
            {
                littleBlindPlayer = this.Players[this.Players.Count - 1];
                bigBlindPlayer = this.Players[this.Players.Count - 2];
            }
            else
            {
                bigBlindPlayer = this.Players.First(x => x.CurrentBlind == Blind.Little);
                var bigBlindIndex = this.Players.IndexOf(bigBlindPlayer);
                littleBlindPlayer = this.Players[(bigBlindIndex + 1) % this.Players.Count];
            }

            littleBlindPlayer.CurrentBlind = Blind.Little;
            bigBlindPlayer.CurrentBlind = Blind.Big;

            this.BlindPlayers.Clear();
            this.BlindPlayers.Add(littleBlindPlayer);
            this.BlindPlayers.Add(bigBlindPlayer);

            this.Bet(littleBlindPlayer, this.LittleBlind);
            this.Bet(bigBlindPlayer, this.BigBlind);
        }

        private void DealHands()
        {
            this.CurrentState = GameState.Deal;

            foreach (var player in this.Players)
            {
                var handCards = this.Deck.Deal(2);

                player.HandCards.AddRange(handCards);
            }
        }

        private void DealFlop()
        {
            this.CurrentState = GameState.Flop;

            this.Flop = this.Deck.Deal(3);

            foreach (var player in this.Players)
            {
                player.CommunityCards.AddRange(this.Flop);
            }
        }

        private void DealTurn()
        {
            this.CurrentState = GameState.Turn;

            this.Turn = this.Deck.Deal(1);

            foreach (var player in this.Players)
            {
                player.CommunityCards.AddRange(this.Turn);
            }
        }

        private void DealRiver()
        {
            this.CurrentState = GameState.River;

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

        private void PostRoundCleanup()
        {
            foreach (var player in this.Players)
            {
                if (player.Chips == 0)
                {
                    this.Players.Remove(player);
                }
            }

            if (this.Players.Count < 2)
            {
                this.CurrentState = GameState.End;
            }
        }
    }
}
