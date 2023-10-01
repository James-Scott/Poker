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
            Console.WriteLine(@$"Player: {engine.WinningPlayer.Name} won {engine.Pot} chips with a {engine.WinningPlayer.HandRankResult.HandRank} of\n
                {GetCardNames(engine.WinningPlayer.Cards)}\n
                and a kicker {engine.WinningPlayer.HandRankResult.Kicker}
            ");
        }

        private static string GetCardNames(List<Card> cards)
        {
            return string.Join(", ", cards.OrderBy(x => x.Rank).ThenBy(x => x.Suit).Select(x => x.ToString()));
        }
    }
}