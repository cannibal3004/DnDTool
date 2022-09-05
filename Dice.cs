namespace DnDTool
{
    internal static class Dice
    {
        public enum Die
        {
            D4 = 4,
            D6 = 6,
            D8 = 8,
            D10 = 10,
            D12 = 12,
            D20 = 20,
            D100 = 100
        }
        private static Random rand = new Random();

        public static void RollDice(Die die)
        {
            Console.Clear();
            Console.WriteLine("Roll how many dice?");
            string? input = Console.ReadLine();
            if (input != null)
            {
                Console.Clear();
                Console.WriteLine("Enter advantage: (blank for none)");
                string? advantageStr = Console.ReadLine();
                int.TryParse(advantageStr, out int advantage);
                Console.Clear();
                int qty;
                if (int.TryParse(input, out qty))
                {
                    for (int i = 0; i < qty; i++)
                    {
                        Console.Write("D" + (int)die + " " + (i + 1) + " : ");
                        Console.WriteLine(RollDie(die, advantage));
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static int RollDie(Die die, int advantage = 0)
        {
            return rand.Next(1, (int)die) + advantage;
        }
    }
}