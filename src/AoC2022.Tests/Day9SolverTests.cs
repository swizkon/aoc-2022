using System.Drawing;
using FluentAssertions;

namespace AoC2022.Tests;

public class Day9SolverTests
{
    [Fact]
    public void It_should_count_visible_trees()
    {
        var s = Day9Solver.ParseInput(input);

        s.Should().StartWith("RRRRUUUULLLDRRRR");
    }

    [Fact]
    public void It_return_tail_for_none_stretchy_moves()
    {
        var head = new Point(-2, -1);
        var tail = new Point(-1, -2);
        var calculateTailPosition = Day9Solver.CalculateTailPosition(head, tail);

        calculateTailPosition.Should().Be(tail);
    }

    [Fact]
    public void It_return_tail_for_up()
    {
        var head = new Point(0, -2);
        var tail = new Point(0, 0);

        var calculateTailPosition = Day9Solver.CalculateTailPosition(head, tail);

        calculateTailPosition.Should().Be(tail with { Y = tail.Y - 1 });
    }

    [Fact]
    public void It_return_tail_for_down()
    {
        var head = new Point(0, 2);
        var tail = new Point(0, 0);

        var calculateTailPosition = Day9Solver.CalculateTailPosition(head, tail);

        calculateTailPosition.Should().Be(tail with { Y = tail.Y + 1 });
    }

    [Fact]
    public void It_should_count_visited_positions()
    {
        var visitedPositions = Day9Solver.CountVisitedPositions(input);

        visitedPositions.Should().Be(13);
    }
    /*
    */

    private string input
        =
        @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";
}