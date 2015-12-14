using System;
using System.Collections.Generic;


class PlusRemove
{
    static void Main()
    {
        char[,] matrix = new char[100, 100];
        int counterRows = 0;
        int longestInputStr = 0;

        while (true)
        {
            string txtInput = Console.ReadLine();
            if (txtInput.Length > longestInputStr)
            {
                longestInputStr = txtInput.Length;
            }

            if (txtInput == "END")
            {
                break;
            }

            for (int counterCols = 0; counterCols < 100 && counterCols < txtInput.Length; counterCols++)
            {
                matrix[counterRows, counterCols] = txtInput[counterCols];
            }
            counterRows++;
        }

        HashSet<KeyValuePair<int, int>> coordinatesSet = new HashSet<KeyValuePair<int, int>>();
        char currentChar = '\0';

        for (int rows = 0; rows < counterRows - 2; rows++)
        {
            for (int cols = 1; cols < longestInputStr - 1; cols++)
            {
                currentChar = Char.ToUpper(matrix[rows, cols]);

                char ch2 = Char.ToUpper(matrix[rows + 1, cols]);
                char ch3 = Char.ToUpper(matrix[rows + 2, cols]);
                char ch4 = Char.ToUpper(matrix[rows + 1, cols - 1]);
                char ch5 = Char.ToUpper(matrix[rows + 1, cols + 1]);

                if (currentChar == ch2 && currentChar == ch3 && currentChar == ch4 && currentChar == ch5)
                {
                    coordinatesSet.Add(new KeyValuePair<int, int>(rows, cols));
                    coordinatesSet.Add(new KeyValuePair<int, int>(rows + 1, cols));
                    coordinatesSet.Add(new KeyValuePair<int, int>(rows + 2, cols));
                    coordinatesSet.Add(new KeyValuePair<int, int>(rows + 1, cols - 1));
                    coordinatesSet.Add(new KeyValuePair<int, int>(rows + 1, cols + 1));
                }
            }
        }



        for (int i = 0; i < counterRows; i++)
        {
            for (int n = 0; n < longestInputStr; n++)
            {
                KeyValuePair<int, int> currKeyValuePair = new KeyValuePair<int, int>(i, n);
                if (!coordinatesSet.Contains(currKeyValuePair))
                {
                    Console.Write(matrix[i, n]);
                }
            }
            Console.WriteLine();
        }
    }
}

