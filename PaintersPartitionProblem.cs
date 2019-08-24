using System;
using static System.Console;

namespace DC
{
    public class PaintersPartitionProblem
    {
        private int MinimizeMaxWork(int noOfPainters, int[] boards)
        {
            int[,] dp = new int[boards.Length, noOfPainters + 1];

            return MinimizeMaxWork(boards.Length - 1, noOfPainters);



            int MinimizeMaxWork(int noOfBoards, int painters)
            {
                // Solve small sub-problems
                if (painters == 1) return dp[noOfBoards, 1] = SumWork(0, noOfBoards); // No.of painters = 1

                if (noOfBoards == 0) return dp[0, painters] = boards[0]; // No.of boards = 1


                // Divide
                int minimizedMaxWork = int.MaxValue;
                for (int i = 0; i < noOfBoards; i++)
                {
                    int prevPaintersMax = dp[i, painters - 1] == 0
                        ? dp[i, painters - 1] = MinimizeMaxWork(i, painters - 1)
                        : dp[i, painters - 1];
                    int lastPainterSum = SumWork(i + 1, noOfBoards);


                    // Combine
                    int currentMaxWork = Math.Max(prevPaintersMax, lastPainterSum);
                    minimizedMaxWork = Math.Min(currentMaxWork, minimizedMaxWork);
                }

                return dp[noOfBoards, painters] = minimizedMaxWork;
            }


            int SumWork(int start, int end)
            {
                int totalTime = 0;

                for (int i = start; i <= end; i++) totalTime += boards[i];

                return totalTime;
            }
        }


        internal static void Work()
        {
            //int noOfPainters = 2;
            //int[] boards = { 10, 10, 10, 10 };   // Ans: 20
            //int[] boards = { 10, 20, 30, 40 };   // Ans: 60

            //int noOfPainters = 3;
            //int[] boards = { 2, 1, 3, 4, 9, 8 };   // Ans: 10

            //int noOfPainters = 14;
            //int[] boards =
            //{
            //    189, 107, 444, 400, 84, 270, 225, 334, 410, 433, 249, 193, 487, 312, 493, 430, 422, 208, 90, 245, 337,
            //    234, 168, 360
            //};
            // Ans: 740   // Calls: 6690448

            int noOfPainters = 26;
            int[] boards =
            {
                274, 465, 130, 135, 254, 45, 70, 122, 149, 95, 453, 65, 392, 331, 316, 484, 372, 339, 45, 46, 31, 167,
                351, 415, 387, 275, 355, 440, 290, 462, 436, 416, 279, 66, 403, 33, 464, 473, 8, 113, 420, 461, 30, 312
            };
            // Ans: 647

            int fairMaxWork = new PaintersPartitionProblem().MinimizeMaxWork(noOfPainters, boards);
            WriteLine(fairMaxWork);
        }
    }
}