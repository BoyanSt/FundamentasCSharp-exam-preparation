using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class StringMatrixRotation
{
    static void Main()
    {
        string[] txtInput = new string[1000];
        int arrCounter = 0;
        int longestStringInput = 0;

        string[] inputRotation = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        int rotationValue = int.Parse(inputRotation[1]) / 90;

        while (true)
        {
            string currentString = Console.ReadLine();

            if (currentString == "END")
            {
                break;
            }
            if (longestStringInput < currentString.Length)
            {
                longestStringInput = currentString.Length;
            }
            txtInput[arrCounter] = currentString;
            arrCounter++;
        }
        int totalRows = arrCounter;
        int totalCols = longestStringInput;

        if (rotationValue % 4 == 0)
        {
            char[,] matrix = new char[totalRows, totalCols];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int currStrLength = txtInput[rows].Length;
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (cols >= currStrLength)
                    {
                        matrix[rows, cols] = ' ';
                    }
                    else
                    {
                        matrix[rows, cols] = txtInput[rows][cols];
                    }
                }
            }
            PrintMatrix(matrix);
        }

        if (rotationValue % 4 == 1)
        {
            char[,] matrix90 = new char[totalCols, totalRows];
            int countStringToPut = totalRows - 1;

            for (int cols = 0; cols < matrix90.GetLength(1); cols++)
            {
                for (int rows = 0; rows < matrix90.GetLength(0); rows++)
                {
                    if (rows >= txtInput[countStringToPut].Length)
                    {
                        matrix90[rows, cols] = ' ';
                    }
                    else
                    {
                        matrix90[rows, cols] = txtInput[countStringToPut][rows];
                    }
                }
                countStringToPut--;
            }
            PrintMatrix(matrix90);
        }


        if (rotationValue % 4 == 2)
        {
            char[,] matrix180 = new char[totalRows, totalCols];
            int countStringToPut = totalRows - 1;


            for (int rows = 0; rows < matrix180.GetLength(0); rows++)
            {
                int counterChars = 0;
                for (int cols = matrix180.GetLength(1) - 1; cols >= 0; cols--)
                {
                    if (counterChars >= txtInput[countStringToPut].Length)
                    {
                        matrix180[rows, cols] = ' ';
                    }
                    else
                    {
                        matrix180[rows, cols] = txtInput[countStringToPut][counterChars];
                    }
                    counterChars++;
                }
                countStringToPut--;
            }
            PrintMatrix(matrix180);
        }

        if (rotationValue % 4 == 3)
        {
            char[,] matrix270 = new char[totalCols, totalRows];
            int countStringToPut = totalRows - 1;

            for (int cols = matrix270.GetLength(1) - 1; cols >= 0; cols--)
            {
                int counterChars = 0;
                for (int rows = matrix270.GetLength(0) - 1; rows >= 0; rows--)
                {
                    if (counterChars>=txtInput[countStringToPut].Length)
                    {
                        matrix270[rows, cols] = ' ';
                    }
                    else
                    {
                        matrix270[rows, cols] = txtInput[countStringToPut][counterChars];
                    }

                    counterChars++;
                }
                countStringToPut--;
            }
            PrintMatrix(matrix270);
        }


    }

    public static void PrintMatrix(char[,] matrix)
    {

        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                Console.Write("{0}", matrix[rows, cols]);
            }
            Console.WriteLine();
        }
    }
}

