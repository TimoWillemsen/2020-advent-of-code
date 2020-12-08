using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("input/input");
            var seats = new List<int>();
            foreach (var line in lines)
            {
                var row = Parse(line.Substring(0, 7),  128, 'F', 'B');
                var col = Parse(line.Skip(7), 8, 'L', 'R');
                var seat = (row * 8) + col;
                seats.Add(seat);
            }
            
            seats.Sort();

            var firstSolution = seats.Last();
            var secondSolution = seats.First(seat => !seats.Contains(seat + 1)) + 1;
            
            Console.WriteLine($"First solution: {firstSolution}");
            Console.WriteLine($"Second solution: {secondSolution}");
        }

        private static int Parse(IEnumerable<char> str, int maxRange, char lowChar, char highChar)
        {
            var options = Enumerable.Range(0, maxRange).ToList();
            foreach (var character in str)
            {
                if (character == lowChar)
                {
                    options = options.Take(options.Count / 2).ToList();
                }

                if (character == highChar)
                {
                    options = options.Skip(options.Count / 2).ToList();
                }
            }
            return int.Parse(options[0].ToString());
        }
        
    }
}