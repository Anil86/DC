using static System.Console;
using System;

namespace DC
{
    public class ZeroOneKnapsack
    {
        private int FillKnapsack(Item[] items, int capacity)
        {
            return FillKnapsack(capacity, 0);



            int FillKnapsack(int cap, int current)
            {
                // Solve small sub-problems
                if (cap == 0 || current == items.Length) return 0;


                // Divide
                int considerCurrentValue = 0;
                if (items[current].Weight <= cap)
                    considerCurrentValue = items[current].Value +
                                            FillKnapsack(cap - items[current].Weight, current + 1);
                int skipCurrentValue = FillKnapsack(cap, current + 1);


                // Combine
                return Math.Max(considerCurrentValue, skipCurrentValue);
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



    internal struct Item
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