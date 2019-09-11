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
                // When reached the 1st cell, destination reached.
                // So return its value.
                if (row == 0 && column == 0) return array[0, 0];


                // Divide
                // Consider current cell's value
                // 
                // Optimizations:
                // 1st row & 1st column
                // Case 3: 1st row
                // Only left move possible, so consider left cell
                if (row == 0)
                    return array[0, column] + FindMinCost(0, column - 1);
                // Case 4: 1st column
                // Only top move possible, so consider top cell
                if (column == 0)
                    return array[row, 0] + FindMinCost(row - 1, 0);


                // 2 possible ways to move:
                // Case 1: Consider left cell
                int costUsingLeftCell = array[row, column] + FindMinCost(row, column - 1);
                // Case 2: Consider top cell
                int costUsingTopCell = array[row, column] + FindMinCost(row - 1, column);


                // Combine
                // As min cost has to be found, take min of left & top move
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
            };   // Ans: 36
            //int[,] array =
            //{
            //    {4, 7, 8},
            //    {6, 7, 3}
            //};   // Ans: 20

            int minCost = new MinCostReachArrayEnd().FindMinCost(array);
            WriteLine(minCost);
        }
    }
}