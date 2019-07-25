using static System.Console;

namespace DC
{
    public class NoOfWaysReachLastGivenCost
    {
        private int NoOfWays(int[,] array, int cost)
        {
            return NoOfWays(array.GetLength(0) - 1, array.GetLength(1) - 1, cost);



            int NoOfWays(int row, int column, int c)
            {
                // Solve small sub-problems
                if (c <= 0) return 0;   // Cost = 0

                // 1st cell
                if (row == 0 && column == 0) return c == array[0, 0] ? 1 : 0;


                // Divide
                int previousCellAllowedCost = c - array[row, column];

                // 1st row
                if (row == 0) return NoOfWays(0, column - 1, previousCellAllowedCost);
                // 1st column
                if (column == 0) return NoOfWays(row - 1, 0, previousCellAllowedCost);

                // Other than 1st row & 1st column
                int noOfWaysReachLeftCell = NoOfWays(row, column - 1, previousCellAllowedCost);
                int noOfWaysReachTopCell = NoOfWays(row - 1, column, previousCellAllowedCost);


                // Combine
                return noOfWaysReachLeftCell + noOfWaysReachTopCell;
            }
        }



        internal static void Work()
        {
            int[,] array =
            {
                {4, 7, 1, 6},
                {5, 7, 3, 9},
                {3, 2, 1, 2},
                {7, 1, 6, 3}
            };
            //int[,] array =
            //{
            //    {4, 7, 1},
            //    {7, 1, 3}
            //};
            int cost = 25;
            //int cost = 15;

            int noOfWays = new NoOfWaysReachLastGivenCost().NoOfWays(array, cost);
            WriteLine(noOfWays);
        }
    }
}