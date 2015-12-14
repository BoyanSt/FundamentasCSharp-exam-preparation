using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ExtractHyperlinks
{
    static void Main()
    {
        StringBuilder textInput = new StringBuilder();

        while (true)
        {
            string currentInputLine = Console.ReadLine();
            if (currentInputLine=="END")
            {
                break;
            }
            textInput.Append(currentInputLine);
        }

        string text = textInput.ToString();

        string pattern = @"(<a.+?(?=>)>)";

        Regex regexFragment = new Regex(pattern);

        MatchCollection matchesHtmlFragment = regexFragment.Matches(text);

        foreach (var match in matchesHtmlFragment)
        {
            string fragment = match.ToString();

            if (fragment.Contains("href="))
            {
                int startChar = fragment.IndexOf("href=")+5;

                for (int i = startChar; i < fragment.Length; i++)
                {
                    if (fragment[i]!='"'&&fragment[i]!='>')
                    {
                        if (fragment[i] == ' ')
                        {
                            break;
                        }
                        Console.Write(fragment[i]);

                    }
                }
                Console.WriteLine();
            }
            else if (fragment.Contains("href ="))
            {
                 int startChar = fragment.IndexOf("href=")+6;
                 for (int i = startChar; i < fragment.Length; i++)
                 {
                     if (fragment[i] != '"' && fragment[i] != '>')
                     {
                         if (fragment[i] == ' ')
                         {
                             break;
                         }
                         Console.Write(fragment[i]);

                     }
                 }
            }
            //Console.WriteLine(match);
        }        
    }
}

