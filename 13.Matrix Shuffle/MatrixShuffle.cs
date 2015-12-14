using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class MatrixShuffle
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string keyWord = Console.ReadLine();

        char[,] spiralMatrix = new char[n, n];


        // Loop spiralMatrix

        int row = 0, col = 0, size = n, currentCounter = 0;

        while (size > 0)
        {
            for (int i = col; i <= col + size - 1 && currentCounter < keyWord.Length; i++)
            {
                spiralMatrix[row, i] = keyWord[currentCounter];
                currentCounter++;
            }
            for (int j = row + 1; j <= row + size - 1 && currentCounter < keyWord.Length; j++)
            {
                spiralMatrix[j, col + size - 1] = keyWord[currentCounter];
                currentCounter++;
            }
            for (int i = col + size - 2; i >= col && currentCounter < keyWord.Length; i--)
            {
                spiralMatrix[row + size - 1, i] = keyWord[currentCounter];
                currentCounter++;
            }
            for (int k = row + size - 2; k >= row + 1 && currentCounter < keyWord.Length; k--)
            {
                spiralMatrix[k, col] = keyWord[currentCounter];
                currentCounter++;
            }
            row++;
            col++;
            size -= 2;
        }

        StringBuilder leftResult = new StringBuilder();
        StringBuilder rightResult = new StringBuilder();
        StringBuilder textToPrintLeft = new StringBuilder();
        StringBuilder textToPrintRight = new StringBuilder();
        string result = null;
        

        for (int rows = 0; rows < spiralMatrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < spiralMatrix.GetLength(1); cols++)
            {
                char currCharValue = spiralMatrix[rows, cols];
                if (currCharValue=='\0')
                {
                    currCharValue = ' ';
                }

                if ((currCharValue >= 'a'&&currCharValue<='z') || (currCharValue >= 'A'&&currCharValue<='Z')||currCharValue==' ')
                {
                    if (rows % 2 == 0 && cols % 2 == 1)
                    {
                        rightResult.Append(currCharValue);
                    }
                    if (rows % 2 == 1 && cols % 2 == 0)
                    {
                        rightResult.Append(currCharValue);
                    }
                    if (rows % 2 == 0 && cols % 2 == 0)
                    {
                        leftResult.Append(currCharValue);
                    }
                    if (rows % 2 == 1 && cols % 2 == 1)
                    {
                        leftResult.Append(currCharValue);
                    }
                }

                    if (rows % 2 == 0 && cols % 2 == 1)
                    {
                        textToPrintRight.Append(currCharValue);
                    }
                    if (rows % 2 == 1 && cols % 2 == 0)
                    {
                        textToPrintRight.Append(currCharValue);
                    }
                    if (rows % 2 == 0 && cols % 2 == 0)
                    {
                        textToPrintLeft.Append(currCharValue);
                    }
                    if (rows % 2 == 1 && cols % 2 == 1)
                    {
                        textToPrintLeft.Append(currCharValue);
                    }               
            }
        }
        
        result = leftResult.ToString().ToLower()+rightResult.ToString().ToLower();
        result = Regex.Replace(result, @"\s+", "");
        string textToPrint = textToPrintLeft.ToString() + textToPrintRight.ToString();

        bool isPolidromes = CheckIsPolidromes(result);

        string leftRightText = leftResult.ToString()+rightResult.ToString();
        if (isPolidromes)
        {
            Console.WriteLine(@"<div style='background-color:#4FE000'>{0}</div>", textToPrint);
        }
        else
        {
            Console.WriteLine(@"<div style='background-color:#E0000F'>{0}</div>", textToPrint);
        }
    }

    private static bool CheckIsPolidromes(string text)
    {
        bool isPolidromes = true;

            int counter = 0;

            while (counter < text.Length)
            {
                if (text[counter] != text[text.Length - counter - 1])
                {
                    isPolidromes = false;
                    break;
                }
                counter++;
            }

        return isPolidromes;
    }
}

