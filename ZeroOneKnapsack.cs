using static System.Console;
using System;

namespace DC
{
    public class ZeroOneKnapsack
    {
        private int FillKnapsack(Item[] items, int capacity)
        {
            return FillKnapsack(0, capacity);



            int FillKnapsack(int current, int cap)
            {
                // Solve small sub-problems
                // When considered all 
                if (current == items.Length ||   // When considered all items, return
                    cap == 0) return 0;   // When knapsack filled, return


                // Divide
                // Choice 1: Pick current item +
                // Profit from remaining items
                int valueConsiderCurrent = 0;
                if (items[current].Weight <= cap)   // Check current weight not > capacity
                    valueConsiderCurrent =
                        items[current].Value + FillKnapsack(current + 1, cap - items[current].Weight);

                // Choice 2: Skip current item + 
                // Profit from remaining items
                int valueSkipCurrent = FillKnapsack(current + 1, cap);


                // Combine
                // Return max of above 2 choices
                return Math.Max(valueConsiderCurrent, valueSkipCurrent);
            }
        }



        internal static void Work()
        {
            Item[] items =
            {
                new Item("Item 1", 3, 31),
                new Item("Item 2", 1, 26),
                new Item("Item 3", 5, 72),
                new Item("Item 4", 2, 17)
            };

            int profit = new ZeroOneKnapsack().FillKnapsack(items, 7);
            WriteLine(profit);
        }
    }



    internal struct Item   // Knapsack item struct
    {
        public Item(string name, int weight, int value)
        {
            Name = name;
            Weight = weight;
            Value = value;
        }

        public string Name { get; }
        public int Weight { get; }
        public int Value { get; }


        /// <inheritdoc />
        public override string ToString() => $"{Name}: {Weight} Kg, {Value:C0}";
    }
}