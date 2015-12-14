using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class UppercaseWords
{
    static void Main()
    {

        string line = Console.ReadLine();
        Regex regex = new Regex(@"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])");
        //^(\b[A-Z]+?(?=[ \W0-9_]))|(?<=[ 0-9\W_])[A-Z]+?(?=[ \W0-9_])


        while (line!="END")
        {

            MatchCollection matches = regex.Matches(line);

            int offset = 0;

            foreach (Match match in matches)
            {
                string word = match.Value;
                string reversed = Reversed(word);

                if (reversed==word)
                {
                    reversed = DoubleEachLetter(reversed);
                }

                int index = match.Index;
                line = line.Remove(index+offset, word.Length);
                line = line.Insert(index+offset, reversed);
                offset += reversed.Length - word.Length;
            }

            Console.WriteLine(SecurityElement.Escape(line));
            line = Console.ReadLine();
        }


    }

    private static string DoubleEachLetter(string reversed)
    {
        StringBuilder doubled = new StringBuilder();

        for (int i = 0; i < reversed.Length; i++)
        {
            doubled.Append(new string(reversed[i], 2));
        }
        return doubled.ToString();
    }

    private static string Reversed(string word)
    {
        StringBuilder reversed = new StringBuilder();

        for (int i = word.Length-1; i >= 0; i--)
        {
            reversed.Append(word[i]);
        }

        return reversed.ToString();
    }
}

