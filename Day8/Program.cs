using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input/input")
                .Select(x => x.Split(' '))
                .Select(y => (op: y[0], val: int.Parse(y[1]))).ToArray();
            
          
            var acc = DoesLoop(lines);
            
            Console.WriteLine(acc);

            
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].op == "nop" || lines[i].op == "jmp")
                {
                    //Console.WriteLine($"Replacing {lines[i].op} on line {i}");
                    var newArr = ((string op, int val)[])lines.Clone();
                    newArr[i].op = newArr[i].op == "nop" ? "jmp" : "nop";

                    var doesLoop = DoesLoop(newArr);
                    if(!doesLoop)
                        Console.WriteLine($"When replace op on {i} it loops: {doesLoop}");

                }
            }
            
            Console.WriteLine(lines.Count(x => x.op == "nop"));
            Console.WriteLine(lines.Count(x => x.op == "jmp"));

        }

        private static bool DoesLoop(IList<(string op, int val)> lines)
        {
            var visitedLines = new List<int>();
            var row = 0;
            var acc = 0;
            do
            {
                if (row >= lines.Count)
                {
                    Console.WriteLine(acc);
                    return false;
                }
                visitedLines.Add(row);
                switch (lines[row].op)
                {
                    case "jmp":
                        row += lines[row].val;
                        break;
                    case "acc":
                        acc += lines[row].val;
                        row += 1;
                        break;
                    case "nop":
                        row += 1;
                        break;
                }
            } while (!visitedLines.Contains(row));
            return true;
        }
    }
}