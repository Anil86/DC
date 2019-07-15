using static System.Console;
using System;

namespace DC
{
    public class Convert1String2Another
    {
        private int CalculateNoOfOperations(string s1, string s2, int i1, int i2)
        {
            // Solve small sub-problems
            if (i1 == s1.Length) return s2.Length - i2;
            if (i2 == s2.Length) return s1.Length - i1;


            if (s1[i1] == s2[i2]) return CalculateNoOfOperations(s1, s2, i1 + 1, i2 + 1);

            // Divide
            int create = 1 + CalculateNoOfOperations(s1, s2, i1 + 1, i2);
            int update = 1 + CalculateNoOfOperations(s1, s2, i1 + 1, i2 + 1);
            int delete = 1 + CalculateNoOfOperations(s1, s2, i1, i2 + 1);


            // Conquer
            return Math.Min(create, Math.Min(update, delete));
        }



        internal static void Work()
        {
            string s1 = "table",
                s2 = "tbres";

            int minOperations = new Convert1String2Another().CalculateNoOfOperations(s1, s2, 0, 0);
            WriteLine(minOperations);
        }
    }
}