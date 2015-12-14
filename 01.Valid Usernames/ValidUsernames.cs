using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


    class ValidUsernames
    {
        static void Main()
        {
            string txtInput = Console.ReadLine();
            string pattern = @"^([a-zA-Z]\w{1,24}?(?=[ \\\/)()]))|((?<=[ \\\/)()])[a-zA-Z]\w{1,24}?(?=[ \\\/)()]))|([a-zA-Z]\w{1,24}$)";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(txtInput);

            int maxSum = 0;
            int positionElement = 0;

            for (int i = 0; i < matches.Count-1; i++)
            {
                int sum = matches[i].Groups[0].Value.Length + matches[i+1].Groups[0].Value.Length;
                if (sum>maxSum)
                {
                    maxSum = sum;
                    positionElement = i;
                }
            }
            Console.WriteLine(matches[positionElement].Groups[0].Value);
            Console.WriteLine(matches[positionElement + 1].Groups[0].Value);
        }
    }

