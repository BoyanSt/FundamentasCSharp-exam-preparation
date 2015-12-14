using System;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ClearingCommands
{
    static void Main()
    {
        List<string> listInput = new List<string>();

        while (true)
        {
            string inputLine = Console.ReadLine();
            if (inputLine == "END")
            {
                break;
            }

            listInput.Add(inputLine);
        }

        char[,] matrix = new char[listInput.Count, listInput[0].Length];

        // fill the matrix 

        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                matrix[rows, cols] = listInput[rows][cols];
            }
        }


        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                if (matrix[rows, cols] == '>')
                {
                    for (int i = cols + 1; i < matrix.GetLength(1); i++)
                    {
                        if (ContainCommand(matrix, rows, i))
                        {
                            break;
                        }
                        matrix[rows, i] = ' ';
                    }
                }
                else if (matrix[rows, cols] == '<')
                {
                    for (int i = cols - 1; i >= 0; i--)
                    {
                        if (ContainCommand(matrix, rows, i))
                        {
                            break;
                        }
                        matrix[rows, i] = ' ';
                    }
                }
                else if (matrix[rows, cols] == '^')
                {
                    for (int i = rows - 1; i >= 0; i--)
                    {
                        if (ContainCommand(matrix, i, cols))
                        {
                            break;
                        }
                        matrix[i, cols] = ' ';
                    }
                }
                else if (matrix[rows, cols] == 'v')
                {
                    for (int i = rows + 1; i < matrix.GetLength(0); i++)
                    {
                        if (ContainCommand(matrix, i, cols))
                        {
                            break;
                        }
                        matrix[i, cols] = ' ';
                    }
                }
            }
        }
        PrintMatrix(matrix);
    }

    private static bool ContainCommand(char[,] matrix, int startPostion, int endPosition)
    {
        bool isEscaped = false;
        return isEscaped ?
            matrix[startPostion, endPosition] == '^'
            || matrix[startPostion, endPosition].ToString() == SecurityElement.Escape("^")
            || matrix[startPostion, endPosition] == 'v'
            || matrix[startPostion, endPosition].ToString() == SecurityElement.Escape("v")
            || matrix[startPostion, endPosition] == '>'
            || matrix[startPostion, endPosition].ToString() == SecurityElement.Escape(">")
            || matrix[startPostion, endPosition] == '<'
            || matrix[startPostion, endPosition].ToString() == SecurityElement.Escape("<") :
            matrix[startPostion, endPosition] == '^' || matrix[startPostion, endPosition] == 'v'
            || matrix[startPostion, endPosition] == '>' || matrix[startPostion, endPosition] == '<';
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            Console.Write("<p>");
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                //Console.Write("{0} ",matrix[rows,cols]);
                Console.Write(SecurityElement.Escape(matrix[rows, cols].ToString()));
            }
            Console.WriteLine("</p>");
        }
    }
}

