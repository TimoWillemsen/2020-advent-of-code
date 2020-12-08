using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input/input");
            var bags = new List<Bag>();
            
            foreach (var line in lines)
            {
                var words = line.Split(' ');
                var color = words[0] + " " + words[1];
                var bag = bags.FirstOrDefault(x => x.Color == color);
                if (bag == null)
                {
                    bag = new Bag(color);
                    bags.Add(bag);
                }

                int count = 4;
                if(words[4] == "no") continue;
                while (count < words.Length)
                {
                    var amount = words[count];
                    var c = words[count + 1] + " " + words[count + 2];
                    
                    var bag2 = bags.FirstOrDefault(x => x.Color == c);
                    if (bag2 == null)
                    {
                        bag2 = new Bag(c);
                        bags.Add(bag2);
                    }

                    bag.Contents.Add(bag2, int.Parse(amount));
                    count = count + 4;
                }


            }

            int solution1 = bags.Select(CanContainShinyGold).Count(canHold => canHold);
            Console.WriteLine(solution1);
            
            var solution2 = CanContainBags(bags.First(x => x.Color == "shiny gold"));
            Console.WriteLine(solution2);
        }


        private static int CanContainBags(Bag bag)
        {
            if (!bag.Contents.Any()) return 0;
            var count = bag.Contents.Sum(x => x.Value);
            return count + bag.Contents.Sum(x => CanContainBags(x.Key) * x.Value);
        }

        private static bool CanContainShinyGold(Bag bag)
        {
            return bag.Contents.Any(x => x.Key.Color == "shiny gold") 
                   || bag.Contents.Select(content => content.Key).Any(CanContainShinyGold);
        }
    }


    public class Bag
    {
        public Bag(string color)
        {
            Color = color;
        }
        public IDictionary<Bag,int> Contents { get; } = new Dictionary<Bag, int>();
        public string Color { get; }
    }
}