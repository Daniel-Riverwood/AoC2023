﻿namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly List<string> _input;
    private readonly Dictionary<string, string> numbers = new Dictionary<string, string>() 
    { { "zero", "ze0o" }, { "one", "o1e" }, { "two", "t2o" }, { "three", "th3ee" }, { "four", "fo4r" }, { "five", "fi5e" }, { "six", "s6x" }, { "seven", "se7en" }, { "eight", "ei8ht" }, { "nine", "ni9e" } };
    
    public Day01()
    {
        _input = File.ReadAllText(InputFilePath).Split("\n").ToList();
    }

    private string ProcessInput1 (string line)
    {
        var convertedList = line.ToCharArray().Where(x => char.IsDigit(x)).Select(y => y - '0').ToList();
        return $"{convertedList.First()}{convertedList.Last()}";
    }

    private string ProcessInput2 (string line)
    {
        foreach (var number in numbers) line = line.Replace(number.Key, number.Value);
        var converted = line.ToCharArray().Where(x => char.IsDigit(x)).Select(y => y - '0').ToList();
        return $"{converted.First()}{converted.Last()}";
    }

    public override ValueTask<string> Solve_1() => new($"{_input.Select(x => ProcessInput1(x)).Sum(q => int.Parse(q))}");

    public override ValueTask<string> Solve_2() => new($"{_input.Select(x => ProcessInput2(x)).Sum(q => int.Parse(q))}");
}
