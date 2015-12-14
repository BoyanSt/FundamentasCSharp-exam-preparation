using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Pyramid
{
    class Pyramid
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> sequence = new List<int>();

            int previousNumber = int.Parse(Console.ReadLine().Trim());
            sequence.Add(previousNumber);

            for (int i = 1; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] numbersAsStringArr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int[] numbers = new int[numbersAsStringArr.Length];

                for (int k = 0; k < numbers.Length; k++)
                {
                    numbers[k] = int.Parse(numbersAsStringArr[k]);
                }

                int minNumber = int.MaxValue;
                bool foundNumber = false;

                for (int j = 0; j < numbers.Length; j++)
                {
                    int currNumber = numbers[j];

                    if (currNumber < minNumber && currNumber > previousNumber)
                    {
                        minNumber = currNumber;
                        foundNumber = true;
                    }
                }

                if (foundNumber)
                {
                    sequence.Add(minNumber);
                    previousNumber = minNumber;                   
                }
                else
                {
                    previousNumber++;
                }
            }

            Console.WriteLine(string.Join(", ",sequence));
        }
    }
}
