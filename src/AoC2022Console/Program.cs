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



using System;
using AoC2022.Day5;

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
var moves = Day5Parser.ParseMoves(inout);

foreach (var move in moves)
{
    state = state.ApplyMove(move);
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

for (var i = 0; i < 10; i++)
{
    // Console.Clear();
    Console.SetCursorPosition(0, 0);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(start);
    foreach (var consoleColor in fadeOutColors)
    {
        Console.ForegroundColor = consoleColor;
        //Console.SetCursorPosition(0, 0);
        //Console.WriteLine(start);

        Console.SetCursorPosition(1,1);
        Console.Write("[a]");

        Thread.Sleep(frame);
        // Console.Write("[a][b][c][d][e][f]");
    }

    foreach (var fadeInColor in fadeInColors)
    {
        Console.ForegroundColor = fadeInColor;
        Console.SetCursorPosition(9, 3);
        Console.Write("[a]");
        Thread.Sleep(frame);
    }



    Thread.Sleep(frame);
    Thread.Sleep(frame);


    foreach (var consoleColor in fadeOutColors)
    {
        Console.ForegroundColor = consoleColor;
        Console.SetCursorPosition(1, 2);
        Console.Write("[b]");
        Thread.Sleep(frame);
    }

    foreach (var fadeInColor in fadeInColors)
    {
        Console.ForegroundColor = fadeInColor;
        Console.SetCursorPosition(9, 2);
        Console.Write("[b]");
        Thread.Sleep(frame);
    }


    Thread.Sleep(frame);
    Thread.Sleep(frame);
}


Console.WriteLine(" ");

/*
var result = RockPaperScissors.CalculateScoreAndOutcome(data);

Console.WriteLine("result: " + result.Count);

Console.WriteLine("Score: " + result.Sum(x => x.Score));
*/