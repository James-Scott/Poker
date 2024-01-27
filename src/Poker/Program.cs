namespace Poker
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();

            for (int i = 0; i < 5; i++)
            {
                engine.Players.Add(new Player($"Player Number: {i + 1}", 100));
            }

            foreach (var player in engine.Players)
            {
                engine.Bet(player, 50);
            }

            engine.Run();

            PrettyPrintOutput(engine);
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
            Console.WriteLine(@$"Player: {engine.WinningPlayer.Name} 
                won {engine.Pot} chips 
                with a {engine.WinningPlayer.HandRankResult.HandRank} of {engine.WinningPlayer.HandRankResult.WinningRank} 
                and a kicker {engine.WinningPlayer.HandRankResult.KickerRank}
            ");

            Console.WriteLine();

            Console.WriteLine("HAND CARDS:");
            foreach (var card in engine.WinningPlayer.HandCards)
            {
                Console.WriteLine(card);
            }
        }
    }
}