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
                // If start & end coincide, it's a palindrome of length 1.
                // Also no more processing needed.
                // So return 0.
                if (start == end) return 1;

                // If start crosses end, then no more processing required. So return 0.
                if (end < start) return 0;


                // Divide
                // Base on matching start & end chars, there are 2 possibilities:
                // Case 1: Both chars match
                // To be a palindrome, start & end chars must match
                if (str[start] == str[end])
                {
                    int noOfPalindromicChars = FindLongestPalindromeLength(start + 1, end - 1);

                    int noOfInBetwnChars = end - start - 1;   // Find no.of in-between chars
                    // To be a palindrome, in-between chars must be palindromic
                    // If in-between chars are palindromic, add current 2 chars count to
                    // no.of in-between palindromic chars
                    if (noOfInBetwnChars == noOfPalindromicChars) return 2 + noOfPalindromicChars;
                }


                // Case 2: Chars don't match
                // Match unmatched chars
                // Case 2.1: Match start w/ end's previous char
                int noOfMatchSkipEnd = FindLongestPalindromeLength(start, end - 1);

                // Case 2.2: Match end w/ start's next char
                int noOfMatchSkipStart = FindLongestPalindromeLength(start + 1, end);


                // Combine
                // When chars don't match, we consider cases 2.1 & 2.2.
                // Because longest palindromic substring has to be found, return max of 2 cases.
                return Math.Max(noOfMatchSkipEnd, noOfMatchSkipStart);
            }
        }



        internal static void Work()
        {
            //string str = "amadamb";   // Ans: 5
            //string str = "abccbua";   // Ans: 4
            //string str = "mamdrdm";   // Ans: 5
            string str = "mqadasm";   // Ans: 3

            int longestPalindromeCount = new LongestPalindromicSubstring().FindLongestPalindromeLength(str);
            WriteLine(longestPalindromeCount);
        }
    }
}