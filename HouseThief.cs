using static System.Console;
using System;

namespace DC
{
    public class HouseThief
    {
        private int StealMaxValue(int[] houses, int current)
        {
            if (current >= houses.Length) return 0;


            int considerCurrentHouseValue = houses[current] + StealMaxValue(houses, current + 2);
            int skipCurrentHouseValue = StealMaxValue(houses, current + 1);


            return Math.Max(considerCurrentHouseValue, skipCurrentHouseValue);
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