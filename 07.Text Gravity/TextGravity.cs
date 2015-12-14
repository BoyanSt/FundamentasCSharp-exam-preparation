using System;
using System.Security;
using System.Text;


class TextGravity
{
    static void Main()
    {
        int lineLength = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();

        int maxRows = text.Length / lineLength;
        if (text.Length % lineLength > 0)
        {
            maxRows++;
        }
        char[,] matrix = new char[maxRows, lineLength];

        int countCharsText = 0;

        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                if (countCharsText < text.Length)
                {
                    matrix[rows, cols] = text[countCharsText];
                    countCharsText++;
                }
                else
                {
                    matrix[rows, cols] = ' ';
                }

            }
        }

        for (int rows = matrix.GetLength(0) - 1; rows > 0; rows--)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                if (matrix[rows, cols] == ' ')
                {
                    for (int rowChar = rows - 1; rowChar >= 0; rowChar--)
                    {
                        if (matrix[rowChar, cols] != ' ')
                        {

                            matrix[rows, cols] = matrix[rowChar, cols];
                            matrix[rowChar, cols] = ' ';
                            break;
                        }
                    }
                }
            }
        }

        PrintMatrix(matrix);
    }

    private static void PrintMatrix(char[,] matrix)
    {
        StringBuilder output = new StringBuilder();

        output.Append("<table>");

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            output.Append("<tr>");
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                output.AppendFormat("<td>{0}</td>", SecurityElement.Escape(matrix[row, cols].ToString()));
            }
            output.Append("</tr>");
        }
        output.Append("</table>");
        Console.WriteLine(output.ToString());
    }
}

