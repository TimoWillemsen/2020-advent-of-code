using System;
using System.IO;
using System.Linq;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = File.ReadLines("input/input")
                .Select(x =>
                {
                    var split = x.Split(":");
                    var split2 = split[0].Split(' ');
                    var split3 = split2[0].Split('-');
                    return (min: int.Parse(split3[0].Trim()), max: int.Parse(split3[1].Trim()), character: split2[1].Trim(), s: split[1].Trim());
                });


            Console.WriteLine(
                $"Solution 2: {entries.Count(entry => entry.s[entry.min - 1].ToString() == entry.character ^ entry.s[entry.max - 1].ToString() == entry.character)}");

        }
    }
}