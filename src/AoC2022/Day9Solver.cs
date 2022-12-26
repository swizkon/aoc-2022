using System.Drawing;
using System.Runtime.CompilerServices;

namespace AoC2022;

public class Day9Solver
{
    private static readonly IDictionary<char, Func<Point, Point>> Moves = new Dictionary<char, Func<Point, Point>>()
    {
        {'U', point => point with{Y = point.Y - 1}},
        {'D', point => point with{Y = point.Y + 1}},
        {'L', point => point with{X = point.X - 1}},
        {'R', point => point with{X = point.X + 1}}
    };

    public static int CountVisitedPositions(string input)
    {
        var data = ParseInput(input);

        var head = new Point(0, 0);
        var tail = new Point(0, 0);

        var tailPositions = new List<Point>
        {
            tail
        };

        foreach (var m in data)
        {
            head = Moves[m](head);
            tail = CalculateTailPosition(head, tail);
            tailPositions.Add(tail);
        }

        return tailPositions.Distinct().Count();
    }

    public static Point CalculateTailPosition(Point head, Point tail)
    {
        var xd = Math.Abs(head.X - tail.X);
        var yd = Math.Abs(head.Y - tail.Y);

        if (xd < 2 && yd < 2)
            return tail;

        int x = 0, y = 0;

        if (xd > yd)
        {
            y = head.Y;
            x = tail.X + ((head.X < tail.X) ? -1 : 1);
        }
        if (xd < yd)
        {
            x = head.X;
            y = tail.Y + ((head.Y < tail.Y) ? -1 : 1);
        }

        return tail with{ X = x, Y = y};
    }

    public static IEnumerable<char> ParseInput(string input) =>
        input.Split(Environment.NewLine)
            .SelectMany(x => Enumerable.Repeat(x[0], int.Parse(x[2..])));
}