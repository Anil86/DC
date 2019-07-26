using static System.Console;

namespace DC
{
    public class NumberFactor
    {
        private int NoOfTimes(int n, (int p1, int p2, int p3) parts)
        {
            _count++;
            // Solve small sub-problems
            switch (n)
            {
                case 0:   // {}
                case 1:   // {1}
                case 2:   // {1, 1}
                    return 1;
                case 3: return 2;   // {3}, {1, 1, 1}
                default: break;
            }


            // Divide
            int noOfTimesP1 = NoOfTimes(n - parts.p1, parts);
            int noOfTimesP2 = NoOfTimes(n - parts.p2, parts);
            int noOfTimesP3 = NoOfTimes(n - parts.p3, parts);


            // Combine
            return noOfTimesP1 + noOfTimesP2 + noOfTimesP3;
        }


        private static int _count;
        public static void Work()
        {
            int noOfTimes = new NumberFactor().NoOfTimes(6, (p1: 1, p2: 3, p3: 4));
            WriteLine(noOfTimes);WriteLine(_count);
        }
    }
}