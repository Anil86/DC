using static System.Console;

namespace DC
{
    public class NumberFactor
    {
        /// <summary>Calculates no.of ways number can be obtained from given 3 numbers.</summary>
        /// <param name="n">The number.</param>
        /// <param name="parts">The parts.</param>
        /// <returns>  No.of ways.</returns>
        private int NoOfTimes(int n, (int p1, int p2, int p3) parts)
        {
            // Solve small sub-problems
            switch (n)
            {
                case 0:   // {}
                case 1:   // {1}
                case 2:   // {1, 1}
                    return 1;
                case 3: return 2;   // {3}, {1, 1, 1}
            }


            // Divide
            int noOfTimesP1 = NoOfTimes(n - parts.p1, parts);
            int noOfTimesP2 = NoOfTimes(n - parts.p2, parts);
            int noOfTimesP3 = NoOfTimes(n - parts.p3, parts);


            // Combine
            return noOfTimesP1 + noOfTimesP2 + noOfTimesP3;
        }


        
        public static void Work()
        {
            int noOfTimes = new NumberFactor().NoOfTimes(6, (p1: 1, p2: 3, p3: 4));
            WriteLine(noOfTimes);
        }
    }
}