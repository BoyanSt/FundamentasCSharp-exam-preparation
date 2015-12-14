using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.StuckNumbers
{
    class StuckNumbers
    {
        static void Main()
        {
            string n = Console.ReadLine();
            string[] numbers = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            bool isStuckNums = false;

            for (int a = 0; a < numbers.Length; a++)
            {
                for (int b = 0; b < numbers.Length; b++)
                {
                    for (int c = 0; c < numbers.Length; c++)
                    {
                        for (int d = 0; d < numbers.Length; d++)
                        {
                            string firstNum = numbers[a];
                            string secondNum = numbers[b];
                            string thirdNum = numbers[c];
                            string forthNum = numbers[d];

                            if (firstNum != secondNum && firstNum != thirdNum && firstNum != forthNum && secondNum != thirdNum && secondNum != forthNum && thirdNum != forthNum)
                            {
                                if (firstNum + secondNum == thirdNum + forthNum)
                                {
                                    Console.WriteLine("{0}|{1}=={2}|{3}", firstNum, secondNum, thirdNum, forthNum);
                                    isStuckNums = true;
                                }
                            }
                        }
                    }
                }
            }

            if (!isStuckNums)
            {
                Console.WriteLine("No");
            }
        }
    }
}
