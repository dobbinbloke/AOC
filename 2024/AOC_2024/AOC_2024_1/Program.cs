// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.CompilerServices;

//string file = @"C:\Dev\AOC\2024\AOC_2024\AOC_2024_1\example.txt";
//Distance is 11 total 18 ms  load 17 ms sort 1 ms 
//Similarity is 31 total 18 ms  load 18 

string file = @"C:\Dev\AOC\2024\AOC_2024\AOC_2024_1\part1.txt";
//Distance is 2031679 total 17 ms  load 15 ms sort 2 ms 
//Similarity is 19678534 total 21 ms  load 20 ms 
//release: Similarity is 19678534 total 11 ms  load 10 ms
//Part1(file);
Part2(file);

void Part2(string file)
{
    Dictionary<long, int>? one;
    Dictionary<long, int>? two;

    Stopwatch stopwatch = Stopwatch.StartNew();

    (one, two) = Part2LoadFile(file);

    var l = stopwatch.ElapsedMilliseconds;

    long sim = Part2CalculateSimilarity(one, two);

    var d = stopwatch.ElapsedMilliseconds;

    Console.WriteLine($"Similarity is {sim} total {d} ms  load {l} ms ");
}
long Part2CalculateSimilarity(Dictionary<long, int> one, Dictionary<long, int> two)
{
    long sim = 0;

    foreach (var k in one.Keys)
    {
        if (two.ContainsKey(k))
        {
            sim += (k * one[k] * two[k]);
        }
    }
    return sim;
}

(Dictionary<long, int> one, Dictionary<long, int> two) Part2LoadFile(string file)
{
    Dictionary<long, int>? one = new();
    Dictionary<long, int>? two = new();

    var lines = File.ReadLines(file);
    foreach (var line in lines)
    {
        var p = line.Split("   ");
        long l1 = long.Parse(p[0]);
        long l2 = long.Parse(p[1]);

        if (!one.ContainsKey(l1))
            one[l1] = 1;
        else
            one[l1]++;

        if (!two.ContainsKey(l2))
            two[l2] = 1;
        else
            two[l2]++;

        //Debug.WriteLine(line);
    }

    return (one, two);
}

void Part1(string file)
{
    List<long>? one;
    List<long>? two;

    Stopwatch stopwatch = Stopwatch.StartNew();

    (one, two) = Part1LoadFile(file);

    var l = stopwatch.ElapsedMilliseconds;

    one.Sort();
    two.Sort();

    var s = stopwatch.ElapsedMilliseconds;

    long distance = Part1CalculateDistance(one, two);

    var d = stopwatch.ElapsedMilliseconds;

    Debug.WriteLine($"Distance is {distance} total {d} ms  load {l} ms sort {s - l} ms ");
}

long Part1CalculateDistance(List<long> one, List<long> two)
{
    long distance = 0;
    for(int i=0; i< one.Count; i++ )
    {
        long diff = one[i] - two[i];
        distance += diff>=0?diff:-diff;
    }

    return distance;
}

(List<long> one, List<long> two) Part1LoadFile(string file)
{
    List<long>? one = new();
    List<long>? two = new(); 

    var lines = File.ReadLines(file);
    foreach (var line in lines)
    {
        var p = line.Split("   ");
        one.Add(long.Parse(p[0]));
        two.Add(long.Parse(p[1]));
        //Debug.WriteLine(line);
    }

    return (one, two);
}
