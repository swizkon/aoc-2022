namespace AoC2022.Day5
{
    public class Day5StateFrame
    {
        public int FrameNumber { get; set; }
        public List<Stack> Stacks { get; set; }

        public Day5StateFrame ApplyMove(string moveFromTo)
        {
            var m = moveFromTo.Split(" ");

            var quantity = int.Parse(m[1]);
            var sourceStack = int.Parse(m[3]) - 1;
            var targetStack = int.Parse(m[5]) - 1;


            var sourceValue = Stacks[sourceStack].Crates;
            var targetValue = Stacks[targetStack].Crates;

            // var newVal = targetValue + new string(Stacks[sourceStack].Crates.TakeLast(quantity).Reverse().ToArray());
            var newVal = targetValue + new string(Stacks[sourceStack].Crates.TakeLast(quantity).ToArray());

            Stacks[targetStack].Crates = newVal;


            Stacks[sourceStack].Crates = new string(sourceValue.SkipLast(quantity).ToArray());

            return this;
        }
    }
}