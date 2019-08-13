using System;
using static System.Console;

namespace DC
{
    public class PaintersPartitionProblem
    {
        private int MinimizeMaxWork(int noOfPainters, int[] boards)
        {
            int fairMaxWork = int.MaxValue;
            for (int e1 = 0; e1 < boards.Length - 1; e1++)
            {
                int painter1Work = PainterWork(0, e1);
                int painter2Work = PainterWork(e1 + 1, boards.Length - 1);
                int maxPainterWork = Math.Max(painter1Work, painter2Work);
                
                fairMaxWork = Math.Min(fairMaxWork, maxPainterWork);
            }

            return fairMaxWork;



            int PainterWork(int start, int end)
            {
                int totalTime = 0;

                for (int i = start; i <= end; i++) totalTime += boards[i];

                return totalTime;
            }
        }



        internal static void Work()
        {
            int noOfPainters = 2;
            //int[] boards = { 10, 10, 10, 10 };
            int[] boards = { 10, 20, 30, 40 };

            int fairMaxWork = new PaintersPartitionProblem().MinimizeMaxWork(noOfPainters, boards);
            WriteLine(fairMaxWork);
        }
    }
}