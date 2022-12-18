namespace AoC2022
{
    public class Day6Solver
    {
        public static int TuningTrouble(string input, int packetSize = 4)
        {
            for (var i = packetSize; i < input.Length - packetSize; i++)
            {
                var str = input.Substring(i - packetSize, packetSize);

                if (str.ToCharArray().Distinct().Count() == packetSize)
                    return i;
            }


            return input.Length;
        }
    }
}