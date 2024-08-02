namespace Poker
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();

            for (int i = 0; i < 5; i++)
            {
                engine.Players.Add(new Player($"Player Number: {i + 1}", 1000));
            }

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Hand Number: {i + 1}");

                foreach (var player in engine.Players)
                {
                    engine.Bet(player, 10);
                }

                engine.Run();

                PrettyPrintOutput(engine);

                engine.Reset();
            }
        }

        private static void PrettyPrintOutput(Engine engine)
        {
            Console.WriteLine("FLOP:");

            foreach (var card in engine.Flop)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();

            Console.WriteLine("TURN:");
            foreach (var card in engine.Turn)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();

            Console.WriteLine("RIVER:");
            foreach (var card in engine.River)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();

            Console.WriteLine("WINNER:");

            foreach (var winningPlayer in engine.WinningPlayers)
            {
                Console.WriteLine(@$"Player: {winningPlayer.Name} 
                    won {engine.Pot / engine.WinningPlayers.Count} chips 
                    with a {winningPlayer.HandRankResult.HandRank} of {winningPlayer.HandRankResult.WinningRank} 
                    and a kicker {winningPlayer.HandRankResult.KickerRank}
                ");

                Console.WriteLine();

                Console.WriteLine("HAND CARDS:");
                foreach (var card in winningPlayer.HandCards)
                {
                    Console.WriteLine(card);
                }
            }
        }
    }
}