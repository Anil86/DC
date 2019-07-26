using static System.Console;
using System;

namespace DC
{
    public class HouseThief
    {
        private int StealMaxValue(int[] houses, int current)
        {
            // Solve small sub-problems
            if (current >= houses.Length) return 0;


            // Divide
            int valueConsiderCurrentHouse = houses[current] + StealMaxValue(houses, current + 2);
            int valueSkipCurrentHouse = StealMaxValue(houses, current + 1);


            // Combine
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