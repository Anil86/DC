using static System.Console;
using System;

namespace DC
{
    public class Convert1String2Another
    {
        private int CalculateNoOfOperations(string s1, string s2)
        {
            return CalculateNoOfOperations(0, 0);



            int CalculateNoOfOperations(int i1, int i2)
            {
                // Solve small sub-problems
                if (i1 == s1.Length) return s2.Length - i2;   // If good string finishes, delete remaining bad chars
                if (i2 == s2.Length) return s1.Length - i1;   // If bad string finishes, copy remaining good chars


                // Divide
                // If chars match, no need of any operation
                if (s1[i1] == s2[i2]) return CalculateNoOfOperations(i1 + 1, i2 + 1);

                // Add current good char + Convert remaining chars
                int ifCurrentCreateNoOfOperations = 1 + CalculateNoOfOperations(i1 + 1, i2);
                // Update current bad char + Convert remaining chars
                int ifCurrentUpdateNoOfOperations = 1 + CalculateNoOfOperations(i1 + 1, i2 + 1);
                // Delete current bad char + Convert remaining chars
                int ifCurrentDeleteNoOfOperations = 1 + CalculateNoOfOperations(i1, i2 + 1);


                // Combine
                // Find min no.of operations
                return Math.Min(ifCurrentCreateNoOfOperations,
                    Math.Min(ifCurrentUpdateNoOfOperations, ifCurrentDeleteNoOfOperations));
            }
        }



        internal static void Work()
        {
            string s1 = "table",
                s2 = "tbres";   // Ans: 3

            int minOperations = new Convert1String2Another().CalculateNoOfOperations(s1, s2);
            WriteLine(minOperations);
        }
    }
}