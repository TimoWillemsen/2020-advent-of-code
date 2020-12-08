using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = File.ReadLines("input/input")
                .Select(x => int.Parse(x))
                .OrderBy(x => x);

            var pairResult= FindPair(entries, 2020);
            if (pairResult.HasValue)
            {
                var (firstValue, secondValue) = pairResult.Value;
                Console.WriteLine($"Found pair: {firstValue} * {secondValue} = {firstValue * secondValue}");
            }
            
            foreach (var firstValue in entries)
            {
                var missing = 2020 - firstValue;
                var result = FindPair(entries.Where(x => x < missing), missing);
                if (!result.HasValue)
                    continue;

                var (secondValue, thirdValue) = result.Value;

                Console.WriteLine($"Found triple: {firstValue} * {secondValue} * {thirdValue} = {firstValue*secondValue*thirdValue}");
                break;
            }
        }

        private static (int firstValue, int secondValue)? FindPair(IEnumerable<int> entries, int sum)
        {
            foreach (var entry in entries)
            {
                var missing = sum - entry;
                if (!entries.Contains(missing)) continue;
                return (missing, entry);
            }

            return null;
        }
    }
}