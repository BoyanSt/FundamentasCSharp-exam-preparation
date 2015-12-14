using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LettersChangeNumbers
{
    static void Main()
    {
        string[] txtInput = Console.ReadLine().Split(new char[]{ },StringSplitOptions.RemoveEmptyEntries);

        double sumAllNumbers = 0;

        for (int i = 0; i < txtInput.Length; i++)
        {
            double sumNum = 0;
            double firstLeter = txtInput[i][0]+1;
            double number = double.Parse(txtInput[i].Substring(1, txtInput[i].Length - 2));
            double secondLeter = txtInput[i][txtInput[i].Length - 1]+1;

            if (firstLeter >= 'A' && firstLeter <= 'Z'+1)
            {
                firstLeter -= 'A';
                sumNum += number / firstLeter;
            }
            else
            {
                firstLeter -= 'a';
                sumNum += number * firstLeter;
            }

            if (secondLeter >= 'A' && secondLeter <= 'Z'+1)
            {
                secondLeter-= 'A';
                sumNum -= secondLeter;
            }
            else
            {
                secondLeter -= 'a';
                sumNum += secondLeter;
            }
            sumAllNumbers += sumNum;
        }
        Console.WriteLine("{0:F2}", sumAllNumbers);
    }
}

