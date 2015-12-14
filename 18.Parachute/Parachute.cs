using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Parachute
{
    static void Main()
    {
        string line = Console.ReadLine();
        int startRow = 0;
        int startCol = 0;
        int maxRow = 0;
        int maxCol = line.Length;

        List<string> listInput = new List<string>();

        while (line != "END")
        {
            int counter = 0;
            if (line.Contains("o"))
            {
                startCol = line.IndexOf("o");
                startRow = counter;
            }
            listInput.Add(line);
            counter++;
            line = Console.ReadLine();
        }
        maxRow = listInput.Count;

        char[,] matrix = new char[maxRow, maxCol];

        //fill the matrix

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = listInput[row][col];
            }
        }


        int endColPosition = startCol;
        int endRowPosition = startRow;

        for (int row = startRow + 1; row < matrix.GetLength(0); row++)
        {
            int leftWindCount = 0;
            int rightWindCount = 0;
            int moveLeftRight = 0;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                char currChar = matrix[row, col];

                if (currChar == '<')
                {
                    leftWindCount++;
                }
                else if (currChar == '>')
                {
                    rightWindCount++;
                }

            }


            if (rightWindCount > leftWindCount)
            {
                moveLeftRight = rightWindCount - leftWindCount;
                endColPosition += moveLeftRight;
            }
            else if (rightWindCount < leftWindCount)
            {
                moveLeftRight = leftWindCount - rightWindCount;
                endColPosition -= moveLeftRight;
            }

            endRowPosition++;


            if (matrix[endRowPosition, endColPosition] == '/' || matrix[endRowPosition, endColPosition] == '\\' ||
                matrix[endRowPosition,endColPosition]=='|')
            {
                Console.WriteLine("Got smacked on the rock like a dog!");
                Console.WriteLine("{0} {1}", endRowPosition, endColPosition);
                break;
            }
            else if (matrix[endRowPosition, endColPosition] == '~')
            {
                Console.WriteLine("Drowned in the water like a cat!");
                Console.WriteLine("{0} {1}", endRowPosition, endColPosition);
                break;
            }
            else if (matrix[endRowPosition, endColPosition] == '_')
            {
                Console.WriteLine("Landed on the ground like a boss!");
                Console.WriteLine("{0} {1}", endRowPosition, endColPosition);
                break;
            }
        }
    }
}

