using static System.Console;
using System;

namespace DC
{
    public class HouseThief
    {
        private int StealMaxValue(int[] houses, int current)
        {
            // Solve small sub-problems
            if (current >= houses.Length) return 0;   // When crossed last house, return


            // Divide
            // Choice 1: Take current house
            // Skip next house & find remaining values from current + 2
            // choice1Value = currentHouse + Steal(currentHouse + 2)
            int valueConsiderCurrentHouse = houses[current] + StealMaxValue(houses, current + 2);

            // Choice 2: Skip current house
            // Don't consider current house & find remaining values from current + 1
            // choice2Value = 0 + Steal(currentHouse + 1)
            int valueSkipCurrentHouse = StealMaxValue(houses, current + 1);


            // Combine
            // Because max value has to be found, take max of choice 1 & 2.
            return Math.Max(valueConsiderCurrentHouse, valueSkipCurrentHouse);
        }



        public static void Work()
        {
            int[] houses = { 6, 7, 1, 30, 8, 2, 4 };
            //int[] houses = { 20, 5, 1, 13, 6, 11, 40 };

            int value = new HouseThief().StealMaxValue(houses, 0);
            WriteLine(value);
        }
    }
}