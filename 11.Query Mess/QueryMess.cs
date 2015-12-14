using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class QueryMess
{
    static void Main()
    {



        while (true)
        {
            Dictionary<string, HashSet<string>> result = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }

            string[] currInputLine = input.Split(new char[] { '&', '?' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < currInputLine.Length; i++)
            {
                string currPair = currInputLine[i];
                string field = null;
                string value = null;

                if (currPair.IndexOf("=") != -1)
                {
                    field = currPair.Substring(0, currPair.IndexOf("="));
                    field = field.Replace("%20", " ");
                    field = field.Replace("+", " ");
                    field = field.Trim();
                    field = Regex.Replace(field, @"\s+", " ");
                    value = currPair.Substring(currPair.IndexOf("=") + 1);
                    value = value.Replace("%20", " ");
                    value = value.Replace("+", " ");
                    value = value.Trim();
                    value = Regex.Replace(value, @"\s+", " ");

                }
                else
                {
                    continue;
                }


                if (!result.ContainsKey(field))
                {
                    HashSet<string> values = new HashSet<string>();
                    values.Add(value);
                    result.Add(field,values);
                }
                else
                {
                    result[field].Add(value);
                }
            }
            foreach (var match in result)
            {
                Console.Write("{0}=[{1}]",match.Key,string.Join(", ", match.Value));
            }
            Console.WriteLine();          
        }
    }
}

