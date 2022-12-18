namespace AoC2022.Day5;

public class Day5Parser
{
    public static Day5StateFrame ParseInput(string input)
    {
        var stackLines = input.Split(Environment.NewLine + Environment.NewLine)
            .First()
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var stackCount = stackLines.Last().Length / 4 + 1;

        var stacks = Enumerable.Range(1, stackCount).Select(stackNum => new Stack
        {
            Number = stackNum,
            Crates = new string(stackLines
                    .SkipLast(1)
                    .Reverse()
                    .Select(x => x[(stackNum - 1) * 4 + 1]).ToArray())
                .Trim()
        });

        return new Day5StateFrame
        {
            FrameNumber = 1,
            Stacks = stacks.ToList()
        };
    }

    public static IEnumerable<string> ParseMoves(string input)
    {
        return input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Where(x => x.StartsWith("move"));
    }

    public static IEnumerable<string> SplitMultiMoves(string input)
    {
        var m = input.Split(" ");

        var quantity = int.Parse(m[1]);
        var sourceStack = int.Parse(m[3]);
        var targetStack = int.Parse(m[5]);

        return Enumerable.Range(1, quantity).Select(y => $"move 1 from {sourceStack} to {targetStack}");

    }
}