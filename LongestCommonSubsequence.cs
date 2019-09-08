using static System.Console;
using System;

namespace DC
{
    public class LongestCommonSubsequence
    {
        private int FindLongestSubsequence(string str1, string str2)
        {
            return FindLongestSubsequence(0, 0);



            int FindLongestSubsequence(int i1, int i2)
            {
                // Solve small sub-problems
                // When 1 of the strings finish, no further match possible
                if (i1 == str1.Length || i2 == str2.Length) return 0;


                // Divide
                // Case 1: Current chars match
                // Increase count + 
                // Find matches in remaining chars
                if (str1[i1] == str2[i2])
                    return 1 + FindLongestSubsequence(i1 + 1, i2 + 1);


                // Case 2: Current chars don't match
                // Case 2.1: Keep count 0 + 
                // Find i1's match in string 2. So increase i2's index
                int noOfMatchesSkipStr2 = FindLongestSubsequence(i1, i2 + 1);

                // Case 2.2: Keep count 0 + 
                // Find i2 char's match in string 1. So increase i1's index
                int noOfMatchesSkipStr1 = FindLongestSubsequence(i1 + 1, i2);


                // Combine
                // Take max of Case 2.1 & Case 2.2
                return Math.Max(noOfMatchesSkipStr2, noOfMatchesSkipStr1);
            }
        }



        internal static void Work()
        {
            //string s1 = "elephant",
            //    s2 = "eretpat";   // Ans: 5
            //string s1 = "houdini",
            //    s2 = "hdupti";   // Ans: 3
            string s1 = "text",
                s2 = "set";   // Ans: 2

            int longestSubsequence = new LongestCommonSubsequence().FindLongestSubsequence(s1, s2);
            WriteLine(longestSubsequence);
        }
    }
}