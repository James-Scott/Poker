namespace Poker
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();

            for (int i = 0; i < 5; i++)
            {
                engine.Players.Add(new Player($"Player Number: {i + 1}"));
            }

            engine.Run();

            Console.WriteLine($"Player: {engine.WinningPlayer.Name} won with a {engine.WinningPlayer.HandRank} of {GetCardNames(engine.WinningPlayer.Cards)}");
        }

        public static string GetCardNames(List<Card> cards)
        {
            return string.Join(", ", cards.OrderBy(x => x.Rank).ThenBy(x => x.Suit).Select(x => x.ToString()));
        }
    }
}