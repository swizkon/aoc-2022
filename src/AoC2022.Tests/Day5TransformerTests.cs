using AoC2022.Day5;
using FluentAssertions;

namespace AoC2022.Tests;

public class Day5TransformerTests
{
    [Fact]
    public void It_should_be_frame_one()
    {
        var s = Day5Parser.ParseInput(input);

        s.FrameNumber.Should().Be(1);
    }
    
    [Fact]
    public void It_should_have_correct_crates()
    {
        var s = Day5Parser.ParseInput(input);

        s.Stacks[3].Crates.Trim().Should().Be("FVNGRTQ");
        s.Stacks[8].Crates.Trim().Should().Be("PGS");

        s = s.ApplyMove("move 3 from 9 to 4");

        s.Stacks[8].Crates.Trim().Should().Be("");
        s.Stacks[3].Crates.Trim().Should().Be("FVNGRTQSGP");

        s = s.ApplyMove("move 2 from 5 to 2");

        s.Stacks[1].Crates.Trim().Should().Be("RSNJHFQ");
        s.Stacks[4].Crates.Trim().Should().Be("LT");

        s = s.ApplyMove("move 8 from 1 to 9");

        s.Stacks[0].Crates.Trim().Should().Be("");
        s.Stacks[8].Crates.Trim().Should().Be("NRJTZBDF");
    }



    string input = @"
[N]     [Q]         [N]            
[R]     [F] [Q]     [G] [M]        
[J]     [Z] [T]     [R] [H] [J]    
[T] [H] [G] [R]     [B] [N] [T]    
[Z] [J] [J] [G] [F] [Z] [S] [M]    
[B] [N] [N] [N] [Q] [W] [L] [Q] [S]
[D] [S] [R] [V] [T] [C] [C] [N] [G]
[F] [R] [C] [F] [L] [Q] [F] [D] [P]
 1   2   3   4   5   6   7   8   9 

move 3 from 9 to 4
move 2 from 5 to 2
move 8 from 1 to 9
move 4 from 7 to 1
move 5 from 3 to 8
move 3 from 3 to 7";




}