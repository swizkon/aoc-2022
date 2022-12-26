using System.Drawing;
using System.Runtime.InteropServices;
using FluentAssertions;

namespace AoC2022.Tests;

public class Day8SolverTests
{

    [Fact]
    public void It_should_count_visible_trees()
    {
        var s = Day8Solver.CountVisibleTrees(input);

        s.Should().Be(21);
    }

    /*
    [Fact]
    public void It_should_calculate_scenic_score()
    {
        var s = Day8Solver.FindMaximumScenicScore(input);

        s.Should().Be(8);
    }
    */

    [Fact]
    public void It_should_blablabla()
    {
        var map = Day8Solver.ParseInput(input);

        var entry = new KeyValuePair<Point, int>(new Point(2, 1), 5);
        var scenicScore = Day8Solver.GetScenicScore(entry, map);

        scenicScore.Should().Be(4);
    }

    [Fact]
    public void It_should_blablablasdfsdsd()
    {
        var map = Day8Solver.ParseInput(input);

        var entry = new KeyValuePair<Point, int>(new Point(2, 3), 5);
        var scenicScore = Day8Solver.GetScenicScore(entry, map);

        scenicScore.Should().Be(8);
    }

    private string input 
        = 
@"30373
25512
65332
33549
35390";


}