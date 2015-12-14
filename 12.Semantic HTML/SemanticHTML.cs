using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SemanticHTML
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] currInputLine = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (currInputLine[0] == "<div")
        {        
            for (int i = 1; i < currInputLine.Length; i++)
            {
                if (currInputLine[i].Substring(0, 2) == "id"||currInputLine[i].Substring(0,5)=="class")
                {
                    string[] idClassPair = currInputLine[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string idClassValue = idClassPair[1].Replace("\"", "");
                    idClassValue = idClassValue.Replace(">", "");

                    string outputLine = input.Replace("div", idClassValue).Replace(currInputLine[i].Replace(">",""), "");

                    Console.WriteLine(outputLine);
                    break;
                }
            }

        }
    }
}

