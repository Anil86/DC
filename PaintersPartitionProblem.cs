using System;
using static System.Console;

namespace DC
{
    public class PaintersPartitionProblem
    {
        private static int _count;
        private int MinimizeMaxWork(int noOfPainters, int[] boards)
        {
            return MinimizeMaxWork(boards.Length - 1, noOfPainters);



            int MinimizeMaxWork(int noOfBoards, int painters)
            {
                _count++;
                // Solve small sub-problems
                if (painters == 1) return SumWork(0, noOfBoards);   // No.of painters = 1

                if (noOfBoards == 0) return boards[0];   // No.of boards = 1


                // Divide
                int minimizedMaxWork = int.MaxValue;
                for (int i = 0; i < noOfBoards; i++)
                {
                    int prevPaintersMax = MinimizeMaxWork(i, painters - 1);
                    int lastPainterSum = SumWork(i + 1, noOfBoards);


                    // Combine
                    int currentMaxWork = Math.Max(prevPaintersMax, lastPainterSum);
                    minimizedMaxWork = Math.Min(currentMaxWork, minimizedMaxWork);
                }

                return minimizedMaxWork;
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

            int noOfPainters = 14;
            int[] boards =
            {
                189, 107, 444, 400, 84, 270, 225, 334, 410, 433, 249, 193, 487, 312, 493, 430, 422, 208, 90, 245, 337,
                234, 168, 360
            };
            // Ans: 740   // Calls: 6690448

            int fairMaxWork = new PaintersPartitionProblem().MinimizeMaxWork(noOfPainters, boards);
            WriteLine(fairMaxWork); WriteLine($"Count: {_count}");
        }
    }
}