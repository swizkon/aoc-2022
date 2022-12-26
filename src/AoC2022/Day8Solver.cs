using System.Drawing;
using System.Net;

namespace AoC2022;

public class Day8Solver
{
    public class TreeItem
    {
        public Point Position { get; set; }
        public bool Visible { get; set; }
        public int Height { get; set; }

        public int ScenicScore { get; set; }
    }
    
    public static int CountVisibleTrees(string input)
    {
        var data = ParseTreeMap(input);

        return data.Count(t => t.Visible);
    }


    public static int FindMaximumScenicScore(string input)
    {
        var data = ParseTreeMap(input);

        return data.Max(t => t.ScenicScore);
    }

    public static IDictionary<Point, int> ParseInput(string input)
    {
        IDictionary<Point, int> map = new Dictionary<Point, int>();

        int x = 0, y = 0;
        foreach (var c in input.Replace("\r\n", "^"))
        {
            if (!char.IsDigit(c))
            {
                y += 1;
                x = 0;
                continue;
            }

            map[new Point(x: x, y: y)] = int.Parse(c.ToString());
            x += 1;
        }

        return map;
    }

    private static IEnumerable<TreeItem> ParseTreeMap(string input)
    {
        var map = ParseInput(input);
        foreach (var entry in map)
        {
            var item = new TreeItem
            {
                Height = entry.Value,
                Position = entry.Key,
                Visible = IsVisible(entry, map),
                ScenicScore = GetScenicScore(entry, map)
            };

            yield return item;
        }
    }

    public static int GetScenicScore(KeyValuePair<Point, int> entry, IDictionary<Point, int> map)
    {
        var position = entry.Key;

        if (IsEdgeTree(map, position))
            return 0;
        
        int up = 0, down = 0, left = 0, right = 0;
        
        var checkPoint = position with{X = position.X + 1};
        while (map.ContainsKey(checkPoint) && map[checkPoint] < entry.Value)
        {
            right++;
            checkPoint = checkPoint with { X = checkPoint.X + 1 };
        }
        if (map.ContainsKey(checkPoint) && checkPoint != position && map[checkPoint] >= entry.Value)
        {
            right++;
        }

        checkPoint = position  with { X = position.X - 1 };
        while (map.ContainsKey(checkPoint) && map[checkPoint] < entry.Value)
        {
            left++;
            checkPoint = checkPoint with { X = checkPoint.X - 1 };
        }
        if (map.ContainsKey(checkPoint) && checkPoint != position && map[checkPoint] >= entry.Value)
        {
            left++;
        }

        checkPoint = position with { Y = position.Y - 1 };
        while (map.ContainsKey(checkPoint) && map[checkPoint] < entry.Value)
        {
            up++;
            checkPoint = checkPoint with { Y = checkPoint.Y - 1 };
        }
        if (map.ContainsKey(checkPoint) && checkPoint != position && map[checkPoint] >= entry.Value)
        {
            up++;
        }

        checkPoint = position with { Y = position.Y + 1 };
        while (map.ContainsKey(checkPoint) && map[checkPoint] < entry.Value)
        {
            down++;
            checkPoint = checkPoint with { Y = checkPoint.Y + 1 };
        }
        if (map.ContainsKey(checkPoint) && checkPoint != position && map[checkPoint] >= entry.Value)
        {
            down++;
        }

        var result = up * down * left * right;

        return result;
    }

    private static bool IsVisible(KeyValuePair<Point, int> entry, IDictionary<Point, int> map)
    {
        var position = entry.Key;
        
        // Edges
        if (IsEdgeTree(map, position))
            return true;

        // Check if all lefties are shorter....

        var rightLower = map.Where(kv => kv.Key.X == position.X && kv.Key.Y > position.Y)
            .All(x => x.Value < entry.Value);
        if (rightLower)
            return true;

        var bottomLower = map.Where(kv => kv.Key.Y == position.Y && kv.Key.X > position.X)
            .All(x => x.Value < entry.Value);
        if (bottomLower)
            return true;

        var leftLower = map.Where(kv => kv.Key.X == position.X && kv.Key.Y < position.Y)
            .All(x => x.Value < entry.Value);
        if (leftLower)
            return true;

        var topLower = map.Where(kv => kv.Key.Y == position.Y && kv.Key.X < position.X)
            .All(x => x.Value < entry.Value);
        if (topLower)
            return true;


        return false;
    }

    private static bool IsEdgeTree(IDictionary<Point, int> map, Point position)
    {
        return position.X == 0 || position.Y == 0 ||
               !map.ContainsKey(position with { Y = position.Y + 1 }) ||
               !map.ContainsKey(position with { X = position.X + 1 });
    }
}