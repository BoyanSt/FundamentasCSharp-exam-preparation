using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TerroristsWin
{
    static void Main()
    {
        string text = Console.ReadLine();
        string[] txtInput = text.Split('|');

        StringBuilder result = new StringBuilder();

        for (int i = 1; i < txtInput.Length ; i += 2)
        {
            string bomb = null;
            if (i == 1)
            {
                bomb = txtInput[i];
                int sumCharsBomb = 0;
                int lastDigitSumChars = 0;

                for (int m = 0; m < bomb.Length; m++)
                {
                    sumCharsBomb += bomb[m];
                }

                lastDigitSumChars = sumCharsBomb % 10;

                result.Append(txtInput[i - 1].Substring(0, txtInput[i - 1].Length - lastDigitSumChars));
                result.Append(new string('.', lastDigitSumChars));
                result.Append(new string('.', bomb.Length + 2));
                result.Append(new string('.', lastDigitSumChars));
                result.Append(txtInput[i + 1].Substring(lastDigitSumChars));
            }
            else
            {
                bomb = txtInput[i];
                int sumCharsBomb = 0;
                int lastDigitSumChars = 0;

                for (int m = 0; m < bomb.Length; m++)
                {
                    sumCharsBomb += bomb[m];
                }

                lastDigitSumChars = sumCharsBomb % 10;

                result.Remove(result.Length-lastDigitSumChars,lastDigitSumChars);
                result.Append(new string('.', lastDigitSumChars));
                result.Append(new string('.', bomb.Length + 2));
                result.Append(new string('.', lastDigitSumChars));
                result.Append(txtInput[i + 1].Substring(lastDigitSumChars));
            }
        }

            Console.WriteLine(result);

    }
}

