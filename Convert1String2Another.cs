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
                if (i1 == s1.Length) return s2.Length - i2;
                if (i2 == s2.Length) return s1.Length - i1;


                // Divide
                if (s1[i1] == s2[i2]) return CalculateNoOfOperations(i1 + 1, i2 + 1);

                int noOfCreateOperations = 1 + CalculateNoOfOperations(i1 + 1, i2);
                int noOfUpdateOperations = 1 + CalculateNoOfOperations(i1 + 1, i2 + 1);
                int noOfDeleteOperations = 1 + CalculateNoOfOperations(i1, i2 + 1);


                // Combine
                return Math.Min(noOfCreateOperations, Math.Min(noOfUpdateOperations, noOfDeleteOperations));
            }
        }



        internal static void Work()
        {
            string s1 = "table",
                s2 = "tbres";

            int minOperations = new Convert1String2Another().CalculateNoOfOperations(s1, s2);
            WriteLine(minOperations);
        }
    }
}