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
                // If start & end coincide, it's a palindrome of length 1.
                // Also no more processing needed.
                // So return 0.
                if (start == end) return 1;

                // If start crosses end, then no more processing required. So return 0.
                if (end < start) return 0;


                // Divide
                // Match start & end char
                // Case 1: Chars match
                // Take count 2 & 
                // find remaining matches
                if (str[start] == str[end])
                    return 2 + FindLongestPalindromeLength(start + 1, end - 1);


                // Case: 2 Chars don't match
                // Take count 0 & 
                // match unmatched chars in remaining chars
                // Case 2.1: Match start char w/ end's previous char
                int noOfMatchSkipEnd = FindLongestPalindromeLength(start, end - 1);

                // Case 2.2: Match end char w/ start's next char
                int noOfMatchSkipStart = FindLongestPalindromeLength(start + 1, end);


                // Combine
                // When chars don't match, we consider cases 2.1 & 2.2.
                // Because longest palindromic subsequence has to be found, return max of 2 cases.
                return Math.Max(noOfMatchSkipEnd, noOfMatchSkipStart);
            }
        }



        internal static void Work()
        {
            string str = "elrmenmet";   // Ans: 5
            //string str = "ameewmea";   // Ans: 6
            //string str = "abccbua";   // Ans: 6
            //string str = "mamdrdm";   // Ans: 5
            //string str = "mqadasm";   // Ans: 5

            int longestPalindromeCount = new LongestPalindromicSubsequence().FindLongestPalindromeLength(str);
            WriteLine(longestPalindromeCount);
        }
    }
}