using static System.Console;

namespace DC
{
    public class ElementOnceInSortedArray
    {
        private int FindElement(int[] numbers)
        {
            return FindElement(0);



            int FindElement(int current)
            {
                // Solve small sub-problems
                if (current == numbers.Length - 1) return numbers[current];

                // Divide
                if (numbers[current] == numbers[current + 1])
                    return FindElement(current + 2);

                return numbers[current];   // if (numbers[current] != numbers[current + 1])
            }
        }



        internal static void Work()
        {
            //int[] numbers = { 1, 1, 2, 2, 3, 3, 4, 50, 50, 65, 65};
            //int[] numbers = { 1, 1, 2, 2, 3, 3, 4, 4, 50, 50, 65, 65, 66 };
            int[] numbers = { 0, 1, 1, 2, 2, 3, 3, 4, 4, 50, 50, 65, 65 };

            int uniqueNumber = new ElementOnceInSortedArray().FindElement(numbers);
            WriteLine(uniqueNumber);
        }
    }
}