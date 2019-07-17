using static System.Console;
using System;

namespace DC
{
    public class LongestCommonSubsequence
    {
        private int FindLongestSubsequence(string s1, string s2)
        {
            return FindLongestSubsequence(s1, s2, 0, 0);



            int FindLongestSubsequence(string str1, string str2, int i1, int i2)
            {
                if (i1 == str1.Length || i2 == str2.Length) return 0;   // Solve small sub-problems


                // Divide
                int match = 0, noMatchSkipS2 = 0, noMatchSkipS1 = 0;

                if (str1[i1] == str2[i2])
                    match = 1 + FindLongestSubsequence(str1, str2, i1 + 1, i2 + 1);
                else
                {
                    noMatchSkipS2 = FindLongestSubsequence(str1, str2, i1, i2 + 1);
                    noMatchSkipS1 = FindLongestSubsequence(str1, str2, i1 + 1, i2);
                }


                // Combine
                return Math.Max(match, Math.Max(noMatchSkipS1, noMatchSkipS2));
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