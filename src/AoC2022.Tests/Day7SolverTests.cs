using FluentAssertions;

namespace AoC2022.Tests;

public class Day7SolverTests
{

    [Fact]
    public void It_should_calculate_folder_sizes()
    {
        var s = Day7Solver.CalculateFolderSizes(input);

        s.First().TotalSize.Should().Be(48381165);
    }

    [Fact]
    public void It_should_calculate_folder_size_for_a()
    {
        var s = Day7Solver.CalculateFolderSizes(input);

        s.ElementAt(3).TotalSize.Should().Be(24933642);
    }

    [Fact]
    public void It_should_calculate()
    {
        var s = Day7Solver.CalculateSize(input);

        s.Should().Be(95437);
    }
    
    
    private string input = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";


}