using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20.Treta
{
    public class WordObject
    {

        public static Dictionary<string, int> SpeicalChars = new Dictionary<string, int>{
			{ "$", 1},
			{ "%", 2},
			{ "&", 3},
			{ "'", 4}
		};

        public string word;
        public string specialChar;

        // Return the new processd version based on special cahr weight
        public string Process()
        {

            string result = "";
            int weight = SpeicalChars[specialChar];

            int idx = 0;

            foreach (char c in word)
            {
                int code = (int)c + (idx % 2 != 0 ? -1 : 1) * weight;
                result += (char)code;
                idx++;
            }


            return result;
        }
    }

    class Treta
    {


        public static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder();
            string line = Console.ReadLine();

            //1. Read the program input

            while (line != "burp")
            {
                input.Append(line);
                line = Console.ReadLine();
            }


            //from file
            //string[] file = System.IO.File.ReadAllLines("/Users/tsetso/Desktop/test.txt");
            //string data = string.Join("", file);

            //input.Append(data);


            //2. Replace space
            string flat = ReplaceSpace(input.ToString());
            //3. Parse result ( transform )
            string result = Parse(flat);

            Console.WriteLine(result);
        }

        public static string ReplaceSpace(string input)
        {
            Regex reg = new Regex(@"\s+");
            return reg.Replace(input, " ");
        }

        /// <summary>
        /// Parse string input and return match cases
        /// </summary>
        /// <param name="input">Input.</param>
        public static string Parse(string input)
        {

            StringBuilder result = new StringBuilder();

            Regex re = new Regex(@"([$%&'])([^$%&']+?)(\1){1}");

            MatchCollection matches = re.Matches(input);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                //get the match and stored it as WordObject
                result.Append(new WordObject
                {
                    specialChar = groups[1].Value,
                    word = groups[2].Value
                }.Process() + " ");
            }

            return result.ToString();
        }
    }
}
