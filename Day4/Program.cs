using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllText("input/input")
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(x => x.Replace(Environment.NewLine, " "))
                .Select(x => x.Split(" ").Select(item => item.Split(":"))
                    .ToDictionary(result => result[0], result => result[1]))
                .Where(x => x.ContainsKey("byr") && x.ContainsKey("iyr") && x.ContainsKey("eyr") &&
                            x.ContainsKey("hgt") && x.ContainsKey("hcl") && x.ContainsKey("ecl") &&
                            x.ContainsKey("pid"));
            
            var solution1 = data.Count();
            var solution2 = data.Count(IsValidRecord);
            Console.WriteLine($"Solution 1: {solution1}");
            Console.WriteLine($"Solution 2: {solution2}");
        }

        private static bool IsValidRecord(Dictionary<string, string> record)
        {
            return IsValidYear(record["byr"], 1920, 2002) &&
                          IsValidYear(record["iyr"], 2010, 2020) &&
                          IsValidYear(record["eyr"], 2020, 2030) && 
                          IsValidLength(record["hgt"]) &&
                          Regex.IsMatch(record["hcl"], @"^#[a-f0-9]{6}$") &&
                          new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(record["ecl"]) && 
                          record["pid"].All(char.IsDigit) && record["pid"].Length == 9;

        }
        private static bool IsValidYear(string value, int from, int to)
        {
            return int.Parse(value) >= from && int.Parse(value) <= to;
        }

        private static bool IsValidLength(string str)
        {
            var unit = str.Substring(str.Length - 2);
            if (unit == "cm")
            {
                var value = int.Parse(str.Substring(0, str.Length - 2));
                return value >= 150 && value <= 193;
            }

            if (unit == "in")
            {
                var value = int.Parse(str.Substring(0, str.Length - 2));
                return value >= 59 && value <= 76;
            }

            return false;
        }
    }
}