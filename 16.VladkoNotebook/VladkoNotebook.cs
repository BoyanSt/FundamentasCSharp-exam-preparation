using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.VladkoNotebook
{
    class VladkoNotebook
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            Dictionary<string, Player> pagesByColour = new Dictionary<string, Player>();


            while (line != "END")
            {
                string[] data = line.Split('|');
                string colour = data[0];

                if (!pagesByColour.ContainsKey(colour))
                {
                    pagesByColour[colour] = new Player();
                    pagesByColour[colour].Opponents = new List<string>();
                }

                //purple|age|99
                if (data[1] == "age")
                {
                    pagesByColour[colour].Age = int.Parse(data[2]);
                }

                //blue|win|pesho

                if (data[1] == "win")
                {
                    pagesByColour[colour].Opponents.Add(data[2]);
                    pagesByColour[colour].WinCount++;
                }

                //purple|loss|Kiko

                if (data[1] == "loss")
                {
                    pagesByColour[colour].Opponents.Add(data[2]);
                    pagesByColour[colour].LossCount++;
                }
                //red|name|gosho

                if (data[1] == "name")
                {
                    pagesByColour[colour].Name = data[2].ToString();
                }

                line = Console.ReadLine();
            }

            var validPages = pagesByColour
                .Where(p => p.Value.Age != 0 && p.Value.Name != null)
                .OrderBy(p => p.Key);

            if (validPages.Count()==0)
            {
                Console.WriteLine("No data recovered.");
                return;
            }


            foreach (var page in validPages)
            {
                string opponents = "(empty)";

                if (page.Value.Opponents.Count > 0)
                {
                    var sortedOppenets = page.Value.Opponents.OrderBy(o => o, StringComparer.Ordinal);
                    opponents = String.Join(", ", sortedOppenets);
                }

                Console.WriteLine("Color: {0}", page.Key);
                Console.WriteLine("-age: {0}", page.Value.Age);
                Console.WriteLine("-name: {0}", page.Value.Name);
                Console.WriteLine("-opponents: {0}", opponents);
                Console.WriteLine("-rank: {0:F2}", ((double)page.Value.WinCount + 1) / ((double)page.Value.LossCount + 1));
            }
        }
        class Player
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public List<string> Opponents { get; set; }

            public int WinCount { get; set; }

            public int LossCount { get; set; }
        }
    }
}
