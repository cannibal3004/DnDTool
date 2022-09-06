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

        public static int RollDie(Die die, int advantage = 0)
        {
            return rand.Next(1, (int)die+1) + advantage;
        }
    }
}