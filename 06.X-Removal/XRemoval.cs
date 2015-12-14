using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class XRemoval
{
    static void Main()
    {
        List<string> listInput = new List<string>();
        int longestLine = 0;

        while (true)
        {
            string inputLine = Console.ReadLine();
            if (inputLine == "END")
            {
                break;
            }

            if (inputLine.Length > longestLine)
            {
                longestLine = inputLine.Length;
            }
            listInput.Add(inputLine);
        }

        // fill the matrix

        char[,] matrix = new char[listInput.Count, longestLine];

        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1) && cols < listInput[rows].Length; cols++)
            {
                matrix[rows, cols] = listInput[rows][cols];
            }
        }

        HashSet<KeyValuePair<int, int>> coordinatesSet = new HashSet<KeyValuePair<int, int>>();

        for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1) - 2; cols++)
            {
                char ch1 = char.ToUpper(matrix[rows, cols]);
                char ch2 = char.ToUpper(matrix[rows, cols + 2]);
                char ch3 = char.ToUpper(matrix[rows + 1, cols + 1]);
                char ch4 = char.ToUpper(matrix[rows + 2, cols]);
                char ch5 = char.ToUpper(matrix[rows + 2, cols + 2]);

                if (ch1 == ch2 && ch1 == ch3 && ch3 == ch4 && ch1 == ch5)
                {
                    coordinatesSet.Add(new KeyValuePair<int, int>(rows, cols));
                    coordinatesSet.Add(new KeyValuePair<int, int>(rows, cols + 2));
                    coordinatesSet.Add(new KeyValuePair<int, int>(rows + 1, cols + 1));
                    coordinatesSet.Add(new KeyValuePair<int, int>(rows + 2, cols));
                    coordinatesSet.Add(new KeyValuePair<int, int>(rows + 2, cols + 2));
                }
            }
        }
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                KeyValuePair<int, int> currentKeyValue = new KeyValuePair<int, int>(rows, cols);

                if (!coordinatesSet.Contains(currentKeyValue))
                {
                    Console.Write(matrix[rows, cols]);
                }
            }
            Console.WriteLine();
        }
    }
}

