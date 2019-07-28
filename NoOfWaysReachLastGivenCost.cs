using static System.Console;

namespace DC
{
    public class NoOfWaysReachLastGivenCost
    {
        private int NoOfWays(int[,] array, int capacity)
        {
            return NoOfWays(array.GetLength(0) - 1, array.GetLength(1) - 1, capacity);



            int NoOfWays(int row, int column, int cap)
            {
                // Solve small sub-problems
                if (cap <= 0) return 0;   // Cost = 0

                // 1st cell
                if (row == 0 && column == 0) return cap == array[row, column] ? 1 : 0;


                // Divide
                int previousCellAllowedCost = cap - array[row, column];

                if (row == 0)   // Case 3: 1st row
                    return NoOfWays(0, column - 1, previousCellAllowedCost);
                if (column == 0)   // Case 4: 1st column
                    return NoOfWays(row - 1, 0, previousCellAllowedCost);

                // Case 1: No.of ways considering left cell
                int noOfWaysReachLeftCell = NoOfWays(row, column - 1, previousCellAllowedCost);
                // Case 2: No.of ways considering top cell
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