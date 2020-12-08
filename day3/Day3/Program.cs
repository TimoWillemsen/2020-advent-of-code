using System;
using System.IO;
using System.Linq;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = File.ReadLines("input/input").ToList()
                .Select(x => x.ToArray()).ToArray();

            var result1 = CalculateSlope(grid, 3, 1);
            var result2 = result1 *
                          CalculateSlope(grid, 1, 1) *
                          CalculateSlope(grid, 5, 1) *
                          CalculateSlope(grid, 7, 1) *
                          CalculateSlope(grid, 1, 2);
            
            Console.WriteLine($"Day3 1: {result1}");
            Console.WriteLine($"Day3 2: {result2}");
        }

        private static uint CalculateSlope(char[][] grid, int xSlope, int ySlope)
        {
            uint treeCount = 0;
            var currentRow = 0;
            var currentColumn = 0;
            
            while (currentRow < grid.Length)
            {               
                if (grid[currentRow][currentColumn] == '#')
                {
                    treeCount++;
                }

                currentRow = (currentRow + ySlope);
                currentColumn = (currentColumn + xSlope) % grid[0].Length;
            }

            return treeCount;
        }
    }
    
}