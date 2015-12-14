using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class LittleJohn
{
    static void Main()
    {

        int countSmallArrows = 0;
        int countMediumArrows = 0;
        int countLargeArrows = 0;

        for (int i = 0; i < 4; i++)
        {
            string text = Console.ReadLine();

            string patternSmallArrow = @"((?<!>)>----->(?!>))";
            string patternMediumArrow = @"((?<!>)>>----->(?!>))";
            string pattermLargeArrow = @"((?<!>)>>>----->>(?!>))";

            Regex regexSmallArrow = new Regex(patternSmallArrow);
            Regex regexMediumArrow = new Regex(patternMediumArrow);
            Regex regexLargeArrow = new Regex(pattermLargeArrow);

            MatchCollection matchesSmallArrows = regexSmallArrow.Matches(text);
            MatchCollection matchesMediumArrows = regexMediumArrow.Matches(text);
            MatchCollection matchesLargeArrows = regexLargeArrow.Matches(text);

            countSmallArrows += matchesSmallArrows.Count;
            countMediumArrows += matchesMediumArrows.Count;
            countLargeArrows += matchesLargeArrows.Count;
        }

        int sumConcatenated = int.Parse(countSmallArrows.ToString() +
             countMediumArrows.ToString() + countLargeArrows.ToString());

        string sumToBinary = Convert.ToString(sumConcatenated, 2);
        char[] reversedBinary = sumToBinary.ToCharArray();
        Array.Reverse(reversedBinary);
        string binaryConcatenated = sumToBinary + new string(reversedBinary);

        long resultDecimal = Convert.ToInt64(binaryConcatenated, 2);
        Console.WriteLine(resultDecimal);
    }
}

