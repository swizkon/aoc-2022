using AoC2022.Day5;
using FluentAssertions;

namespace AoC2022.Tests;

public class Day6SolverTests
{
    [Fact]
    public void It_should_be_frame_one()
    {
        var s = Day6Solver.TuningTrouble("mjqjpqmgbljsphdztnvjfqwrcgsmlb");

        s.Should().Be(7);
    }

    [Fact]
    public void It_should_be_frame_dddd()
    {
        var s = Day6Solver.TuningTrouble("bvwbjplbgvbhsrlpgdmjqwftvncz");

        s.Should().Be(5);
    }

    //mjqjpqmgbljsphdztnvjfqwrcgsmlb 7
    //bvwbjplbgvbhsrlpgdmjqwftvncz: first marker after character 5
    //nppdvjthqldpwncqszvftbrmjlhg: first marker after character 6
    //nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg: first marker after character 10
    //zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw: first marker after character 11



}