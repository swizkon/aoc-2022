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


            // Day5Animator.AnimateMove(this, moveFromTo);


            Stacks[targetStack].Crates = targetValue + new string(Stacks[sourceStack].Crates.TakeLast(quantity).Reverse().ToArray());
            
            Stacks[sourceStack].Crates = new string(sourceValue.SkipLast(quantity).ToArray());

            return this;
        }
    }



    public static class Day5Animator
    {
        private static int frame = 1;

        private static List<ConsoleColor> fadeOutColors = new()
        {
            ConsoleColor.White,
            ConsoleColor.Gray,
            ConsoleColor.DarkGray,
            ConsoleColor.Black,
            ConsoleColor.Black,
            ConsoleColor.Black
        };

        private static List<ConsoleColor> fadeInColors = new()
        {
            ConsoleColor.Black,
            ConsoleColor.DarkGray,
            ConsoleColor.Gray,
            ConsoleColor.White
        };

        public static void DrawFrame(Day5StateFrame state, int maxCrates)
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetWindowSize(120, maxCrates + 1);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;

            for (var i = 0; i < state.Stacks.Count; i++)
            {
                var stack = state.Stacks[i];

                var crates = stack.Crates;

                for (var j = 0; j < crates.Length; j++)
                {
                    Console.SetCursorPosition(i * 4, maxCrates - j - 1);
                    Console.Write($" [{crates[j]}]");
                }

                Console.SetCursorPosition(i * 4, maxCrates);
                Console.Write($"  {stack.Number}");
            }
        }

        public static void AnimateMove(Day5StateFrame state, string move)
        {
            Console.CursorVisible = false;


            var m = move.Split(" ");

            var sourceStack = int.Parse(m[3]) - 1;
            var sourceValue = state.Stacks[sourceStack].Crates;

            foreach (var consoleColor in fadeOutColors)
            {
                Console.ForegroundColor = consoleColor;
                Console.SetCursorPosition(sourceStack * 4 + 1, 40 - sourceValue.Length);
                Console.Write($"[{sourceValue[^1..]}]");
                Thread.Sleep(frame);
            }

            var targetStack = int.Parse(m[5]) - 1;
            var targetValue = state.Stacks[targetStack].Crates;

            foreach (var consoleColor in fadeInColors)
            {
                Console.ForegroundColor = consoleColor;
                Console.SetCursorPosition(targetStack * 4 + 1, 40 - targetValue.Length - 1);
                Console.Write($"[{sourceValue[^1..]}]");

                Thread.Sleep(frame);
            }
        }
    }
}