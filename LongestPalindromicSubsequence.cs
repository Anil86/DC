using static System.Console;
using System;

namespace DC
{
    public class LongestPalindromicSubsequence
    {
        private int FindLongestPalindromeLength(string str)
        {
            return FindLongestPalindromeLength(0, str.Length - 1);



            int FindLongestPalindromeLength(int start, int end)
            {
                // Solve small sub-problem
                if (start == end) return 1;

                // If we have traversed more than 1/2 of string then return 0 as we don't need to process it
                if (start > end) return 0;


                // Divide
                int match = 0, noMatchR = 0, noMatchL = 0;

                if (str[start] == str[end])
                    match = 2 + FindLongestPalindromeLength(start + 1, end - 1);
                else
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
            //string str = "elrmenmet";
            string str = "ameewmea";

            int longestPalindromeCount = new LongestPalindromicSubsequence().FindLongestPalindromeLength(str);
            WriteLine(longestPalindromeCount);
        }
    }
}