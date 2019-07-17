using static System.Console;
using System;

namespace DC
{
    public class LongestPalindromicSubstring
    {
        private int FindLongestPalindromeLength(string str)
        {
            return FindLongestPalindromeLength(0, str.Length - 1);



            int FindLongestPalindromeLength(int start, int end)
            {
                // Solve small sub-problems
                if (start == end) return 1;

                if (start > end) return 0;


                // Divide
                int match = 0, noMatchR = 0, noMatchL = 0;

                if (str[start] == str[end])
                {
                    int noOfInBetweenChars = end - 1 - start;
                    int noOfInBetweenPalindromicChars = FindLongestPalindromeLength(start + 1, end - 1);

                    // start → end will be palindromic substring only if in-between chars are palindromic substring
                    if (noOfInBetweenChars == noOfInBetweenPalindromicChars)
                        match = noOfInBetweenPalindromicChars + 2;
                }

                // When start → end is not palindromic, 
                // try finding palindromic substring using remaining 2 cases.
                if (match == 0)
                {
                    noMatchR = FindLongestPalindromeLength(start, end - 1);
                    noMatchL = FindLongestPalindromeLength(start + 1, end);
                }


                // Combine
                return Math.Max(match, Math.Max(noMatchR, noMatchL));
            }
        }



        internal static void Work()
        {
            string str = "amadamb";
            //string str = "abccbua";
            //string str = "mamdrdm";
            //string str = "mqadasm";

            int longestPalindromeCount = new LongestPalindromicSubstring().FindLongestPalindromeLength(str);
            WriteLine(longestPalindromeCount);
        }
    }
}