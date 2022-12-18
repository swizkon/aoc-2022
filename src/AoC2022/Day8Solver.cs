using System.Drawing;

namespace AoC2022;

public class Day8Solver
{
    public class TreeItem
    {
        public Point Position { get; set; }
        public bool Visible { get; set; }
        public int Height { get; set; }
    }
    
    public static int CountVisibleTrees(string input)
    {
        var data = ParseTreeMap(input);

        return data.Count(t => t.Visible);
    }

    private static IEnumerable<TreeItem> ParseTreeMap(string input)
    {
        var lines = input.Split(Environment.NewLine);
        
        var width = lines.First().Length;
        var height = lines.Length;
        
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

        foreach (var entry in map)
        {
            var item = new TreeItem
            {
                Height = entry.Value,
                Position = entry.Key,
                Visible = IsVisible(entry, map)
            };

            yield return item;
        }
    }

    private static bool IsVisible(KeyValuePair<Point, int> entry, IDictionary<Point, int> map)
    {
        var position = entry.Key;

        //// Edge
        //if (position.X == 0 || position.Y == 0)
        //    return true;
        
        // right / bottom Edge
        if (position.X == 0 || position.Y == 0 ||
            !map.ContainsKey(new Point(x: position.X, y: position.Y + 1)) ||
            !map.ContainsKey(new Point(x: position.X + 1, y: position.Y)))
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
}