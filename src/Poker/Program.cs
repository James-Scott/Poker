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
            Console.WriteLine(@$"Player: {engine.WinningPlayer.Name} won {engine.Pot} chips with a {engine.WinningPlayer.HandRankResult.HandRank} of
                {GetCardNames(engine.WinningPlayer.Cards)}
                and a kicker {engine.WinningPlayer.HandRankResult.Kicker}
            ");
        }

        private static string GetCardNames(List<Card> cards)
        {
            return string.Join(", ", cards.OrderBy(x => x.Rank).ThenBy(x => x.Suit).Select(x => x.ToString()));
        }
    }
}