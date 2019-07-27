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
                if (i1 == str1.Length || i2 == str2.Length) return 0;


                // Divide
                if (str1[i1] == str2[i2])
                    return 1 + FindLongestSubsequence(i1 + 1, i2 + 1);

                int noOfMatchesSkipStr2 = FindLongestSubsequence(i1, i2 + 1);
                int noOfMatchesSkipStr1 = FindLongestSubsequence(i1 + 1, i2);


                // Combine
                return Math.Max(noOfMatchesSkipStr2, noOfMatchesSkipStr1);
            }
        }



        internal static void Work()
        {
            string s1 = "elephant",
                s2 = "eretpat";
            //string s1 = "houdini",
            //    s2 = "hdupti";
            //string s1 = "text",
            //    s2 = "set";

            int longestSubsequence = new LongestCommonSubsequence().FindLongestSubsequence(s1, s2);
            WriteLine(longestSubsequence);
        }
    }
}