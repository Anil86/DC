using static System.Console;

namespace DC
{
    public class NumberFactor
    {
        private int NoOfTimes(int n, (int p1, int p2, int p3) parts)
        {
            switch (n)   // Solve small sub-problems
            {
                case 0:   // {}   
                case 1:   // {1}
                case 2:
                    return 1;   // {1, 1}
                case 3: return 2;   // {3}, {1, 1, 1}
                default: break;
            }


            // Divide
            int noOfP1 = NoOfTimes(n - parts.p1, parts);
            int noOfP2 = NoOfTimes(n - parts.p2, parts);
            int noOfP3 = NoOfTimes(n - parts.p3, parts);


            // Combine (Conquer)
            return noOfP1 + noOfP2 + noOfP3;
        }



        public static void Work()
        {
            int noOfTimes = new NumberFactor().NoOfTimes(6, (p1: 1, p2: 3, p3: 4));
            WriteLine(noOfTimes);
        }
    }
}