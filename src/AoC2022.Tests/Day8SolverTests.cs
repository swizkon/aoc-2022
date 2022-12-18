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
    
    private string input = @"30373
25512
65332
33549
35390";


}