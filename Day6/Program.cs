using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllText("input/input")
                .Split(Environment.NewLine + Environment.NewLine).ToList()
                .Select(x => x.Split(Environment.NewLine).ToList());

            var sum = 0;
            foreach (var group in lines)
            {
                var p = 0;
                var allAnswers = new List<char>();
                foreach (var person in group)
                {
                    var k = person.ToList();
                    if (p == 0)
                    {
                        allAnswers = k;
                    }
                    else
                    {
                        allAnswers = allAnswers.Intersect(k).ToList();
                    }

                    p++;
                }

                sum += allAnswers.Count;
                Console.WriteLine(allAnswers.Count);
            }
            
            Console.WriteLine(sum);
        }
    }
}