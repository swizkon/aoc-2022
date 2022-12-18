// See https://aka.ms/new-console-template for more information

/*
 * Day 01
Console.WriteLine("Hello, World!");

var input = InputReader.GetInputRaw(Environment.CurrentDirectory, folderName: "aoc-2022-data", fileName: "input-day01.txt");

var bagsByCaloriesCount = input
    .Split(Environment.NewLine + Environment.NewLine)
    .Select(x => x.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse))
    .Select((v, i) => new { pos = i + 1, calories = v.Sum()})
    .OrderByDescending(x => x.calories);

var top1 = bagsByCaloriesCount.First().calories;
var top3 = bagsByCaloriesCount.Take(3).Sum(x => x.calories);

//foreach (var chunk in bagsByCaloriesCount)
//{
//    Console.WriteLine(chunk.pos);
//    Console.WriteLine(chunk.calories);
//}

Console.WriteLine("Sum: " + top1);
Console.WriteLine("top3: " + top3);
 * */




/*
 * Day 2
 */

//var input = InputReader.GetInput(Environment.CurrentDirectory, folderName: "aoc-2022-data", fileName: "input-day02.txt");

//var data = RockPaperScissors.ParseInputWithOutcomeStrategy(input);
//// Console.WriteLine("data: " + data.Count);

//var result = RockPaperScissors.CalculateScoreAndOutcome(data);

// Console.WriteLine("result: " + result.Count);


// Console.WriteLine("Score: " + result.Sum(x => x.Score));


using AoC2022;
using AoC2022.Day5;

var day8 = File.ReadAllText("Day08.txt");

/*
day8 = @"30373
25512
65332
33549
35390";
*/

var day8Result = Day8Solver.CountVisibleTrees(day8);
Console.WriteLine($"Day 8: {day8Result}");

Environment.Exit(0);

var day7 = File.ReadAllText("Day07.txt");
var day7Result = Day7Solver.CalculateSize(day7);
Console.WriteLine( day7Result);

Environment.Exit(0);
/*
*/
    
Console.Clear();

var fadeOutColors = new[]
{
    ConsoleColor.White,
    ConsoleColor.Gray,
    ConsoleColor.DarkGray,
    ConsoleColor.Black,
    ConsoleColor.Black,
    ConsoleColor.Black
};

var fadeInColors = new[]
{
    ConsoleColor.Black,
    ConsoleColor.DarkGray,
    ConsoleColor.Gray,
    ConsoleColor.White
};

//var start = @"
// [a] [b] [c] [d] [e] [f] 
// [a] [b] [c] [d] [e] [f] 
// [a] [b] [c] [d] [e] [f] 
//  1   2   3   4   5   6 ";

var inout = File.ReadAllText("Day05.txt");

var state = Day5Parser.ParseInput(inout);

Day5Animator.DrawFrame(state, 40);

var moves = Day5Parser.ParseMoves(inout);

// var maxCrates = 40;
foreach (var move in moves)
{
    Console.SetCursorPosition(1, 1);
    Console.Write(move);
    var submoves = Day5Parser.SplitMultiMoves(move);

    foreach (var m in submoves)
        state = state.ApplyMove(m);

    // maxCrates = Math.Max(maxCrates, state.Stacks.Max(x => x.Crates.Length));
}


var res = new string(state.Stacks.OrderBy(x => x.Number).Select(y => y.Crates.Last()).ToArray());


Console.WriteLine(res);

var frame = 100;

var s = new Dictionary<string, List<string>>
{
    ["1"] = "a,b,c".Split(',').ToList()
};

var start = @"
 [a]                                                                   
 [b]                                                                   
 [c]                                                                   
  1   2   3";


//Console.CursorSize = 1;
Console.CursorVisible = false;


/*
var result = RockPaperScissors.CalculateScoreAndOutcome(data);

Console.WriteLine("result: " + result.Count);

Console.WriteLine("Score: " + result.Sum(x => x.Score));
*/