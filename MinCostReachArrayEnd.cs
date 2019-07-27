using System;
using static System.Console;

namespace DC
{
    public class MinCostReachArrayEnd
    {
        private int FindMinCost(int[,] array)
        {
            return FindMinCost(array.GetLength(0) - 1, array.GetLength(1) - 1);



            int FindMinCost(int row, int column)
            {
                // Solve small sub-problems
                if (row == 0 && column == 0) return array[0, 0];


                // Divide
                if (row == 0)   // Case 3: 1st row
                    return array[0, column] + FindMinCost(0, column - 1);
                if (column == 0)   // Case 4: 1st column
                    return array[row, 0] + FindMinCost(row - 1, 0);

                // Cells other than 1st row & 1st column
                // Case 1: Cost considering left cell
                int costUsingLeftCell = array[row, column] + FindMinCost(row, column - 1);
                // Case 2: Cost considering top cell
                int costUsingTopCell = array[row, column] + FindMinCost(row - 1, column);


                // Combine
                return Math.Min(costUsingLeftCell, costUsingTopCell);
            }
        }



        internal static void Work()
        {
            int[,] array =
            {
                {4, 7, 8, 6, 4},
                {6, 7, 3, 9, 2},
                {3, 8, 1, 2, 4},
                {7, 1, 7, 3, 7},
                {2, 9, 8, 9, 3}
            };
            //int[,] array =
            //{
            //    {4, 7, 8},
            //    {6, 7, 3}
            //};

            int minCost = new MinCostReachArrayEnd().FindMinCost(array);
            WriteLine(minCost);
        }
    }
}