namespace Poker
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var deck = new Deck();
            deck.Shuffle(5);

            foreach (var card in deck.Cards)
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine($"Total Cards: {deck.Cards.Count}");
        }
    }
}