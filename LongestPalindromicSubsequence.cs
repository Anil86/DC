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
                // Solve small sub-problems
                if (start == end) return 1;

                // If more than 1/2 of string traversed, then return 0 as no processing required
                if (end < start) return 0;


                // Divide
                if (str[start] == str[end]) // Case 1
                    return 2 + FindLongestPalindromeLength(start + 1, end - 1);

                int noOfMatchSkipEnd = FindLongestPalindromeLength(start, end - 1);   // Case 2
                int noOfMatchSkipStart = FindLongestPalindromeLength(start + 1, end);   // Case 3


                // Combine
                return Math.Max(noOfMatchSkipEnd, noOfMatchSkipStart);
            }
        }



        internal static void Work()
        {
            string str = "elrmenmet";
            //string str = "ameewmea";
            //string str = "abccbua";
            //string str = "mamdrdm";
            //string str = "mqadasm";

            int longestPalindromeCount = new LongestPalindromicSubsequence().FindLongestPalindromeLength(str);
            WriteLine(longestPalindromeCount);
        }
    }
}